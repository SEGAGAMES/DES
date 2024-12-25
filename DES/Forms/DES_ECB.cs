namespace Forms
{
    public class DES_ECB
    {
        #region Перестановки переменные.
        /// <summary>
        /// Узлы перестановки S.
        /// </summary>
        static int[,,] S =
        {
            {
                {14,4,13,1,2,15,11,8,3,10,6,12,5,9,0,7 },
                {0,15,7,4,14,2,13,1,10,6,12,11,9,5,3,8 },
                {4,1,14,8,13,6,2,11,15,12,9,7,3,10,5,0 },
                {15,12,8,2,4,9,1,7,5,11,3,14,10,0,6,13 }
            },
            {
                {15,1,8,14,6,11,3,4,9,7,2,13,12,0,5,10 },
                {3,13,4,7,15,2,8,14,12,0,1,10,6,9,11,5 },
                {0,14,7,11,10,4,13,1,5,8,12,6,9,3,2,15 },
                {13,8,10,1,3,15,4,2,11,6,7,12,0,5,14,9 }
            },
            {
                {10,0,9,14,6,3,15,5,1,13,12,7,11,4,2,8 },
                {13,7,0,9,3,4,6,10,2,8,5,14,12,11,15,1 },
                {13,6,4,9,8,15,3,0,11,1,2,12,5,10,14,7 },
                {1,10,13,0,6,9,8,7,4,15,14,3,11,5,2,12 }
            },
            {
                {7,13,14,3,0,6,9,10,1,2,8,5,11,12,4,15 },
                {13,8,11,5,6,15,0,3,4,7,2,12,1,10,14,9 },
                {10,6,9,0,12,11,7,13,15,1,3,14,5,2,8,4 },
                {3,15,0,6,10,1,13,8,9,4,5,11,12,7,2,14 }
            },
            {
                {2,12,4,1,7,10,11,6,8,5,3,15,13,0,14,9 },
                {14,11,2,12,4,7,13,1,5,0,15,10,3,9,8,6 },
                {4,2,1,11,10,13,7,8,15,9,12,5,6,3,0,14 },
                {11,8,12,7,1,14,2,13,6,15,0,9,10,4,5,3 }
            },
            {
                {12,1,10,15,9,2,6,8,0,13,3,4,14,7,5,11 },
                {10,15,4,2,7,12,9,5,6,1,13,14,0,11,3,8 },
                {9,14,15,5,2,8,12,3,7,0,4,10,1,13,11,6 },
                {4,3,2,12,9,5,15,10,11,14,1,7,6,0,8,13 }
            },
            {
                {4,11,2,14,15,0,8,13,3,12,9,7,5,10,6,1 },
                {13,0,11,7,4,9,1,10,14,3,5,12,2,15,8,6 },
                {1,4,11,13,12,3,7,14,10,15,6,8,0,5,9,2 },
                {6,11,13,8,1,4,10,7,9,5,0,15,14,2,3,12 }
            },
            {
                {13,2,8,4,6,15,11,1,10,9,3,14,5,0,12,7 },
                {1,15,13,8,10,3,7,4,12,5,6,11,0,14,9,2 },
                {7,11,4,1,9,12,14,2,0,6,10,13,15,3,5,8 },
                {2,1,14,7,4,10,8,13,15,12,9,0,3,5,6,11 }
            }
        };

        /// <summary>
        /// Перестановка IP.
        /// </summary>
        static int[] IP = {
                58,50,42,34,26,18,10,2,
                60,52,44,36,28,20,12,4,
                62,54,46,38,30,22,14,6,
                64,56,48,40,32,24,16,8,
                57,49,41,33,25,17,9,1,
                59,51,43,35,27,19,11,3,
                61,53,45,37,29,21,13,5,
                63,55,47,39,31,23,15,7
            };

        /// <summary>
        /// Перестановка IP-1.
        /// </summary>
        static int[] IP2 =
            {
                40,8,48,16,56,24,64,32,
                39,7,47,15,55,23,63,31,
                38,6,46,14,54,22,62,30,
                37,5,45,13,53,21,61,29,
                36,4,44,12,52,20,60,28,
                35,3,43,11,51,19,59,27,
                34,2,42,10,50,18,58,26,
                33,1,41,9,49,17,57,25
            };

        /// <summary>
        /// Перестановка PC1.
        /// </summary>
        static int[] PC1 =
            {
                57,49,41,33,25,17,9,
                1,58,50,42,34,26,18,
                10,2,59,51,43,35,27,
                19,11,3,60,52,44,36,
                63,55,47,39,31,23,15,
                7,62,54,46,38,30,22,
                14,6,61,53,45,37,29,
                21,13,5,28,20,12,4
            };

        /// <summary>
        /// Перестановка PC2.
        /// </summary>
        static int[] PC2 =
            {
                14,17,11,24,1,5,
                3,28,15,6,21,10,
                23,19,12,4,26,8,
                16,7,27,20,13,2,
                41,52,31,37,47,55,
                30,40,51,45,33,48,
                44,49,39,56,34,53,
                46,42,50,36,29,32
            };

        /// <summary>
        /// Перестановка P.
        /// </summary>
        static int[] P =
                {
                16,7,20,21,29,12,28,17,
                1,15,23,26,5,18,31,10,
                2,8,24,14,32,27,3,9,
                19,13,30,6,22,11,4,25
            };
        #endregion

        #region Методы перестановок.

        /// <summary>
        /// Перестановка P.
        /// </summary>
        /// <param name="input">Переставляемый массив.</param>
        /// <returns>Переставленный массив.</returns>
        static public Bit[] PReplace(Bit[] input)
        {
            Bit[] output = new Bit[input.Length];
            Bit[] H_copy = new Bit[32];
            input.CopyTo(H_copy, 0);
            for (int i = 0; i < 32; i++)
                output[i] = H_copy[P[i] - 1];
            return output;
        }

        /// <summary>
        /// Перестановка IP.
        /// </summary>
        /// <param name="input">Переставляемый массив.</param>
        /// <returns>Переставленный массив.</returns>
        static public Bit[] IPReplace(Bit[] input)
        {
            Bit[] output = new Bit[input.Length];
            Bit[] copy = new Bit[input.Length];
            input.CopyTo(copy, 0);
            for (int j = 0; j < input.Length; j++)
                output[j] = copy[IP[j] - 1];
            return output;
        }

        /// <summary>
        /// Перестановка IP2.
        /// </summary>
        /// <param name="input">Переставляемый массив.</param>
        /// <returns>Переставленный массив.</returns>
        static public Bit[] IP2Replace(Bit[] input)
        {
            Bit[] output = new Bit[input.Length];
            Bit[] TnewCopy = new Bit[64];
            input.CopyTo(TnewCopy, 0);
            for (int j = 0; j < 64; j++)
                output[j] = TnewCopy[IP2[j] - 1];
            return output;
        }
        #endregion

        #region Обработка данных.
        /// <summary>
        /// Разделение на 2 половинки.
        /// </summary>
        /// <param name="Key">Что разбиваем.</param>
        /// <param name="d">Размерность половинок.</param>
        /// <returns>Две половинки H и L.</returns>
        static public (Bit[], Bit[]) CreateH1_L1(Bit[] input, int d)
        {
            Bit[] H1 = new Bit[d];
            Bit[] L1 = new Bit[d];
            for (int i = 0; i < d; i++)
            {
                H1[i] = input[i];
            }
            int n = 0;
            for (int i = d; i < d * 2; i++)
            {
                L1[n++] = input[i];
            }
            return (H1, L1);
        }

        /// <summary>
        /// Циклический сдвиг.
        /// </summary>
        /// <param name="input">Сдвигаемый массив.</param>
        /// <param name="p">Сдвиг на 1 или на 2 бита.</param>
        /// <returns>Сдвинутый массив.</returns>
        static Bit[] CycleMove(Bit[] input, int p)
        {
            if (p == 1)
            {
                Bit first = input[0];
                for (int i = 0; i < input.Length - 1; i++)
                {
                    input[i] = input[i + 1];
                }
                input[input.Length - 1] = first;

            }
            if (p == 2)
            {
                Bit first = input[0];
                for (int i = 0; i < input.Length - 1; i++)
                {
                    input[i] = input[i + 1];
                }
                input[input.Length - 1] = first;
                first = input[0];
                for (int i = 0; i < input.Length - 1; i++)
                {
                    input[i] = input[i + 1];
                }
                input[input.Length - 1] = first;
            }
            return input;
        }

        /// <summary>
        /// Объединение половинок и перестановка.
        /// </summary>
        /// <param name="H">Первая половинка.</param>
        /// <param name="L">Вторая половинка.</param>
        /// <param name="PC2">Перестановка.</param>
        /// <returns>Ключ.</returns>
        static Bit[] CreateKey(Bit[] H, Bit[] L, int[] PC2)
        {
            Bit[] key = new Bit[56];
            int n = 0;
            for (int i = 0; i < 28; i++)
                key[n++] = H[i];
            for (int i = 0; i < 28; i++)
                key[n++] = L[i];
            Bit[] newkey = new Bit[48];
            for (int i = 0; i < 48; i++)
                newkey[i] = key[PC2[i] - 1];
            return newkey;
        }

        /// <summary>
        /// Создание ключей из заданного
        /// </summary>
        /// <param name="Key">Заданный ключ длины 64 (с паритетными битами).</param>
        /// <returns></returns>
        static public Bit[][] CreateKeys(Bit[] Key)
        {
            Bit[][] keys = new Bit[16][]; // 16x48
            Bit[] copykey = new Bit[64];
            Key.CopyTo(copykey, 0);
            Bit[] Key2 = new Bit[56];
            for (int i = 0; i < 56; i++)
                Key2[i] = copykey[PC1[i] - 1];
            (Bit[] H1, Bit[] L1) = CreateH1_L1(Key2, 28); // 28,28
            for (int i = 0; i < 16; i++)
            {
                int p;
                if (i == 0 || i == 1 || i == 8 || i == 15)
                    p = 1;
                else
                    p = 2;
                H1 = CycleMove(H1, p); // 28
                L1 = CycleMove(L1, p); // 28
                keys[i] = CreateKey(H1, L1, PC2); // 48
            }
            return keys;
        }

        /// <summary>
        /// Функция расширения Е. 
        /// </summary>
        /// <param name="L">Li 32 бита разбивается на 8 тетрад по 4 бита.</param>
        /// <returns>48-битовый блок Х.</returns>
        static public Bit[] E(Bit[] L)
        {
            Bit[] output = new Bit[48];
            Bit[][] tetr = new Bit[8][];
            int n = 0;
            int k = 0;
            for (int i = 0; i < 8; i++)
            {
                tetr[i] = new Bit[6];
                if (i == 0)
                    tetr[i][0] = L[L.Length - 1];
                else
                    tetr[i][0] = L[n - 1];
                tetr[i][1] = L[n++];
                tetr[i][2] = L[n++];
                tetr[i][3] = L[n++];
                tetr[i][4] = L[n++];
                if (i == 7)
                    tetr[i][5] = L[0];
                else
                    tetr[i][5] = L[n];
                for (int j = 0; j < 6; j++)
                    output[k++] = tetr[i][j];
            }
            return output;
        }

        /// <summary>
        /// Функция сжатия c использованием узла замены S.
        /// </summary>
        /// <param name="H">48-битовый блок данных.</param>
        /// <returns>32-битовый блок H_.</returns>
        static public Bit[] Hnew(Bit[] H)
        {
            Bit[] output = new Bit[32];
            string row;
            string column;
            int n = 0;
            int j = 0;
            for (int i = 0; i < 8; i++)
            {
                row = H[n++].Value;
                column = H[n++].Value;
                column += H[n++].Value;
                column += H[n++].Value;
                column += H[n++].Value;
                row += H[n++].Value;
                int rowint = Convert.ToInt32(row, 2);
                int columnint = Convert.ToInt32(column, 2);

                string numb = Convert.ToString(S[i, rowint, columnint], 2);
                switch (numb.Length)
                {
                    case 1:
                        numb = "000" + numb; break;
                    case 2:
                        numb = "00" + numb; break;
                    case 3:
                        numb = "0" + numb; break;
                }
                output[j++] = new Bit(Convert.ToString(numb[0]));
                output[j++] = new Bit(Convert.ToString(numb[1]));
                output[j++] = new Bit(Convert.ToString(numb[2]));
                output[j++] = new Bit(Convert.ToString(numb[3]));
            }
            return output;

        }

        /// <summary>
        /// Объединение половинок.
        /// </summary>
        /// <param name="H1">Верхняя половинка.</param>
        /// <param name="L1">Нижняя половинка.</param>
        /// <returns>Объединение.</returns>
        static public Bit[] Union(Bit[] H1, Bit[] L1)
        {
            Bit[] Tnew = new Bit[64];
            for (int j = 0; j < 64; j++)
            {
                if (j < 32)
                    Tnew[j] = H1[j];
                else
                    Tnew[j] = L1[j - 32];
            }
            return Tnew;
        }
        #endregion
    }

}
