using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class CreateActivityDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Category { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Venue { get; set; }
    }
}
