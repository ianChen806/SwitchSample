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

        [Fact]
        public void PropertyPattern()
        {
            var myClass = new MyClass
            {
                Id = 123
            };
            var id = myClass switch
            {
                {Id: 123} => "123",
                {Id: 234} => "234",
                _ => "non"
            };

            Assert.Equal("123", id);
        }
    }

    public class MyClass
    {
        public int Id { get; set; }
    }
}