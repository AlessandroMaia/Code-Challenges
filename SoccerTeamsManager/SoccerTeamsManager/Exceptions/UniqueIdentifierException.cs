﻿using System;
using System.Runtime.Serialization;

namespace SoccerTeamsManager.Exceptions
{
    [Serializable]
    public class UniqueIdentifierException : Exception
    {
        public UniqueIdentifierException()
        {
        }

        public UniqueIdentifierException(string message)
            : base(message)
        {
        }

        public UniqueIdentifierException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected UniqueIdentifierException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
