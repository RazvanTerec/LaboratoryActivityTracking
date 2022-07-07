using System;

namespace DataAccess
{
    public class LaboratoryEntity
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string Objectives { get; set; }
        public string Description { get; set; }
    }
}
