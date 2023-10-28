using Domain.Asbtract;
using Domain.Contract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    [Table("Users")]
    public class User : BaseEntity<int>
    {
        [Required]
        [Column(TypeName = "varchar(255)")]
        public string UserName { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "varchar(255)")]
        public string Password { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "varchar(255)")]
        public string Email { get; set; } = string.Empty;

        [Column(TypeName = "bit")]
        public bool Active { get; set; }

    }
}
