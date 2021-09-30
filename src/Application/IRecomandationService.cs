using Domain;
using Domain.NormalDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public interface IRecomandationService
    {
        void RecalculateRating(Review review);
    }
}
