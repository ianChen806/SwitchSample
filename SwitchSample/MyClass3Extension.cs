using System.Collections.Generic;

namespace SwitchSample
{
    public static class MyClass3Extension
    {
        public static void Add(this List<MyClass3> list, int id, string name, int score, bool pass)
        {
            list.Add(new MyClass3()
            {
                Id = id,
                Name = name,
                Score = score,
                IsPassed = pass
            });
        }
    }
}