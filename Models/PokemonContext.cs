using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PokéBase.Models
{
    public class PokemonContext : DbContext
    {
        public PokemonContext(DbContextOptions<PokemonContext> options) : base(options)
        {

        }

        public DbSet<Pokemon> pokemonSet { get; set; }
        public DbSet<Trainer> trainerSet { get; set; }
    }
}
