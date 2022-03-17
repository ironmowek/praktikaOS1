using System;
using System.IO;


    int Number;
    Number = 0;
    Console.WriteLine("Введите число: ");
    Number = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Вы ввели Number: {0}", Number);

    //if (Number == 1)


namespace HelloApp

{
    class Program
    {
        static void Main(string[] args)
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives)
            {
                Console.WriteLine($"Название: {drive.Name}");
                Console.WriteLine($"Тип: {drive.DriveType}");

                if (drive.IsReady)
                {
                    Console.WriteLine($"Объем диска: {drive.TotalSize}");
                    Console.WriteLine($"Свободное пространство: {drive.TotalFreeSpace}");
                    Console.WriteLine($"Метка: {drive.VolumeLabel}");
                }
                Console.WriteLine();
            }
        }
    }
}
 