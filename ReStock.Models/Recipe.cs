using System.Collections.Generic;

namespace ReStock.Models
{
    public enum RecipeCategory
    {
        Chicken,
        Pork,
        Meat,
        Vegetarian,
        Soup,
        Dairy
    }
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? CookTime { get; set; }
        public string Instruction { get; set; }
        public ICollection<RecipeCategory> Categories { get; set; }
    }
}
