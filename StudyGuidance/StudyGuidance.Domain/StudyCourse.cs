using StudGuidance.Domain.Models;
using StudyGuidance.Domain.Exceptions;
using StudyGuidance.Domain.Models;

namespace StudyGuidance.Domain
{
    public class StudyCourse
    {
        private string _school = string.Empty;
        private string _study = string.Empty;
        private Diploma _diplomaType;
        private int _jobRelation;
        private Location _location;

        public StudyCourse()
        {

        }

        public StudyCourse(StudyCourseRequest studyCourseRequest)
        { 
            _study = studyCourseRequest.Study;
            _school = studyCourseRequest.School;
            if (Enum.TryParse(studyCourseRequest.DiplomaType, out Diploma diplomaType))
            {
                _diplomaType = diplomaType;
            }
            else
            {
                throw new ArgumentException($"Invalid diploma type: {studyCourseRequest.DiplomaType}");
            }

            if (Enum.TryParse(studyCourseRequest.Location, out Location location))
            {
                _location = location;
            }
            else
            {
                throw new ArgumentException($"Invalid location: {studyCourseRequest.Location}");
            }
            _jobRelation = studyCourseRequest.JobRelation;
        }

        public int Id { get; set; }

        public string School
        {
            get => _school;
            set => _school = value ?? throw new BusinessException(nameof(School));
        }

        public string Study
        {
            get => _study;
            set => _study = value ?? throw new BusinessException(nameof(value));
        }

        public Diploma DiplomaType
        {
            get => _diplomaType;
            set
            {
                if (!Enum.IsDefined(typeof(Diploma), value))
                {
                    throw new BusinessException("Invalid or default DiplomaType");
                }

                _diplomaType = value;
            }
        }

        public Location Location
        {
            get => _location;
            set
            {
                if (!Enum.IsDefined(typeof(Location), value))
                {
                    throw new BusinessException("Invalid or default Location");
                }

                _location = value;
            }
        }

        public int JobRelation
        {
            get => _jobRelation;
            set
            {
                if (value <= 0)
                {
                    throw new BusinessException("JobRelation must be greater than 0.");
                }

                _jobRelation = value;
            }
        }
    }
}
