using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewDataTypes
{
    public class Fraction{
        private int numerator;
        private int denominator;
        private string result;

        public Fraction()
        {
            numerator = 1;
            denominator = 1;
            result = "(" + numerator.ToString() + "/" + denominator.ToString() + ")";
        }
        public Fraction(int numerator ,int denominator)
        {
            this.numerator = numerator;
            this.denominator = denominator;
            result = "(" + numerator.ToString() + "/" + denominator.ToString() + ")";
        }

        //setting data methods
        public void setValue(double value)
        {
            value = reducePrecision(value);
            convert(value);
        }
        public void setArguments(int numerator, int denominator)
        {
            this.numerator = numerator;
            this.denominator = denominator;
            result = "(" + numerator.ToString() + "/" + denominator.ToString() + ")";
        }
        public void setNumerator(int numerator)
        {
            this.numerator = numerator;
            result = "(" + numerator.ToString() + "/" + denominator.ToString() + ")";
        }
        public void setDenominator(int denominator)
        {
            this.denominator = denominator;
            result = "(" + numerator.ToString() + "/" + denominator.ToString() + ")";
        }

        //getting data methods
        public int getNumerator()
        {
            return numerator;
        }
        public int getDenominator()
        {
            return denominator;
        }
        public double getFloatingResult()
        {
            return (float)numerator / denominator;
        }
        public string getResult()
        {
            return result;
        }

        //data manipultaion methods
        private void convert(double value)
        {
            string strVal = value.ToString();
            if (strVal.Split('.').Length == 1)
                strVal += ".0";
            string[] strArr = strVal.Split('.');
            string num = strArr[0] + strArr[1];
            string den = "1";
            for (int i = 0; i < strArr[1].Length; i++)
            {
                den += "0";
            }
            numerator = Convert.ToInt32(num);
            denominator = Convert.ToInt32(den);
            cancel();
        }
        public void cancel()
        {
            if (numerator > denominator)
                beginCanceling(denominator);
            else
                beginCanceling(numerator);
        }
        private void beginCanceling(int range)
        {
            if (numerator % range == 0 && denominator % range == 0)
            {
                numerator = numerator / range;
                denominator = denominator / range;
                result = "(" + numerator.ToString() + "/" + denominator.ToString() + ")";
                return;
            }
            IEnumerable<int> tempRange = Enumerable.Range(2, range / 2 - 1);
            int[] checkList = tempRange.ToArray();
            checkList = checkList.Reverse().ToArray();
            foreach(int i in checkList)
            {
                if (numerator % i == 0 && denominator % i == 0)
                {
                    numerator = numerator / i;
                    denominator = denominator / i;
                    result = "(" + numerator.ToString() + "/" + denominator.ToString() + ")";
                    if (numerator == 1 || denominator == 1)
                        break;
                }
            }
        }
        private double reducePrecision(double value)
        {
            string strVal = value.ToString();
            if (strVal.Split('.').Length == 1)
                strVal += ".0";
            string[] strArr = strVal.Split('.');
            strVal = strArr[1];
            string afterDec = "";
            string beforeDec = strArr[0];
            for (int i = 0; i < strVal.Length; i++)
            {
                if (i > 7)
                    break;
                afterDec += strVal[i];
            }
            return Convert.ToDouble(beforeDec + "." + afterDec);
        }
       
        //overloading methods
        public static Fraction operator + (Fraction f1 , Fraction f2)
        {
            double val1 = (float)f1.numerator / f1.denominator;
            double val2 = (float)f2.numerator / f2.denominator;
            double total = val1 + val2;
            Fraction temp = new Fraction();
            temp.setValue(total);
            return temp;
        }
        public static Fraction operator +(Fraction f1, double val)
        {
            double val1 = (float)f1.numerator / f1.denominator;
            double val2 = val;
            double total = val1 + val2;
            Fraction temp = new Fraction();
            temp.setValue(total);
            return temp;
        }
        public static Fraction operator +(double val, Fraction f1)
        {
            double val1 = val;
            double val2 = (float)f1.numerator / f1.denominator;
            double total = val1 + val2;
            Fraction temp = new Fraction();
            temp.setValue(total);
            return temp;
        }
        public static Fraction operator -(Fraction f1, Fraction f2)
        {
            double val1 = (float)f1.numerator / f1.denominator;
            double val2 = (float)f2.numerator / f2.denominator;
            double total = val1 - val2;
            Fraction temp = new Fraction();
            temp.setValue(total);
            return temp;
        }
        public static Fraction operator -(Fraction f1, double val)
        {
            double val1 = (float)f1.numerator / f1.denominator;
            double val2 = val;
            double total = val1 - val2;
            Fraction temp = new Fraction();
            temp.setValue(total);
            return temp;
        }
        public static Fraction operator -(double val, Fraction f1)
        {
            double val1 = val;
            double val2 = (float)f1.numerator / f1.denominator;
            double total = val1 - val2;
            Fraction temp = new Fraction();
            temp.setValue(total);
            return temp;
        }
        public static Fraction operator /(Fraction f1, Fraction f2)
        {
            double val1 = (float)f1.numerator / f1.denominator;
            double val2 = (float)f2.numerator / f2.denominator;
            double total = val1 / val2;
            Fraction temp = new Fraction();
            temp.setValue(total);
            return temp;
        }
        public static Fraction operator /(Fraction f1, double val)
        {
            double val1 = (float)f1.numerator / f1.denominator;
            double val2 = val;
            double total = val1 / val2;
            Fraction temp = new Fraction();
            temp.setValue(total);
            return temp;
        }
        public static Fraction operator /(double val, Fraction f1)
        {
            double val1 = val;
            double val2 = (float)f1.numerator / f1.denominator;
            double total = val1 / val2;
            Fraction temp = new Fraction();
            temp.setValue(total);
            return temp;
        }
        public static Fraction operator *(Fraction f1, Fraction f2)
        {
            double val1 = (float)f1.numerator / f1.denominator;
            double val2 = (float)f2.numerator / f2.denominator;
            double total = val1 * val2;
            Fraction temp = new Fraction();
            temp.setValue(total);
            return temp;
        }
        public static Fraction operator *(Fraction f1, double val)
        {
            double val1 = (float)f1.numerator / f1.denominator;
            double val2 = val;
            double total = val1 * val2;
            Fraction temp = new Fraction();
            temp.setValue(total);
            return temp;
        }
        public static Fraction operator *(double val, Fraction f1)
        {
            double val1 = val;
            double val2 = (float)f1.numerator / f1.denominator;
            double total = val1 * val2;
            Fraction temp = new Fraction();
            temp.setValue(total);
            return temp;
        }
        public override bool Equals(object obj)
        {
            return true;
        }
        public override int GetHashCode()
        {
            return 1;
        }
        public static bool operator ==(Fraction f1, Fraction f2)
        {
            return f1.getFloatingResult() == f2.getFloatingResult();
        }
        public static bool operator !=(Fraction f1, Fraction f2)
        {
            return f1.getFloatingResult() != f2.getFloatingResult();
        }
        public static bool operator <=(Fraction f1, Fraction f2)
        {
            return f1.getFloatingResult() <= f2.getFloatingResult();
        }
        public static bool operator >=(Fraction f1, Fraction f2)
        {
            return f1.getFloatingResult() >= f2.getFloatingResult();
        }
        public static bool operator <(Fraction f1, Fraction f2)
        {
            return f1.getFloatingResult() < f2.getFloatingResult();
        }
        public static bool operator >(Fraction f1, Fraction f2)
        {
            return f1.getFloatingResult() > f2.getFloatingResult();
        }


        public override string ToString()
        {
            return result;
        }
    }
    
}
