using System;
using System.Collections.Generic;
using System.Text;

namespace GourmetSp
{
    public class Food
    {
        public double calories;
        public string unit { get; set; }
        public string name { get; set; }
        public string group { get; set; }

        public Food(double calories, string unit, string group, string name)
        {
            this.calories = calories;
            this.unit = unit;
            this.group = group;
            this.name = name;
        }

        public Food() { }
    }
}
