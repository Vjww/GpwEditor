using System;
using App.ObjectMapping.AutoMapper.Configurations;
using NUnit.Framework;

namespace App.Tests.Services
{
    [TestFixture]
    public class AutoMapperObjectMapperService
    {
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
    }
}