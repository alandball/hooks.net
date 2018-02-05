using System;

namespace HooksNet
{
    internal class NoGitRepositoryFoundException : Exception
    {
        public NoGitRepositoryFoundException(string path)
        {
            Path = path;
        }

        public string Path { get; }
    }
}