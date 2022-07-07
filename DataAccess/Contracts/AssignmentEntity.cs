using System;

namespace DataAccess
{
    public class AssignmentEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Deadline { get; set; }
        public string Description { get; set; }
        public int LaboratoryId { get; set; }
    }
}
