using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BdCRUDProject
{
    class ManagerDB
    {
        public void showAll()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                List<Worker> users = db.workers.ToList();

                foreach (Worker u in users)
                {
                    Console.WriteLine($"{u.Id}.{u.Surname} - {u.Name} - {u.Age} - {u.Mail}");
                }
            }
        }

        public void addWorker(string name, string surname, int age, string mail)
        {
            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    Worker worker = new Worker { Name = name, Surname=surname, Age = age, Mail=mail};

                    db.workers.Add(worker);
                    db.SaveChanges();
                }
            }
            catch
            {
                Console.WriteLine("(!) Не допустимые для заполнения таблицы поля");
            }

        }

        public Worker findWorkerByID(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                try
                {
                    Worker findUser = db.workers.Find(id);
                    return findUser;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("(!) пользователя с данным id не существует.");
                    return new Worker();
                }

            }
        }

        public List<Worker> findWorkersByName(string name)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                try
                {
                    return db.workers.Where(x => x.Name == name).ToList();

                }
                catch (Exception ex)
                {
                    Console.WriteLine("(!) пользователя с данным name не существует.");
                    return new List<Worker>();
                }

            }
        }

        public List<Worker> findWorkersByAge(int age)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                try
                {
                    return db.workers.Where(x => x.Age == age).ToList();

                }
                catch (Exception ex)
                {
                    Console.WriteLine("(!) Работникка с данным age не существует.");
                    return new List<Worker>();
                }
            }
            
        }

        public List<Worker> findWorkersByNameAndAge(string name, int age)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                try
                {
                    return db.workers.Where(x => x.Name == name && x.Age == age).ToList();

                }
                catch (Exception ex)
                {
                    Console.WriteLine("(!) пользователя с данным age не существует.");
                    return new List<Worker>();
                }
            }
        }

        public void removeByID(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                try
                {
                    db.Remove(findWorkerByID(id));
                    db.SaveChanges();
                }
                catch (Exception ex) { }
            }
        }

        public void removeByName(string name)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                try
                {
                    db.RemoveRange(findWorkersByName(name));
                    db.SaveChanges();
                }
                catch (Exception ex) { }
            }
        }

        public void removeByAge(int age)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                try
                {
                    db.RemoveRange(findWorkersByAge(age));
                    db.SaveChanges();
                }
                catch (Exception ex) { }
            }
        }

        public void removeByNameAndAge(string name, int age)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                try
                {
                    db.RemoveRange(findWorkersByNameAndAge(name, age));
                    db.SaveChanges();
                }
                catch (Exception ex) { }
            }
        }

        public void appdateById(int id, string surname,string name, int age, string mail)
        {
            using (ApplicationContext db = new ApplicationContext())
            {             
                    try
                    {
                    db.workers.Where(b => b.Id == id).FirstOrDefault().Surname = surname;
                    db.workers.Where(b => b.Id == id).FirstOrDefault().Name = name;
                    db.workers.Where(b => b.Id == id).FirstOrDefault().Age = age;
                    db.workers.Where(b => b.Id == id).FirstOrDefault().Mail = mail;
                    db.SaveChanges();
                     }
                    catch (Exception ex) { }
            }
        }

    }





}
