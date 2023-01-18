using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SiparisYonetimi.Common.Models.RequestModels
{
    public class CreateOrderCommand : IRequest<Guid>
    {
        [Required]
        [MaxLength(200)]
        public string CustomerName { get; set; }
        [Required]
        public Guid CompanyId { get; set; }
        [Required]
        [DefaultValue("07:30:00")]
        public string OrderTime { get; set; }
        public virtual ICollection<Guid> Products { get; set; }
    }
}
