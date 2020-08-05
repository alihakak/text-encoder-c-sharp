using NUnit.Framework;
using System.Text;

namespace TextEncoder.EncoderTests
{
    public class EncoderTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [TestCase("A", ";")]
        [TestCase("ABC", ";n,")]
        public void HorizontalFlip_ShouldTransformString(string inputStr, string expectedStr)
        {
            //Arrange 
            Services.TextEncoder encoder = new Services.TextEncoder();

            //Act
            var actualOutput = encoder.HorizontalFlip(inputStr);            

            //Assert
            Assert.AreEqual(actualOutput, expectedStr);
            Assert.AreEqual(actualOutput.Length, expectedStr.Length);

        }

        [TestCase("1", "z")]
        [TestCase("123", "zxc")]
        public void VerticalFlip_ShouldTransformString(string inputStr, string expectedStr)
        {
            //Arrange 
            Services.TextEncoder encoder = new Services.TextEncoder();

            //Act
            var actualOutput = encoder.VerticalFlip(inputStr);

            //Assert
            Assert.AreEqual(actualOutput, expectedStr);
            Assert.AreEqual(actualOutput.Length, expectedStr.Length);

        }

        [TestCase("1", 1, "2")]
        [TestCase("1", 11, "w")]
        [TestCase("12", 5, "67")]
        [TestCase("Z", 5, "n")]
        public void ShiftBy_ShouldTransformString(string inputStr, int shiftBy, string expectedStr)
        {
            //Arrange 
            Services.TextEncoder encoder = new Services.TextEncoder();

            //Act
            var actualOutput = encoder.ShiftBy(inputStr, shiftBy);

            //Assert
            Assert.AreEqual(actualOutput, expectedStr);
            Assert.AreEqual(actualOutput.Length, expectedStr.Length);

        }
    }
}