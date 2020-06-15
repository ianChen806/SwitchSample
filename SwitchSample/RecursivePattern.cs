using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace SwitchSample
{
    public class RecursivePattern
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public RecursivePattern(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

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

        [Fact]
        public void Index_2()
        {
            MyClass3 value = null;
            if (value is object o)
            {
                _testOutputHelper.WriteLine("not null");
            }

            if (value is MyClass3 v)
            {
                _testOutputHelper.WriteLine("not null");
            }

            if (value is {} x)
            {
                _testOutputHelper.WriteLine("not null");
            }

            _testOutputHelper.WriteLine("is null");
        }

        private IEnumerable<MyClass3> Recursive(List<MyClass3> list)
        {
            foreach (var item in list)
            {
                if (item is {Score: 24, IsPassed: false})
                {
                    yield return item;
                }
            }
        }
    }
}