using System;
using System.Drawing;
using System.IO;

namespace BitmapToIcon
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("bti -o<output> <input>");
                Console.WriteLine("<ouput> = *.ico");
                Console.WriteLine("<input> = *.bmp;*.jpg;*.jpeg;*.png");
            }
            else if (args.Length == 2)
            {
                string input = args[0].StartsWith("-o") ? args[1] : args[0];
                string output = args[0].StartsWith("-o") ? args[0].Substring(2) : args[1].Substring(2);

                Console.WriteLine("Input:  <{0}>", input);
                Console.WriteLine("Output: <{0}>", output);

                if (!File.Exists(input))
                {
                    Console.WriteLine("\nDie Datei <{0}> existiert nicht!\n", input);

                    return;
                }

                if (!Directory.Exists(Path.GetPathRoot(output)))
                {
                    Console.WriteLine("\nDas Verzeichnis <{0}> existiert nicht!\n", Path.GetPathRoot(output));
                }

                Bitmap bitmap = null;
                Icon icon = null;
                try
                {
                    bitmap = new Bitmap(Image.FromFile(input));

                    IntPtr hicon = bitmap.GetHicon();
                    icon = Icon.FromHandle(hicon);

                    using (FileStream fs = new FileStream(output, FileMode.Create))
                    {
                        icon.Save(fs);
                    }
                }
                catch (OutOfMemoryException)
                {
                    Console.WriteLine("\nNicht genügend Speicher für diesen Vorgang vorhanden!\n");
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("\nDiese Datei ist für den Vorgang ungültig!\n");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\n{0}:\n\n{1}", ex.StackTrace, ex.Message);
                }
                finally
                {
                    if (bitmap != null)
                        bitmap.Dispose();

                    if (icon != null)
                        icon.Dispose();
                }
            }
            else
            {
                Console.WriteLine("Ungültige Anzahl an Argumenten");
            }
        }
    }
}
