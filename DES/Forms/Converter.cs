using System.Text;

namespace Forms
{
    public class Converter
    {
        #region Вывод данных.
        /// <summary>
        /// Вывод массива бит в строку.
        /// </summary>
        /// <param name="input">Массив бит.</param>
        /// <param name="k">По сколько бит выводить в ряд (k=4: 0000 0000...)</param>
        /// <returns>Строку бит.</returns>
        static public string ToString(Bit[] input, int k)
        {
            string output = "";
            int n = 1;
            foreach (Bit item in input)
            {
                output += item.Value;
                if (n++ % k == 0)
                    output += " ";
            }
            return output;
        }

        /// <summary>
        /// Массивы бит в строку.
        /// </summary>
        /// <param name="inputBits">Массив бит.</param>
        /// <returns>Строка.</returns>
        static public string BitsToString(Bit[][] inputBits)
        {
            string output = "";
            string h = "";
            int n = 0;
            byte[] bytes = new byte[8 * inputBits.Length];
            int k = 0;
            for (int j = 0; j < inputBits.Length; j++)
            {
                for (int i = 0; i < inputBits[j].Length; i++)
                {
                    h += inputBits[j][n++].ToString();
                    if (n % 8 == 0)
                    {
                        int b = Convert.ToInt32(h, 2);
                        output = Convert.ToString(b);
                        bytes[k++] = Convert.ToByte(output);
                        h = "";
                    }
                }
                n = 0;
            }
            string ans = Encoding.BigEndianUnicode.GetString(bytes);
            return ans;
        }

        /// <summary>
        /// Массив бит в строку.
        /// </summary>
        /// <param name="inputBit">Массив бит.</param>
        /// <returns>Строка бит.</returns>
        static public string BitToString(Bit[] inputBit)
        {
            string output = "";
            string h = "";
            int n = 0;
            byte[] bytes = new byte[inputBit.Length / 8];
            int k = 0;
            for (int i = 0; i < inputBit.Length; i++)
            {
                h += inputBit[n++].ToString();
                if (n % 8 == 0)
                {
                    int b = Convert.ToInt32(h, 2);
                    output = Convert.ToString(b);
                    bytes[k++] = Convert.ToByte(output);
                    h = "";
                }
            }
            string ans = Encoding.BigEndianUnicode.GetString(bytes);
            return ans;
        }
        #endregion

        #region Для предобработки данных.
        /// <summary>
        /// Разбиение на блоки по 64 бита.
        /// </summary>
        /// <param name="inputStr">Исходное сообщение.</param>
        /// <returns>Блоки по 64 бита.</returns>
        static public Bit[][] StringToBit(string inputStr)
        {
            Bit[][] output;
            byte[] bytes = Encoding.BigEndianUnicode.GetBytes(inputStr);
            string bits = "";
            foreach (var item in bytes)
            {
                string s = Convert.ToString(item, 2);
                switch (s.Length)
                {
                    case 1:
                        bits += "0000000" + s; break;
                    case 2:
                        bits += "000000" + s; break;
                    case 3:
                        bits += "00000" + s; break;
                    case 4:
                        bits += "0000" + s; break;
                    case 5:
                        bits += "000" + s; break;
                    case 6:
                        bits += "00" + s; break;
                    case 7:
                        bits += "0" + s; break;
                    case 8:
                        bits += s; break;
                }
            }
            if (bits.Length % 64 != 0)
                output = new Bit[bits.Length / 64 + 1][];
            else
                output = new Bit[bits.Length / 64][];
            int k = 0;
            int n = 0;
            output[0] = new Bit[64];
            for (int i = 0; i < bits.Length; i++)
            {
                output[k][n++] = new Bit(Convert.ToInt32(Convert.ToString(bits[i])));
                if ((i + 1) % 64 == 0)
                {
                    k++;
                    if (bits.Length % 64 == 0 & k == bits.Length / 64)
                    {
                        k--;
                        break;
                    }
                    n = 0;
                    output[k] = new Bit[64];
                }
            }
            for (int i = 0; i < 64; i++)
            {
                if (output[k][i] is null)
                    output[k][i] = new Bit(0);
            }
            return output;
        }

        /// <summary>
        /// Преобразование 7 буквенного ключа в 64 битовый.
        /// </summary>
        /// <param name="inputStr">7 буквенный ключ.</param>
        /// <returns>64 битовый ключ.</returns>
        /// <exception cref="ArgumentException"></exception>
        static public Bit[] StringToKey(string inputStr)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(inputStr);
            Bit[] Key = new Bit[64];
            string bits = "";
            foreach (var item in bytes)
            {
                string s = Convert.ToString(item, 2);
                switch (s.Length)
                {
                    case 1:
                        bits += "0000000" + s; break;
                    case 2:
                        bits += "000000" + s; break;
                    case 3:
                        bits += "00000" + s; break;
                    case 4:
                        bits += "0000" + s; break;
                    case 5:
                        bits += "000" + s; break;
                    case 6:
                        bits += "00" + s; break;
                    case 7:
                        bits += "0" + s; break;
                    case 8:
                        bits += s; break;
                }
            }
            int n = 0;
            for (int i = 0; i < bits.Length; i++)
            {
                if ((n + 1) % 8 == 0)
                    Key[n++] = new Bit(0);
                Key[n++] = new Bit(Convert.ToString(bits[i]));
            }
            Key[n++] = new Bit(0);
            return Key;
        }

        /// <summary>
        /// Преобразование цифрового ключа в 64 битовый вектор инициализации.
        /// </summary>
        /// <param name="inputStr">Цифровой ключ 7 символов.</param>
        /// <returns>64 битовый ключ.</returns>
        /// <exception cref="ArgumentException"></exception>
        static public Bit[] StringToIV(string inputStr)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(inputStr);
            Bit[] Key = new Bit[64];
            string bits = "";
            foreach (var item in bytes)
            {
                string s = Convert.ToString(item, 2);
                switch (s.Length)
                {
                    case 1:
                        bits += "0000000" + s; break;
                    case 2:
                        bits += "000000" + s; break;
                    case 3:
                        bits += "00000" + s; break;
                    case 4:
                        bits += "0000" + s; break;
                    case 5:
                        bits += "000" + s; break;
                    case 6:
                        bits += "00" + s; break;
                    case 7:
                        bits += "0" + s; break;
                    case 8:
                        bits += s; break;
                }
            }
            int n = 0;
            for (int i = 0; i < bits.Length; i++)
            {
                Key[n++] = new Bit(Convert.ToString(bits[i]));
            }
            return Key;
        }
        #endregion 
    }

}
