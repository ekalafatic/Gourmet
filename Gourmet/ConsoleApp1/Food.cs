using System;
using System.Collections.Generic;
using System.Text;

namespace GourmetSp
{
    public class Food
    {
        public double Calories { get; set; }
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
