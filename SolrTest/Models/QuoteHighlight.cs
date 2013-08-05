using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SolrTest.Models
{
    public class QuoteHighlight
    {
        public String Id { get; set; }
        public String Title { get; set; }
        public String ArticleBodySnippet { get; set; }
        public String Source { get; set; }
    }
}