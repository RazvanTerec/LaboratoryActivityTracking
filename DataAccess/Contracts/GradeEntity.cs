using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class GradeEntity
    {
        public int Id { get; set; }
        public int IdSubmission { get; set; }
        public int IdStudent { get; set; }
        public double GradeStudent { get; set; }
    }
}
