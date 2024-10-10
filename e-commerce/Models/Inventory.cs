﻿namespace e_commerce.Models
{
    public class Inventory : BaseEntity
    {
        public string Product { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string Location { get; set; }
    }
}