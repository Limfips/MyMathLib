using System.Runtime.Remoting.Messaging;

namespace MyMathLib
{
    public class Math
    {
        public Math(int x1, int x2, int dx, int eps, int n)
        {
            _x1 = x1;
            _x2 = x2;
            _dx = dx;
            _eps = eps;
        }

        private int _x1;    //Интервал от
        private int _x2;    //Bynthdfk до
        private int _dx;    //Шаг
        private int _eps;   //Точность
        private int _n = 1;

        public double Calc()
        {
            double result = 0;
            var x = _x1;
            while (x>=-1 && x<1)
            {
                
            }
            
            return -result;
        }
    }
}