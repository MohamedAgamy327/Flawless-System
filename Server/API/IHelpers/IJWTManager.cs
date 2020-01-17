namespace API.IHelpers
{
    public interface IJWTManager
    {
        public string GenerateToken(int id, string name, string role);
    }
}
