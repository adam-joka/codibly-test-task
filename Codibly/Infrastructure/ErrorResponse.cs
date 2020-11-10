using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Codibly.Infrastructure
{
    public class ErrorResponse
    {
        public List<string> Messages { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string Exception { get; set; }
    }
}
