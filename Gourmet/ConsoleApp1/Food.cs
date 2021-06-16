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
        public double Calories;
        public string Name { get; set; }
        public FoodGroup Group { get; set; }
        public Unit Unit { get; set; }

        public Food(double calories, Unit unit, FoodGroup group, string name)
        {
            this.Calories = calories;
            this.Unit = unit;
            this.Group = group;
            this.Name = name;
        }

        public Food() 
        {
            this.Name = "";
            this.Calories = 0;
            this.Unit = new Unit();
            this.Group = new FoodGroup();
        }
    }
}
