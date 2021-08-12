
using GourmetSp;

namespace GourmetApi.DTOs
{
    public class IngredientDTO
    {
        public int IngredientId { get; set; }
        public Food Food { get; set; }
        public double Amount { get; set; }
    }
}