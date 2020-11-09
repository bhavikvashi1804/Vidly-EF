using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Student
    {
        public int PlacementId { get; set; }
        public int StudentId { get; set; }
        public String StudentName { get; set; }
        public String Company { get; set; }
        public String PlacementYear { get; set; }
    }
}