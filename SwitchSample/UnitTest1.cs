using System;
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

        [Fact]
        public void TuplePattern()
        {
            var player1 = TupleType.Scissors;
            var player2 = TupleType.Paper;
            var result = (player1, player2) switch
            {
                (TupleType.Scissors, TupleType.Paper) => ResultType.Win,
                (TupleType.Rock, TupleType.Scissors) => ResultType.Win,
                (TupleType.Paper, TupleType.Rock) => ResultType.Win,
                var (first, second) when first == second => ResultType.Deuce,
                _ => ResultType.Lose,
            };

            Assert.Equal(ResultType.Win, result);
        }

        [Fact]
        public void PositionPattern()
        {
            var expression = new MyExpression
            {
                Operand = "*",
                X = 2,
                Y = 5
            };
            var result = expression switch
            {
                ("+", var x, var y) => x + y,
                ("-", var x, var y) => x - y,
                ("*", var x, var y) => x * y,
                ("/", _, 0) => double.NaN,
                ("/", var x, var y) => (double)x / y,
                _ => throw new ArgumentException(),
            };

            Assert.Equal(10, result);
        }
    }

    public class MyExpression
    {
        public string Operand { get; set; }

        public int X { get; set; }

        public int Y { get; set; }

        public void Deconstruct(out string operand, out int x, out int y)
        {
            operand = Operand;
            x = X;
            y = Y;
        }
    }

    public enum RoleType
    {
        Admin,
        User,
    }

    public enum ResultType
    {
        Win,
        Deuce,
        Lose
    }

    public enum TupleType
    {
        Scissors,
        Rock,
        Paper,
    }

    public class MyClass
    {
        public int Id { get; set; }
    }
}