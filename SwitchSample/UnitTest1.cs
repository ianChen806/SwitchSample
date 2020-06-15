using Xunit;

namespace SwitchSample
{
    public class UnitTest1
    {
        [Fact]
        public void SwitchPlus()
        {
            var colorType = ColorType.Blue;
            var color = colorType switch
            {
                ColorType.Red => "red",
                ColorType.Blue => "blue",
                ColorType.Yellow => "yellow",
                ColorType.Green => "green",
                _ => "non"
            };

            Assert.Equal("blue", color);
        }
    }
}