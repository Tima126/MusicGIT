using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class User
    {
        public User()
        {
            UserFavorites = new HashSet<UserFavorite>();
        }

        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Lastname { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public DateTime Regdate { get; set; }

        public virtual ICollection<UserFavorite> UserFavorites { get; set; }
    }
}
