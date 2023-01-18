using System;

namespace SiparisYonetimi.Common.Models.QueryModels
{
    public class ProductDetailViewModel
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public int UnitInStock { get; set; }
        public decimal Price { get; set; }
    }
}
