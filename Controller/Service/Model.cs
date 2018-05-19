using System;
using DomainModel.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Service
{
    public class Model:IModel
    {
        public double function(double x, double a)
        {
            return a * a * a / (x * x + a * a);
        }
    }
}
