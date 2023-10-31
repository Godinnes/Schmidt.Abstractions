using AutoMapper;
using AutoMapper.EquivalencyExpression;
using Schmidt.Abstractions.Mapper.Abstractions;
using Schmidt.Abstractions.Mapper.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Schmidt.Abstractions.Mapper.Models
{
    public class DataMapper : IDataMapper
    {
        private readonly IMapper _mapper;
        public DataMapper(IMapper mapper)
        {
            _mapper = mapper;
        }
        public IConfigurationProvider ConfigurationProvider => _mapper.ConfigurationProvider;

        public TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
            => _mapper.Map(source, destination);

        public TDestination Map<TDestination>(object source)
            => _mapper.Map<TDestination>(source);

        public IQueryable ProjectTo(IQueryable source, Type destinationType)
            => _mapper.ProjectTo(source, destinationType);

        public IQueryable<TDestination> ProjectTo<TDestination>(IQueryable source)
            => _mapper.ProjectTo<TDestination>(source);

        public static DataMapper CreateForTesting<T>()
            where T : ProfileMapper, new()
        {
            var mapperConfigurationExpression = new MapperConfigurationExpression();
            mapperConfigurationExpression.AddProfile<T>();

            var mapperConfiguration = CreateMapperConfiguration(mapperConfigurationExpression);

            return new DataMapper(mapperConfiguration.CreateMapper());
        }
        public static DataMapper CreateForTesting(IEnumerable<ProfileMapper> profileMappers)
        {
            var mapperConfigurationExpression = new MapperConfigurationExpression();
            mapperConfigurationExpression.AddProfiles(profileMappers);

            var mapperConfiguration = CreateMapperConfiguration(mapperConfigurationExpression);

            return new DataMapper(mapperConfiguration.CreateMapper());
        }
        internal static MapperConfiguration CreateMapperConfiguration(MapperConfigurationExpression autoMapperConfiguration)
        {
            autoMapperConfiguration.AddCollectionMappers();
            autoMapperConfiguration.ShouldMapProperty = property => property.CanWrite;
            return new MapperConfiguration(autoMapperConfiguration);
        }
    }
}
