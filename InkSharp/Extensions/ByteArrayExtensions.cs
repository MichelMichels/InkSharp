using System;

namespace InkSharp.Extensions
{
    internal static class ByteArrayExtensions
    {
        public static string ToPrettyString(this byte[] array)
        {
            return BitConverter.ToString(array).Replace("-", " ");
        }
    }
}
