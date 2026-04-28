using System;
using System.Collections.Generic;
using GoodsSales.Core.Model;

namespace GoodsSales.ConsoleApplication;

public class ConsoleView
{
    public int ShowMainMenu()
    {
        Console.Clear();
        Console.WriteLine("=== ГЛАВНОЕ МЕНЮ СИСТЕМЫ ПРОДАЖ ===");
        Console.WriteLine("1. Просмотр всех продаж (таблица)");
        Console.WriteLine("2. Отчет по количеству товаров");
        Console.WriteLine("3. Показать информацию о покупателе по id");
        Console.WriteLine("0. Выход");
        Console.WriteLine("====================================");
        Console.Write("Выберите действие: ");


        if (int.TryParse(Console.ReadLine(), out int choice))
        {
            return choice;
        }

        throw new ArgumentException("Невернный ввод");
    }


    public void ShowPersonDetails(Person? person)
    {
        if (person == null)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n[Ошибка] Покупатель с таким ID не найден в базе данных.");
            Console.ResetColor();
            return;
        }

        Console.WriteLine("\n======= ИНФОРМАЦИЯ О ПОКУПАТЕЛЕ =======");
        Console.WriteLine($"{"ID:",-15} {person.Id}");
        Console.WriteLine($"{"Фамилия:",-15} {person.LastName}");
        Console.WriteLine($"{"Имя:",-15} {person.FirstName}");

        Console.WriteLine($"{"Отчество:",-15} {person.Patronymic ?? "—"}");

        Console.WriteLine($"{"Дата рожд.:",-15} {person.DateOfBirth}");

        if (person.IsDeleted)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($"{"Статус:",-15} УДАЛЕН");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{"Статус:",-15} АКТИВЕН");
            Console.ResetColor();
        }

        Console.WriteLine("=======================================");
    }

    public void WaitForKey()
    {
        Console.WriteLine("\nНажмите любую клавишу, чтобы вернуться в меню...");
        Console.ReadKey();
    }


    public void ShowProductCount(List<ProductCount> productCounts)
    {
        foreach (var productCount in productCounts)
        {
            Console.WriteLine($"{productCount.Name,-30} | {productCount.QuantityInStock,10}");
        }
    }


    public void ShowTotalsSales(List<TotalSalesPerPerson> sales)
    {
        string header = $"{"ID",-5} | {"ФИО",-35} | {"Заказ",-7} | {"Кол-во",-7} | {"Сумма",-10}";
        string separator = new string('-', header.Length);

        Console.WriteLine("\nОТЧЕТ ПО ПРОДАЖАМ:");
        Console.WriteLine(separator);
        Console.WriteLine(header);
        Console.WriteLine(separator);

        foreach (var sale in sales)
        {
            string fullName = $"{sale.Person.LastName} {sale.Person.FirstName} {sale.Person.Patronymic}".Trim();

            Console.WriteLine(
                $"{sale.Person.Id,-5} | " +
                $"{fullName,-35} | " +
                $"{sale.SaleId,-7} | " +
                $"{sale.TotalItem,-7} | " +
                $"{sale.TotalPrice,8:C0}"
            );
        }

        Console.WriteLine(separator);
    }

    public int ShowInputIdHint()
    {
        Console.WriteLine($"\nВведите id покупателя: ");

        if (int.TryParse(Console.ReadLine(), out int choice))
        {
            return choice;
        }

        throw new ArgumentException("Неверный ввод");
    }

    public void ShowExitText()
    {
        Console.WriteLine("Завершение работы...");
    }

    public void ShowError()
    {
        Console.WriteLine("Ошибка: Неверный ввод. Попробуйте еще раз.");
    }
    
}