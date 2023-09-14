namespace WebAPi6.Services
{
    public interface ITokenGenerator
    {
        public string GenerateToken(Dictionary<string, object> payload);
    }
}
