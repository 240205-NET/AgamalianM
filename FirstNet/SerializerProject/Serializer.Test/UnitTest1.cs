using Serializer;

namespace Serializer.Test
{

    public class UnitTest1
    {
        [Fact]  // The [Fact] annotation denotes that the test method does not require any parameters to run.
        public void SmokeCheck()
        {
            // Arrange
            // Act
            // Assert
            Assert.Equal(true, true);
        }

        [Fact]
        public void TextToNumber_5_TypeOfInt()
        {
            // Arrange
            string data = "1";

            // Act
            var actual = Program.TextToNumber(data);

            // Assert
            Assert.IsType<int>(actual);
        }

        [Fact]
        public void TextToNumber_5_ValueOf5()
        {
            // Arrange
            string data = "1";
            int expected = 1;

            // Act
            var actual = Program.TextToNumber(data);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory] // The [Theory] annotation denotes that the test method will
                 // accept a parameter to use during testing.
        [InlineData("1")]
        [InlineData("2")] // The [InlineData()] annotation supplies the data for the test
        public void TestWithParameters(string numText)
        {
            // Arrange
            // Act
            var actual = Program.TextToNumber(numText);
            // Assert
            Assert.IsType<int>(actual);
        }

        public static readonly List<string> data = new List<string>
        {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6"
        };

        [Theory]
        [MemberData(data)]
        public void TextToNumber_List_Ints(string inputData)
        {
            // Arrange

            // Act
            var actual = Program.TextToNumber(inputData);
            // Assert
            Assert.IsType<int>(actual);
        }
    }
}