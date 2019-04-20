using System;
using System.Collections.Generic;
using System.Xml;

namespace MyMathLib
{
    public class Math
    {
        private readonly double _xStep;                                         //Шаг
        private readonly double _eps;                                           //Точность
        private readonly double _xFrom;                                         //Интервал от
        private readonly int _n;                                                //Количество повторов

        private readonly List<Function> _interimValues = new List<Function>();  //Промежуточные значения
        private long _time;                                                     //Время работы программы

        public Math(double xFrom, double xTo, double xStep, double eps = 0.1)
        {
            _xFrom = xFrom;
            _n =  (int) ((xTo-xFrom)/xStep);
            _xStep = xStep;
            _eps = eps;
        }

        //Генерация значений
        public List<Function> GenerateValues()
        {
            _time = DateTime.Now.Ticks;
            double result;
            int j;

            for (int i = 0; i <= _n; i++)
            {
                j = 1;
                result = 0;
                var x = _xFrom;
                for (int k = 0; k < _xFrom+_xStep*i; k++)
                {
                    result += Func(x,j);
                    x += _xStep;
                    j *= 2;
                }
                _interimValues.Add(new Function {X = x-_xStep, FuncX = -result, N = i+1});
            }
            Console.WriteLine(_time);
            _time = DateTime.Now.Ticks - _time;
            return _interimValues;
        }

        public long GetTime()
        {
            return _time;
        }

        private double Func(double x,int n)
        {
            double result = System.Math.Pow(x, n) / n;
            return result - result % _eps;
        }
    }
    public class Function
    {
        public double X { get; set; }
        public double FuncX { get; set; }
        public int N { get; set; }
    }
}