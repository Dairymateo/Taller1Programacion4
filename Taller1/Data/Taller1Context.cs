using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Taller1.Models;

namespace Taller1.Data
{
    public class Taller1Context : DbContext
    {
        public Taller1Context (DbContextOptions<Taller1Context> options)
            : base(options)
        {
        }

        public DbSet<Taller1.Models.Auto> Auto { get; set; } = default!;
        public DbSet<Taller1.Models.Propietario> Propietario { get; set; } = default!;
        public DbSet<Taller1.Models.Motor> Motor { get; set; } = default!;
    }
}
