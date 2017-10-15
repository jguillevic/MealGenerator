using System;
using System.Collections.Generic;
using System.Text;

namespace MealGenerator.Model
{
    [Flags]
    public enum Days
    {
        Saturday = 1,
        Sunday = 2,
        Monday = 4,
        Tuesday = 8,
        Wednesday = 16,
        Thursday = 32,
        Friday = 64     
    }

    public static class DaysHelper
    {
        public static string GetLabel(Days day)
        {
            switch (day)
            {
                case Days.Monday:
                    return"Lundi";
                case Days.Tuesday:
                    return"Mardi";
                case Days.Wednesday:
                    return"Mercredi";
                case Days.Thursday:
                    return"Jeudi";
                case Days.Friday:
                    return"Vendredi";
                case Days.Saturday:
                    return"Samedi";
                case Days.Sunday:
                    return"Dimanche";
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
