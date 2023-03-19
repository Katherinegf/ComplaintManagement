using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppDataBase.MVVM.Models
{
    public class Customer
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; }= null!;
        public string Email { get; set; } = null!;
        public string? PhoneNumber { get; set; }

        public string DisplayName => $"{FirstName} {LastName}";
    }
}
