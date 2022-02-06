using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessApp.src.Utilities
{
    internal class Utility
    {
        public static bool random(int percentage)
        {

            Random rand = new Random();

            int value = 100 / percentage;

            int n = rand.Next(0, value);

            return (n == 0);
        }


    }
}
