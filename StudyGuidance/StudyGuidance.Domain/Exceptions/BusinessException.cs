using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace StudyGuidance.Domain.Exceptions
{
    /// <summary>
    /// Thrown when a certain contract or pre-condition is not met.
    /// Usually thrown by <see cref="Contracts"/> class.
    /// </summary>
    [Serializable]
    public class BusinessException : Exception
    {
        public BusinessException(string message)
            : base(message)
        {
        }

        public BusinessException()
        {

        }

        public BusinessException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}