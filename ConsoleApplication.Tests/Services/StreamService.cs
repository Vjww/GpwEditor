using System;
using System.IO;
using System.Linq;
using ConsoleApplication.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleApplication.Tests.Services
{
    [TestClass]
    public class StreamService
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StreamService_WhenConstructingWithMemoryStreamBeingANullArgument_ExpectArgumentNullException()
        {
            // ReSharper disable once ObjectCreationAsStatement
            new StreamService<MemoryStream>(null);
        }

        //[TestMethod]
        //public void StreamService_WhenGetting_ExpectReturnedStreamIsNotNull()
        //{
        //    var memoryStream = new MemoryStream();
        //    var streamService = new StreamService<MemoryStream>(memoryStream);

        //    var sut = streamService.Get();

        //    Assert.IsNotNull(sut, "SUT is null.");
        //}

        //[TestMethod]
        //public void StreamService_WhenGetting_ExpectReturnedStreamIsACopy()
        //{
        //    var memoryStream = new MemoryStream();
        //    var streamService = new StreamService<MemoryStream>(memoryStream);

        //    var sut = streamService.Get();

        //    Assert.AreNotEqual(memoryStream, sut, "SUT is not a copy of the stream.");
        //}

        //[TestMethod]
        //[ExpectedException(typeof(ArgumentNullException))]
        //public void StreamService_WhenSettingWithMemoryStreamBeingANullArgument_ExpectArgumentNullException()
        //{
        //    var memoryStream = new MemoryStream();
        //    var streamService = new StreamService<MemoryStream>(memoryStream);

        //    streamService.Set(null);
        //}

        //[TestMethod]
        //public void StreamService_WhenSetting_ExpectStreamIsReplaced()
        //{
        //    var byteArray = new byte[] { 0x01, 0x02, 0x03, 0x04 };
        //    var memoryStream = new MemoryStream(byteArray);
        //    var streamService = new StreamService<MemoryStream>(memoryStream);

        //    var newByteArray = new byte[] { 0x05, 0x06, 0x07, 0x08 };
        //    var newMemoryStream = new MemoryStream(newByteArray);
        //    streamService.Set(newMemoryStream);

        //    var sut = streamService.Read(0, byteArray.Length);

        //    Assert.IsTrue(sut.SequenceEqual(newByteArray), "SUT is not equal to expected bytes.");
        //}

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void StreamService_WhenReadingWithCountBeingAnOutOfRangeArgument_ExpectArgumentOutOfRangeException()
        {
            var memoryStream = new MemoryStream();
            var streamService = new StreamService<MemoryStream>(memoryStream);

            streamService.Read(0, -1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void StreamService_WhenReadingWithSeekOriginBeingAnOutOfRangeArgument_ExpectArgumentOutOfRangeException()
        {
            var memoryStream = new MemoryStream();
            var streamService = new StreamService<MemoryStream>(memoryStream);

            streamService.Read(0, 1, (SeekOrigin)(-1));
        }

        [TestMethod]
        public void StreamService_WhenReadingWithEndToEndArguments_ExpectAllBytesAreReturned()
        {
            var byteArray = new byte[] { 0x01, 0x02, 0x03, 0x04 };
            var memoryStream = new MemoryStream(byteArray);
            var streamService = new StreamService<MemoryStream>(memoryStream);

            var sut = streamService.Read(0, byteArray.Length);

            Assert.IsTrue(sut.SequenceEqual(byteArray), "SUT is not equal to expected bytes.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void StreamService_WhenWritingWithSeekOriginBeingAnOutOfRangeArgument_ExpectArgumentOutOfRangeException()
        {
            var memoryStream = new MemoryStream();
            var streamService = new StreamService<MemoryStream>(memoryStream);

            streamService.Write(0, 0, (SeekOrigin)(-1));
        }

        [TestMethod]
        public void StreamService_WhenWritingWithEndToEndArguments_ExpectAllBytesAreReplaced()
        {
            var byteArray = new byte[] { 0x01, 0x02, 0x03, 0x04 };
            var memoryStream = new MemoryStream(byteArray);
            var streamService = new StreamService<MemoryStream>(memoryStream);

            var newByteArray = new byte[] { 0x05, 0x06, 0x07, 0x08 };
            streamService.Write(0, newByteArray);

            var sut = streamService.Read(0, byteArray.Length);

            Assert.IsTrue(sut.SequenceEqual(newByteArray), "SUT is not equal to expected bytes.");
        }
    }
}