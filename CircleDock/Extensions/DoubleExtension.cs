using System;

namespace CircleDock.Extensions
{
    static class DoubleExtension
    {
        public static double ToRadians(this double value) => value * Math.PI / 180d;
    }
}
