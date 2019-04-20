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

        private double _finalResult;                                            //Финальный результат
        private readonly List<Function> _interimValues = new List<Function>();  //Промежуточные значения

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
            double result = 0;
            double interimResult = 0;
            var x = _xFrom;
            var j = 1;

            for (int i = 1; i <= _n+1; i++)
            {
                    result += Func(x,j);
                _interimValues.Add(new Function {X = x, FunctionFromX = -result, N = i});
                x += _xStep;
                j *= 2;
            }
            _finalResult=-result;
            return _interimValues;
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
        public double FunctionFromX { get; set; }
        public int N { get; set; }
    }
}