using SolrNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SolrTest.Models
{
    public class Quote
    {
        [SolrField("id")]
        [SolrUniqueKey("id")]
        public String Id { get; set; }
        [SolrField("title")]
        public String Title { get; set; }
        [SolrField("articleBody")]
        public String ArticleBody { get; set; }
        [SolrField("year")]
        public Int32 Year { get; set; }
        [SolrField("abstract")]
        public String Abstract { get; set; }
        [SolrField("source")]
        public String Source { get; set; }
    }
}