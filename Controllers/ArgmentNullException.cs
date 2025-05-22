
namespace Catalog.API.Controllers
{
    [Serializable]
    internal class ArgmentNullException : Exception
    {
        public ArgmentNullException()
        {
        }

        public ArgmentNullException(string? message) : base(message)
        {
        }

        public ArgmentNullException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}