using System.Collections.Generic;
using AdvancedMVC2.Infrastructure.Extensions;
using AutoMapper;

namespace AdvancedMVC2.Infrastructure.Bootstrap
{
    public class BootstrapMapper : IBootstrapItem
    {
        private readonly IEnumerable<IMappingBootstrapItem> mapper;

        public BootstrapMapper(IEnumerable<IMappingBootstrapItem> mapper)
        {
            this.mapper = mapper;
        }

        public void Execute()
        {
            Mapper.Reset();
            mapper.ForEach(item => item.CreateMaps());
            Mapper.AssertConfigurationIsValid();
        }
    }
}