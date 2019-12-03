namespace API.DTO.Users
{
    public class UserForEditDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
        public bool IsTerminated { get; set; }
    }
}
