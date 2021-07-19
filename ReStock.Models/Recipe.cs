using System;
using System.Collections.Generic;
using System.Text;

namespace ReStock.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? CookTime { get; set; }
        public string? Instruction { get; set; }
    }
}
