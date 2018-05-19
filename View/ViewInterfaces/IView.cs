using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View.ViewInterfaces
{
    public interface IView
    {
        string Min { get; }
        string Max { get; }
        string A { get; }
        void WrongDataBox();
        void WrongInterval();
        void SetChart(List<double> X, List<double> Y);
        void SetDotsList(List<double> X, List<double> Y);
        event EventHandler ButtonClick;
        void Start();
    }
}
