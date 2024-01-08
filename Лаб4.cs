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

        // Метод, що видаляє користувача зі списку за індексом
        public void RemoveUser(int index)
        {
            users.RemoveAt(index);
        }

        // Метод, що оновлює дані користувача за індексом
        public void UpdateUser(int index, User user)
        {
            users[index] = user;
        }

        // Метод, що повертає список користувачів
        public List<User> GetUsers()
        {
            return users;
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

            // Виводимо привітання
            Console.WriteLine("Вітаю в консольній програмі для авторизації користувачів!");

            // Створюємо змінну для зберігання вибору користувача
            string choice;

            // Створюємо безкінечний цикл для відображення меню
            while (true)
            {
                // Виводимо інструкції
                Console.WriteLine("Введіть 1, щоб зареєструватися, 2, щоб увійти, 3, щоб вийти з програми.");

                // Зчитуємо вибір користувача
                choice = Console.ReadLine();

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

                        // Виводимо список користувачів
                        Console.WriteLine("Список користувачів:");
                        List<User> users = userRepository.GetUsers();
                        for (int i = 0; i < users.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {users[i].FirstName} {users[i].LastName}");
                        }

                        // Виводимо інструкції для роботи з елементами
                        Console.WriteLine("Введіть 1, щоб додати нового користувача, 2, щоб видалити користувача, 3, щоб оновити дані користувача, 4, щоб повернутися до головного меню.");

                        // Зчитуємо вибір користувача
                        string action = Console.ReadLine();

                        // Якщо користувач обрав 1, то запускаємо процес додавання нового користувача
                        if (action == "1")
                        {
                            Console.WriteLine("Введіть ім'я нового користувача:");
                            string newFirstName = Console.ReadLine();
                            Console.WriteLine("Введіть прізвище нового користувача:");
                            string newLastName = Console.ReadLine();
                            Console.WriteLine("Введіть пароль нового користувача:");
                            string newPassword = Console.ReadLine();

                            // Створюємо нового користувача з введеними даними
                            User newUser = new User(newFirstName, newLastName, newPassword);

                            // Додаємо користувача до репозиторію
                            userRepository.AddUser(newUser);

                            // Виводимо повідомлення про успішне додавання
                            Console.WriteLine("Новий користувач доданий!");
                        }
                        // Якщо користувач обрав 2, то запускаємо процес видалення користувача
                        else if (action == "2")
                        {
                            Console.WriteLine("Введіть номер користувача, якого ви хочете видалити:");
                            int index = int.Parse(Console.ReadLine()) - 1;

                            // Видаляємо користувача з репозиторію за індексом
                            userRepository.RemoveUser(index);

                            // Виводимо повідомлення про успішне видалення
                            Console.WriteLine("Користувач видалений!");
                        }
                        // Якщо користувач обрав 3, то запускаємо процес оновлення даних користувача
                        else if (action == "3")
                        {
                            Console.WriteLine("Введіть номер користувача, дані якого ви хочете оновити:");
                            int index = int.Parse(Console.ReadLine()) - 1;

                            Console.WriteLine("Введіть нове ім'я користувача:");
                            string newFirstName = Console.ReadLine();
                            Console.WriteLine("Введіть нове прізвище користувача:");
                            string newLastName = Console.ReadLine();
                            Console.WriteLine("Введіть новий пароль користувача:");
                            string newPassword = Console.ReadLine();

                            // Створюємо нового користувача з введеними даними
                            User newUser = new User(newFirstName, newLastName, newPassword);

                            // Оновлюємо дані користувача в репозиторії за індексом
                            userRepository.UpdateUser(index, newUser);

                            // Виводимо повідомлення про успішне оновлення
                            Console.WriteLine("Дані користувача оновлені!");
                        }
                        // Якщо користувач обрав 4, то повертаємося до головного меню
                        else if (action == "4")
                        {
                            Console.WriteLine("Повернення до головного меню.");
                        }
                        // Якщо користувач ввів щось інше, то виводимо повідомлення про неправильний вибір
                        else
                        {
                            Console.WriteLine("Неправильний вибір! Спробуйте ще раз.");
                        }
                    }
                    // Якщо ні, то виводимо повідомлення про помилку
                    else
                    {
                        Console.WriteLine("Невірне ім'я або пароль!");
                    }
                }
                // Якщо користувач обрав 3, то виходимо з програми
                else if (choice == "3")
                {
                    Console.WriteLine("До побачення!");
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