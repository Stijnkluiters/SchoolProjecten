using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class Partij
    {
        [Key]
        public int Id { get; set; }
        public Dagen Dag { get; set; }

        public Uitslagen Uitslag { get; set; }

        public int PlayerId { get; set; }
        public Player Player { get; set; }

        [NotMapped]
        public List<Player> Players { get; set; } = new List<Player>();
    }
    public enum Uitslagen { Verloren, Remise, Gewonnen }
}
