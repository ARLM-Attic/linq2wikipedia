using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Linq.Expressions;

namespace LinqToWikipedia
{
    internal sealed class WikipediaOpenSearchProvider : IQueryProvider
    {
        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            return new WikipediaOpenSearch<TElement>(this, expression);
        }

        public IQueryable CreateQuery(Expression expression)
        {
            try
            {
                SystemType linqtype = new SystemType();

                return (IQueryable)Activator.CreateInstance(typeof(WikipediaOpenSearch<>).MakeGenericType(linqtype.GetLinqElementType(expression.Type)), new object[] { this, expression });
            }
            catch (TargetInvocationException tie)
            {
                throw tie.InnerException;
            }
        }

        public TResult Execute<TResult>(Expression expression)
        {
            return (TResult)Execute(expression);
        }

        public object Execute(Expression expression)
        {
            SystemType linqtype = new SystemType();

            if (linqtype.GetLinqElementType(expression.Type) == typeof(WikipediaOpenSearchResult))
                return WikipediaOpenSearchResponse.Get(WikipediaOpenSearchRequest.Send(linqtype.GetLinqElementType(expression.Type), expression));

            return null;
        }
    }
}
