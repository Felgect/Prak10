using System;
using static System.Console;

namespace Praktika10
{
    // Исходный класс Original, который содержит 3 метода
    // OriginalDouble(), OriginalInt(), OriginalChar()
    class Original
    {
        public void OriginalDouble(double value)
        {
            WriteLine("Method Original.OriginalDouble(), value = {0}", value);
        }

        public void OriginalInt(int value)
        {
            WriteLine("Method Original.OriginalInt(), value = {0}", value);
        }

        public void OriginalChar(char value)
        {
            WriteLine("Method Original.OriginalChar, value = {0}", value);
        }
    }

    interface ITarget
    {
        void ClientDouble(double value);
        void ClientInt(int value);
        void ClientChar(char value);
    }

    // Класс Adapter - реализует интерфейс ITarget, наследует класс Original
    class Adapter : Original, ITarget
    {
        public void ClientDouble(double value)
        {
            // в методе ClientDouble() вызвать метод OriginalDouble()
            OriginalDouble(value);
        }

        public void ClientInt(int value)
        {
            OriginalInt(value * 2);
        }

        public void ClientChar(char value)
        {
            for (int i = 0; i < 5; i++)
                OriginalChar(value);
        }
    }

    // Класс Client - получает ссылку на интерфейс ITarget в конструкторе
    class Client
    {
        private ITarget client; // ссылка на интерфейс ITarget

        // Конструктор
        public Client(ITarget _client)
        {
            client = _client;
        }

        // Метод, который вызывает все методы интерфейса
        public void Show()
        {
            client.ClientDouble(3.5);
            client.ClientInt(23);
            client.ClientChar('k');
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Adapter adapter = new Adapter();

            Client client = new Client(adapter);

            client.Show();
        }
    }
}
