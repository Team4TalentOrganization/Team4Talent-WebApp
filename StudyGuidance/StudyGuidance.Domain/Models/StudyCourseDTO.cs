using StudyGuidance.Domain;

namespace StudGuidance.Domain.Models
{
    public class StudyCourseDTO
    {
        public int Id { get; set; }
        public string School { get; set; }
        public string Study { get; set; }
        public string DiplomaType { get; set; }
        public string Location { get; set; }
        public int JobRelation { get; set; }

        public StudyCourseDTO()
        {

        }

        public StudyCourseDTO(StudyCourse course)
        {
            Id = course.Id;
            School = course.School;
            Study = course.Study;
            DiplomaType = course.DiplomaType.ToString();
            Location = course.Location.ToString();
            JobRelation = course.JobRelation;
        }
    }
}
