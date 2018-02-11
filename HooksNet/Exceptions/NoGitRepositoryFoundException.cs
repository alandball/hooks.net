using System;

namespace HooksNet
{
    internal class NoGitRepositoryFoundException : Exception
    {
        public NoGitRepositoryFoundException(string path)
        {
            Path = path;
        }

        public NoGitRepositoryFoundException()
        {
        }

        protected NoGitRepositoryFoundException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context)
        {
        }

        public NoGitRepositoryFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public string Path { get; }
    }
}