using System;
using System.Collections.Generic;

namespace MyMathLib
{
    public class Math
    {
        private readonly double _dx; //Шаг
        private readonly double _eps; //Точность

        private readonly double _x; //Интервал от
        private readonly int _n;

        public Math(double x, double x2, double dx, double eps)
        {
            _x = x;
            _n =  (int) ((x2-x)/dx);
            _dx = dx;
            _eps = eps;
        }

        public double Calc()
        {
            double result = 0;
            double interimResult;
            var x = _x;

            return _n;
            //return -result - -result % _eps;
        }
    }
}