using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppDataBase.MVVM.Models.Enteties
{
    internal class CaseEntity
    {
        [Key]
        public int Id { get; set; }

        [MaxLength]
        public string Description { get; set; } = null!;

        [Column(TypeName = "datetime")]
        public DateTime EntryTime { get; set; } = DateTime.Now;

        [EnumDataType(typeof(CaseStatus))]
        [Column(TypeName = "nvarchar(20)")]
        public CaseStatus? Status { get; set; }


        [Required]
        public Guid CustomerId { get; set; }

        public CustomerEntity Customer { get; set; } = null!;

        public ICollection<CommentEntity> Comments = new HashSet<CommentEntity>();

    }
}
