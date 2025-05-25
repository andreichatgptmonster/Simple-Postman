using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Simple_Postman
{
    class Program
    {
        static async Task Main()
        {
            Console.WriteLine("Выберите метод запроса (GET или POST):");
            string method = Console.ReadLine()?.Trim().ToUpper();

            if (method != "GET" && method != "POST")
            {
                Console.WriteLine("Ошибка: поддерживаются только методы GET и POST.");
                return;
            }

            Console.WriteLine("Введите аргументы (например: key1=value1&key2=value2) или оставьте пустым:");
            string args = Console.ReadLine()?.Trim();

            Console.WriteLine("Введите URL:");
            string url = Console.ReadLine()?.Trim();

            if (string.IsNullOrEmpty(url))
            {
                Console.WriteLine("Ошибка: URL не может быть пустым.");
                return;
            }

            await http_client.SendAndGetResponseStatus(url: url, args: args, method: method);
        }
    }
}