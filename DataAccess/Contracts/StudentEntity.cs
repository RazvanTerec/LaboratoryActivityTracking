using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class StudentEntity
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public int Group { get; set; }
        public string Hobby { get; set; }
        public double Average { get; set; }
        public string Status { get; set; }
    }
}
