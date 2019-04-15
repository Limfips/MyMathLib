using System;

namespace MyMathLib
{
    public class Math
    {
        private readonly double _dx; //Шаг
        private readonly double _eps; //Точность

        private readonly double _x1; //Интервал от
        private readonly double _x2; //Bynthdfk до
        private double _n = 1;

        public Math(double x1, double x2, double dx, double eps)
        {
            _x1 = x1;
            _x2 = x2;
            _dx = dx;
            _eps = eps;
        }

        public double Calc()
        {
            double result = 0;
            double interimResult;
            var x = _x1;
            while (x >= -1 && x < 1 || x >= _x2)
            {
                interimResult = System.Math.Pow(x,_n)/_n;
                result += interimResult - interimResult % _eps;
                x += _dx;
                _n = System.Math.Pow(_n,2);
            }

            return -result;
        }
    }
}