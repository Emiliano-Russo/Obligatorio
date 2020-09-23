using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace ObligatorioDDA2.Models.Logic
{
    public class Admin : IEquatable<Admin>
    {
        public string email { get; set; }

        public string contrasenia { get; set; }

        public bool Equals([AllowNull] Admin other)
        {
            return other.email == this.email;
        }
    }
}
