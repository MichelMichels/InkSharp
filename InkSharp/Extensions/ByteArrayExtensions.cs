using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
