using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class SubmissionEntity
    {
        public int Id { get; set; }
        public int IdStudent { get; set; }
        public int IdAssignment { get; set; }
        public string Link { get; set; }
        public string Comment { get; set; }
    }
}
