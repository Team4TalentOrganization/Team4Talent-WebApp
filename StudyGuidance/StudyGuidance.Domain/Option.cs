using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyGuidance.Domain
{
    public class Option
    {
        public int OptionId { get; set; }

        public int QuestionId { get; set; }

        public string Content { get; set; } = string.Empty;

        public bool IsChecked { get; set; } = false;
    }
}
