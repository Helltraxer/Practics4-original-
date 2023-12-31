﻿using System;
using System.Collections.Generic;
using System.Linq;

class Дата
{
    private int день;
    private int месяц;
    private int год;

    public Дата(int день, int месяц, int год)
    {
        if (ПроверитьКорректностьДата(день, месяц, год))
        {
            this.день = день;
            this.месяц = месяц;
            this.год = год;
        }
        else
        {
            throw new ArgumentException("Некорректная дата.");
        }
    }

    public int День => день;
    public int Месяц => месяц;
    public int Год => год;

    private bool ПроверитьКорректностьДата(int день, int месяц, int год)
    {
        if (год < 1 || месяц < 1 || месяц > 12 || день < 1)
            return false;

        int[] дниВМесяце = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

        if (месяц == 2 && (год % 4 == 0 && (год % 100 != 0 || год % 400 == 0)))
            return день <= 29;
        else
            return день <= дниВМесяце[месяц - 1];
    }
}

class Program
{
    static void Main()
    {
        List<Дата> даты = new List<Дата>
        {
            new Дата(5, 6, 2023),
            new Дата(15, 7, 2023),
            new Дата(27, 8, 2023),
            new Дата(7, 9, 2023),
            new Дата(18, 10, 2023),
            new Дата(12, 10, 2023),
            new Дата(15, 12, 2023)
        };

        // Запрос для выбора списка дат для заданного года:
        int заданныйГод = 2023;
        var датыЗаданногоГода = даты.Where(дата => дата.Год == заданныйГод);

        Console.WriteLine("Даты для года " + заданныйГод + ":");
        foreach (var дата in датыЗаданногоГода)
        {
            Console.WriteLine(дата.День + "." + дата.Месяц + "." + дата.Год);
        }

        // Запрос для выбора списка дат в заданном месяце:
        int заданныйМесяц = 8;
        var датыВЗаданномМесяце = даты.Where(дата => дата.Месяц == заданныйМесяц);

        Console.WriteLine("Даты в месяце " + заданныйМесяц + ":");
        foreach (var дата in датыВЗаданномМесяце)
        {
            Console.WriteLine(дата.День + "." + дата.Месяц + "." + дата.Год);
        }

        // Запрос для подсчета количества дат в определенном диапазоне:
        var начальнаяДата = new Дата(1, 8, 2023);
        var конечнаяДата = new Дата(30, 9, 2023);
        var количествоДатВДиапазоне = даты.Count(дата => дата.Год >= начальнаяДата.Год && дата.Год <=
конечнаяДата.Год &&
                                                         дата.Месяц >= начальнаяДата.Месяц && дата.Месяц <=
конечнаяДата.Месяц &&
                                                         дата.День >= начальнаяДата.День && дата.День <= конечнаяДата.День);

        Console.WriteLine("Количество дат в заданном диапазоне (от 01.08.2023 до 30.09.2023): " +
количествоДатВДиапазоне);

        // Запрос для нахождения максимальной даты:
        var максимальнаяДата = даты.Max(дата => дата.Год * 10000 + дата.Месяц * 100 + дата.День);
        var максимальнаяДатаОбъект = даты.First(дата => (дата.Год * 10000 + дата.Месяц * 100 + дата.День) ==
максимальнаяДата);

        Console.WriteLine("Максимальная дата: " + максимальнаяДатаОбъект.День + "." +
максимальнаяДатаОбъект.Месяц + "." + максимальнаяДатаОбъект.Год);

        // Запрос для нахождения первой даты для заданного дня (например, день 15):
        int заданныйДень = 15;
        var перваяДатаДляЗаданногоДня = даты.First(дата => дата.День == заданныйДень);

        Console.WriteLine("Первая дата для дня " + заданныйДень + ": " + перваяДатаДляЗаданногоДня.День + "."
+ перваяДатаДляЗаданногоДня.Месяц + "." + перваяДатаДляЗаданногоДня.Год);

        // Запрос для упорядочивания списка дат (хронологически):
        var упорядоченныеДаты = даты.OrderBy(дата => дата.Год * 10000 + дата.Месяц * 100 + дата.День);

        Console.WriteLine("Упорядоченные даты:");
        foreach (var дата in упорядоченныеДаты)
        {
            Console.WriteLine(дата.День + "." + дата.Месяц + "." + дата.Год);
        }
    }
}