using ConsoleApp9.Models;
using ConsoleApp9.Models.Activity;
using ConsoleApp9.Models.EF;
using ConsoleApp9.Models.Interfaces;
using ConsoleApp9.Models.Product;
using ConsoleApp9.Models.User;
using ConsoleApp9.Sort;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace ConsoleApp9.Menu
{
    public class MenuPanel
    {
        UserProfile currentUser;
        List<BaseActivity> currentActivities = new List<BaseActivity>();
        UserProfile CreateUser(string nickName)
        {
            string name;
            double height, weight, wishWeight;
            Console.WriteLine("Введiть iм'я: ");
            name = Console.ReadLine();
            Console.WriteLine("Введiть зрiст: ");
            height = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введiть вагу: ");
            weight = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введiть бажану вагу: ");
            wishWeight = Convert.ToDouble(Console.ReadLine());
            return new UserProfile(name, nickName, height, weight, wishWeight);
        }

        ActivityDatabase db;
        public MenuPanel(ActivityDatabase db)
        {
            this.db = db;
        }

        void MenuTable()
        {
            while (true)
            {
                int choosen;
                Console.WriteLine("\n\n\n");
                Console.WriteLine("Введiть 1, щоб перевiрити поточний профiль\nВведiть 2, щоб додати сьогоднiшню фiзичну вправу\nВведiть 3, щоб перевiрити статистику журналу про минулу активнiсть\nВведiть 4, щоб створити статистику щодо сьогоднiшньої активностi\nВведiть 5, щоб зупинити запущену програму\nВаш вибiр:");
                choosen = Convert.ToInt32(Console.ReadLine());
                switch (choosen)
                {
                    case 1:
                        {
                            Console.WriteLine(currentUser);
                            Console.WriteLine();
                            break;
                        }
                    case 2:
                        {
                            int id;
                            Console.WriteLine("Введiть ID активностi:\nId: 1. Пiдтягування\nId: 2. Пiдняття ваги\nId: 3. Бiг\nId: 4. Ходьба\nId: 5. Плавання\nId: 6. Гiмнастика\nId: 7. Йога");
                            Console.WriteLine("Ваш вибiр: ");
                            id = Convert.ToInt32(Console.ReadLine());
                            switch (id)
                            {
                                case 1:
                                    {
                                        int amount;
                                        double height;
                                        Console.WriteLine("Введiть кiлькiсть пiдтягувань: ");
                                        amount = Convert.ToInt32(Console.ReadLine());
                                        Console.WriteLine("Введiть висоту пiдтягувань: ");
                                        height = Convert.ToDouble(Console.ReadLine());
                                        currentActivities.Add(new PullUps(45, amount, height));
                                        break;
                                    }
                                case 2:
                                    {
                                        int durationSecond;
                                        Console.WriteLine("Введiть тривалість активностi(секунди): ");
                                        durationSecond = Convert.ToInt32(Console.ReadLine());
                                        currentActivities.Add(new BaseActivity("Пiдняття ваги", durationSecond));
                                        break;
                                    }
                                case 3:
                                    {
                                        int durationSecond, steps;
                                        double speed;
                                        Console.WriteLine("Введiть тривалiсть активностi(секунди): ");
                                        durationSecond = Convert.ToInt32(Console.ReadLine());
                                        Console.WriteLine("Введiть швидкiсть бiгу: ");
                                        speed = Convert.ToDouble(Console.ReadLine());
                                        Console.WriteLine("Ввести кiлькiсть пройдених крокiв: ");
                                        steps = Convert.ToInt32(Console.ReadLine());
                                        currentActivities.Add(new Run(durationSecond, speed , steps));
                                        break;
                                    }
                                case 4:
                                    {

                                        int durationSecond, amountSteps;
                                        double speed;
                                        Console.WriteLine("Введiть тривалiсть активностi(секунди): ");
                                        durationSecond = Convert.ToInt32(Console.ReadLine());
                                        Console.WriteLine("Введiть швидкiсть ходьби: ");
                                        speed = Convert.ToDouble(Console.ReadLine());
                                        Console.WriteLine("Ввести кiлькiсть крокiв");
                                        amountSteps = Convert.ToInt32(Console.ReadLine());
                                        currentActivities.Add(new Walking(durationSecond , speed, amountSteps));

                                        break;
                                    }
                                case 5:
                                    {
                                        int durationSecond;
                                        Console.WriteLine("Введiть тривалiсть активностi(секунди): ");
                                        durationSecond = Convert.ToInt32(Console.ReadLine());
                                        currentActivities.Add(new BaseActivity("Плавання", durationSecond));
                                        break;
                                    }
                                case 6:
                                    {
                                        int durationSecond;
                                        Console.WriteLine("Введiть тривалiсть активностi(секунди): ");
                                        durationSecond = Convert.ToInt32(Console.ReadLine());
                                        currentActivities.Add(new BaseActivity("Гiмнастика", durationSecond));
                                        break;
                                    }
                                case 7:
                                    {
                                        int durationSecond;
                                        Console.WriteLine("Введiть тривалiсть активностi(секунди): ");
                                        durationSecond = Convert.ToInt32(Console.ReadLine());
                                        currentActivities.Add(new BaseActivity("Йога", durationSecond));
                                        break;
                                    }
                            }
                            break;
                        }
                    case 3:
                        {
                            foreach (var unit in db.TrainingUnits.Include(x => x.Actives))
                            {
                                if(unit.User.Id == currentUser.Id)
                                {
                                    Console.WriteLine(unit);
                                }
                            }
                            break;
                        }
                    case 4:
                        {
                            List<EatenProduct> productsByDay = new List<EatenProduct>();
                            Console.WriteLine("Позначте продукти, якi ви їсте сьогоднi.\nВведiть iдентифiкатор продукту, щоб додати його. якщо ви хочете вийти з програми, введiть -1");
                            int id;
                            double grams;
                            Console.WriteLine("Всi продукти: ");
                            foreach (var item in db.Products.ToList())
                            {
                                Console.WriteLine(item);
                            }
                            while (true)
                            {
                                Console.WriteLine("Введiть id: ");
                                id = Convert.ToInt32(Console.ReadLine());
                                if (id == -1)
                                {
                                    break;
                                }
                                Console.WriteLine("Введiть грами з'їденого продукту: ");
                                grams = Convert.ToDouble(Console.ReadLine());
                                productsByDay.Add(new EatenProduct(id, grams));
                            }
                            var temp = new TrainingUnit(DateTime.Now, currentUser, currentActivities);
                            temp.CalculateCaloriesByDay(productsByDay, db.Products.ToList());
                            db.TrainingUnits.Add(temp);
                            db.SaveChanges();
                            Console.WriteLine(temp);
                            break;
                        }
                    case 5:
                        return;
                }
            }
        }

        public void StartMenu()
        {
            string nickName;
            List<UserProfile> users;
            Console.WriteLine("Введiть ваш нiкнейм: ");
            nickName = Console.ReadLine();  
            if(db.Users.ToList().Count != 0)
            {
                users = db.Users.Where(x => x.NickName == nickName).ToList();
                if (users.Count == 0)
                {
                    db.Users.Add(CreateUser(nickName));
                    Console.WriteLine("Додано");
                }
            }
            else
            {
                db.Users.Add(CreateUser(nickName));
                Console.WriteLine("Додано");
            }
            db.SaveChanges();
            currentUser = db.Users.Where(x => x.NickName == nickName).First();
            Console.WriteLine("\nПоточний юзер:");
            Console.WriteLine(currentUser);
            MenuTable();
        }
    }
}
