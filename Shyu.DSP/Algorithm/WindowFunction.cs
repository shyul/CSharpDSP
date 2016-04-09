using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shyu.DSP
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class WindowFunctionType : Attribute { }

    public class WindowFunction
    {
        public virtual double[] GetWindow(int N)
        {
            double[] data = new double[N];
            for (int i = 0; i < N; i++)
                data[i] = 1;
            return data;
        }

        public virtual double[] Calibrate(int N)
        {
            double[] data = new double[N];

            return data;
        }
    }
    [WindowFunctionType]
    public class FlatTop : WindowFunction
    {
        public const string Name = "FlatTop";
        public override double[] GetWindow(int N)
        {
            double[] data = new double[N];
            double a0 = Math.PI * 2 / (N - 1);
            double a1 = 2 * a0;
            double a2 = 3 * a0;
            double a3 = 4 * a0;
            for (int i = 0; i < N; i++)
                data[i] = 1
                    - 1.93 * Math.Cos(i * a0)
                    + 1.29 * Math.Cos(i * a1)
                    - 0.388 * Math.Cos(i * a2)
                    + 0.032 * Math.Cos(i * a3);
            return data;
        }
    }
    [WindowFunctionType]
    public class BlackmanHarris : WindowFunction
    {
        public const string Name = "Blackman Harris";
        public override double[] GetWindow(int N)
        {
            double[] data = new double[N];
            double a0 = Math.PI * 2 / (N - 1);
            double a1 = 2 * a0;
            double a2 = 3 * a0;
            for (int i = 0; i < N; i++)
            {
                data[i] = 0.35875
                    - 0.48829 * Math.Cos(a0 * i)
                    + 0.14128 * Math.Cos(a1 * i)
                    - 0.01168 * Math.Cos(a2 * i);
            }
            return data;
        }
    }
    [WindowFunctionType]
    public class BlackmanNuttall : WindowFunction
    {
        public const string Name = "Blackman Nuttall";
        public override double[] GetWindow(int N)
        {
            double[] data = new double[N];
            double a0 = Math.PI * 2 / (N - 1);
            double a1 = 2 * a0;
            double a2 = 3 * a0;
            for (int i = 0; i < N; i++)
            {
                data[i] = 0.3635819
                    - 0.4891775 * Math.Cos(a0 * i)
                    + 0.1365995 * Math.Cos(a1 * i)
                    - 0.0106411 * Math.Cos(a2 * i);
            }
            return data;
        }
    }
    [WindowFunctionType]
    public class Blackman : WindowFunction
    {
        public const string Name = "Blackman";
        public override double[] GetWindow(int N)
        {
            double[] data = new double[N];
            double a0 = Math.PI * 2 / (N - 1);
            double a1 = 2 * a0;
            for (int i = 0; i < N; i++)
            {
                data[i] = 0.42 - 0.5 * Math.Cos(a0 * i) + 0.08 * Math.Cos(a1 * i);
            }
            return data;
        }
    }
    [WindowFunctionType]
    public class Nuttall : WindowFunction
    {
        public const string Name = "Nuttall";
        public override double[] GetWindow(int N)
        {
            double[] data = new double[N];
            double a0 = Math.PI * 2 / (N - 1);
            double a1 = 2 * a0;
            double a2 = 3 * a0;
            for (int i = 0; i < N; i++)
            {
                data[i] = 0.355768
                    - 0.487396 * Math.Cos(a0 * i)
                    + 0.144232 * Math.Cos(a1 * i)
                    - 0.012604 * Math.Cos(a2 * i);
            }
            return data;
        }
    }
    [WindowFunctionType]
    public class Hamming : WindowFunction
    {
        public const string Name = "Hamming";
        public override double[] GetWindow(int N)
        {
            double[] data = new double[N];
            double a = Math.PI * 2 / (N - 1);
            for (int i = 0; i < N; i++)
                data[i] = 0.53836 - 0.46164 * Math.Cos(i * a);
            return data;
        }
    }
    [WindowFunctionType]
    public class Hanning : WindowFunction
    {
        public const string Name = "Hanning";
        public override double[] GetWindow(int N)
        {
            double[] data = new double[N];
            double a = Math.PI * 2 / (N - 1);
            for (int i = 0; i < N; i++)
                data[i] = 0.5 - 0.5 * Math.Cos(i * a);
            return data;
        }
    }
    [WindowFunctionType]
    public class Triangle : WindowFunction
    {
        public const string Name = "Triangle";
        public override double[] GetWindow(int N)
        {
            double[] data = new double[N];
            double N1 = N + 1;
            for (int i = 0; i < N; i++)
                data[i] = 1D - Math.Abs((2 * i - N1)) / N;
            return data;
        }
    }
    [WindowFunctionType]
    public class Rectangle : WindowFunction
    {
        public const string Name = "Rectangle";
        public override double[] GetWindow(int N)
        {
            double[] data = new double[N];
            for (int i = 0; i < N; i++)
                data[i] = 1;
            return data;
        }
    }
}
