using System:
using System.Threading;
using System.Threading.Tasks;

namespace TaskCsharp
{
    class TareasAsincronas
    {
        static async Task Main(string[] args)
        {
            var task = new Task(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("La tarea interna del task");
            });
            task.Start();

            var task2 = new Task(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("La tarea interna 2 del task");
            });
            task2.Start();

            Console.WriteLine("hago algo mas")

            await task;
            await task2;

            int resultRandom = await RandomAsync(5);

            Console.WriteLine(resultRandom);
            Console.WriteLine("He terminado la tarea");

            Console.ReadLine();
        }

        public static async TaskCsharp<int> RandomAsync(int num)
        {
            var task = new Task<int>(() => new Random().Next(1000) * num);
            task.Start();
            int result = await task;
            return result;
        }
    }
}