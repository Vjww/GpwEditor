using System;
using App.ObjectMapping.AutoMapper.Configurations;
using NUnit.Framework;

namespace App.Tests.Services
{
    [TestFixture]
    public class AutoMapperObjectMapperService
    {
        private PresentationConfiguration _presentationConfiguration;
        private InfrastructureConfiguration _infrastructureConfiguration;

        [SetUp]
        public void SetUp()
        {
            _presentationConfiguration = new PresentationConfiguration();
            _infrastructureConfiguration = new InfrastructureConfiguration();
        }

        [Test]
        public void AutoMapperObjectMapperService_WhenInvokingConstructorWithNullFirstParameter_ExpectException()
        {
            var infrastructureConfiguration = new InfrastructureConfiguration();

            void TestDelegate()
            {
                var _ = new App.Services.AutoMapperObjectMapperService(null, infrastructureConfiguration);
            }

            Assert.Throws(typeof(ArgumentNullException), TestDelegate);
        }

        [Test]
        public void AutoMapperObjectMapperService_WhenInvokingConstructorWithNullSecondParameter_ExpectException()
        {
            var presentationConfiguration = new PresentationConfiguration();

            void TestDelegate()
            {
                var _ = new App.Services.AutoMapperObjectMapperService(presentationConfiguration, null);
            }

            Assert.Throws(typeof(ArgumentNullException), TestDelegate);
        }

        [Test]
        public void AutoMapperObjectMapperService_WhenInvokingMapMethodWithNullParameter_ExpectException()
        {
            var mapperService = new App.Services.AutoMapperObjectMapperService(_presentationConfiguration, _infrastructureConfiguration);

            void TestDelegate()
            {
                var _ = mapperService.Map<object, object>(null);
            }

            Assert.Throws(typeof(ArgumentNullException), TestDelegate);
        }

        [Test]
        public void AutoMapperObjectMapperService_WhenInvokingMapMethodWithNullFirstParameter_ExpectException()
        {
            var mapperService = new App.Services.AutoMapperObjectMapperService(_presentationConfiguration, _infrastructureConfiguration);

            void TestDelegate()
            {
                var _ = mapperService.Map<object, object>(null, new object());
            }

            Assert.Throws(typeof(ArgumentNullException), TestDelegate);
        }

        [Test]
        public void AutoMapperObjectMapperService_WhenInvokingMapMethodWithNullSecondParameter_ExpectException()
        {
            var mapperService = new App.Services.AutoMapperObjectMapperService(_presentationConfiguration, _infrastructureConfiguration);

            void TestDelegate()
            {
                var _ = mapperService.Map<object, object>(new object(), null);
            }

            Assert.Throws(typeof(ArgumentNullException), TestDelegate);
        }
    }
}