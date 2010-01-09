using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqToWikipedia
{
    public class WikipediaOpenSearchResult
    {
        public string Text { get; set; }

        public string Description { get; set; }

        public Uri Url { get; set; }

        public Uri ImageUrl { get; set; }

        public string Keyword { get; set; }
    }
}
