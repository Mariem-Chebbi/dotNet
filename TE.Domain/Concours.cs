using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TE.Core.Domain
{
    public class Concours
    {
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public int NbrEM { get; set; }
        public int NbrGC { get; set; }
        public int NbrGED { get; set; }
        public int NbrLANGUE { get; set; }
        public int NbrMATH { get; set; }
        public int NbrTIC { get; set; }
        [Key]
        [Range(2003, int.MinValue)]
        public int Promotion { get; set; }
        public virtual IList<Candidature> Candidatures { get; set; }


    }
}
