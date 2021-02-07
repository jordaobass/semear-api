using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SemearApi.Entities
{
    [Table("USER")]
    public class User : DbContext
    {
        [Key] public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
       
        public string Age { get; set; }

        public string Description { get; set; }

        public string linkedin { get; set; }
        
        public string GitHub { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public ICollection<UserLearn> UserLearn { get; set; }
        public ICollection<UserCareers> UserCareers { get; set; }
        
        public ICollection<UserIntructs> UserIntructs { get; set; }
        
        public User()
        {
        }

        public User(string name, string email, string password)
        {
            this.Name = name;
            this.Email = email;
            this.Password = password;
            this.Role = Entities.Role.User;
        }
    }
}