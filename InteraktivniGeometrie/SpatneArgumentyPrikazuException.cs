using System;
using System.Runtime.Serialization;

namespace InteraktivniGeometrie
{
    [Serializable]
    internal class SpatneArgumentyPrikazuException : Exception
    {
        public SpatneArgumentyPrikazuException()
        {
        }

        public SpatneArgumentyPrikazuException(string message) : base(message)
        {
        }

        public SpatneArgumentyPrikazuException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected SpatneArgumentyPrikazuException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}