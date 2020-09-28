using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObligatorioDDA2.Models.Entidades
{
    public static class CodigoRandom
    {
        private static readonly Random _random = new Random();

        public static string GetCodigoRandom(int size)
        {
            var builder = new StringBuilder(size);

            char offset = 'a'; 
            const int lettersOffset = 26; // largo=26  

            for (var i = 0; i < size; i++)
            {
                var @char = (char)_random.Next(offset, offset + lettersOffset);
                builder.Append(@char);
            }

            return builder.ToString();
        }

    }
}
