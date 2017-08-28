using ConsoleApplication.Entities.BaseGame;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleApplication.Tests
{
    [TestClass]
    public class SampleUnitTest
    {
        [TestMethod]
        public void GivenAEntity_WhenEntityHasBeenCreated_ThenIdShouldEqualZero()
        {
            var entity = new CarNumberEntity();

            Assert.IsTrue(entity.Id == 0);
        }
    }
}