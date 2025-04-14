
using System.Threading;
bool is_loading = true;
int percent = 0;
ThreadPool.QueueUserWorkItem(_ =>
{
    while (is_loading)
    {

        Console.Clear();
        Console.Write("Loading:[");
        int progress = percent / 5;
        Console.Write(new string('#', progress));
        Console.WriteLine($"]{percent}%");
        Console.WriteLine(":D");
        Thread.Sleep(3000);



    }
});
ThreadPool.QueueUserWorkItem(_ =>
{
    while (is_loading)
    {
        if (Console.KeyAvailable)
        {
            var key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.Escape)
            {
                is_loading = false;
                Console.WriteLine("\n Progress canceled... I wonder why:3 ?");
            }
        }
    }
});

for (int i = 0; i <= 100; i++)
{
    percent = i;
    Thread.Sleep(3000);
}
Console.WriteLine("weeeow... you made it through 100%");
is_loading = false;