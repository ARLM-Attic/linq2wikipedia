using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqToWikipedia
{
    public class WikipediaContext
    {
        private WikipediaQueryProvider _queryprovider;
        private WikipediaOpenSearchProvider _opensearchprovider;

        public WikipediaContext()
        {
            _queryprovider = new WikipediaQueryProvider();
            _opensearchprovider = new WikipediaOpenSearchProvider();
        }

        public IWikipediaQueryable<WikipediaSiteSearchResult> Query
        {
            get
            {
                return new WikipediaQuery<WikipediaSiteSearchResult>(_queryprovider);
            }
        }

        public IWikipediaQueryable<WikipediaOpenSearchResult> OpenSearch
        {
            get
            {
                return new WikipediaOpenSearch<WikipediaOpenSearchResult>(_opensearchprovider);
            }
        }
    }
}
