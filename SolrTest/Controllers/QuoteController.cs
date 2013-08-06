using Microsoft.Practices.ServiceLocation;
using SolrNet;
using SolrNet.Commands.Parameters;
using SolrTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SolrTest.Controllers
{
    public class QuoteController : Controller
    {
        private readonly ISolrOperations<Quote> _solr;

        public QuoteController()
        {
            _solr = ServiceLocator.Current.GetInstance<ISolrOperations<Quote>>();
        }

        public ActionResult Index()
        {
            var quotes = _solr.Query(new SolrQuery("*:*"));
            var trimmedQuotes = quotes.Select(q => new Quote
            {
                Abstract = q.Abstract,
                ArticleBody = q.ArticleBody.Substring(0,200),
                Id = q.Id,
                Source = q.Source,
                Title = q.Title,
                Year = q.Year
            });
            return View(trimmedQuotes);
        }

        public ActionResult Details(String id)
        {

            var options = new QueryOptions()
            {
                MoreLikeThis = new MoreLikeThisParameters(new[] { "articlebody", "source" })
                {
                    MinDocFreq = 1,
                    MinTermFreq = 1
                }
            };
            var quotes = _solr.Query(new SolrQuery("id:" + id), options);

            if (quotes.Count>0)
            {
                var similarQuotes = new List<QuoteDetail>();
                var quote = quotes[0];
                var similar = quotes.SimilarResults;
                foreach (var item in quotes.SimilarResults)
                {
                    foreach (var itemValue in item.Value)
                    {
                        var similarQuote = new QuoteDetail()
                        {
                            Id = itemValue.Id,
                            Title = itemValue.Title
                        };
                        similarQuotes.Add(similarQuote);
                    }
                }
                var theQuote = new QuoteDetail()
                {
                    SimilarItems = similarQuotes,
                    Abstract = quote.Abstract,
                    ArticleBody = quote.ArticleBody,
                    Id = quote.Id,
                    Source = quote.Source,
                    Title = quote.Title,
                    Year = quote.Year
                };

                return View(theQuote);
            }
            return View(new QuoteDetail());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Quote theQuote)
        {
            try
            {
                _solr.Add(theQuote);
                _solr.Commit();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(String id)
        {
            var quotes = _solr.Query(new SolrQuery("id:" + id));
            return View(quotes.FirstOrDefault());
        }

        [HttpPost]
        public ActionResult Edit(String id, Quote theQuote)
        {
            try
            {
                // TODO: Add update logic here
                _solr.Add(theQuote);
                _solr.Commit();
                _solr.Optimize();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Delete(String id)
        {
            try
            {
                _solr.Delete(new SolrQuery("id:" + id));
                _solr.Commit();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Search(String id)
        {
            //var query = new SolrQueryByField("text", id);
            var query = new SolrQuery("text:" + id);

            var options = new QueryOptions()
            {
                //I don't need all the fields returned
                Fields = new[] { "id", "title", "source" },
                //enable hit highlighting
                Highlight = new HighlightingParameters()
                {
                    Fields = new[] { "articleBody", "abstract" }
                    ,
                    Fragsize = 200
                    ,
                    AfterTerm = "</em></strong>"
                    ,
                    BeforeTerm = "<em><strong>"
                    ,
                    UsePhraseHighlighter = true
                    //, AlternateField = "source"
                }
            };

            //issue the query
            var results = _solr.Query(query, options);
            var highlights = results.Highlights;

            var resultCount = results.Highlights.Count;
            var searchResults = new List<QuoteHighlight>();
            for (int i = 0; i < resultCount; i++)
            {
                //get the basic document information before dealing with highlights
                var highlight = new QuoteHighlight()
                {
                    Id = results[i].Id,
                    Title = results[i].Title,
                    Source = results[i].Source
                };

                //highlights are a separate array, and can be an array of hits...
                foreach (var h in highlights[results[i].Id])
                {
                    highlight.ArticleBodySnippet += String.Join(",", h.Value.ToArray());
                }
                searchResults.Add(highlight);
            }
            ViewBag.Term = id;
            return View(searchResults);
        }
    }
}
