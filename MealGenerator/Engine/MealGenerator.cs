using MealGenerator.DAL;
using MealGenerator.Helper;
using MealGenerator.Model;
using System;
using System.Collections.Generic;

namespace MealGenerator.Engine
{
    public class MealGenerator
    {
        private List<Meal> _mealsCache;
        private MealDAL _mealDAL;

        public MealRepartitions Repartitions { get; private set; }
        public MealPlanning Planning { get; private set; }

        public MealGenerator()
        {
            _mealsCache = new List<Meal>();
            _mealDAL = new MealDAL();

            Repartitions = new MealRepartitions();
            Planning = new MealPlanning();
        }

        public void Init()
        {
            // TODO : Possible de modifier l'algo pour :
            // 1/ Charger les identifiants des repas respectant les critères
            // 2/ Charger les recette une fois les identifiants des repas déterminés

            _mealsCache.Clear();

            _mealDAL.Init();

            var meals = _mealDAL.Load();
            _mealsCache.AddRange(meals);
        }

        public void Run(int personsNumber)
        {
            Planning.PersonsNumber = personsNumber;

            var rand = new Random();
            int pos;
            // "Duplication" du cache pour manipulation.
            var tempCache = new List<Meal>(_mealsCache);

            foreach (var item in Repartitions.GetAllElements())
            {
                if (item.Value != MealTimes.None)
                {
                    foreach (MealTimes mealTime in EnumHelper.GetFlags(item.Value))
                    {
                        if (mealTime != MealTimes.None)
                        {
                            pos = rand.Next(0, tempCache.Count);

                            Planning.AddMeal(item.Key, mealTime, tempCache[pos]);

                            if (tempCache.Count > 1)
                            {
                                // Suppression du repas pour ne pas avoir de doublon.
                                tempCache.RemoveAt(pos);
                            }
                        }
                    }
                }
            }
        }
    }
}
