using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Collections;

namespace LinqToWikipedia
{
    internal sealed class WikipediaOpenSearch<T> : IWikipediaQueryable<T>
    {
        private WikipediaOpenSearchProvider _queryProvider;
        private Expression _expression;

        public WikipediaOpenSearch(WikipediaOpenSearchProvider queryProvider)
        {
            _queryProvider = queryProvider;
            _expression = Expression.Constant(this);
        }

        public WikipediaOpenSearch(WikipediaOpenSearchProvider queryProvider, Expression expression)
        {
            _queryProvider = queryProvider;
            _expression = expression;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            IEnumerable<T> sequence = _queryProvider.Execute<IEnumerable<T>>(_expression);

            return sequence.GetEnumerator();
        }

        Type IQueryable.ElementType { get { return typeof(T); } }

        Expression IQueryable.Expression { get { return _expression; } }

        IQueryProvider IQueryable.Provider { get { return _queryProvider; } }
    }
}
