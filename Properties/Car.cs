using System;
using System.Threading;
using System.Xml.Linq;

public class Car
{
    public string brand { get; set; }
    public string model { get; set; }
    public double price { get; set; }
    public int amount { get; set; }

    public Car() { }

    public void Print()
    {
        Console.WriteLine($"Бренд машины:{brand}, модель:{model}, цена: {price}, количество: {amount}");

    }
}