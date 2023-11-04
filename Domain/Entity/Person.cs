using Domain.Asbtract;
using Domain.Contract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    [Table("People")]
    public class Person : BaseEntity<int>
    {
        [Required]
        [Column(TypeName = "varchar(255)")]
        public string FirstName { get; set; } = string.Empty;
        [Column(TypeName = "varchar(255)")]
        public string? SecondName { get; set; } = string.Empty;
        [Required]
        [Column(TypeName = "varchar(255)")]
        public string LastName { get; set; } = string.Empty;
        [Required]
        [Column(TypeName = "varchar(255)")]
        public string SecondLastName { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "varchar(255)")]
        public string Document { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "int")]
        public DocumentType DocumentType { get; set; }


        [Required]
        [Column(TypeName = "int")]
        //[ForeignKey(nameof(User))]
        public int UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }

        [Column(TypeName = "bit")]
        public bool State { set; get; }

        public string GetFullName() 
            => $"{FirstName} {SecondName} {LastName} {SecondLastName}";

    }
}
