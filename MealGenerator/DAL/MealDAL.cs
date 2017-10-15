using MealGenerator.Helper;
using MealGenerator.Model;
using System;
using System.Collections.Generic;
using System.IO;

namespace MealGenerator.DAL
{
    public class MealDAL
    {
        private string _fileName = "Meals.json";

        public void Init()
        {
            if (!File.Exists(_fileName))
            {
                var meals = new List<Meal>();
                var meal = new Meal { Id = Guid.NewGuid(), Name = "Steak frites" };
                meal.Components.Add(new MealComponent { Id = Guid.NewGuid(), Quantity = 200, Unit = "g", Name = "steak" });
                meal.Components.Add(new MealComponent { Id = Guid.NewGuid(), Quantity = 400, Unit = "g", Name = "pommes de terre" });
                meals.Add(meal);

                using (var fs = new FileStream(_fileName, FileMode.Create))
                {
                    JsonHelper.Serialize(meals, fs);
                }
            }
        }

        public List<Meal> Load()
        {
            var meals = new List<Meal>();

            using (var fs = new FileStream(_fileName, FileMode.Open))
            {
                meals.AddRange(JsonHelper.Deserialize<List<Model.Meal>>(fs));
            }

            return meals;
        }
    }
}
