
using System.Text;
using System.Text.RegularExpressions;

namespace Cesarcode {
    class CesarCode
    {
        static void Main(string[] args)
        {
            var regex = new Regex("^[a-zA-Z ]*%");
            string text = "";
            while (true)
            {
                Console.WriteLine("Podaj tekst do zaszyfrowania: ");
                text = Console.ReadLine();
                if (string.IsNullOrEmpty(text))
                {
                    Console.WriteLine("Podaj poprawny tekst!!");
                    continue;
                }
                else if ((regex.IsMatch(text)))
                {
                    Console.WriteLine("Podaj poprawny tekst!!!");
                    continue;
                }

                break;
            }

            Console.WriteLine("Podaj o ile przesunąć znak: ");
            byte shift;
            while (!byte.TryParse(Console.ReadLine(), out shift))
            {
                Console.WriteLine("Podaj liczbe!");
            }


            Console.WriteLine(shiftFunction(text, shift));

        }

        public static string shiftFunction(string text, byte valueOfShift)
        {
            text = text.ToLower();
            byte[] arrayOfText = Encoding.ASCII.GetBytes(text);

            for (int i = 0; i < arrayOfText.Length; i++)
            {
                int s = arrayOfText[i] + valueOfShift;

                if (s < 96 || s > 123)
                {
                    s = s - 26;
                    
                }
                arrayOfText[i] = (byte)s;
            }

            return Encoding.ASCII.GetString(arrayOfText);
        }
    }
}