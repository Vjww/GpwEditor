using System;
using AutoMapper;
using FluentAssertions;
using Moq;
using Xunit;

namespace App.BaseGameEditor.Infrastructure.Tests.Services
{
    public class AutoMapperMapperService
    {
        [Fact]
        public void AutoMapperMapperService_WhenInvokingConstructorWithNullParameter_ExpectException()
        {
            var action = new Action(() =>
            {
                var _ = new Infrastructure.Services.AutoMapperMapperService(null);
            });

            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void AutoMapperMapperService_WhenInvokingMapMethodWithNullParameter_ExpectException()
        {
            var mockMapper = new Mock<IMapper>();
            var mapperService = new Infrastructure.Services.AutoMapperMapperService(mockMapper.Object);

            var action = new Action(() =>
            {
                var _ = mapperService.Map<object, object>(null);
            });

            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void AutoMapperMapperService_WhenInvokingMapMethodWithNullFirstParameter_ExpectException()
        {
            var mockMapper = new Mock<IMapper>();
            var mapperService = new Infrastructure.Services.AutoMapperMapperService(mockMapper.Object);

            var action = new Action(() =>
            {
                var _ = mapperService.Map<object, object>(null, new object());
            });

            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void AutoMapperMapperService_WhenInvokingMapMethodWithNullSecondParameter_ExpectException()
        {
            var mockMapper = new Mock<IMapper>();
            var mapperService = new Infrastructure.Services.AutoMapperMapperService(mockMapper.Object);

            var action = new Action(() =>
            {
                var _ = mapperService.Map<object, object>(new object(), null);
            });

            action.Should().Throw<ArgumentNullException>();
        }
    }
}