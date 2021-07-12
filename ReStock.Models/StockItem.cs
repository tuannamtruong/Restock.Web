namespace ReStock.Models
{
    public enum StockType
    {
        Spices,
        FruitsAndVeggies,
        Proteins,
        Other 
    }
    public class StockItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Amount { get; set; }
        public StockType StockType { get; set; }
    }
}
