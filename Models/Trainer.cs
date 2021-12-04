using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PokéBase.Models
{
    public class Trainer
    {
        [Key] public int trainerID { get; set; }
        [Required] public string name { get; set; }
        [Required] public string region { get; set; }
        [Required] public string trainerClass { get; set; }
    }
}
