using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PokéBase.Models
{
    public class Pokemon
    {
        [Key] public int pokeID { get; set; }
        [Required] public int dexNum { get; set; }
        [Required] public string name { get; set; }
        [Required] public int originalTrainer { get; set; }
    }
}
