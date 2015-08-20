using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddWithoutArithmeticOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            //// Console.WriteLine(Add(1, 2)); // 1 - 1, 1 - 10
            // Console.WriteLine(Add(8, 6)); // 8 - 1000, 6 - 0110

            Console.WriteLine(Add(12, 6)); // 12 - 1100, 6 - 0110

            Console.WriteLine(CountBits(4096));

            Console.WriteLine(8 << 1); /// 0000 1000 ---> 0001 0000
            Console.ReadKey();
        }

        static int Add(int x, int y)
        {
            // Iterate till there is no carry  
            while (y != 0)
            {
                // AND - carry now contains common set bits of x and y
                int carry = x & y;

                // XOR - Sum of bits of x and y where one of the bits is one
                x = x ^ y;

                // Carry is shifted by one so that adding it to x gives the required sum
                y = carry << 1;
            }
            return x;
        }

        public static int CountBits(ulong v)
        {
            unchecked
            {
                const ulong MASK_01010101010101010101010101010101 = 0x5555555555555555UL;
                const ulong MASK_00110011001100110011001100110011 = 0x3333333333333333UL;
                const ulong MASK_00001111000011110000111100001111 = 0x0F0F0F0F0F0F0F0FUL;
                const ulong MASK_00000000111111110000000011111111 = 0x00FF00FF00FF00FFUL;
                const ulong MASK_00000000000000001111111111111111 = 0x0000FFFF0000FFFFUL;
                const ulong MASK_11111111111111111111111111111111 = 0x00000000FFFFFFFFUL;
                v = (v & MASK_01010101010101010101010101010101) + ((v >> 1) & MASK_01010101010101010101010101010101);
                v = (v & MASK_00110011001100110011001100110011) + ((v >> 2) & MASK_00110011001100110011001100110011);
                v = (v & MASK_00001111000011110000111100001111) + ((v >> 4) & MASK_00001111000011110000111100001111);
                v = (v & MASK_00000000111111110000000011111111) + ((v >> 8) & MASK_00000000111111110000000011111111);
                v = (v & MASK_00000000000000001111111111111111) + ((v >> 16) & MASK_00000000000000001111111111111111);
                v = (v & MASK_11111111111111111111111111111111) + ((v >> 32) & MASK_11111111111111111111111111111111);
                return (int)v;
            }
        }
    }
}
