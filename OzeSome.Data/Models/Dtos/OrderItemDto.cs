﻿namespace OzeSome.Data.Models.Dtos
{
    public class OrderItemDto
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        // Product Data
        public string? ProductCategoryName { get; set; }
        public string ProductName { get; set; } = null!;
        public decimal ProductPrice { get; set; }
    }
}
