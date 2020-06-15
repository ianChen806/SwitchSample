using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace SwitchSample
{
    public class RecursivePattern
    {
        [Fact]
        public void Index()
        {
            var list = new List<MyClass3>
            {
                { 1, "name", 12, true },
                { 2, "name2", 24, false },
            };

            var result = Recursive(list);

            result.Should().BeEquivalentTo(new { Id = 2, Name = "name2", Score = 24, IsPassed = false });
        }

        private IEnumerable<MyClass3> Recursive(List<MyClass3> list)
        {
            foreach (var item in list)
            {
                if (item is MyClass3 {Score: 24, IsPassed: false})
                {
                    yield return item;
                }
            }
        }
    }
}