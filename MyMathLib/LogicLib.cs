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
        private readonly double _xTo;                                           //Интервал до
        private readonly int _n = 5;                                            //Количество повторов

        private readonly List<Function> _interimValues = new List<Function>();  //Промежуточные значения
        private long _time;                                                     //Время работы программы

        public Math(double xFrom, double xTo, double xStep, double eps = 0.1)
        {
            if (xFrom>=-1 && xFrom<=1 && xTo>=-1 && xTo<=1 && xFrom<=xTo)
            {
                _xTo = xTo;
                _xFrom = xFrom;
                _xStep = xStep;
                _eps = eps;
            }
            else
            {
                throw new Exception();
            }
        }

        //Генерация значений
        public List<Function> GenerateValues()
        {
            _time = DateTime.Now.Ticks;
            for (double x = _xFrom; x < _xTo; x+=_xStep)
            {
                double result = 0.0;
                for (int j = 1; j <= _n; j++)
                {
                    result += Func(x,j);
                    _interimValues.Add(new Function {X = x, FuncX = result, N = j});
                }
            }
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