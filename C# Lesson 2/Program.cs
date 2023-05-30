
using System.Text;

namespace C__Lesson_2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //  ------------------ Task 1 --------------------

            //string toReverse = "This string must be reversed!";

            //Console.WriteLine(ReverseString(toReverse));

            //  -----------------------------------------------


            //  ------------------ Task 2 --------------------

            //Console.Write("Please input any number: ");
            //int startNumber = int.Parse(Console.ReadLine());
            //MethodSyrakuz(startNumber);

            //  -----------------------------------------------


            //  ------------------ Task 3 --------------------

            //string someText = "Это был ПиДр невероятно Сука хороший день";

            //Console.WriteLine(BadWordsFilter(someText));

            //  -----------------------------------------------


            //  ------------------ Task 4 --------------------

            //Console.Write("Please input how many symbols do you want: ");
            //int numberOfChars = int.Parse(Console.ReadLine());
            //char[] chars = CharsGenerator(numberOfChars);
            //foreach (char c in chars)
            //{
            //    Console.WriteLine(c);
            //}

            //  -----------------------------------------------


            //  ------------------ Task 5 --------------------

            //int[] ints = { 3, 6, 2, 5, 1, 0, };
            //Console.WriteLine($"Number {Hole(ints)} is`t exist");

            //  -----------------------------------------------


            //  ------------------ Task 7 --------------------

            //Console.WriteLine("Please write nucloid chain ( A, C, G, T )");
            //string nucloid = Console.ReadLine();

            //byte[] bytes = NucloidCompressing(nucloid);

            //Console.WriteLine(NucloidDecompressing(bytes));

            //  -----------------------------------------------


            //  ------------------ Task 8 --------------------

            //string textToEncrypt = "This text must be encrypted and Decripted";
            //Console.WriteLine(textToEncrypt);

            //Encryption(ref textToEncrypt);
            //Console.WriteLine("Encrypted text");
            //Console.WriteLine(textToEncrypt);

            //Decryption(ref textToEncrypt);
            //Console.WriteLine("Decrypted text");
            //Console.WriteLine(textToEncrypt);

            //  -----------------------------------------------
        }





        //  Task 1

        private static string ReverseString(string toReverse)
        {

            //  Проще всего для реверса

            return new string(toReverse.Reverse().ToArray());

            //  Если чарами то тогда можно сделать void метод и в обратном порядке всё распечатать
            
            /*
            char[] chars = toReverse.ToCharArray();
            char temp;
            int charIndexToChange = chars.Length - 1;

            for (int i = 0; i < charIndexToChange; i++)
            {
                temp = chars[i];
                chars[i] = chars[charIndexToChange];
                chars[charIndexToChange] = temp;
                charIndexToChange--;
            }
            foreach (char c in chars)
            {
                Console.Write(c);
            }
            */
        }


        //  Task 2

        private static void MethodSyrakuz(int getNumber)
        {

            if (getNumber == 1)
            {
                Console.WriteLine(getNumber);
                return;
            }

            getNumber = getNumber % 2 == 0 ? getNumber / 2 : (getNumber * 3 + 1) / 2;
            
            Console.WriteLine(getNumber);
            MethodSyrakuz(getNumber);

        }
        
        //  Task 3
        private static string BadWordsFilter(string textToFilter)
        {
            string[] bedWords = new string[] { "Блять", "Сука", "Пидр", "Пидор", "Мразь", "Ублюдок", "Охуеть"};

            string[] wordsToFilter = textToFilter.Split(' ');

            StringBuilder newText = new StringBuilder();
            
            for(int i = 0; i < wordsToFilter.Length; i++)
            {
                foreach (string bedWord in bedWords)
                {
                    if (wordsToFilter[i].ToLower() == bedWord.ToLower())
                    {
                        wordsToFilter[i] = "*****";
                    }
                }
                newText.Append(wordsToFilter[i] + " ".ToString());
            }
            return newText.ToString();

        }

        //  Task 4
        private static char[] CharsGenerator(int numberOfChars)
        {
            Random random = new Random();
            char newChar;
            char[] randomChars = new char[numberOfChars];
            for (int i = 0; i < numberOfChars; i++)
            {
                newChar = (char)random.Next(033,190);
                randomChars[i] = newChar;
            }
            return randomChars;
        }

        //  Task 5
        private static int Hole(int[] ints)
        {

            try
            {

                for (int i = 0;i < ints.Length;i++)
                {
                    if (!ints.Any((x) => x == i))
                        return i;
                }
                throw new Exception("All numbers are in array ");
            
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return 0;
            }            

        }


        //  Task 7
        private static byte[] NucloidCompressing(string nucloidToCompress)
        {
            List<byte> bytes = new List<byte>();
            byte compressToByte = 0b0000_0000;
            
            char[] charsToCompress = nucloidToCompress.ToCharArray();
            byte numberOfNucloid = (byte)charsToCompress.Length;
            Dictionary<char, byte> dict = new Dictionary<char, byte>()
            {
                { 'A', 0b0000_0000 },
                { 'C', 0b0000_0001 },
                { 'G', 0b0000_0010 },
                { 'T', 0b0000_0011 }
            };
            int pushToList = 0;
            for (int i = 0; i < charsToCompress.Length; i++)
            {
                compressToByte |= dict[charsToCompress[i]];
                if ( pushToList < 3 && i+1 < charsToCompress.Length)
                    compressToByte <<= 2;
                if ( pushToList++ == 3 )
                {
                    bytes.Add(compressToByte);
                    pushToList = 0;
                    compressToByte = 0b0000_0000;
                }
            }
            if (pushToList != 0)
                bytes.Add(compressToByte);
            bytes.Add(numberOfNucloid);

            return bytes.ToArray();
        }
        private static string NucloidDecompressing(byte[] nucloidArrayToDecompress)
        {
            int nucloidValueInBytes;
            int numberOfNucloids = nucloidArrayToDecompress[^1];
            
            StringBuilder resultOfDecompresing = new StringBuilder();

            Dictionary <byte, char> dict = new Dictionary<byte, char>()
            {
                {  0b0000_0000, 'A'},
                {  0b0000_0001, 'C'},
                {  0b0000_0010, 'G'},
                {  0b0000_0011, 'T'}
            };


            for (int i = 0; i < nucloidArrayToDecompress.Length; i++)
            {
                if (numberOfNucloids == 0)
                    break;

                byte byteToDecompress = nucloidArrayToDecompress[i];
                char[] chars = new char[4];
                
                for (int j = 3; j > -1; j--)
                {
                    if ( numberOfNucloids == 0 )
                        break;
                    nucloidValueInBytes = byteToDecompress & 0b0000_0011;
                    byteToDecompress >>= 2;

                    foreach (byte c in dict.Keys)
                    {
                        if (c == nucloidValueInBytes)
                        {
                            chars[j] = dict[c];                            
                            numberOfNucloids--;
                            break;
                        }
                    }

                }
                resultOfDecompresing.Append(chars.ToArray());

            }

            return resultOfDecompresing.ToString();
        }


        //  Task 8

        private static void Encryption(ref string toEncrypt)
        {
            StringBuilder encryptText = new StringBuilder();
            Random random = new Random();

            char ch = '"';

            Dictionary<int,char> keyValuePairs = new Dictionary<int, char>() 
            {
                { 1 , '#' },
                { 2 , 'G' },
                { 3 , 'S' },
                { 4 , 'H' },
                { 5 , '"' },
                { 6 , ' ' },
                { 7 , '!' },
                { 8 , 'D' },
                { 9 , '/' },
                { 10 , 'U' },
            };

            Dictionary<int,string> encrypt = new Dictionary<int, string>()
            {
                { 1 , $"A012345^6789+-*/;BCD MN{ch}OP#QRSTU:VE?FG'HIJK!LWXYZ" },
                { 2 , $"GH{ch}IJKLM^NO!PQ:R#STU VW01'2345?6789+-*/;XYZABCDEF" },
                { 3 , $"PQRSTUV W!X{ch}YZAB#012?345:6789+-*/;CDEF^GHIJKL'MNO" },
                { 4 , $"TUVWXY:ZABC'DEF?GH{ch}IJ!KLM NOP^QRS01#23456789+-*/;" }
            };

            int mainKey = random.Next(1,5);
            int pushFor = random.Next(1,10);
            
            char pushForChar = keyValuePairs[pushFor];
            char mainKeyChar = keyValuePairs[mainKey];

            char[] charsToEncrypt = toEncrypt.ToCharArray();
            char[] charsThatEncrypt = encrypt[mainKey].ToCharArray();

            for (int i = 0;i < charsToEncrypt.Length;i++)
            {
                for (int j = 0;j < charsThatEncrypt.Length; j++)
                {
                    if (char.ToLower(charsToEncrypt[i]) == char.ToLower(charsThatEncrypt[j]))
                    {
                        if (j + pushFor >= charsThatEncrypt.Length)
                        {
                            encryptText.Append(charsThatEncrypt[j+pushFor-charsThatEncrypt.Length]);
                            break;
                        }
                        encryptText.Append(charsThatEncrypt[j+pushFor]);
                        break;                        
                    }
                }
                
            }

            encryptText.Append(mainKeyChar.ToString()+ pushForChar.ToString());
            toEncrypt = encryptText.ToString();

        }

        private static void Decryption(ref string toDecrypt)
        {
            int pullFor;
            int mainKey;
            char ch = '"';
            StringBuilder decryptedText = new StringBuilder();

            Dictionary<char, int> keyValuePairs = new Dictionary<char, int>()
            {
                { '#' , 1 },
                { 'g' , 2 },
                { 's' , 3 },
                { 'h' , 4 },
                { '"' , 5 },
                { ' ' , 6 },
                { '!' , 7 },
                { 'd' , 8 },
                { '/' , 9 },
                {  'u', 10 },
            };

            Dictionary<int, string> decrypt = new Dictionary<int, string>()
            {
                { 1 , $"A012345^6789+-*/;BCD MN{ch}OP#QRSTU:VE?FG'HIJK!LWXYZ" },
                { 2 , $"GH{ch}IJKLM^NO!PQ:R#STU VW01'2345?6789+-*/;XYZABCDEF" },
                { 3 , $"PQRSTUV W!X{ch}YZAB#012?345:6789+-*/;CDEF^GHIJKL'MNO" },
                { 4 , $"TUVWXY:ZABC'DEF?GH{ch}IJ!KLM NOP^QRS01#23456789+-*/;" }
            };

            char[] charsToDecrypt = toDecrypt.ToLower().ToCharArray();
            



            pullFor = keyValuePairs[charsToDecrypt[^1]];
            mainKey = keyValuePairs[charsToDecrypt[^2]];

            char[] charsThatEncrypt = decrypt[mainKey].ToLower().ToCharArray();

            for (int i = 0; i < charsToDecrypt.Length-2; i++)
            {
                for (int j = 0; j < charsThatEncrypt.Length; j++)
                {
                    if (char.ToLower(charsToDecrypt[i]) == charsThatEncrypt[j])
                    {
                        if (j - pullFor < 0)
                        {
                            decryptedText.Append(charsThatEncrypt[j - pullFor + charsThatEncrypt.Length]);
                            break;
                        }
                        
                        decryptedText.Append(charsThatEncrypt[j - pullFor]);
                        break;
                    }
                }

            }
            toDecrypt = decryptedText.ToString();

        }





    }
}