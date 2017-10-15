using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace MealGenerator.Model
{
    public class MealPlanning
    {
        private Dictionary<Days, Dictionary<MealTimes, Meal>> _innerDic;

        public int PersonsNumber { get; set; }

        public MealPlanning()
        {
            _innerDic = new Dictionary<Days, Dictionary<MealTimes, Meal>>();

            foreach (Days day in Enum.GetValues(typeof(Days)))
            {
                _innerDic.Add(day, new Dictionary<MealTimes, Meal>());
            }
        }

        public void AddMeal(Days day, MealTimes mealTime, Meal meal)
        {
            _innerDic[day].Add(mealTime, meal);
        }

        public void WriteTo(Stream stream)
        {
            using (var writer = new StreamWriter(stream, Encoding.UTF8, 512, true))
            {
                WriteTo(writer);
            }
        }

        public void WriteTo(StreamWriter writer)
        {
            WritePlanning(writer);

            writer.WriteLine();

            WriteShoppingList(writer);
        }

        private void WritePlanning(StreamWriter writer)
        {
            writer.WriteLine("Liste des repas pour {0} personne(s)", PersonsNumber);
            writer.WriteLine();

            Dictionary<MealTimes, Meal> mealsOfTheDay;

            foreach (Days day in Enum.GetValues(typeof(Days)))
            {
                writer.WriteLine("+ {0} :", DaysHelper.GetLabel(day));

                mealsOfTheDay = _innerDic[day];

                foreach (MealTimes mealTime in mealsOfTheDay.Keys)
                {
                    writer.Write("  > {0} : {1}", MealTimesHelper.GetLabel(mealTime), mealsOfTheDay[mealTime].Name);

                    if (!string.IsNullOrWhiteSpace(mealsOfTheDay[mealTime].ExternalLink))
                        writer.Write(" ({0})", mealsOfTheDay[mealTime].ExternalLink);

                    writer.WriteLine();
                }

                writer.WriteLine();
            }
        }

        private void WriteShoppingList(StreamWriter writer)
        {
            writer.WriteLine("A acheter");
            writer.WriteLine();

            var groupedComps = _innerDic.SelectMany(item => item.Value).Select(item => item.Value).SelectMany(item => item.Components).GroupBy(item => string.Format("{0} {1}", item.Unit, item.Name));

            IEnumerable<MealComponent> comps;
            MealComponent comp;
            decimal quantity;
            foreach (var groupedComp in groupedComps)
            {
                comps = groupedComp.Select(item => item);

                writer.Write("+");

                if (comps.Where(item => item.Quantity.HasValue).Count() == comps.Count())
                {
                    quantity = PersonsNumber * comps.Sum(item => item.Quantity.HasValue ? item.Quantity.Value : 0);
                    writer.Write(" {0}", quantity);
                }

                comp = comps.ElementAt(0);

                if (!string.IsNullOrWhiteSpace(comp.Unit))
                    writer.Write(" {0}", comp.Unit);

                writer.WriteLine(" {0}", comp.Name);
            }
        }
    }
}
