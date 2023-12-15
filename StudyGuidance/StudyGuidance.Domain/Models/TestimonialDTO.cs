using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyGuidance.Domain.Models
{
    public class TestimonialDTO
    {
        public int Id { get; set; }
        public int JobId { get; set;}
        public string Name { get; set;}
        public string Description { get; set;}
        public string JobTitel { get; set;}

        public TestimonialDTO()
        {
        }

        public TestimonialDTO(Testamonial testamonial)
        {
            Id = testamonial.Id;
            JobId = testamonial.JobId;
            Name = testamonial.Name;
            Description = testamonial.Description;
            JobTitel = testamonial.JobTitel;
        }
    }
}
