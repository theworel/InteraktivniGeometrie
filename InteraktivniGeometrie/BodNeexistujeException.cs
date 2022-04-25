using System;
using System.Runtime.Serialization;

namespace InteraktivniGeometrie
{
    [Serializable]
    internal class BodNeexistujeException : Exception
    {
        public BodNeexistujeException()
        {
        }

        public BodNeexistujeException(string message) : base(message)
        {
        }

        public BodNeexistujeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected BodNeexistujeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}