using System;
using System.Collections.Generic;
using System.Text;

namespace Revelbase.JsonParser.Core
{
    public class Choice
    {
        public string ID { get; set; }
        public string Weighting { get; set; }
        public string Groups { get; set; }
        public string EventName { get; set; }
        public string ChoiceName { get; set; }
        public string OutcomeName { get; set; }
        public string OutcomeNextGroup { get; set; }
        public string OutcomeAddCards { get; set; }
        public string ChoiceName1 { get; set; }
        public string OutcomeName1 { get; set; }
        public string OutcomeNextGroup1 { get; set; }
        public string OutcomeAddCards1 { get; set; }
    }
}