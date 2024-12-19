class Program
{
    static void Main()
    {
        Console.OutputEncoding=System.Text.Encoding.UTF8;
        Console.Write("Введіть годину: ");
        int hour = int.Parse(Console.ReadLine());
        Console.Write("Введіть хвилини: ");
        int minute = int.Parse(Console.ReadLine());
        Console.Write("Введіть секунди: ");
        int second = int.Parse(Console.ReadLine());

        MyTime userTime = new MyTime(hour, minute, second);
        Console.WriteLine("Введений час: " + userTime.ToString());

        int secondsSinceMidnight = userTime.TimeSinceMidnight();
        Console.WriteLine("Кількість секунд від початку доби: " + secondsSinceMidnight);
               
        MyTime timeFromSeconds = MyTime.TimeSinceMidnight(secondsSinceMidnight);
        Console.WriteLine("Час з кількості секунд: " + timeFromSeconds.ToString());
                
        userTime.AddOneSecond();
        Console.WriteLine("Час після додавання однієї секунди: " + userTime.ToString());
        
        userTime.AddOneMinute();
        Console.WriteLine("Час після додавання однієї хвилини: " + userTime.ToString());
                
        userTime.AddOneHour();
        Console.WriteLine("Час після додавання однієї години: " + userTime.ToString());
                
        Console.Write("Введіть кількість секунд для додавання: ");
        int additionalSeconds = int.Parse(Console.ReadLine());
        userTime.AddSeconds(additionalSeconds);
        Console.WriteLine("Час після додавання секунд: " + userTime.ToString());
        
        Console.Write("Введіть годину для другого часу: ");
        int hour2 = int.Parse(Console.ReadLine());
        Console.Write("Введіть хвилини для другого часу: ");
        int minute2 = int.Parse(Console.ReadLine());
        Console.Write("Введіть секунди для другого часу: ");
        int second2 = int.Parse(Console.ReadLine());

        MyTime userTime2 = new MyTime(hour2, minute2, second2);
        int difference = MyTime.Difference(userTime, userTime2);
        Console.WriteLine("Різниця між введеними часами в секундах: " + difference);
      
        string lesson = userTime.WhatLesson();
        Console.WriteLine("Поточний урок: " + lesson);
    }
}
