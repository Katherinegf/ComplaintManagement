using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WpfAppDataBase.MVVM.Models.Entities
{
    [Index(nameof(Email), IsUnique = true)] // no two identical emails
    public class CustomerEntity
    {

        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [StringLength(50)]
        public string FirstName { get; set; } = null!;

        [StringLength(60)]
        public string LastName { get; set; } = null!;

        [StringLength(150)]
        public string Email { get; set; } = null!;

        [Column(TypeName = "char(13)")]
        public string? PhoneNumber { get; set; }

        // since one customer can have more than one addresses its an -> one to many relation
        public ICollection<AddressEntity> Addresses = new HashSet<AddressEntity>();

    }
}


