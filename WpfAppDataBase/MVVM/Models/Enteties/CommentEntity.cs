using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppDataBase.MVVM.Models.Enteties
{
    internal class CommentEntity
    {
        [Key]
        public int Id { get; set; }

        [MaxLength]
        public string Comment { get; set; } = null!;

        [Column(TypeName = "datetime")]
        public DateTime EntryTime { get; set; }


        [Required]
        public int CaseId { get; set; }

        public CaseEntity Case { get; set; } = null!;

        [Required]
        public int CustomerId { get; set; }

        public CustomerEntity Customer { get; set; } = null!;
    }
}
