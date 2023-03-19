using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppDataBase.MVVM.Models.Entities;

namespace WpfAppDataBase.MVVM.Models
{
    public class Case
    {
        public string CaseNumber { get; set; } = null!;
        public DateTime EntryDate { get; set; }
        public string CustomerName { get; set; } = null!;
        public string CustomerEmail { get; set; } = null!;
        public string CustomerPhoneNumber { get; set; } = null!;
        public string? Description { get; set; }
        public string Status { get; set; } = string.Empty;

        public int AddressId { get; set; }
        public Address Address { get; set; } = null!;

        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;

        public int CommentsId { get; set; }
        public Comment Comment { get; set; } = null!;
    }
}
