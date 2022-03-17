using System;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Xml.Linq;
using System.Xml;
using System.IO.Compression;
using System.Collections;


namespace Неговора_Александра_Сергеевна_1_БББО_05_20
{
    class Program
    {
        static int GetInput(string output)
        {
            bool goodInput = true;
            int mode = 1;
            do
            {
                try
                {
                    Console.Write(output);
                    mode = Convert.ToInt32(Console.ReadLine());
                    if (mode < 1 || mode > 5)
                    {
                        throw new ArgumentException();
                    }
                    goodInput = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Это не похоже на необходимое число( попробуй снова");
                    goodInput = false;
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Введите натуральное не превышающее 5!");
                    goodInput = false;
                }
            }
            while (!goodInput);

            return mode;
        }

        static void Main(string[] args)
        {
            while (true)
            {


                int mode = GetInput("Введите режим работы от 1 до 5: ");
                switch (mode)
                {
                    case 1:
                        Program1.Run();
                        break;
                    case 2:
                        Program2.Run();
                        break;
                    case 3:
                        Program3.Run();
                        break;
                    case 4:
                        Program4.Run();
                        break;
                    case 5:
                        Program5.Run();
                        break;

                }
            }

        }
    }

    class Program1 //файл
    {
        static public void Run()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();

            foreach (DriveInfo drive in drives)
            {
                Console.WriteLine($"Название: {drive.Name} байт.");
                Console.WriteLine($"Общий размер: {drive.TotalSize} байт.");
                Console.WriteLine($"Тип файловой системы: {drive.DriveFormat} байт.");
                Console.WriteLine($"Метка: {drive.VolumeLabel}");
            }
        }
    }

    class Program2
    {
        static public void WriteStringToFileAndRead(string fileName, string str)
        {
            try
            {
                using (FileStream fs = File.Create(fileName))
                {
                    
                    byte[] info = new UTF8Encoding(true).GetBytes(str);
                    fs.Write(info, 0, info.Length);
                }

                using (StreamReader sr = File.OpenText(fileName))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(s);
                    }
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine("Что-то пошло не так");
            }
        }
        static public void Run()
        {
            Console.WriteLine("Введите строку");
            string toWrite = Console.ReadLine();
            WriteStringToFileAndRead("newFile.txt", toWrite);
        }
    }

    class Program3 //JSON
    {
        private static readonly int O_MY_GOD = 2;

        static public void SimulateProccess(string firstToWrite, int howManyDots, float loadingLenght)
        {
            DateTime now = DateTime.Now; 

            int dotCount = 0;
            Console.Write(firstToWrite);
            while (DateTime.Now - now < TimeSpan.FromSeconds(loadingLenght))
            {

                for (int i = 0; i < dotCount % (howManyDots + 1); i++)
                {
                    Console.Write("\b \b");
                }

                dotCount++;
                for (int i = 0; i < dotCount % (howManyDots + 1); i++)
                {
                    Console.Write(".");
                }
                Thread.Sleep(300);
            }
        }
        static public void Run()
        {
            SimulateProccess("Созданиe экземпляров класса ", 3, O_MY_GOD);
            Console.WriteLine();

            ABCD Jesus = new ABCD("Jesus", new string[3] { "lamb of god", "wine god", "god-man" }, new string[1] { "great martyr"}, 0, new string[1] { "in the name of the father, the son and the holy spirit" });
            string jsonString = JsonSerializer.Serialize(Jesus);

            SimulateProccess("Создание файла", 3, 1);
            Console.WriteLine();
            SimulateProccess("Сериализация объекта и запись в ABCD.txt", 3, 1);
            Console.WriteLine();
            Program2.WriteStringToFileAndRead("ABCD.txt", jsonString);
            SimulateProccess("Запись выполнена!", 0, 0.5f);
            Console.WriteLine();
            SimulateProccess("Удаление файла", 3, 2);
            Console.WriteLine();
            File.Delete("ABCD.txt");
            Console.WriteLine("Файл удален!");


        }
    }

    class ABCD 
    {
        //properties
        public string _name { get; set; }
        public string[] _alias { get; set; }
        public string[] _species { get; set; }
        public int _age { get; set; }
        public string[] _slogan { get; set; }

        //constructor
        public ABCD(string name, string[] alias, string[] species, byte age, string[] slogan)
        {
            _name = name;
            _alias = alias;
            _species = species;
            _age = age;
            _slogan = slogan;
        }

    }


    class Program4 //XML
    {
        static private string fileName = "XmlDocument.xml";

        static private void AddUser(string name, string age, string color)
        {
            using (FileStream fs = File.Create(fileName)) //инициализация
            { }

            XElement xUser = new XElement("user");
            xUser.Add(new XAttribute("name", name));

            XElement xAge = new XElement("age", age);
            xUser.Add(xAge);

            XElement xColor = new XElement("color", color);
            xUser.Add(xColor);

            XDocument xDoc = new XDocument(new XElement("users", xUser));
            xDoc.Save(fileName);
        }

        static private void RedLines(string filename)
        {
            using (StreamReader sr = File.OpenText(filename))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    Console.WriteLine(s);
                }
            }
        }


        static public void Run()
        {
            Console.WriteLine("Добавление пользователей в систему");
            Console.Write("Введите имя пользователя: ");
            string name = Console.ReadLine();
            Console.Write("Введите возраст пользователя: ");
            string age = Console.ReadLine();
            Console.Write("Введите ваш никнейм: ");
            string color = Console.ReadLine();

            AddUser(name, age, color);
            RedLines(fileName);

            Program3.SimulateProccess("Удаление файла", 3, 1);
            Console.WriteLine();
            File.Delete(fileName);

        }
    }

    class Program5 //ZIP архивы
    {
        static public string directoryPath = "Folder";
        static public string archivePath = "Folder.zip";
        static public string fileName = "file.txt";
        static public string newFile = "newFile.txt";
        static public void Run()
        {
            if (Directory.Exists(directoryPath))
            {
                Directory.Delete(directoryPath);
            }

            if (File.Exists(archivePath))
            {
                File.Delete(archivePath);
            }


            Directory.CreateDirectory(directoryPath);
            CreateArchive();
            AddFileToArchive();
            ReArchiveFile();
        }

        static public void DeleteAll()
        {
            File.Delete(archivePath);
            File.Delete(fileName);
        }

        static public void ReArchiveFile()
        {
            using (FileStream fs = new FileStream($@"{archivePath}", FileMode.Open))
            {
                using (ZipArchive archive = new ZipArchive(fs, ZipArchiveMode.Read))
                {
                    ZipArchiveEntry entry = archive.GetEntry(fileName);
                    using (StreamReader sr = new StreamReader(entry.Open()))
                    {

                        using (StreamWriter sw = new StreamWriter(newFile))
                        {
                            sw.Write(sr.ReadToEnd());
                        }
                    }
                    Console.WriteLine($"Имя файла: {entry.Name}");
                    Console.WriteLine($"Размер файла: {entry.Length}");
                    Console.WriteLine($"Расположение файла: {entry.FullName}");
                }
            }
        }
        static public void AddFileToArchive()
        {
            using (FileStream fs = new FileStream($@"{archivePath}", FileMode.Open))
            {

                using (ZipArchive zip = new ZipArchive(fs, ZipArchiveMode.Update))
                {
                    ZipArchiveEntry entry = zip.CreateEntry(fileName);
                    using (StreamWriter sw = new StreamWriter(entry.Open()))
                    {
                        string data = File.ReadAllText($@"{fileName}");
                        sw.Write(data);

                    }
                }

            }
        }
        static public void CreateArchive()
        {
            ZipFile.CreateFromDirectory(directoryPath, archivePath);

        }

    }
}





