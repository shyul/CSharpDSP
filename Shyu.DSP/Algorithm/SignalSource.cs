using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Data;

namespace Shyu.DSP
{
    public static class SignalSource
    {
        public static double[] SineWave(int N, double Cycle)
        {
            double[] data = new double[N];
            double ang = Math.PI * 2 / (N - 1);
            for (int i = 0; i < N; i++)
                data[i] = Math.Sin(i * ang * Cycle);
            return data;
        }

    }
}
