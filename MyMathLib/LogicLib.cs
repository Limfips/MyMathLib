using System;
using System.Collections.Generic;

namespace MyMathLib
{
    public class Math
    {
        //Интервал от
        private readonly double _xFrom;
        //Интервал до
        private readonly double _xTo;
        //Шаг
        private readonly double _xStep;
        //Точность
        private readonly double _eps;                                           
        //Промежуточные значения
        private readonly List<Values> _interimValues = new List<Values>();
        //Время работы программы
        private long _time;
        private int _n;
        
        public Math(double xFrom, double xTo, double xStep, double eps)
        {
            if (xFrom < xTo && xFrom>= -1 && xTo<=1)
            {
                _xTo = xTo;
                _xFrom = xFrom;
                _xStep = xStep;
                _eps = eps;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }
        //Генерация значений
        public List<Values> GenerateValues()
        {
            _time = DateTime.Now.Ticks;
            

            for (double x = _xFrom; x <= _xTo; x += _xStep)
            {
                _interimValues.Add(new Values { X = x, 
                                                FuncX = -Func(x),
                                                FuncMath = System.Math.Log(1-x),
                                                Difference = System.Math.Abs(-Func(x)-System.Math.Log(x)),
                                                N = _n}); 
            }
            _time = DateTime.Now.Ticks - _time;
            return _interimValues;
        }

        public long GetTime()
        {
            return _time;
        }
        private double Func(double x)
        {
            double result = 0.0;
            double currValue = 0;
            int n = 1;
            while (System.Math.Abs(currValue) > _eps) // Если очередной элемент ряда меньше точности - выход.
            {
                currValue = System.Math.Pow(x, n) / n;
                result += currValue;
                n++;
            }
            _n = n;
            return result;
        }
    }
    public class Values
    {
        public double X { get; set; }
        public double FuncX { get; set; }
        public double FuncMath { get; set; }
        public double Difference { get; set; }
        public int N { get; set; }
    }
}