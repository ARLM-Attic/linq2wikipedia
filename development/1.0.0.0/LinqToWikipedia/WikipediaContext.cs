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

        public IWikipediaQueryable<WikipediaQueryResult> Query
        {
            get
            {
                return new WikipediaQuery<WikipediaQueryResult>(_queryprovider);
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
