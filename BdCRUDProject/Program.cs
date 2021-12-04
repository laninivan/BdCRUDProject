using System;
using System.Collections.Generic;
using System.Linq;

namespace BdCRUDProject
{
    class Program
    {

        static void interfaceStates()
        {
            Console.WriteLine("________________________________");
            Console.WriteLine("\t\t\tИнтерфейс");
            Console.WriteLine("________________________________");
            Console.WriteLine("0] Интерфейс");
            Console.WriteLine("1] Вывод работников");
            Console.WriteLine("2] Добавить работника");
            Console.WriteLine("3] Удалить работника по id");
            Console.WriteLine("4] Удалить работника по name");
            Console.WriteLine("5] Удалить работника по age");
            Console.WriteLine("6] Удалить работника по name и age");
            Console.WriteLine("7] Получить работника по id");
            Console.WriteLine("8] Получить работника по name");
            Console.WriteLine("9] Получить работника по age");
            Console.WriteLine("10] Получить работника по name и age");
            Console.WriteLine("11] Обновить данные работника");
            Console.WriteLine("12] Выход");
            Console.WriteLine("________________________________");

        }
        static void Main(string[] args)
        {

            ManagerDB mDB = new ManagerDB();
            int state = 0;
            
            interfaceStates();
            while (state!=12)
            {

                Console.Write("state: ");
                state=int.Parse(Console.ReadLine());
                Console.Clear();
                switch (state)
                {
                    case 0:
                        interfaceStates();
                        break;
                    case 1:
                        Console.WriteLine("Все работники:");
                        mDB.showAll();
                        break;
                    case 2:
                        Console.WriteLine("Добавить работника:");
                        Console.Write("\tsurname: ");
                        string surname = Console.ReadLine();
                        Console.Write("\tname: ");
                        string name = Console.ReadLine();
                        Console.Write("\tage: ");
                        int  age = int.Parse(Console.ReadLine());
                        Console.Write("\tmail: ");
                        string mail = Console.ReadLine();
                        mDB.addWorker(name,surname, age,mail);
                        break;
                    case 3:
                        Console.WriteLine("Удалить по id:");
                        Console.Write("id: ");
                         int id = int.Parse(Console.ReadLine());
                        mDB.removeByID(id);
                        break;
                    case 4:
                        Console.WriteLine("Удалить по name:");
                        Console.Write("name: ");
                        string namRemovee = Console.ReadLine();
                        mDB.removeByName(namRemovee);
                        break;
                    case 5:
                        Console.WriteLine("Удалить по age:");
                        Console.Write("age: ");
                        int ageremove = int.Parse(Console.ReadLine());
                        mDB.removeByAge(ageremove);
                        break;
                    case 6:
                        Console.WriteLine("Удалить по name и age:");
                        Console.Write("name: ");
                        string namRemovee2 = Console.ReadLine();
                        Console.Write("age: ");
                        int ageremove2 = int.Parse(Console.ReadLine());
                        mDB.removeByNameAndAge(namRemovee2, ageremove2);
                        break;
                    case 7:
                        Console.WriteLine("Получить по id:");
                        Console.Write("id: ");
                        int idSearch = int.Parse(Console.ReadLine());
                        Worker userSearch = mDB.findWorkerByID(idSearch);
                        Console.WriteLine($"{userSearch.Id}  {userSearch.Surname}   {userSearch.Name}    {userSearch.Age}   {userSearch.Mail} ");
                        break;
                    case 8:
                        Console.WriteLine("Получить по name:");
                        Console.Write("name: ");
                        string nameSearch = Console.ReadLine();
                        List<Worker>usersSearch=mDB.findWorkersByName(nameSearch);
                        foreach (Worker u in usersSearch)
                            Console.WriteLine($"{u.Id}.{u.Surname} - {u.Name} - {u.Age} - {u.Mail}");
                        break;
                    case 9:
                        Console.WriteLine("Получить по age:");
                        Console.Write("age: ");
                        int ageSearch = int.Parse(Console.ReadLine());
                        List<Worker> usersSearch2 = mDB.findWorkersByAge(ageSearch);
                        foreach (Worker u in usersSearch2)
                            Console.WriteLine($"{u.Id}.{u.Surname} - {u.Name} - {u.Age} - {u.Mail}");
                        break;
                    case 10:
                        Console.WriteLine("Получить по name и age:");
                        Console.Write("name: ");
                        string nameSearch3 = Console.ReadLine();
                        Console.Write("age: ");
                        int ageSearch3 = int.Parse(Console.ReadLine());
                        List<Worker> usersSearch3 = mDB.findWorkersByNameAndAge(nameSearch3, ageSearch3);
                        foreach (Worker u in usersSearch3)
                            Console.WriteLine($"{u.Id}.{u.Surname} - {u.Name} - {u.Age} - {u.Mail}");
                        break;
                    case 11:
                        Console.WriteLine("Изменить по по id:");
                        Console.Write("id: ");
                        int idAppdate = int.Parse(Console.ReadLine());

                        Console.Write("surname: ");
                        string surnamAppdate = Console.ReadLine();
                        Console.Write("name: ");
                        string namAppdate = Console.ReadLine();
                        Console.Write("age: ");
                        int ageAppdate = int.Parse(Console.ReadLine());
                        Console.Write("mail: ");
                        string mailAppdate = Console.ReadLine();
                        mDB.appdateById(idAppdate, surnamAppdate,namAppdate, ageAppdate, mailAppdate);
                        break;
                    case 12:
                        break;
                }



            }

        }
    }
}
