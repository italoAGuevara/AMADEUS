
namespace Login.API.Exception
{
    public class UserNotFoundException : IOException
    {
        public UserNotFoundException(string message) : base(message)
        {
        }

        public UserNotFoundException(string name, object key) : base($"Entity \"{name}\" ({key}) was not found.")
        {
        }
    }
}
