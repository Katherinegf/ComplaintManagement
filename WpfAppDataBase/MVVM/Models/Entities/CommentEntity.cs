using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppDataBase.MVVM.Models.Entities
{
    public class CommentEntity
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime Created { get; set; }

        public string? Description { get; set; }

        public CaseEntity Case { get; set; } =null!;

        public CustomerEntity Customer { get; set; } = null!;
        public DateTime EntryTime { get; internal set; }
    }
}
