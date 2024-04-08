using System;using System.Collections.Generic;using System.IO;using System.Linq;using System.Linq.Expressions;using System.Xml.Serialization;using Patterns;namespace Patterns
{
        public interface ICommand
        {
            void Execute();
        }
     class Count_types: ICommand
        {
        public void Execute()
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(List<Car>));
            TextReader reader = new StreamReader("Car.xml");
            List<Car> AB = (List<Car>)deserializer.Deserialize(reader);
            reader.Close();
            var cars = from Car in AB
                            group Car by Car.brand into g
                            select new { brand = g.Key, Count = g.Count() }; 
            foreach (var car in cars)
            {
                Console.WriteLine($"{car.brand} : {car.Count}");
            }
        }
    }
            public class Count_all: ICommand
            {public void Execute()
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(List<Car>));
            TextReader reader = new StreamReader("Car.xml");
            List<Car> AB = (List<Car>)deserializer.Deserialize(reader);
            reader.Close();
            int E = AB.Sum(item => item.amount);
            Console.WriteLine($"Общее количество всех автомобилей {E}");
        }            }
    }
            class Average_price: ICommand
{
    public void Execute()
    {
        XmlSerializer deserializer = new XmlSerializer(typeof(List<Car>));
        TextReader reader = new StreamReader("Car.xml");
        List<Car> AB = (List<Car>)deserializer.Deserialize(reader);
        reader.Close();

        double E = AB.Average(item => item.price);
        Console.WriteLine($"Средняя цена автомобиля {E}");
    }
}
            class Average_price_type : ICommand
{
    public void Execute()
    {
        XmlSerializer deserializer = new XmlSerializer(typeof(List<Car>));
        TextReader reader = new StreamReader("Car.xml");
        List<Car> AB = (List<Car>)deserializer.Deserialize(reader);
        reader.Close();
        Console.WriteLine("Введите название бренда, среднюю стоимость автомобиля которого Вы хотите узнать");
        string J = Console.ReadLine();
        List<Car> newOne = AB.FindAll(item => item.brand == J);        
        double R = newOne.Average(item => item.price);
        Console.WriteLine($"Средняя стоимость автомобиля бренда {J} составляет {R}");
    }
}
            class Exit : ICommand
{
    public void Execute()
    { 
        Environment.Exit(0); 
    }
}
        class Receiver        {            public void Operation()            { }        }
class Invoker
{
    private ICommand command;
    public Invoker(ICommand command)
    {
        this.command = command;
    }
    public void ExecuteCommand()
    {
        this.command.Execute();
    }
}
class Singleton
{
    private Singleton() { }
    private static Singleton _instance;
    private static readonly object _lock = new object();
    public static Singleton GetInstance(string value)
    {
        if (_instance == null)
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new Singleton();
                    _instance.Value = value;
                }
            }
        }
        return _instance;
    }
    public string Value { get; set; }
}
public class Program
{
    public static void Main(String[] args)
    {
        var instance = Singleton.GetInstance("Добро пожаловать в виртуальный автопарк!");
        Console.WriteLine(instance.Value);
            List<Car> AB = new List<Car>();
            for (int i = 0; ; i++)
            {
                Car A = new Car();
                Console.WriteLine("Введите марку автомобиля");
                A.brand = Console.ReadLine();
                Console.WriteLine("Введите модель автомобиля");
                A.model = Console.ReadLine();
                Console.WriteLine("Введите стоимость одного автомобиля");
                A.price = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Введите количество автомобилей");
                A.amount = Convert.ToInt32(Console.ReadLine());
                AB.Add(A);

                XmlSerializer xmlSer = new XmlSerializer(typeof(List<Car>));
                using (FileStream fs = new FileStream("Car.xml", FileMode.Create))
                {
                    xmlSer.Serialize(fs, AB);
                }
                Console.WriteLine("Objects has been serialized");
                Console.WriteLine("Какую команду хотите выполнить: 1- ввести данные автомобиля, 2 - выполнить операцию");
                int Q = Convert.ToInt32(Console.ReadLine());
                if (Q == 1)
                {
                    continue;
                }
                else if (Q == 2)
                { }
            else
            {
                Console.WriteLine("Вы выбрали неверную операцию");
            }
            try
            {
                Console.WriteLine("Какую задачу Вы желаете выполнить: 1 - посчитать все автомобили в автопарке, " +
                        "2 - вычислить среднюю цену автомобиля, 3 - просмотреть, какие бренды автомобилей присутствуют и количество авто каждого бренда," +
                        "4 - среднюю стоимость автомобиля опред бренда, 5 - exit");
                int P = Convert.ToInt32(Console.ReadLine());
                if (P == 1)
                {
                    Stack<ICommand> commandHistory = new Stack<ICommand>();
                    ICommand command = new Count_all();
                    Invoker invoker = new Invoker(command);
                    invoker.ExecuteCommand();
                    commandHistory.Push(command);
                }
                else if (P == 2)
                {
                    Stack<ICommand> commandHistory = new Stack<ICommand>();
                    ICommand command = new Average_price();
                    Invoker invoker = new Invoker(command);
                    invoker.ExecuteCommand();
                    commandHistory.Push(command);
                }
                else if (P == 3)
                {
                    Stack<ICommand> commandHistory = new Stack<ICommand>();
                    ICommand command = new Count_types();
                    Invoker invoker = new Invoker(command);
                    invoker.ExecuteCommand();
                    commandHistory.Push(command);
                }
                else if (P == 4)
                {
                    Stack<ICommand> commandHistory = new Stack<ICommand>();
                    ICommand command = new Average_price_type();
                    Invoker invoker = new Invoker(command);
                    invoker.ExecuteCommand();
                    commandHistory.Push(command);
                }
                else if (P == 5)
                {
                    Stack<ICommand> commandHistory = new Stack<ICommand>();
                    ICommand command = new Exit();
                    Invoker invoker = new Invoker(command);
                    invoker.ExecuteCommand();
                    commandHistory.Push(command);
                }
                else
                {
                    throw new Exception("Вы выбрали неверную операцию");
                }
            }
            catch (Exception e) { Console.WriteLine($"Ошибка: {e.Message}"); }
        } }

        }
    
        
    

                                             