using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TE.Core.Domain
{
    public enum Grade
    {
        AssistantTechnologue,Technologue,MaitreTechnologue
    }
    public enum Specialite
    {
        TIC,EM,GC,MATH,GED,LANGUE
    }
    public class Enseignant
    {
        [Required]
        public Grade Grade { get; set; }
        [Key]
        [Range(0, int.MaxValue, ErrorMessage = "donner une capacite positive")]
        public int Matricule { get; set; }
        [Required]
        public Specialite Specialite { get; set; }
        [ForeignKey("MyUP")]
        public string UPFK { get; set; }
        public virtual UP MyUP { get; set; }
        public virtual IList<Candidature> Candidatures { get; set; }
    }
}
