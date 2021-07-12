namespace ReStock.Models
{
    public enum StockType
    {
        Spices = 0,
        FruitsAndVeggies = 1,
        Proteins = 2,
        Other = 3
    }
    public class StockItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Amount { get; set; }
        public StockType StockType { get; set; }
    }
}
