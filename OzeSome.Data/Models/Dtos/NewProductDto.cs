using System;

namespace OZEsome.Helpers
{
    public class NewProductDto
    {
        public Guid CategoryId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
    }
}
