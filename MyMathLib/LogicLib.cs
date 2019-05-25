using System;
using System.Collections.Generic;
using System.Diagnostics;
using raminrahimzada;

namespace MyMathLib
{
    public class Math
    {
        //Интервал от
        private readonly decimal _xFrom;
        //Интервал до
        private readonly decimal _xTo;
        //Шаг
        private readonly decimal _xStep;
        //Точность
        private readonly decimal _eps;                                           
        //Промежуточные значения
        private readonly List<Values> _interimValues = new List<Values>();
        //Время работы программы
        private long _time;
        private int _n;
        
        public Math(decimal xFrom, decimal xTo, decimal xStep, decimal eps)
        {
            if (xFrom < xTo && xFrom>= -1 && xTo<=1)
            {
                _xTo = xTo;
                _xFrom = xFrom;
                _xStep = xStep;
                _eps = eps;
                
                //0.10000000000000001
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
            for (decimal x = _xFrom; x <= _xTo; x = x + _xStep)
            {
              //  Debug.WriteLine(_xFrom+" "+_xTo);
                decimal df = 0;
                for (int i = 1; System.Math.Abs(System.Math.Abs(Func(x, i))) > _eps; i++)
                {
                    df += Func(x, i);
                    _n = i;
                }

                decimal log;
                decimal mathFunc = 0.0M;
                decimal differenceFunc = 0.0M;
                try
                {
                    log = DecimalMath.Log(1 - x);
                    mathFunc = GetAccurate(log,_eps);
                    differenceFunc = GetAccurate(DecimalMath.Abs(-df - log), _eps);
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.ToString());
                }
                
                _interimValues.Add(new Values { X = x, 
                    FuncX = -df,
                    FuncMath = System.Math.Round(mathFunc,3), //  3     0,001
                    Difference = differenceFunc,
                    N = _n});
            }
            _time = DateTime.Now.Ticks - _time;
            
            return _interimValues;
        }

        private decimal GetAccurate(decimal number,decimal esp)
        {
            string[] temp = _eps.ToString().Split('.',',');
            
            return System.Math.Round(number,temp[1].Length);
        }

        public long GetTime()
        {
            return _time;
            
        }
        private decimal Func(decimal x, int n)
        {
            decimal result = DecimalMath.Power( x, n) / n;
            return GetAccurate(result,_eps);
        }
    }
    public class Values
    {
        public decimal X { get; set; }
        public decimal FuncX { get; set; }
        public decimal FuncMath { get; set; }
        public decimal Difference { get; set; }
        public int N { get; set; }
    }
}