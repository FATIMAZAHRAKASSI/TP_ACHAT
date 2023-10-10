namespace TP_ACHAT.Models
{
    public class Produit
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public int StockQuantity { get; set; }

        public String image { get; set; }
    }
}
