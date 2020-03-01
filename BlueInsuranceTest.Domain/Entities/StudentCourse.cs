namespace BlueInsuranceTest.Domain.Entities
{
    public class StudentCourse : BaseEntity
    {
        public long StudentId { get; set; }
        public virtual Student Student { get; set; }
        public long CourseId { get; set; }
        public virtual Course Course { get; set; }
    }
}
