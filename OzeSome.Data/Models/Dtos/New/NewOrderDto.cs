﻿namespace OzeSome.Data.Models.Dtos.New
{
    public class NewOrderDto
    {
        public DateTime OrderDate { get; set; }
        public Guid CustomerId { get; set; }
        public int OrderStatusId { get; set; }
    }
}
