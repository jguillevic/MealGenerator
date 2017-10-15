using MealGenerator.Model;
using System;
using System.IO;

namespace MealGenerator
{
    class Program
    {
        /// <summary>
        /// args[0] = Repas à générer pour le lundi. 0 : Pas de repas, 1 : le midi, 2 : le soir, 3 : midi et soir.
        /// args[1] = Repas à générer pour le mardi. 0 : Pas de repas, 1 : le midi, 2 : le soir, 3 : midi et soir.
        /// args[2] = Repas à générer pour le mercredi. 0 : Pas de repas, 1 : le midi, 2 : le soir, 3 : midi et soir.
        /// args[3] = Repas à générer pour le jeudi. 0 : Pas de repas, 1 : le midi, 2 : le soir, 3 : midi et soir.
        /// args[4] = Repas à générer pour le vendredi. 0 : Pas de repas, 1 : le midi, 2 : le soir, 3 : midi et soir.
        /// args[5] = Repas à générer pour le samedi. 0 : Pas de repas, 1 : le midi, 2 : le soir, 3 : midi et soir.
        /// args[6] = Repas à générer pour le dimanche. 0 : Pas de repas, 1 : le midi, 2 : le soir, 3 : midi et soir.
        /// args[7] = Chemin de sauvegarde du fichier.
        /// args[8] = Nombre de personnes.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var mealGen = new Engine.MealGenerator();

            mealGen.Repartitions[Days.Monday] = (MealTimes)Convert.ToInt32(args[0]);
            mealGen.Repartitions[Days.Tuesday] = (MealTimes)Convert.ToInt32(args[1]);
            mealGen.Repartitions[Days.Wednesday] = (MealTimes)Convert.ToInt32(args[2]);
            mealGen.Repartitions[Days.Thursday] = (MealTimes)Convert.ToInt32(args[3]);
            mealGen.Repartitions[Days.Friday] = (MealTimes)Convert.ToInt32(args[4]);
            mealGen.Repartitions[Days.Saturday] = (MealTimes)Convert.ToInt32(args[5]);
            mealGen.Repartitions[Days.Sunday] = (MealTimes)Convert.ToInt32(args[6]);

            mealGen.Init();

            mealGen.Run(Convert.ToInt32(args[7]));

            var fileFullPath = string.Format("Planning.txt");

            using (var writer = File.CreateText(fileFullPath))
            {
                mealGen.Planning.WriteTo(writer);
            }
        }
    }
}
