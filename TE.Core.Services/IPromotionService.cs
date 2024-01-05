using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TE.Core.Domain;

namespace TE.Core.Services
{
    internal interface IPromotionService: IService<Concours>
    {
        IList<Enseignant> getC(string promo);
        int getC(string promo, Specialite spec);
    }
}
