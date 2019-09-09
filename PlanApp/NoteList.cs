using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PlanApp
{
    class NoteList
    {
        //переменная для хранения номера
        int number = 0;
        //переменная для хранения описания
        string description = "";
        //переменная для хранения даты начала
        DateTime startDate;
        //переменная для хранения даты окончания
        DateTime endDate;
        readonly DateTime date = new DateTime();

        public void AddNote(List<Note> notes)
        {
            number = SetNumber(number);
            description = SetDescrip(description);
            startDate = SetStartDate(date);
            endDate = SetEndDate(date, startDate);
            notes.Add(new Note(number, description, startDate, endDate));
        }

        public void SaveNotes(List<Note> myList)
        {
            BinaryFormatter bf = new BinaryFormatter();
            string fileName = "myNotes";
            var FileName = Directory.GetCurrentDirectory() + "/" + fileName;
            using (FileStream fstream = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                bf.Serialize(fstream, myList);
                Console.WriteLine("Список сохранен");
                return;
            }
        }
        public void LoadFromFile(ref List<Note> myList)
        {
            BinaryFormatter bf = new BinaryFormatter();
            string fileName = "myNotes";
            var FileName = Directory.GetCurrentDirectory() + "/" + fileName;
            using (var fstream = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                myList = (List<Note>)bf.Deserialize(fstream) ?? throw new Exception("Файл пуст");
                Console.WriteLine("Список загружен");
                return;
            }

        }

        public bool RemoveNote(List<Note> myList, string keySearch)
        {
            for (int i = 0; i < myList.Count; i++)
            {
                if (myList[i].number == Convert.ToInt32(keySearch))
                {
                    myList.Remove(myList[i]);
                    return true;
                }
            }
            return false;
        }

        public bool EditNote(List<Note> myList, string keySearch, string keyEdit)
        {
            for (int i = 0; i < myList.Count; i++)
            {
                if (myList[i].number == Convert.ToInt32(keySearch))
                {
                    switch (keyEdit)
                    {
                        case "1":
                            myList[i].number = SetNumber(number);
                            break;
                        case "2":
                            myList[i].description = SetDescrip(description);
                            break;
                        case "3":
                            myList[i].startDate = SetStartDate(date);
                            break;
                        case "4":
                            myList[i].endDate = SetEndDate(date, startDate);
                            break;
                        default: Console.WriteLine("\nНет такого номера\n"); break;
                    }
                    return true;
                }
            }
            return false;
        }

        public static DateTime SetStartDate(DateTime date)
        {
            while (true)
            {
                try
                {
                    Console.Write("Введите дату начала задачи(dd.mm.yyyy hh:mm:ss): ");
                    date = Convert.ToDateTime(Console.ReadLine());
                    if (date < DateTime.Now) throw new Exception("Неверная дата. Дата должна быть больше текущей. Попробуйте еще раз!");
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }
            return date;
        }

        public static DateTime SetEndDate(DateTime date, DateTime startDate)
        {
            while (true)
            {
                try
                {
                    Console.Write("Введите дату конца задачи(dd.mm.yyyy hh:mm:ss): ");
                    date = Convert.ToDateTime(Console.ReadLine());
                    if (date < DateTime.Now) throw new Exception("Неверная дата. Дата должна быть больше текущей. Попробуйте еще раз!");
                    if (date < startDate) throw new Exception("Неверная дата. Дата должна быть больше даты начала задачи. Попробуйте еще раз!");
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }
            return date;
        }

        public static int SetNumber(int num)
        {
            while (true)
            {
                try
                {
                    Console.Write("Введите номер задачи: ");
                    num = int.Parse(Console.ReadLine());
                    if (num < 0 || num == 0) throw new Exception("Неверный ввод. Попробуйте еще раз!");
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }
            return num;
        }

        public static string SetDescrip(string des)
        {
            while (true)
            {
                try
                {
                    Console.Write("Введите описание задачи: ");
                    des = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(des)) throw new Exception("Описание не должно быть пустым. Введите еще раз!");
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }
            return des;
        }
    }
}
