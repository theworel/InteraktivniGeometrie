using System;
using System.Runtime.Serialization;

namespace InteraktivniGeometrie
{
    [Serializable]
    internal class NesouhlasneDimenzeException : Exception
    {
        public NesouhlasneDimenzeException()
        {
        }

        public NesouhlasneDimenzeException(string message) : base(message)
        {
        }

        public NesouhlasneDimenzeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NesouhlasneDimenzeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}