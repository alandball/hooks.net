using System;

namespace HooksNet
{
    internal class NoGitRepositoryFoundException : Exception
    {
        public string Path { get; }

        public NoGitRepositoryFoundException(string path)
        {
            Path = path;
        }
    }
}