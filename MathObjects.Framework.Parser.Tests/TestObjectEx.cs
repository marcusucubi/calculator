using System;

namespace MathObjects.Framework.Parser.Tests
{
    public static class TestObjectEx
    {
        public static string GetString(this IMathObject obj)
        {
            return obj.GetValue<string>();
        }
    }
}

