namespace API.DTO.User
{
    public class UserForChangePasswordDTO
    {
        public int Id { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
