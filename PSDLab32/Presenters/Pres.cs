using System;
using DomainModel.Infrastructure;
using View.ViewInterfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presenter.Presenters
{
    public class Pres
    {
        public IView view;
        public IModel model;

        public Pres(IView view, IModel model)
        {
            this.view = view;
            this.model = model;
        }

        public void Run()
        {
            view.ButtonClick += View_ButtonClick;
            view.Start();
        }


        private void View_ButtonClick(object sender, EventArgs e)
        {
            GenerateDots();
        }

        private List<double> GenerateX(double left, double right)
        {
            List<double> X = new List<double>();
            for (int i = Convert.ToInt32(left); i < right; i++)
            {
                X.Add(i);
            }
            return X;
        }

        private List<double> GenerateY(double left, double right, double a)
        {
            List<double> Y = new List<double>();
            for (int i = Convert.ToInt32(left); i < right; i++)
            {
                Y.Add(model.function(i, a));
            }
            return Y;
        }

        public void GenerateDots()
        {
            double l = 0, r = 0, a = 0;
            bool isCorrectData = false;
            try
            {
                l = Convert.ToDouble(view.Min);
                r = Convert.ToDouble(view.Max);
                a = Convert.ToDouble(view.A);
                isCorrectData = true;
            }
            catch (FormatException e)
            {
                view.WrongDataBox();
            }
            if(l >= r)
            {
                view.WrongInterval();
                isCorrectData = false;
            }

            if (isCorrectData)
            {
                List<double> generatedX = GenerateX(l, r);
                List<double> generatedY = GenerateY(l, r, a);
                view.SetChart(generatedX, generatedY);
                view.SetDotsList(generatedX, generatedY);
            }
        }
    }
}
