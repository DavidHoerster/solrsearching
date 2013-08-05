using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SolrTest.Models
{
    public class CategoryItem
    {
        public String Item { get; set; }
        public String ItemCriteria { get; set; }
        public Int32 Count { get; set; }
    }

    public class HitterCategory
    {
        public String CategoryField { get; set; }
        public IList<CategoryItem> Items { get; set; }
    }

    public class HitterSearchResult
    {
        public String Id { get; set; }
        public Int32 LahmanId { get; set; }
        public String PlayerId { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public Int32 Hits { get; set; }
        public Int32 HomeRuns { get; set; }
        public Double Average { get; set; }
        public Int32 Year { get; set; }
        public Int32 RunsBattedIn { get; set; }
        public Int32 StrikeOuts { get; set; }
        public Int32 Doubles { get; set; }
        public Int32 Triples { get; set; }
        public Int32 Salary { get; set; }
        public String TeamName { get; set; }
    }

    public class HitterSearchViewModel
    {
        public IList<HitterSearchResult> SearchResults { get; set; }

        public HitterSearch OriginalCriteria { get; set; }

        public IDictionary<String, HitterCategory> Categories { get; set; }

        public Int32 NumberFound { get; set; }
        public Int32 RecordsShown { get; set; }
    }
}