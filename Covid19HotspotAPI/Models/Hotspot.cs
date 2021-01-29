using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TestAPI.Models
{
    public class Hotspot
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string Province { get; set; }
        public string District { get; set; }

        public int casesPer100k { get; set; }

        public double growthRate { get; set; }

        public double avgNewCases { get; set; }
    }
}