using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzeSome.Data.Models.Dtos
{
    public class MeetingDto
    {
        public int Id { get; set; }
        // Customer Data
        public string CustomerFirstName { get; set; } = null!;
        public string CustomerLastName { get; set; } = null!;
        public DateTime MeetingDate { get; set; }
        public string MeetingStatus { get; set; } = null!;
    }
}
