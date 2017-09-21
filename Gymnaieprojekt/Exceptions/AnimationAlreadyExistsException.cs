using System;

namespace Gymnaieprojekt.Exceptions
{
    public class AnimationAlreadyExistsException : Exception
    {
        private static string message = "En animation med det namnet finns redan.";
        public AnimationAlreadyExistsException() : base(message)
        {
            
        }
    }
}
