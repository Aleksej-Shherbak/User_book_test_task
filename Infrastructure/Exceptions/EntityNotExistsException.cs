using System;

namespace Infrastructure.Exceptions
{
    public class EntityNotExistsException : Exception
    {
        public const string ModelStateKeyText = "entityNotFound";

        public EntityNotExistsException(string message) : base(message)
        {
        }
    }

}