using SolrNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SolrTest.Models
{
    /*
   <field name="id" type="string" indexed="true" stored="true" required="true" multiValued="false" /> 

   <field name="lahmanId" type="int" indexed="true" stored="true" required="true" multiValued="false" />
   <field name="playerId" type="string" indexed="true" stored="true" required="true" multiValued="false" />
   <field name="firstName" type="string" indexed="true" stored="true" required="false" multiValued="false" />
   <field name="lastName" type="string" indexed="true" stored="true" required="true" multiValued="false" />
   <field name="hits" type="int" indexed="true" stored="true" required="false" multiValued="false" />
   <field name="homeruns" type="int" indexed="true" stored="true" required="false" multiValued="false" />
   <field name="average" type="float" indexed="true" stored="true" required="false" multiValued="false" />
   <field name="year" type="int" indexed="true" stored="true" required="true" multiValued="false" />
   <field name="runsBattedIn" type="int" indexed="true" stored="true" required="false" />
   <field name="strikeOuts" type="int" indexed="true" stored="true" required="false" />
   <field name="doubles" type="int" indexed="true" stored="true" required="false" />
   <field name="triples" type="int" indexed="true" stored="true" required="false" />
   <field name="salary" type="int" indexed="true" stored="true" required="false" />
   <field name="team" type="string" indexed="true" stored="true" required="false" />
     */
    public class Hitter
    {
        [SolrField("id")]
        [SolrUniqueKey("id")]
        public String Id { get; set; }
        [SolrField("lahmanId")]
        public Int32 LahmanId { get; set; }
        [SolrField("playerId")]
        public String PlayerId { get; set; }
        [SolrField("firstName")]
        public String FirstName { get; set; }
        [SolrField("lastName")]
        public String LastName { get; set; }
        [SolrField("hits")]
        public Int32 Hits { get; set; }
        [SolrField("homeruns")]
        public Int32 HomeRuns { get; set; }
        [SolrField("average")]
        public Double Average { get; set; }
        [SolrField("year")]
        public Int32 Year { get; set; }
        [SolrField("runsBattedIn")]
        public Int32 RunsBattedIn { get; set; }
        [SolrField("strikeOuts")]
        public Int32 StrikeOuts { get; set; }
        [SolrField("doubles")]
        public Int32 Doubles { get; set; }
        [SolrField("triples")]
        public Int32 Triples { get; set; }
        [SolrField("salary")]
        public Int32 Salary { get; set; }
        [SolrField("team")]
        public String TeamName { get; set; }
    }
}