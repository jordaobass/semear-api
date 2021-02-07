using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SemearApi.Entities
{
    [Table("INTRUCTS")]
    public class Intructs : DbContext
    {
        public int Id { get; set; }
        
        public int Name { get; set; }
        
        public ICollection<UserIntructs> UserIntructs { get; set; }
    }
}