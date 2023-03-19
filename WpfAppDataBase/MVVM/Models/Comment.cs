using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppDataBase.MVVM.Models.Entities;

namespace WpfAppDataBase.MVVM.Models
{
    public class Comment
    {

        public int Id { get; set; }
        public DateTime Created { get; set; } 
        public string? Description { get; set; }

        public string? CaseNumber { get; set; } = null!;

        public CaseEntity Case { get; set; } = null!;

        public Guid CustomerId { get; set; }
        public CustomerEntity Customer { get; set; } = null!;
        public DateTime EntryTime { get; internal set; }
    }
}
