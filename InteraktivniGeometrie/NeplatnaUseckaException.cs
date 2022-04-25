using System;
using System.Runtime.Serialization;

namespace InteraktivniGeometrie
{
    [Serializable]
    internal class NeplatnaUseckaException : Exception
    {
        public NeplatnaUseckaException()
        {
        }

        public NeplatnaUseckaException(string message) : base(message)
        {
        }

        public NeplatnaUseckaException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NeplatnaUseckaException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}