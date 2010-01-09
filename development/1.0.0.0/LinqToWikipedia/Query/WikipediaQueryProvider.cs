using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace LinqToWikipedia
{
    internal sealed class WikipediaQueryProvider : IQueryProvider
    {
        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            return new WikipediaQuery<TElement>(this, expression);
        }

        public IQueryable CreateQuery(Expression expression)
        {
            try
            {
                SystemType linqtype = new SystemType();

                return (IQueryable)Activator.CreateInstance(typeof(WikipediaQuery<>).MakeGenericType(linqtype.GetLinqElementType(expression.Type)), new object[] { this, expression });
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

            if (linqtype.GetLinqElementType(expression.Type) == typeof(WikipediaSiteSearchResult))
                return WikipediaQueryResponse.Get(WikipediaQueryRequest.Send(linqtype.GetLinqElementType(expression.Type), expression));

            return null;
        }
    }
}
