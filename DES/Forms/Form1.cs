namespace Forms
{
    public partial class Form1 : Form
    {
        string mode;
        Bit[][] encryptResult;
        Bit[][] decryptResult;
        public Form1()
        {
            InitializeComponent();
            mode = "ECB";
            Text = "DES-" + mode;
        }

        #region Выбор режима.
        private void ECBRdBtn_CheckedChanged(object sender, EventArgs e)
        {
            key2Lbl.Visible = false;
            key3Lbl.Visible = false;
            key2TxtBox.Visible = false;
            key3TxtBox.Visible = false;
            IVLbl.Visible = false;
            IVTxtBox.Visible = false;
            mode = "ECB";
            Text = "DES-" + mode;
        }

        private void CBCRdBtn_CheckedChanged(object sender, EventArgs e)
        {
            key2Lbl.Visible = false;
            key3Lbl.Visible = false;
            key2TxtBox.Visible = false;
            key3TxtBox.Visible = false;
            IVLbl.Visible = true;
            IVTxtBox.Visible = true;
            mode = "CBC";
            Text = "DES-" + mode;
        }

        private void EEE3RdBtn_CheckedChanged(object sender, EventArgs e)
        {
            key2Lbl.Visible = true;
            key3Lbl.Visible = true;
            key2TxtBox.Visible = true;
            key3TxtBox.Visible = true;
            IVLbl.Visible = false;
            IVTxtBox.Visible = false;
            mode = "EEE3";
            Text = "DES-" + mode;
        }

        private void EDE3RdBtn_CheckedChanged(object sender, EventArgs e)
        {
            key2Lbl.Visible = true;
            key3Lbl.Visible = true;
            key2TxtBox.Visible = true;
            key3TxtBox.Visible = true;
            IVLbl.Visible = false;
            IVTxtBox.Visible = false;
            mode = "EDE3";
            Text = "DES-" + mode;
        }

        private void EEE2RdBtn_CheckedChanged(object sender, EventArgs e)
        {
            key2Lbl.Visible = true;
            key3Lbl.Visible = false;
            key2TxtBox.Visible = true;
            key3TxtBox.Visible = false;
            IVLbl.Visible = false;
            IVTxtBox.Visible = false;
            mode = "EEE2";
            Text = "DES-" + mode;
        }

        private void EDE2RdBtn_CheckedChanged(object sender, EventArgs e)
        {
            key2Lbl.Visible = true;
            key3Lbl.Visible = false;
            key2TxtBox.Visible = true;
            key3TxtBox.Visible = false;
            IVLbl.Visible = false;
            IVTxtBox.Visible = false;
            mode = "EDE2";
            Text = "DES-" + mode;
        }
        #endregion

        void PrintLog(string inputText)
        {

            logTxtBox.Text += inputText + "\r\n";
        }
        void PrintLog(string inputText, Bit[] inputBits, int length)
        {
            logTxtBox.Text += inputText + " " + Converter.ToString(inputBits, length) + "\r\n";
        }
        Bit[][] EncryptECB(string inputText, string inputKey)
        {
            PrintLog("Шифрование сообщения: " + inputText);
            Bit[] key = Converter.StringToKey(inputKey);
            PrintLog("Ключ в битовом представлении", key, 8);
            Bit[][] keys = DES_ECB.CreateKeys(key);
            Bit[][] T = Converter.StringToBit(inputText);
            Bit[][] output = new Bit[T.Length][];
            for (int block = 0; block < T.Length; block++)
            {
                PrintLog("");
                PrintLog("Шифрование " + (block + 1).ToString() + " блока:");
                PrintLog("Начальное сообщение:", T[block], 8);
                T[block] = DES_ECB.IPReplace(T[block]);
                PrintLog("Перестановка IP:", T[block], 8);
                (Bit[] H, Bit[] L) = DES_ECB.CreateH1_L1(T[block], 32);
                PrintLog("_________________________________________________________");
                // 16 раундов.
                for (int i = 0; i < 16; i++)
                {
                    PrintLog((i + 1).ToString() + " раунд");
                    PrintLog("Нижняя половина L", L, 4);
                    // Функция f.
                    Bit[] X = DES_ECB.E(L);
                    PrintLog("Функция расширения E:", X, 6);
                    PrintLog("Ключ:", keys[i], 6);
                    for (int j = 0; j < 48; j++)
                        X[j] = X[j] + keys[i][j];
                    PrintLog("Сложение по модулю 2:", X, 6);
                    Bit[] H_ = DES_ECB.Hnew(X);
                    PrintLog("Перестановка S:", H_, 4);
                    H_ = DES_ECB.PReplace(H_);
                    PrintLog("Перестановка P:", H_, 4);
                    PrintLog("Верхняя половина H:", H, 4);
                    for (int j = 0; j < 32; j++)
                        H[j] = H[j] + H_[j];
                    PrintLog("Сложение H и f:", H, 4);
                    if (i != 15)
                        (H, L) = (L, H);
                    PrintLog("_________________________________________________________");
                }
                Bit[] Tnew = DES_ECB.Union(H, L);
                PrintLog("Объединение половинок:", Tnew, 8);
                Tnew = DES_ECB.IP2Replace(Tnew);
                PrintLog("Перестановка IP2:", Tnew, 8);
                PrintLog("Зашифрованный блок: " + Converter.BitToString(Tnew));
                PrintLog("");
                output[block] = Tnew;
            }
            PrintLog("Зашифрованное сообщение: " + Converter.BitsToString(output));
            return output;
        }

        Bit[][] EncryptECB(Bit[][] input, string inputKey)
        {
            Bit[][] T = new Bit[input.Length][];
            input.CopyTo(T, 0);
            Bit[] key = Converter.StringToKey(inputKey);
            PrintLog("Ключ в битовом представлении", key, 8);
            Bit[][] keys = DES_ECB.CreateKeys(key);
            Bit[][] output = new Bit[T.Length][];
            for (int block = 0; block < T.Length; block++)
            {
                PrintLog("");
                PrintLog("Шифрование " + (block + 1).ToString() + " блока:");
                PrintLog("Начальное сообщение:", T[block], 8);
                T[block] = DES_ECB.IPReplace(T[block]);
                PrintLog("Перестановка IP:", T[block], 8);
                (Bit[] H, Bit[] L) = DES_ECB.CreateH1_L1(T[block], 32);
                PrintLog("_________________________________________________________");
                // 16 раундов.
                for (int i = 0; i < 16; i++)
                {
                    PrintLog((i + 1).ToString() + " раунд");
                    PrintLog("Нижняя половина L", L, 4);
                    // Функция f.
                    Bit[] X = DES_ECB.E(L);
                    PrintLog("Функция расширения E:", X, 6);
                    PrintLog("Ключ:", keys[i], 6);
                    for (int j = 0; j < 48; j++)
                        X[j] = X[j] + keys[i][j];
                    PrintLog("Сложение по модулю 2:", X, 6);
                    Bit[] H_ = DES_ECB.Hnew(X);
                    PrintLog("Перестановка S:", H_, 4);
                    H_ = DES_ECB.PReplace(H_);
                    PrintLog("Перестановка P:", H_, 4);
                    PrintLog("Верхняя половина H:", H, 4);
                    for (int j = 0; j < 32; j++)
                        H[j] = H[j] + H_[j];
                    PrintLog("Сложение H и f:", H, 4);
                    if (i != 15)
                        (H, L) = (L, H);
                    PrintLog("_________________________________________________________");
                }
                Bit[] Tnew = DES_ECB.Union(H, L);
                PrintLog("Объединение половинок:", Tnew, 8);
                Tnew = DES_ECB.IP2Replace(Tnew);
                PrintLog("Перестановка IP2:", Tnew, 8);
                PrintLog("Зашифрованный блок: " + Converter.BitToString(Tnew));
                PrintLog("");
                output[block] = Tnew;
            }
            PrintLog("Зашифрованное сообщение: " + Converter.BitsToString(output));
            return output;
        }


        Bit[][] DecryptECB(Bit[][] input, string inputKey)
        {
            Bit[][] T = new Bit[input.Length][];
            input.CopyTo(T, 0);
            Bit[] key = Converter.StringToKey(inputKey);
            PrintLog("Ключ в битовом представлении", key, 8);
            Bit[][] keys = DES_ECB.CreateKeys(key);
            Bit[][] output = new Bit[T.Length][];
            for (int block = 0; block < T.Length; block++)
            {
                PrintLog("");
                PrintLog("Дешифрование " + (block + 1).ToString() + " блока:");
                PrintLog("Начальное сообщение:", T[block], 8);
                T[block] = DES_ECB.IPReplace(T[block]);
                PrintLog("Перестановка IP:", T[block], 8);
                (Bit[] H, Bit[] L) = DES_ECB.CreateH1_L1(T[block], 32);
                PrintLog("_________________________________________________________");
                // 16 раундов.
                for (int i = 0; i < 16; i++)
                {
                    PrintLog((i + 1).ToString() + " раунд");
                    PrintLog("Нижняя половина L", L, 4);
                    // Функция f.
                    Bit[] X = DES_ECB.E(L);
                    PrintLog("Функция расширения E:", X, 6);
                    PrintLog("Ключ:", keys[15 - i], 6);
                    for (int j = 0; j < 48; j++)
                        X[j] = X[j] + keys[15 - i][j];
                    PrintLog("Сложение по модулю 2:", X, 6);
                    Bit[] H_ = DES_ECB.Hnew(X);
                    PrintLog("Перестановка S:", H_, 4);
                    H_ = DES_ECB.PReplace(H_);
                    PrintLog("Перестановка P:", H_, 4);
                    PrintLog("Верхняя половина H:", H, 4);
                    for (int j = 0; j < 32; j++)
                        H[j] = H[j] + H_[j];
                    PrintLog("Сложение H и f:", H, 4);
                    if (i != 15)
                        (H, L) = (L, H);
                    PrintLog("_________________________________________________________");
                }
                Bit[] Tnew = DES_ECB.Union(H, L);
                PrintLog("Объединение половинок:", Tnew, 8);
                Tnew = DES_ECB.IP2Replace(Tnew);
                PrintLog("Перестановка IP2:", Tnew, 8);
                PrintLog("Дешифрованный блок: " + Converter.BitToString(Tnew));
                PrintLog("");
                output[block] = Tnew;
            }
            PrintLog("Дешифрованное сообщение: " + Converter.BitsToString(output));
            return output;
        }

        Bit[][] DecryptECB(string inputText, string inputKey)
        {
            PrintLog("Дешифрование сообщения: " + inputText);
            Bit[] key = Converter.StringToKey(inputKey);
            PrintLog("Ключ в битовом представлении", key, 8);
            Bit[][] keys = DES_ECB.CreateKeys(key);
            Bit[][] T = Converter.StringToBit(inputText);
            Bit[][] output = new Bit[T.Length][];
            for (int block = 0; block < T.Length; block++)
            {
                PrintLog("");
                PrintLog("Дешифрование " + (block + 1).ToString() + " блока:");
                PrintLog("Начальное сообщение:", T[block], 8);
                T[block] = DES_ECB.IPReplace(T[block]);
                PrintLog("Перестановка IP:", T[block], 8);
                (Bit[] H, Bit[] L) = DES_ECB.CreateH1_L1(T[block], 32);
                PrintLog("_________________________________________________________");
                // 16 раундов.
                for (int i = 0; i < 16; i++)
                {
                    PrintLog((i + 1).ToString() + " раунд");
                    PrintLog("Нижняя половина L", L, 4);
                    // Функция f.
                    Bit[] X = DES_ECB.E(L);
                    PrintLog("Функция расширения E:", X, 6);
                    PrintLog("Ключ:", keys[15 - i], 6);
                    for (int j = 0; j < 48; j++)
                        X[j] = X[j] + keys[15 - i][j];
                    PrintLog("Сложение по модулю 2:", X, 6);
                    Bit[] H_ = DES_ECB.Hnew(X);
                    PrintLog("Перестановка S:", H_, 4);
                    H_ = DES_ECB.PReplace(H_);
                    PrintLog("Перестановка P:", H_, 4);
                    PrintLog("Верхняя половина H:", H, 4);
                    for (int j = 0; j < 32; j++)
                        H[j] = H[j] + H_[j];
                    PrintLog("Сложение H и f:", H, 4);
                    if (i != 15)
                        (H, L) = (L, H);
                    PrintLog("_________________________________________________________");
                }
                Bit[] Tnew = DES_ECB.Union(H, L);
                PrintLog("Объединение половинок:", Tnew, 8);
                Tnew = DES_ECB.IP2Replace(Tnew);
                PrintLog("Перестановка IP2:", Tnew, 8);
                string toPrint = Converter.BitToString(Tnew);
                toPrint = toPrint.Replace("\0", string.Empty);
                PrintLog("Дешифрованный блок: " + toPrint);
                PrintLog("");
                output[block] = Tnew;
            }
            string result = Converter.BitsToString(output);
            result = result.Replace("\0", string.Empty);
            PrintLog("Дешифрованное сообщение: " + result);
            return output;
        }

        private void ecnryptBtn_Click(object sender, EventArgs e)
        {
            logTxtBox.Text = "";
            switch (mode)
            {
                case "ECB":
                    encryptResult = EncryptECB(encryptTextTxtBox.Text, key1TxtBox.Text);
                    encryptResultTxtBox.Text = Converter.BitsToString(encryptResult);
                    decryptTextTxtBox.Text = Converter.BitsToString(encryptResult);
                    break;
                case "CBC":
                    throw new NotImplementedException();
                case "EEE3":
                    encryptResult = EncryptECB(encryptTextTxtBox.Text, key1TxtBox.Text);
                    encryptResult = EncryptECB(encryptResult, key2TxtBox.Text);
                    encryptResult = EncryptECB(encryptResult, key3TxtBox.Text);
                    encryptResultTxtBox.Text = Converter.BitsToString(encryptResult);
                    decryptTextTxtBox.Text = Converter.BitsToString(encryptResult);
                    break;
                case "EDE3":
                    encryptResult = EncryptECB(encryptTextTxtBox.Text, key1TxtBox.Text);
                    decryptResult = DecryptECB(encryptResult, key2TxtBox.Text);
                    encryptResult = EncryptECB(decryptResult, key3TxtBox.Text);
                    encryptResultTxtBox.Text = Converter.BitsToString(encryptResult);
                    decryptTextTxtBox.Text = Converter.BitsToString(encryptResult);
                    break;
                case "EEE2":
                    encryptResult = EncryptECB(encryptTextTxtBox.Text, key1TxtBox.Text);
                    encryptResult = EncryptECB(encryptResult, key2TxtBox.Text);
                    encryptResult = EncryptECB(encryptResult, key1TxtBox.Text);
                    encryptResultTxtBox.Text = Converter.BitsToString(encryptResult);
                    decryptTextTxtBox.Text = Converter.BitsToString(encryptResult);
                    break;
                case "EDE2":
                    encryptResult = EncryptECB(encryptTextTxtBox.Text, key1TxtBox.Text);
                    decryptResult = DecryptECB(encryptResult, key2TxtBox.Text);
                    encryptResult = EncryptECB(decryptResult, key1TxtBox.Text);
                    encryptResultTxtBox.Text = Converter.BitsToString(encryptResult);
                    decryptTextTxtBox.Text = Converter.BitsToString(encryptResult);
                    break;
            }
        }

        private void decryptBtn_Click(object sender, EventArgs e)
        {
            logTxtBox.Text = "";
            if (decryptTextTxtBox.Text.Contains("�"))
            {
                decryptTextTxtBox.Text = "Ошибка кодировки, найден символ �. Данные для декодирования взяты из памяти";
                switch (mode)
                {
                    case "ECB":
                        decryptResult = DecryptECB(encryptResult, key1TxtBox.Text);
                        decryptResultTxtBox.Text = Converter.BitsToString(decryptResult);
                        break;
                    case "CBC":
                        throw new NotImplementedException();
                    case "EEE3":
                        decryptResult = DecryptECB(encryptResult, key3TxtBox.Text);
                        decryptResult = DecryptECB(decryptResult, key2TxtBox.Text);
                        decryptResult = DecryptECB(decryptResult, key1TxtBox.Text);
                        decryptResultTxtBox.Text = Converter.BitsToString(decryptResult);
                        break;
                    case "EDE3":
                        decryptResult = DecryptECB(encryptResult, key3TxtBox.Text);
                        encryptResult = EncryptECB(decryptResult, key2TxtBox.Text);
                        decryptResult = DecryptECB(encryptResult, key1TxtBox.Text);
                        decryptResultTxtBox.Text = Converter.BitsToString(decryptResult);
                        break;
                    case "EEE2":
                        decryptResult = DecryptECB(encryptResult, key1TxtBox.Text);
                        decryptResult = DecryptECB(decryptResult, key2TxtBox.Text);
                        decryptResult = DecryptECB(decryptResult, key1TxtBox.Text);
                        decryptResultTxtBox.Text = Converter.BitsToString(decryptResult);
                        break;
                    case "EDE2":
                        decryptResult = DecryptECB(encryptResult, key1TxtBox.Text);
                        encryptResult = EncryptECB(decryptResult, key2TxtBox.Text);
                        decryptResult = DecryptECB(encryptResult, key1TxtBox.Text);
                        decryptResultTxtBox.Text = Converter.BitsToString(decryptResult);
                        break;
                }
            }
            else
            {
                switch (mode)
                {
                    case "ECB":
                        decryptResult = DecryptECB(decryptTextTxtBox.Text, key1TxtBox.Text);
                        string result = Converter.BitsToString(decryptResult);
                        result = result.Replace("\0", string.Empty);
                        decryptResultTxtBox.Text = result;
                        break;
                    case "CBC":
                        throw new NotImplementedException();
                    case "EEE3":
                        decryptResult = DecryptECB(decryptTextTxtBox.Text, key3TxtBox.Text);
                        decryptResult = DecryptECB(decryptResult, key2TxtBox.Text);
                        decryptResult = DecryptECB(decryptResult, key1TxtBox.Text);
                        result = Converter.BitsToString(decryptResult);
                        result = result.Replace("\0", string.Empty);
                        decryptResultTxtBox.Text = result;
                        break;
                    case "EDE3":
                        decryptResult = DecryptECB(encryptResult, key3TxtBox.Text);
                        encryptResult = EncryptECB(decryptResult, key2TxtBox.Text);
                        decryptResult = DecryptECB(encryptResult, key1TxtBox.Text);
                        result = Converter.BitsToString(decryptResult);
                        result = result.Replace("\0", string.Empty);
                        decryptResultTxtBox.Text = result;
                        break;
                    case "EEE2":
                        decryptResult = DecryptECB(decryptTextTxtBox.Text, key1TxtBox.Text);
                        decryptResult = DecryptECB(decryptResult, key2TxtBox.Text);
                        decryptResult = DecryptECB(decryptResult, key1TxtBox.Text);
                        result = Converter.BitsToString(decryptResult);
                        result = result.Replace("\0", string.Empty);
                        decryptResultTxtBox.Text = result;
                        break;
                    case "EDE2":
                        decryptResult = DecryptECB(encryptResult, key1TxtBox.Text);
                        encryptResult = EncryptECB(decryptResult, key2TxtBox.Text);
                        decryptResult = DecryptECB(encryptResult, key1TxtBox.Text);
                        result = Converter.BitsToString(decryptResult);
                        result = result.Replace("\0", string.Empty);
                        decryptResultTxtBox.Text = result;
                        break;
                }
            }
        }

        private void encryptResultTxtBox_MouseDown(object sender, MouseEventArgs e)
        {
            decryptTextTxtBox.Text = encryptResultTxtBox.Text;
        }

    }
}
