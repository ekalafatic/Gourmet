using System;
using System.Collections.Generic;
using System.Text;

public enum FoodGroup
{
    Dairies, // lácteos
    Meets,
    Vegetables,
    Fruits,
    Legumes,
    Cereals
}

public enum Unit
{
    grams,
    kilos,
    cn,
    unit
}

namespace GourmetSp
{
    public class Food
    {
        public double calories;
        public string name { get; set; }
        public FoodGroup group { get; set; }
        public Unit unit { get; set; }

        public Food(double calories, Unit unit, FoodGroup group, string name)
        {
            this.calories = calories;
            this.unit = unit;
            this.group = group;
            this.name = name;
        }

        public Food() { }
    }
}
