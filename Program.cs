using System;
using System.Linq;
class LINQ
{
    static void Main()
    {
        string[] months = new string[]
        {
            "June", "July", "May", "December", "January", "February",
            "March", "April", "August", "September", "October", "November"
        };

        // Запрос для выбора месяцев с длиной строки равной n (например, 5):
        int n = 5;
        var monthsWithLengthN = months.Where(month => month.Length == n);

        Console.WriteLine("Месяцы с длиной строки равной " + n + ":");
        foreach (var month in monthsWithLengthN)
        {
            Console.WriteLine(month);
        }

        // Запрос для выбора только летних и зимних месяцев:
        var summerAndWinterMonths = months.Where(month =>
            month == "June" || month == "July" || month == "August" || month == "December" || month == "January" ||
month == "February");

        Console.WriteLine("Летние и зимние месяцы:");
        foreach (var month in summerAndWinterMonths)
        {
            Console.WriteLine(month);
        }

        // Запрос для вывода месяцев в алфавитном порядке:
        var sortedMonths = months.OrderBy(month => month);

        Console.WriteLine("Месяцы в алфавитном порядке:");
        foreach (var month in sortedMonths)
        {
            Console.WriteLine(month);
        }

        // Запрос для подсчета месяцев, содержащих букву "u" и длиной имени не менее 4-х:
        var monthsWithU = months.Where(month => month.Contains("u") && month.Length >= 4).Count();

        Console.WriteLine("Количество месяцев, содержащих 'u' и длиной не менее 4-х: " + monthsWithU);
    }
}