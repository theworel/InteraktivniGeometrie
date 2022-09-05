using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace InteraktivniGeometrie.Exceptions
{
    [Serializable]
    internal class NemoznyTvarException : Exception
    {
        public NemoznyTvarException()
        {
        }

       

       

        protected NemoznyTvarException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
