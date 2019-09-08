using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        DateTime date = new DateTime();

        public void AddNote(List<Note> notes)
        {
            number = SetNumber(number);
            description = SetDescrip(description);
            startDate = SetStartDate(date);
            endDate = SetEndDate(date, startDate);
            notes.Add(new Note(number, description, startDate, endDate));
        }

        public bool RemoveNote(List<Note> myList, int keySearch)
        {
            for (int i = 0; i < myList.Count; i++)
            {
                if (myList[i].number == keySearch)
                {
                    myList.Remove(myList[i]);
                    return true;
                }
            }
            return false;
        }

        public bool EditNote(List<Note> myList, int keySearch, int keyEdit)
        {
            for (int i = 0; i < myList.Count; i++)
            {
                if (myList[i].number == keySearch)
                {
                    switch (Convert.ToString(keyEdit))
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
