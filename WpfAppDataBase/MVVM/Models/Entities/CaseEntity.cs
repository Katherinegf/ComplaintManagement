using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppDataBase.MVVM.Models.Entities
{
    public class CaseEntity
    {

        [Key]
        public string CaseNumber { get; set; } = null!;

        [Column(TypeName = "datetime")]
        public DateTime OrderDate { get; set; }

        [StringLength(100)]
        public string CustomerName { get; set; } = null!;

        [StringLength(150)]
        public string CustomerEmail { get; set; } = null!;

        [StringLength(13)]
        public string CustomerPhoneNumber { get; set; } = null!;

        public string? Description { get; set; }

        [StringLength(20)]
        public string Status { get; set; } = null!;
        public AddressEntity Address { get; set; } = null!; // get Id from Address
        public DateTime EntryDate { get; internal set; }
        public CustomerEntity Customer { get; set; } = null!;

        //one to many relationship
        public ICollection<CommentEntity> Comments = new HashSet<CommentEntity>();
    }
}