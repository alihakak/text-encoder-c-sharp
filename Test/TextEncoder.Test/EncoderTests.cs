using NUnit.Framework;
using System.Text;

namespace TextEncoder.EncoderTests
{
    public class EncoderTests
    {
        private  Services.TextEncoder _service;

        [SetUp]
        public void Setup()
        {
            _service = new Services.TextEncoder();
        }

        [TestCase("A", ";")]
        [TestCase("ABC", ";n,")]
        public void HorizontalFlip_ShouldTransformString(string inputStr, string expectedStr)
        {

            //Act
            var actualOutput = _service.HorizontalFlip(inputStr);            

            //Assert
            Assert.AreEqual(actualOutput.Result, expectedStr);
            Assert.AreEqual(actualOutput.Result.Length, expectedStr.Length);

        }

        [TestCase("1", "z")]
        [TestCase("123", "zxc")]
        public void VerticalFlip_ShouldTransformString(string inputStr, string expectedStr)
        {

            //Act
            var actualOutput = _service.VerticalFlip(inputStr);

            //Assert
            Assert.AreEqual(actualOutput.Result, expectedStr);
            Assert.AreEqual(actualOutput.Result.Length, expectedStr.Length);
        }

        [TestCase("1", 1, "2")]
        [TestCase("1", 11, "w")]
        [TestCase("12", 5, "67")]
        [TestCase("Z", 5, "n")]
        public void ShiftBy_ShouldTransformString(string inputStr, int shiftBy, string expectedStr)
        {

            //Act
            var actualOutput = _service.ShiftBy(inputStr, shiftBy);

            //Assert
            Assert.AreEqual(actualOutput.Result, expectedStr);
            Assert.AreEqual(actualOutput.Result.Length, expectedStr.Length);
        }

        [TestCase("1","H,1", "q")]
        [TestCase("ABC", "V,H,2,5", "jet")]
        public void Encode_ShouldEncodeStringByCommand(string inputStr, string commandLine, string expectedStr)
        {
            //Act
            var actualOutput = _service.EncodeText(inputStr, commandLine);

            //Assert
            Assert.AreEqual(actualOutput.Result, expectedStr);
            Assert.AreEqual(actualOutput.Result.Length, expectedStr.Length);
        }
    }
}