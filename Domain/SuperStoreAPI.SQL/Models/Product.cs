namespace SuperStoreAPI.SQL.Models
{
    public class Product
    {
        public Product(int id, string title, decimal price, string description, string image, decimal rate, int count, string category, int quantity)
        {
            Id = id;
            Title = title;
            Price = price;
            Description = description;
            Image = image;
            Rate = rate;
            Count = count;
            Category = category;
            Quantity = quantity;
        }

        public int Id { get; set; }
        public string Title { get; set; } = null!; 
        public decimal Price { get; set; }
        public string Description { get; set; } = null!;
        public string Image { get; set; }
        public decimal Rate { get; set; }
        public int Count { get; set; }
        public string Category { get; set; } = null!;
        public int Quantity { get; set; }
    }
}
