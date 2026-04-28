using System;
using GoodsSales.Core.Model;

namespace GoodsSales.ConsoleApplication;

public class ConsoleView
{
    public int ShowMen()
    {
        Console.WriteLine("1. Остаток товаров на складе\n 2. Суммарные продажи ");

        var userInput = Convert.ToInt32(Console.ReadLine());
        return userInput;
    }


    public void ShowProductCount(ProductCount productCount)
    {
        Console.WriteLine("Остаток товара на складе: ");
    }


    public void ShowTotalsSales(TotalSalesPerPerson totalSalesPerPerson)
    {
        Console.WriteLine("Суммарные продажи:");
    }
}