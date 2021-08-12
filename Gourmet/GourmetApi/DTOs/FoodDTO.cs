using GourmetSp;

namespace GourmetApi.DTOs
{
    public class FoodDTO
    {
        public int FoodID { get; set; }
        public double Calories { get; set; }
        public string Name { get; set; }
        public FoodGroup Group { get; set; }
        public Unit Unit { get; set; }
    }
}