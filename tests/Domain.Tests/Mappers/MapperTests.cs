using System.Reflection;
using AutoMapper;
using Xunit;

namespace Domain.Tests.Mappers
{
    public class MapperTests
    {
        [Fact]
        public void AutoMapper_Configuration_IsValid()
        {
            var config = new MapperConfiguration(config => config.AddMaps(Assembly.GetExecutingAssembly().GetReferencedAssemblies().Select(x => Assembly.Load(x))));

            config?.AssertConfigurationIsValid();
        }
    }
}