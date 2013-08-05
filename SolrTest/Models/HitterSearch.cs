using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SolrTest.Models
{
    public class HitterSearch
    {
        public Int32 YearStart { get; set; }
        public Int32 YearEnd { get; set; }
        public Int32 MinHomeRuns { get; set; }
        public Int32 MaxSalary { get; set; }
    }
}