using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TE.Core.Domain
{
    public class Candidature
    {
        public DateTime DateDepot { get; set; }
        public DateTime DateEntretien { get; set; }
        public DateTime DateEpreuve { get; set; }
        public string Dossier { get; set; }
        public bool Resultat { get; set; }
        public float Score { get; set; }
        public virtual Enseignant MyEnseignant { get; set; }
        public virtual Concours MyConcours { get; set; }
        public int EnseignantFk { get; set; }
        public int ConcoursFk { get; set; }
    }
}
