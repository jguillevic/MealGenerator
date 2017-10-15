using System;

namespace MealGenerator.Model
{
    [Flags]
    public enum MealTimes
    {
        None = 0,
        Lunch = 1,
        Dinner = 2,
    }

    public static class MealTimesHelper
    {
        public static string GetLabel(MealTimes mealTime)
        {
            switch (mealTime)
            {
                case MealTimes.Lunch:
                    return "Déjeuner";
                case MealTimes.Dinner:
                    return "Dîner";
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
