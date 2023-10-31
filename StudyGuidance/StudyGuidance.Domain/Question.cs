using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyGuidance.Domain
{
    public class Question
    {
        public int QuestionId { get; set; }
        public List<Option> Options { get; set; } = null!;
        public string Phrase {  get; set; } = string.Empty;
    }
}
