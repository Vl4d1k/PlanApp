using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PlanApp
{
    class Program
    {
        const string menu =
                    "+---------------------------+" +
                    "\n+      Выбор операции:     +" +
                    "\n+--------------------------+" +
                    "\n+      1.Добавить задачу   +" +
                    "\n+      2.Удалить задачу    +" +
                    "\n+      3.Изменить задачу   +" +
                    "\n+      4.Сортировать по    +" +
                    "\n+         дате начала      +" +
                    "\n+      5.Показать задачи   +" +
                    "\n+      6.Сохранить задачи  +" +
                    "\n+      7.Загрузить задачи  +" +
                    "\n+      0.Выход             +" +
                    "\n+--------------------------+";
        const string menuforediting = "Выбор поля:" +
                            "\n1.Номер" +
                            "\n2.Описание" +
                            "\n3.Дата начала" +
                            "\n4.Дата конца";
        static void Main(string[] args)
        {
            //переменная поиска
            string keySearch;

            bool isEnable = false;
            
            NoteList menadger = new NoteList();
            List<Note> myList = new List<Note>();

            while (true)
            {
                Console.WriteLine(menu);
                string key = Console.ReadLine();
                switch (key)
                {
                    case "1":
                        Console.Clear();
                        menadger.AddNote(myList);
                        break;
                    case "2":
                        Console.Clear();
                        if (myList.Count == 0)
                        {
                            Console.WriteLine("Нет записей");
                            break;
                        }
                        Console.Write("Введите номер задачи: ");
                        keySearch = Console.ReadLine();
                        if (menadger.RemoveNote(myList, keySearch)) Console.WriteLine("Задача удалена");
                        else Console.WriteLine("Задача не найдена");
                        break;
                    case "3":
                        Console.Clear();
                        if (myList.Count == 0)
                        {
                            Console.WriteLine("Нет задач");
                            break;
                        }
                        Console.Write("Введите номер задачи: ");
                        keySearch = Console.ReadLine();
                        for (int i = 0; i < myList.Count; i++)
                        {
                            if (myList[i].number == Convert.ToInt32(keySearch))
                                isEnable = true;
                        }
                        if (isEnable)
                        {
                            Console.WriteLine(menuforediting);
                            string keyEdit = Console.ReadLine();
                            menadger.EditNote(myList, keySearch, keyEdit);
                            Console.WriteLine("Задача изменена");
                        }
                        else Console.WriteLine("Задача не найдена");
                        break;
                    case "4":
                        myList.Sort((Note nt1, Note nt2) => nt1.startDate.CompareTo(nt2.startDate));
                        break;
                    case "5":
                        Console.Clear();
                        if (myList.Count == 0)
                        {
                            Console.WriteLine("Нет записей");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                        for (int k = 0; k < myList.Count; k++)
                        {
                            Console.WriteLine("+-----------------------------------+");
                            Console.WriteLine("Номер: {0}", myList[k].number);
                            Console.WriteLine("Описание: {0}", myList[k].description);
                            Console.WriteLine("Дата начала: {0}", myList[k].startDate);
                            Console.WriteLine("Дата конца: {0}", myList[k].endDate);
                            Console.WriteLine("+-----------------------------------+");
                        }
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "6":
                        Console.Clear();
                        menadger.SaveNotes(myList);
                        Console.ReadKey();
                        break;
                    case "7":
                        Console.Clear();
                        menadger.LoadFromFile(ref myList);
                        Console.ReadKey();
                        break;
                    case "0": return;
                    default: Console.WriteLine("\nНет такого номера\n"); break;
                }
            }
        }
    }
}
