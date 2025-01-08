namespace MyFirstConsoleApp
{
    internal class Program
    {
        enum WeekDays { One, Two, Three };
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            string[] sDays = { "Понедельник", "Вторник", "Среда" };
            WeekDays days = WeekDays.Two;
            days++;
            Console.WriteLine(days);
            Console.WriteLine(sDays[(int)days]);

            Console.ReadLine();
        }
    }
}
