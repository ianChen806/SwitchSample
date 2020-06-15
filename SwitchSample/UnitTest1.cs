using Xunit;

namespace SwitchSample
{
    public class UnitTest1
    {
        [Fact]
        public void SwitchPlus()
        {
            var colorType = ColorType.Blue;
            string color;
            switch (colorType)
            {
                case ColorType.Red:
                    color = "red";
                    break;
                case ColorType.Blue:
                    color = "blue";
                    break;
                case ColorType.Yellow:
                    color = "yellow";
                    break;
                case ColorType.Green:
                    color = "green";
                    break;
                default:
                    color = "non";
                    break;
            }

            Assert.Equal("blue", color);
        }
    }
}