using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzeSome.Data.Models.Dtos
{
    public class AddressDto
    {
        public int Id { get; set; }
        public string Street { get; set; } = null!;
        public string Number { get; set; } = null!;
        public string Code { get; set; } = null!;
        public string City { get; set; } = null!;
        public string Country { get; set; } = null!;
    }
}
