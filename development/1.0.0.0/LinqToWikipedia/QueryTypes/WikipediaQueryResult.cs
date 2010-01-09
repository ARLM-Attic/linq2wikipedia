using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqToWikipedia
{
    public class WikipediaQueryResult : IWikipediaQueryResult
    {
        public string Title { get; set; }

        public Uri Url { get; set; }

        public string Description { get; set; }

        public int WordCount { get; set; }

        public DateTime TimeStamp { get; set; }

        public int RecordCount { get; set; }

        public string Keyword { get; set; }
    }
}
