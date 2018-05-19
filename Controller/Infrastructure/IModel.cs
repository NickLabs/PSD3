using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Infrastructure
{
    public interface IModel
    {
        double function(double x, double a);
    }
}
