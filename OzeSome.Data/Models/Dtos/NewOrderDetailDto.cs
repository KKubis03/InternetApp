﻿namespace OzeSome.Data.Models.Dtos
{
    public class NewOrderDetailDto
    {
        public Guid OrderId { get; set; }
        public Guid CustomerId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
