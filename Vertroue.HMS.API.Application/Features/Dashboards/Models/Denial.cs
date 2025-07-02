using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vertroue.HMS.API.Application.Features.Dashboards.Models
{
    public class Denial
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? TPACode { get; set; }

        public string? InsurerCode { get; set; }

        public int? Count { get; set; }
    }
}
