using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shyu.Core;

namespace Shyu.DSP
{
    public class Complex
    {
        public double real;
        public double imag;

        public Complex()
        {
            real = 0;
            imag = 0;
        }
        public Complex(double real)
        {
            this.real = real;
            this.imag = 0;
        }
        public Complex(double real, double imag)
        {
            this.real = real;
            this.imag = imag;
        }

        #region / + - * /
        public static Complex operator +(Complex c1, Complex c2)
        {
            return new Complex(c1.real + c2.real, c1.imag + c2.imag);
        }

        public static Complex operator +(int a, Complex c1)
        {
            return new Complex(c1.real + a, c1.imag);
        }

        public static Complex operator +(double a, Complex c1)
        {
            return new Complex(c1.real + a, c1.imag);
        }

        public static Complex operator -(Complex c1, Complex c2)
        {
            return new Complex(c1.real - c2.real, c1.imag - c2.imag);
        }

        public static Complex operator -(int a, Complex c1)
        {
            return new Complex(-c1.real + a, c1.imag);
        }

        public static Complex operator -(double a, Complex c1)
        {
            return new Complex(-c1.real + a, c1.imag);
        }

        public static Complex operator -(Complex c1, double a)
        {
            return new Complex(c1.real - a, c1.imag);
        }

        public static Complex operator *(Complex c1, Complex c2)
        {
            return new Complex(c1.real * c2.real - c1.imag * c2.imag, c1.imag * c2.real + c1.real * c2.imag);
        }

        public static Complex operator *(int a, Complex c1)
        {
            return new Complex(a * c1.real, a * c1.imag);
        }

        public static Complex operator *(Complex c1, int a)
        {
            return new Complex(a * c1.real, a * c1.imag);
        }

        public static Complex operator *(double a, Complex c1)
        {
            return new Complex(a * c1.real, a * c1.imag);
        }

        public static Complex operator *(Complex c1, double a)
        {
            return new Complex(a * c1.real, a * c1.imag);
        }

        public static Complex operator /(Complex c1, double a)
        {
            return new Complex(c1.real / a, c1.imag / a);
        }

        public Complex Pow(int n)
        {
            Complex res = new Complex(this.real, this.imag);
            while (n > 1)
            {
                res *= this;
                n--;
            }
            return res;
        }

        public double Abs2()
        {
            return real * real + imag * imag;
        }

        public double Abs()
        {
            return Math.Sqrt(Abs2());
        }

        public Complex Conjugate()
        {
            return new Complex(real, -imag);
        }
        #endregion

        public override string ToString()
        {
            return imag > 0 ?
                real.ToString() + " + j" + imag.ToString() :
                real.ToString() + " - j" + (-imag).ToString();
        }

        public string ToString(string format)
        {
            return imag > 0 ?
                real.ToString(format) + " + j" + imag.ToString(format) :
                real.ToString(format) + " - j" + (-imag).ToString(format);
        }

    }
}
