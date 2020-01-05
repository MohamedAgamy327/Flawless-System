using Domain.Enums;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public RoleEnum Role { get; set; }
        public ICollection<Spending> Spendings { get; set; }
    }
}
