using System;
using System.Text;
using System.IO;
using System.Linq;

namespace frequencanalysisV3
{
    class Program
    {
        static void Main(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            string pathTableCp866 = @"d:\newProject\newProject\text\tableCp866.txt";
            string tableCp866 = ReadТNormalTextFromFile(pathTableCp866);
            byte[] bytesCp866 = Encoding.GetEncoding(866).GetBytes(tableCp866);


            for (int i = 0; i < bytesCp866.Length; i++)
            {
                //     Console.WriteLine(bytesCp866[i]);
            }


            string pathText = @"d:\newProject\newProject\text\win1251-cp866.txt";
            string textInCp866 = ReadТNormalTextFromFile(pathText);
            string textCp866Low = textInCp866.ToLower();
            Console.Write(textCp866Low);
            Console.WriteLine();
            byte[] bytesText = Encoding.GetEncoding(866).GetBytes(textCp866Low);

            for (int i = 0; i < bytesText.Length; i++)
            {
                    Console.Write(bytesText[i] + " ");
            }



            EncodingCharacterFrequency[] encodingArray = CountOfCharactersInNormalText(bytesCp866, bytesText);
            UkrСharacterFrequency[] ukrArray = UkrСharactersFrequency();



            for (int i = 0; i < encodingArray.Length; i++)
            {
            Console.WriteLine(encodingArray[i]);
            }

            string resText = GenereteTextResult(bytesText,  encodingArray, ukrArray);
          Console.WriteLine(resText);
        }
        public static string ReadТNormalTextFromFile(string pathForNormalText)
        {
            string[] readText = File.ReadAllLines(pathForNormalText, Encoding.GetEncoding(866));
            string text = "";
            for (int i = 0; i < readText.Length; i++)
            {
                text = text + readText[i];
            }
            return text;
        }

        public static EncodingCharacterFrequency[] CountOfCharactersInNormalText(byte[] bytesCp866, byte[] bytesText)
        {
            Encoding cp866 = Encoding.GetEncoding(866);
            int p = 0;

            EncodingCharacterFrequency[] array = new EncodingCharacterFrequency[bytesCp866.Length];
            char[] Cp866CharsText = new char[cp866.GetCharCount(bytesText, 0, bytesText.Length)];
            cp866.GetChars(bytesText, 0, bytesText.Length, Cp866CharsText, 0);

            int count2 = 0;

            for (int i = 0; i < bytesText.Length; i++)
            {
                if (char.IsLetter(Cp866CharsText[i]))
                {
                    count2++;
                }
            }

            int g = 0;
            foreach (byte c in bytesCp866)
            {
                int count1 = 0;
                foreach (byte s in bytesText)
                {
                    if (s == c)
                    {
                        count1++;
                    }
                }
                double Freq = ((double)count1 / (double)count2);
                Freq = (Math.Round(Freq, 4, MidpointRounding.AwayFromZero));
                array[g] = new EncodingCharacterFrequency(c, Freq);
                g++;

                //   Console.WriteLine("{0}  {1}  [2]", Freq, c, Cp866CharsText[g]);
            }

            return array;

        }


        public static UkrСharacterFrequency[] UkrСharactersFrequency()
        {
            UkrСharacterFrequency[] array = new UkrСharacterFrequency[32];

            UkrСharacterFrequency item = new UkrСharacterFrequency("a", 0.0709);
            array[0] = item;
            item = new UkrСharacterFrequency("б", 0.0136);
            array[1] = item;
            item = new UkrСharacterFrequency("в", 0.0533);
            array[2] = item;
            item = new UkrСharacterFrequency("г", 0.0142);
            array[3] = item;
            item = new UkrСharacterFrequency("д", 0.0350);
            array[4] = item;
            item = new UkrСharacterFrequency("е", 0.0458);
            array[5] = item;
            item = new UkrСharacterFrequency("ж", 0.0066);
            array[6] = item;
            item = new UkrСharacterFrequency("з", 0.0238);
            array[7] = item;
            item = new UkrСharacterFrequency("и", 0.0613);
            array[8] = item;
            item = new UkrСharacterFrequency("й", 0.0114);
            array[9] = item;
            item = new UkrСharacterFrequency("к", 0.0358);
            array[10] = item;
            item = new UkrСharacterFrequency("л", 0.0305);
            array[11] = item;
            item = new UkrСharacterFrequency("м", 0.0283);
            array[12] = item;
            item = new UkrСharacterFrequency("н", 0.0836);
            array[13] = item;
            item = new UkrСharacterFrequency("о", 0.0950);
            array[14] = item;
            item = new UkrСharacterFrequency("п", 0.0304);
            array[15] = item;
            item = new UkrСharacterFrequency("р", 0.0499);
            array[16] = item;
            item = new UkrСharacterFrequency("с", 0.0406);
            array[17] = item;
            item = new UkrСharacterFrequency("т", 0.0546);
            array[18] = item;
            item = new UkrСharacterFrequency("у", 0.0321);
            array[19] = item;
            item = new UkrСharacterFrequency("ф", 0.0061);
            array[20] = item;
            item = new UkrСharacterFrequency("х", 0.0129);
            array[21] = item;
            item = new UkrСharacterFrequency("ц", 0.0108);
            array[22] = item;
            item = new UkrСharacterFrequency("ч", 0.0136);
            array[23] = item;
            item = new UkrСharacterFrequency("ш", 0.0060);
            array[24] = item;
            item = new UkrСharacterFrequency("щ", 0.0040);
            array[25] = item;
            item = new UkrСharacterFrequency("і", 0.0628);
            array[26] = item;
            item = new UkrСharacterFrequency("ї", 0.0111);
            array[27] = item;
            item = new UkrСharacterFrequency("ь", 0.01671);
            array[28] = item;
            item = new UkrСharacterFrequency("є", 0.0081);
            array[29] = item;
            item = new UkrСharacterFrequency("ю", 0.0082);
            array[30] = item;
            item = new UkrСharacterFrequency("я", 0.0268);
            array[31] = item;
            return array;
        }


        public static string GenereteTextResult(byte[] bytesText, EncodingCharacterFrequency[] encodingArray, UkrСharacterFrequency[] ukrArray)
        {
            string text = "";
            byte prob = 32;
            byte koma = 44;
            byte tochka = 46;

            foreach (byte b in bytesText)
            {
                for (int i = 0; i < encodingArray.Length; i++)
                {
                    if (b == encodingArray[i].character)
                    {
                        if (encodingArray[i].character == prob)
                        {
                            text = text + " ";
                            break;
                        }
                        if (encodingArray[i].character == koma)
                        {
                            text = text + ",";
                            break;
                        }
                        if (encodingArray[i].character == tochka)
                        {
                            text = text + ".";
                            break;
                        }
                        for (int g = 0; g < ukrArray.Length; g++)
                        {
                            if (Math.Abs(ukrArray[g].appearance - encodingArray[i].appearance) < 0.01)       //    encodingArray[i].appearance == () )
                            {
                                text = text + ukrArray[g].character;
                                break;
                            }

                        }
                    }
                }
            }

            return text;
        }
    }
}

    struct EncodingCharacterFrequency
    {
        public byte character;
        public double appearance;


        public EncodingCharacterFrequency(byte character, double appearance)
        {
            this.character = character;
            this.appearance = appearance;
        }

        public override string ToString()
        {
            return String.Format("{0}-{1}", this.character, this.appearance);
        }
    }

    struct UkrСharacterFrequency
    {
        public string character;
        public double appearance;
        public UkrСharacterFrequency(string character, double appearance)
        {
            this.character = character;
            this.appearance = appearance;
        }

        public override string ToString()
        {
            return String.Format("{0}-{1}", this.character, this.appearance);
        }
    }

