using AutoMapper.QueryableExtensions;
using Schmidt.Abstractions.Mapper.Interfaces;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Schmidt.Abstractions.Mapper.Extentions
{
    public static class QueryableExtensions
    {
        public static IQueryable<TTo> MapTo<TTo>(this IQueryable @query, IDataMapper mapper, object parameters, params Expression<Func<TTo, object>>[] membersToExpand)
        {
            return @query.ProjectTo<TTo>(mapper.ConfigurationProvider, parameters, membersToExpand);
        }
        public static IQueryable<TTo> MapTo<TTo>(this IQueryable @query, IDataMapper mapper, params Expression<Func<TTo, object>>[] membersToExpand)
        {
            return @query.ProjectTo<TTo>(mapper.ConfigurationProvider, membersToExpand);
        }
    }
}
