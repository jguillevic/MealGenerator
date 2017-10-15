using System;
using System.Collections.Generic;

namespace MealGenerator.Model
{
    public class Meal
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ExternalLink { get; set; }
        public List<MealComponent> Components { get; set; }
        public List<MealInstruction> Instructions { get; set; }

        public Meal()
        {
            Components = new List<MealComponent>();
            Instructions = new List<MealInstruction>();
        }
    }

    public class MealComponent
    {
        public Guid Id { get; set; }
        public decimal? Quantity { get; set; }
        public string Unit { get; set; }
        public string Name { get; set; }
    }

    public class MealInstruction
    {
        public Guid Id { get; set; }
        public int Order { get; set; }
        public string Instruction { get; set; }
    }
}
