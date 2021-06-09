using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Food
    {
        public double calories;
        public string unit { get; set; }
        public string group { get; set; }

        public Food(double calories, string unit, string group)
        {
            this.calories = calories;
            this.unit = unit;
            this.group = group;
        }
    }
}
