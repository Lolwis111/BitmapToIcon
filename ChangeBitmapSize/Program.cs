using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ChangeBitmapSize
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("cbs -o<output> <input> -x<width> -y<height>");
                Console.WriteLine("<input>  = *.jpg;*.jpeg;*.bmp;*.png");
                Console.WriteLine("<output> = *.jpg;*.jpeg;*.bmp;*.png");
                Console.WriteLine("<width>  = Ganzzahl (z.B. 800)");
                Console.WriteLine("<height> = Ganzzahl (z.B. 600)");
            }
            else if (args.Length == 4)
            {
                foreach (string arg in args)
                {
                    
                }
            }
            else
            {
                Console.WriteLine("Ungültige Anzahl von Argumenten!");
            }
        }
    }
}
