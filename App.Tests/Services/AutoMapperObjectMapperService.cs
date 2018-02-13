// TODO: Resolve?
//using System;
//using System.Collections.Generic;
//using App.ObjectMapping.AutoMapper;
//using FluentAssertions;
//using Xunit;

//namespace App.Tests.Services
//{
//    public class AutoMapperObjectMapperService
//    {
//        [Fact]
//        public void AutoMapperObjectMapperService_WhenInvokingConstructorWithNullParameter_ExpectException()
//        {
//            var action = new Action(() =>
//            {
//                var _ = new App.Services.AutoMapperObjectMapperService(null);
//            });

//            action.ShouldThrow<ArgumentNullException>();
//        }

//        [Fact]
//        public void AutoMapperObjectMapperService_WhenInvokingMapMethodWithNullParameter_ExpectException()
//        {
//            var mapperService = new App.Services.AutoMapperObjectMapperService(
//                new List<IAutoMapperConfiguration>()); // TODO: Mock it

//            var action = new Action(() =>
//            {
//                var _ = mapperService.Map<object, object>(null);
//            });

//            action.ShouldThrow<ArgumentNullException>();
//        }

//        [Fact]
//        public void AutoMapperObjectMapperService_WhenInvokingMapMethodWithNullFirstParameter_ExpectException()
//        {
//            var mapperService = new App.Services.AutoMapperObjectMapperService(
//                new List<IAutoMapperConfiguration>()); // TODO: Mock it

//            var action = new Action(() =>
//            {
//                var _ = mapperService.Map<object, object>(null, new object());
//            });

//            action.ShouldThrow<ArgumentNullException>();
//        }

//        [Fact]
//        public void AutoMapperObjectMapperService_WhenInvokingMapMethodWithNullSecondParameter_ExpectException()
//        {
//            var mapperService = new App.Services.AutoMapperObjectMapperService(
//                new List<IAutoMapperConfiguration>()); // TODO: Mock it

//            var action = new Action(() =>
//            {
//                var _ = mapperService.Map<object, object>(new object(), null);
//            });

//            action.ShouldThrow<ArgumentNullException>();
//        }
//    }
//}