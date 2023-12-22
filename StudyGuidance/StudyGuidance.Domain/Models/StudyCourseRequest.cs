using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyGuidance.Domain.Models
{
    public class StudyCourseRequest
    {
        public string School { get; set; }
        public string Study { get; set; }
        public string DiplomaType { get; set; }
        public string Location { get; set; }
        public int JobRelation { get; set; }
    }
}
