using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestHW.Models
{
    public class Offre
    {
        // todo ajouter des controles de surface

        public int Id { get; set; }
        public string IdPoleEmploi { get; set; }
        public string Intitule { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }

        public OrigineOffre OrigineOffre { get; set; }
    }
}
