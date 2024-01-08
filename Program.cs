// система автоизації користувачів
using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    // Клас, що представляє користувача
    class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }

        public User(string firstName, string lastName, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            Password = password;
        }
    }

    // Клас, що зберігає список користувачів
    class UserRepository
    {
        private List<User> users;

        public UserRepository()
        {
            users = new List<User>();
        }

        // Метод, що додає нового користувача до списку
        public void AddUser(User user)
        {
            users.Add(user);
        }

        // Метод, що перевіряє, чи існує користувач з заданим ім'ям та паролем
        public bool CheckUser(string firstName, string lastName, string password)
        {
            foreach (User user in users)
            {
                if (user.FirstName == firstName && user.LastName == lastName && user.Password == password)
                {
                    return true;
                }
            }
            return false;
        }
    }

    // Клас, що реалізує логіку програми
    class Program
    {
        static void Main(string[] args)
        {
            // Створюємо об'єкт класу UserRepository
            UserRepository userRepository = new UserRepository();
            int i = 0;
            while (i == 0) {
                // Виводимо привітання та інструкції
                Console.WriteLine("Вітаю в консольній програмі реєстрації та логіну користувачів!");
                Console.WriteLine("Введіть 1 щоб зареєструватися, 2 щоб увійти або 3 щоб вийти з програми.");

                // Зчитуємо вибір користувача
                string choice = Console.ReadLine();

                // Якщо користувач обрав 1, то запускаємо процес реєстрації
                if (choice == "1")
                {
                    Console.WriteLine("Введіть ваше ім'я:");
                    string firstName = Console.ReadLine();
                    Console.WriteLine("Введіть ваше прізвище:");
                    string lastName = Console.ReadLine();
                    Console.WriteLine("Введіть ваш пароль:");
                    string password = Console.ReadLine();

                    // Створюємо нового користувача з введеними даними
                    User newUser = new User(firstName, lastName, password);

                    // Додаємо користувача до репозиторію
                    userRepository.AddUser(newUser);

                    // Виводимо повідомлення про успішну реєстрацію
                    Console.WriteLine("Ви успішно зареєстровані!");
                }
                // Якщо користувач обрав 2, то запускаємо процес логіну
                else if (choice == "2")
                {
                    Console.WriteLine("Введіть ваше ім'я:");
                    string firstName = Console.ReadLine();
                    Console.WriteLine("Введіть ваше прізвище:");
                    string lastName = Console.ReadLine();
                    Console.WriteLine("Введіть ваш пароль:");
                    string password = Console.ReadLine();

                    // Перевіряємо, чи існує користувач з такими даними
                    bool isValid = userRepository.CheckUser(firstName, lastName, password);

                    // Якщо так, то виводимо повідомлення про успішний вхід
                    if (isValid)
                    {
                        Console.WriteLine("Ви успішно увійшли!");
                    }
                    // Якщо ні, то виводимо повідомлення про помилку
                    else
                    {
                        Console.WriteLine("Невірне ім'я або пароль!");
                    }
                }
                //якщо користувач обрав 3, то запускаємо процес виходу
                else if (choice == "3")
                {
                    Console.WriteLine("Ви вийшли з програми!");
                    break;
                }
                // Якщо користувач ввів щось інше, то виводимо повідомлення про неправильний вибір
                else
                {
                    Console.WriteLine("Неправильний вибір! Спробуйте ще раз.");
                }
            }
        }
    }
}
