using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace ObligatorioDDA2.Models.Logic
{
    [Table("Admin")]
    public class Admin : IEquatable<Admin>
    {
        [Key]
        public string email { get; set; }

        public string contrasenia { get; set; }

        public bool Equals([AllowNull] Admin other)
        {
            return other.email == this.email;
        }
    }
}
