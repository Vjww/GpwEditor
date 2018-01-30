using System;
using App.ObjectMapping.AutoMapper.Configurations;
using FluentAssertions;
using Xunit;

namespace App.Tests.Services
{
    public class AutoMapperObjectMapperService
    {
        // TODO: Constructor tests may become redundant if we can scan for configurations instead
        [Fact]
        public void AutoMapperObjectMapperService_WhenInvokingConstructorWithNullFirstParameter_ExpectException()
        {
            var action = new Action(() =>
            {
                var _ = new App.Services.AutoMapperObjectMapperService(
                    null, new InfrastructureConfiguration()); // TODO: Mock it
            });

            action.ShouldThrow<ArgumentNullException>();
        }

        // TODO: Constructor tests may become redundant if we can scan for configurations instead
        [Fact]
        public void AutoMapperObjectMapperService_WhenInvokingConstructorWithNullSecondParameter_ExpectException()
        {
            var action = new Action(() =>
            {
                var _ = new App.Services.AutoMapperObjectMapperService(
                    new PresentationConfiguration(), null); // TODO: Mock it
            });

            action.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void AutoMapperObjectMapperService_WhenInvokingMapMethodWithNullParameter_ExpectException()
        {
            var mapperService = new App.Services.AutoMapperObjectMapperService(
                new PresentationConfiguration(), new InfrastructureConfiguration()); // TODO: Mock it

            var action = new Action(() =>
            {
                var _ = mapperService.Map<object, object>(null);
            });

            action.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void AutoMapperObjectMapperService_WhenInvokingMapMethodWithNullFirstParameter_ExpectException()
        {
            var mapperService = new App.Services.AutoMapperObjectMapperService(
                new PresentationConfiguration(), new InfrastructureConfiguration()); // TODO: Mock it

            var action = new Action(() =>
            {
                var _ = mapperService.Map<object, object>(null, new object());
            });

            action.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void AutoMapperObjectMapperService_WhenInvokingMapMethodWithNullSecondParameter_ExpectException()
        {
            var mapperService = new App.Services.AutoMapperObjectMapperService(
                new PresentationConfiguration(), new InfrastructureConfiguration()); // TODO: Mock it

            var action = new Action(() =>
            {
                var _ = mapperService.Map<object, object>(new object(), null);
            });

            action.ShouldThrow<ArgumentNullException>();
        }
    }
}