namespace Forms
{
    /// <summary>
    /// Класс для работы с битами.
    /// </summary>
    public class Bit
    {
        /// <summary>
        /// Значение бита 1/0.
        /// </summary>
        bool value;

        /// <summary>
        /// Вывод значения в виде числа.
        /// </summary>
        /// <returns>Бит в виде 1/0.</returns>
        public int Int()
        {
            if (value)
                return 1;
            else return 0;
        }

        public override string ToString() => Value;

        public Bit(bool value) => this.value = value;

        /// <summary>
        /// Конструктор для работы с числом.
        /// </summary>
        /// <param name="value">Значение бита 1/0.</param>
        public Bit(int value)
        {
            if (value == 1)
                this.value = true;
            else
                this.value = false;
        }

        /// <summary>
        /// Конструктор для работы со строкой.
        /// </summary>
        /// <param name="value">Значение бита 1/0.</param>
        public Bit(string newValue)
        {
            int value;
            if (!int.TryParse(newValue, out value))
                throw new ArgumentException("Ошибочное значение бита");
            else
                if (value == 1)
                this.value = true;
            else
                this.value = false;
        }

        /// <summary>
        /// Сложение по модулю 2.
        /// </summary>
        /// <param name="bit1">Бит 1.</param>
        /// <param name="bit2">Бит 2.</param>
        /// <returns>Новый бит - результат сложения по модулю 2.</returns>
        public static Bit operator +(Bit bit1, Bit bit2)
        {
            if (bit1.Value == "1")
                if (bit2.Value == "1")
                    return new Bit(0);
                else
                    return new Bit(1);
            else
                if (bit2.Value == "1")
                return new Bit(1);
            else
                return new Bit(0);
        }

        /// <summary>
        /// Свойство для вывода значения в виде строки.
        /// </summary>
        public string Value
        {
            get
            {
                if (value == true)
                    return "1";
                else
                    return "0";
            }
        }
    }
}
