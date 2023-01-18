using MediatR;
using System;
using System.ComponentModel.DataAnnotations;

namespace SiparisYonetimi.Common.Models.RequestModels
{
    public class CreateProductCommand : IRequest<Guid>
    {
        [Required]
        [MaxLength(200)]
        public string ProductName { get; set; }
        [Required]
        [Range(0, 200000000)]
        public int UnitInStock { get; set; }
        [Required]
        [Range(0, 200000000)]
        public decimal Price { get; set; }
        [Required]
        public Guid CompanyId { get; set; }
    }
}
