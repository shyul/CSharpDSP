using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shyu.Core;

namespace Shyu.DSP
{
    public class FFT
    {
        public Complex[] Result;
        public Complex[] Wn;
        public int Length;

        public WindowFunction Win;
        public double[] WinF;

        public double[] Abs()
        {
            double[] abs = new double[Length];
            for (int i = 0; i < Result.Length; i++)
                abs[i] = Result[i].Abs() / Length;
            return abs;
        }

        public double[] LogAbs()
        {
            double[] abs = new double[Length];
            for (int i = 0; i < Result.Length; i++)
                abs[i] = 10 * Math.Log10(Result[i].Abs2());
            return abs;
        }

        public void Init(int Length, WindowFunction func)
        {
            if (Length < 4) throw new ArgumentException();
            this.Length = Length;
            int n = Length / 2;
            double ang = 2 * Math.PI / Length;
            Complex w = new Complex(Math.Cos(ang), -Math.Sin(ang));
            Wn = new Complex[Length];
            Result = new Complex[Length];
            Wn[0] = new Complex(1D, 0D);
            for (int i = 1; i < n; i++) Wn[i] = Wn[i - 1] * w;
            Win = func;
            if (Win != null) WinF = Win.GetWindow(Length);
        }

        public void Transform(double[] Input)
        {
            if (Input.Length != Length) throw new ArgumentException();
            Complex[] Tmp = new Complex[Length];
            for (int i = 0; i < Input.Length; i++)
            {
                Tmp[i] = new Complex(Input[i]);
            }
            Transform(Tmp);
        }

        public void Transform(Complex[] Input)
        {
            if (Input.Length != Length) throw new ArgumentException();
            for (int i = 0; i < Length; i++)
            {
                Input[i] = Input[i] * WinF[i];
            }
            int LengthBy2 = Length / 2;
            int LengthBy4 = LengthBy2 / 2;
            int m = 0;
            int w = 1;
            while (LengthBy2 >= 1)
            {
                int d = 0;
                for (int i = 0; i < w; i++)
                {
                    d = Length / w;
                    for (int j = 0; j < LengthBy2; j++)
                    {
                        Complex TmpA = Input[i * d + j] + Input[i * d + LengthBy2 + j];
                        Complex TmpB = (Input[i * d + j] - Input[i * d + LengthBy2 + j]) * Wn[w * j];
                        Input[i * d + j] = TmpA;
                        Input[i * d + LengthBy2 + j] = TmpB;
                    }
                }
                LengthBy2 /= 2;
                LengthBy4 = LengthBy2 / 2;
                m += 1;
                w *= 2;
            }
            for (UInt32 i = 0; i < Input.Length; i++)
            {
                Result[i] = Input[uConv.BinaryReverse(i, m)];
            }
        }
    }
}
