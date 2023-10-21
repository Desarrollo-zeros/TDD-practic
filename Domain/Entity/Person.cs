using Domain.Asbtract;
using Domain.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Person : BaseEntity<int>
    {
        public string FirstName { get; set; } = string.Empty;
        public string? SecondName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public string SecondLastName { get; set; } = string.Empty;

        public string Document { get; set; } = string.Empty;

        public DocumentType DocumentType { get; set; }

        public int UserId { get; set; }

        public User User { get; set; } = new User();

        public string GetFullName() 
            => $"{FirstName} {SecondName} {LastName} {SecondLastName}";

    }
}
