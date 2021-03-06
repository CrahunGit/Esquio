﻿using Esquio.Abstractions.Providers;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace UnitTests.Esquio.AspNetCore.Extensions
{
    public class addsquio_should
    {
        [Fact]
        public void include_mandatory_services_in_container()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddEsquio()
                .AddAspNetCoreDefaultServices();

            var serviceProvider = serviceCollection.BuildServiceProvider();

            serviceProvider.GetService<IRoleNameProviderService>()
                .Should().NotBeNull();

            serviceProvider.GetService<IRoleNameProviderService>()
                .Should().NotBeNull();
        }
    }
}
