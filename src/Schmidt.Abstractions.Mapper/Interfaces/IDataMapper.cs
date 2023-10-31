using AutoMapper;
using System;
using System.Linq;

namespace Schmidt.Abstractions.Mapper.Interfaces
{
    public interface IDataMapper
    {
        IConfigurationProvider ConfigurationProvider { get; }
        TDestination Map<TSource, TDestination>(TSource source, TDestination destination);
        TDestination Map<TDestination>(object source);
        IQueryable ProjectTo(IQueryable source, Type destinationType);
        IQueryable<TDestination> ProjectTo<TDestination>(IQueryable source);
    }
}
