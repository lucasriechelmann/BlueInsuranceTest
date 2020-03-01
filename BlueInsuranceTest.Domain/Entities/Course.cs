using System;

namespace BlueInsuranceTest.Domain.Entities
{
    public class Course : BaseEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string TeacherName { get; set; }
        public int StudentLimit { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
