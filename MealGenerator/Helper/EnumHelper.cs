using System;
using System.Collections.Generic;
using System.Text;

namespace MealGenerator.Helper
{
    public static class EnumHelper
    {
        public static IEnumerable<Enum> GetFlags(Enum input)
        {
            foreach (Enum value in Enum.GetValues(input.GetType()))
                if (input.HasFlag(value))
                    yield return value;
        }
    }
}
