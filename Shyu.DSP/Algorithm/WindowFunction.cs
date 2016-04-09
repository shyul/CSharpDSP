using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shyu.DSP
{
    public static class WindowFunction
    {
        public static double[] FlatTop(int N)
        {
            double[] data = new double[N];
            double a = Math.PI * 2 / (N - 1);
            double b = 2 * a;
            double c = 3 * a;
            double d = 4 * a;
            for (int i = 0; i < N; i++)
                data[i] = 1
                    - 1.93 * Math.Cos(i * a)
                    + 1.29 * Math.Cos(i * b)
                    - 0.388 * Math.Cos(i * c)
                    + 0.032 * Math.Cos(i * d);
            return data;
        }

        public static double[] BlackmanHarris(int N)
        {
            double[] data = new double[N];
            double a = Math.PI * 2 / (N - 1);
            double b = 2 * a;
            double c = 3 * a;
            for (int i = 0; i < N; i++)
            {
                data[i] = 0.35875
                    - 0.48829 * Math.Cos(a * i)
                    + 0.14128 * Math.Cos(b * i)
                    - 0.01168 * Math.Cos(c * i);
            }
            return data;
        }

        public static double[] BlackmanNuttall(int N)
        {
            double[] data = new double[N];
            double a = Math.PI * 2 / (N - 1);
            double b = 2 * a;
            double c = 3 * a;
            for (int i = 0; i < N; i++)
            {
                data[i] = 0.3635819
                    - 0.4891775 * Math.Cos(a * i)
                    + 0.1365995 * Math.Cos(b * i)
                    - 0.0106411 * Math.Cos(c * i);
            }
            return data;
        }

        public static double[] Blackman(int N)
        {
            double[] data = new double[N];
            double a = Math.PI * 2 / (N - 1);
            double b = 2 * a;
            for (int i = 0; i < N; i++)
            {
                data[i] = 0.42 - 0.5 * Math.Cos(a * i) + 0.08 * Math.Cos(b * i);
            }
            return data;
        }

        public static double[] Nuttall(int N)
        {
            double[] data = new double[N];
            double a = Math.PI * 2 / (N - 1);
            double b = 2 * a;
            double c = 3 * a;
            for (int i = 0; i < N; i++)
            {
                data[i] = 0.355768
                    - 0.487396 * Math.Cos(a * i)
                    + 0.144232 * Math.Cos(b * i)
                    - 0.012604 * Math.Cos(c * i);
            }
            return data;
        }

        public static double[] Hamming(int N)
        {
            double[] data = new double[N];
            double a = Math.PI * 2 / (N - 1);
            for (int i = 0; i < N; i++)
                data[i] = 0.53836 - 0.46164 * Math.Cos(i * a);
            return data;
        }

        public static double[] Hanning(int N)
        {
            double[] data = new double[N];
            double a = Math.PI * 2 / (N - 1);
            for (int i = 0; i < N; i++)
                data[i] = 0.5 - 0.5 * Math.Cos(i * a);
            return data;
        }

        public static double[] Triangle(int N)
        {
            double[] data = new double[N];
            double N1 = N + 1;
            for (int i = 0; i < N; i++)
                data[i] = 1D - Math.Abs((2 * i - N1)) / N;
            return data;
        }

        public static double[] Rectangle(int N)
        {
            double[] data = new double[N];
            for (int i = 0; i < N; i++)
                data[i] = 1;
            return data;
        }
    }
}
