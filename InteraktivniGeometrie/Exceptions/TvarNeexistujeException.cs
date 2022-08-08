using System;
using System.Runtime.Serialization;

namespace InteraktivniGeometrie
{
    [Serializable]
    internal class TvarNeexistujeException : Exception
    {
        public TvarNeexistujeException()
        {
        }

        public TvarNeexistujeException(string message) : base(message)
        {
        }

        public TvarNeexistujeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected TvarNeexistujeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}