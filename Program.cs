using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

using static MUP_CS.Program;

namespace MUP_CS
{
    internal class Program
    {
        static int determine_file_size(string file_name)
        {
            if (File.Exists(file_name) == false)
            {
                File.Create(file_name).Close();
            }

            FileInfo fileinfo = new FileInfo(file_name);
            int size = (int)fileinfo.Length;
            return size;
        }
        static int get_users_info(string file_name, string input_data)
        {
            string[] lines = File.ReadAllLines("C:\\Users\\Руслан\\source\\repos\\MUP_CS\\users_data.txt");

            string[,] str = new string[lines.Length, lines[0].Split(' ').Length];
            for (int i = 0; i < lines.Length; i++)
            {
                string[] temp = lines[i].Split(' ');
                for (int j = 0; j < temp.Length; j++)
                {
                    str[i, j] = temp[j];
                }

            }

            for (int i = 0; i < lines.GetLength(0); i++)
            {
                if (input_data == str[i, 1])
                {
                    return 0;
                }
            }
            return 1;
        }
        static bool input_validation_mail(string received_data, int length_data)
        {
            string Base = "@abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789.";
            string[] platform = { "mail.ru", "gmail.com", "yandex.ru", "rambler.com" };

            for (int i = 0; i < length_data; i++)
            {
                for (int j = 0; j < 64; j++)
                {

                    if (received_data[i] == Base[j])
                    {
                        break;
                    }
                    if (j == 63)
                    {
                        return false;
                    }
                }

            }
            for (int i = 0; i < 3; i++)
            {
                if (received_data.EndsWith(platform[i]))
                {
                    break;
                }
                if (i == 2)
                {
                    return false;
                }
            }
            return true;
        }
        static bool input_validation_eu_num_sym(string received_data, int length_data)
        {
            string Base = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            int counter = 0;
            for (int i = 0; i < length_data; i++)
            {
                for (int j = 0; j < 62; j++)
                {
                    if (received_data[i] == Base[j])
                    {
                        counter++;
                        break;
                    }
                    if (j == 61)
                    {
                        return false;
                    }
                }
                if (counter == length_data)
                {
                    break;
                }
            }
            return true;
        }
        static bool input_validation_ru(string received_data, int length_data)
        {
            string Base = "абвгдеёжзийклмнопрстуфхцчшщъыьэюяАБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
            int counter = 0;
            for (int i = 0; i < length_data; i++)
            {
                for (int j = 0; j < 67; j++)
                {

                    if (received_data[i] == Base[j])
                    {
                        counter++;
                        break;
                    }

                    if (j == 66)
                    {

                        return false;
                    }

                }
                if (counter == length_data)
                {
                    break;
                }
            }


            return true;
        }
        static bool input_validation_num(string received_data, int length_data)
        {
            string Base = "0123456789";
            int counter = 0;
            for (int i = 0; i < length_data; i++)
            {
                for (int j = 0; j < 11; j++)
                {

                    if (received_data[i] == Base[j])
                    {
                        counter++;
                        break;
                    }

                    if (j == 10)
                    {

                        return false;
                    }
                }
                if (counter == length_data)
                {
                    break;
                }
            }
            return true;
        }

        internal class Users
        {
            private int id;

            private string surname;
            private string name;
            private string patronymic;

            private string day;
            private string month;
            private string year;

            private string phone_number;
            private int balance;

            public int entry;
            public int sum;

            public Users()
            {
                surname = "";
                name = "";
                patronymic = "";
                day = "";
                month = "";
                year = "";
                balance = 0;
                string[] secondLine = File.ReadAllLines("C:\\Users\\Руслан\\source\\repos\\MUP_CS\\entry_check.txt");
                entry = Convert.ToInt32(secondLine[0][0]);
                id = Convert.ToInt32(secondLine[0][2]);
            }

            public void change_surname()
            {
                const int surname_limit = 20;//const
                int strlen;
                do
                {
                    Console.Clear();
                    Console.WriteLine("Введите фамилию: ");
                    this.surname = Console.ReadLine();
                    strlen = surname.Length;

                } while ((strlen > surname_limit) || (input_validation_ru(this.surname, strlen) == false));
                File.AppendAllText("C:\\Users\\Руслан\\source\\repos\\MUP_CS\\users_data.txt", this.surname + " ");
                Console.WriteLine("Данные загружены");
            }
            public void change_name()
            {
                const int name_limit = 20;//const
                int strlen;
                do
                {
                    Console.Clear();
                    Console.WriteLine("Введите фамилию: ");
                    this.name = Console.ReadLine();
                    strlen = name.Length;

                } while ((strlen > name_limit) || (input_validation_ru(this.name, strlen) == false));
                File.AppendAllText("C:\\Users\\Руслан\\source\\repos\\MUP_CS\\users_data.txt", this.name + " ");
                Console.WriteLine("Данные загружены");
            }
            public void change_patronymic()
            {
                const int patronymic_limit = 20;
                int strlen;
                do
                {
                    Console.Clear();
                    Console.WriteLine("Введите фамилию: ");
                    this.patronymic = Console.ReadLine();
                    strlen = patronymic.Length;

                } while ((strlen > patronymic_limit) || (input_validation_ru(this.patronymic, strlen) == false));
                File.AppendAllText("C:\\Users\\Руслан\\source\\repos\\MUP_CS\\users_data.txt", this.patronymic + " ");
                Console.WriteLine("Данные загружены");
            }

            public void change_day_birth()
            {
                const int day_month_limit = 2;
                int strlen;
                do
                {
                    Console.Clear();
                    Console.WriteLine("Введите день рождения: ");
                    this.day = Console.ReadLine();
                    strlen = day.Length;

                } while ((strlen > day_month_limit) || (input_validation_num(this.day, strlen) == false));
                File.AppendAllText("C:\\Users\\Руслан\\source\\repos\\MUP_CS\\users_data.txt", this.day + " ");
                Console.WriteLine("Данные загружены");
            }
            public void change_month_birth()
            {

                const int day_month_limit = 2;
                int strlen;
                do
                {
                    Console.Clear();
                    Console.WriteLine("Введите месяц рождения: ");
                    this.month = Console.ReadLine();
                    strlen = month.Length;

                } while ((strlen > day_month_limit) || (input_validation_num(this.month, strlen) == false));
                File.AppendAllText("C:\\Users\\Руслан\\source\\repos\\MUP_CS\\users_data.txt", this.month + " ");
                Console.WriteLine("Данные загружены");
            }
            public void change_year_birth()
            {
                const int year_limit = 4;
                int strlen;
                do
                {
                    Console.Clear();
                    Console.WriteLine("Введите год рождения: ");
                    this.year = Console.ReadLine();
                    strlen = year.Length;

                } while ((strlen > year_limit) || (input_validation_num(this.year, strlen) == false));
                File.AppendAllText("C:\\Users\\Руслан\\source\\repos\\MUP_CS\\users_data.txt", this.year + "\n");
                Console.WriteLine("Данные загружены");
            }

            public void print_data_curent_client()
            {
                Console.Clear();
                Console.WriteLine("Ваши данные:");
                Console.WriteLine("Фамилия: " + this.surname);
                Console.WriteLine("Имя: " + this.name);
                Console.WriteLine("Отчество: " + this.patronymic);
                Console.WriteLine("Дата рождения: " + this.day + "." + this.month + "." + this.year);
                Console.WriteLine("Баланс: " + this.balance);
            }

            public int compare_data_for_login(string file_name, string input_data)
            {
                string[] arr = File.ReadLines(file_name).ToArray();
                for (int i = 0; i != sum; i++)
                {
                    if (input_data.Equals(arr[0][i]))
                    {
                        return 0; //данные найдены
                    }
                }
                id = 0;
                return 1; //данные не найдены
            }


            public int login_or_reg_menu()
            {
                string choice;
                int res;

                do
                {
                    Console.Clear();
                    Console.WriteLine("1. Войти");
                    Console.WriteLine("2. Зарегестрироваться");
                    Console.WriteLine("3. Выход");
                    Console.WriteLine("Выберите один из пунктов меню: ");
                    choice = Console.ReadLine();
                } while (int.TryParse(choice, out res) == false);

                switch (res)
                {

                    case 1:
                        res = login_menu();
                        if (res == 0)
                        {
                            return 0;
                        }
                        return 1;
                    case 2:
                        res = reg_menu();
                        switch (res)
                        {
                            case 0:

                                return 0;
                            case 1:

                                return 2;
                            default:
                                throw new Exception("Ошибка");

                        }
                    case 3:
                        throw new Exception("Выход");
                    default:
                        throw new Exception("Ошибка!");
                }
            }
            public int login_menu()
            {
                Console.WriteLine("Меню Входа:");
                /////////////////////////////
                const int mail_limit = 20;
                string mail;
                int strlen;
                do
                {
                    Console.Clear();
                    Console.WriteLine("Введите вашу почту: ");
                    mail = Console.ReadLine();
                    strlen = mail.Length;

                } while ((strlen > mail_limit) || (input_validation_mail(mail, strlen) == false));

                const int password_limit = 20;
                string password;
                do
                {
                    Console.Clear();
                    Console.WriteLine("Введите пароль: ");
                    password = Console.ReadLine();
                    strlen = password.Length;
                } while ((strlen > password_limit) || (input_validation_eu_num_sym(password, strlen) == false));
                ///////////////////////////////

                if (compare_data_for_login("mail_list.txt", mail) == 1 || (compare_data_for_login("password_list.txt", password) == 1))
                {
                    Console.WriteLine("Неверное имя пользователя или пароль!");
                    return 1;
                }
                File.AppendAllText("C:\\Users\\Руслан\\source\\repos\\MUP_CS\\entry_check.txt", "1" + " " + id);

                Console.WriteLine("Вход выполнен!");
                return 0;
            }

            public int reg_menu()
            {
                Console.Clear();
                Console.WriteLine("Меню регистрации:");
                const int mail_limit = 20;
                string mail;
                int strlen;
                do
                {
                    Console.Clear();
                    Console.WriteLine("Введите вашу почту, не более " + mail_limit + " символов: ");
                    mail = Console.ReadLine();
                    strlen = mail.Length;

                } while ((mail.Length > mail_limit) || (input_validation_mail(mail, strlen) == false));


                const int password_limit = 20;
                string password;
                do
                {
                    Console.Clear();
                    Console.WriteLine("Введите пароль, не более " + password_limit + " символов: ");
                    password = Console.ReadLine();
                    strlen = password.Length;
                } while ((strlen > password_limit) || input_validation_eu_num_sym(password, strlen) == false);
                //////////////////////////////////////////
                ///




                //////////////////////////////////////////
                if (determine_file_size("C:\\Users\\Руслан\\source\\repos\\MUP_CS\\sum_users.txt") == 0)
                {
                    File.WriteAllText("C:\\Users\\Руслан\\source\\repos\\MUP_CS\\sum_users.txt", "0");
                }
                ////////////////////////////////////////
                int sum;
                string buf = File.ReadAllText("C:\\Users\\Руслан\\source\\repos\\MUP_CS\\sum_users.txt");
                sum = Convert.ToInt32(buf);
                sum += 1;
                buf = Convert.ToString(sum);

                File.WriteAllText("C:\\Users\\Руслан\\source\\repos\\MUP_CS\\sum_users.txt", buf);

                File.WriteAllText("C:\\Users\\Руслан\\source\\repos\\MUP_CS\\entry_check.txt", buf);

                File.AppendAllText("C:\\Users\\Руслан\\source\\repos\\MUP_CS\\mail_list.txt", sum + " " + mail + "\n");

                File.AppendAllText("C:\\Users\\Руслан\\source\\repos\\MUP_CS\\password_list.txt", sum + " " + password + "\n");

                File.AppendAllText("C:\\Users\\Руслан\\source\\repos\\MUP_CS\\users_data.txt", sum + " ");

                File.WriteAllText("C:\\Users\\Руслан\\source\\repos\\MUP_CS\\entry_check.txt", "1" + " " + sum);


                string choice;
                int res;
                do
                {
                    Console.Clear();
                    Console.WriteLine("Вход выполнен.");
                    Console.WriteLine("Желаете добавить персональные данные?");
                    Console.WriteLine("1. Да");
                    Console.WriteLine("2. Нет");
                    Console.WriteLine("Выберите один из пунктов меню: ");
                    choice = Console.ReadLine();

                } while (int.TryParse(choice, out res) == false);

                switch (res)
                {
                    case 1:
                        return 0;
                    case 2:
                        return 1;
                }
                throw new Exception("Ошибка!");
            }

            public int main_menu()
            {
                string choice;
                int res;
                do
                {
                    Console.Clear();
                    Console.WriteLine("Главное меню");
                    Console.WriteLine("1. Профиль");
                    Console.WriteLine("2. Выйти из аккаунта");
                    Console.WriteLine("3. ");
                    Console.WriteLine("0. Выйти из программы");
                    Console.WriteLine("Выберите один из пунктов меню: ");
                    choice = Console.ReadLine();
                } while (int.TryParse(choice, out res));
                return res;
            }
        }
        static void Main(string[] args)
        {

           




            if (determine_file_size("C:\\Users\\Руслан\\source\\repos\\MUP_CS\\entry_check.txt") == 0)
            {

                File.AppendAllText("C:\\Users\\Руслан\\source\\repos\\MUP_CS\\entry_check.txt", "0 0");
            }
            Users current_client = new Users();
            int rezult;
            if (current_client.entry == 48)
            {
                do
                {
                    rezult = current_client.login_or_reg_menu();
                }
                while (rezult == 1);
                switch (rezult)
                {
                    case 0:
                        break;
                    case 2:
                        current_client.change_surname();
                        current_client.change_name();
                        current_client.change_patronymic();
                        current_client.change_day_birth();
                        current_client.change_month_birth();
                        current_client.change_year_birth();
                        break;
                }
            }
            do
            {
                switch (current_client.main_menu())
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Профиль:");
                        current_client.print_data_curent_client();
                        Console.WriteLine("1. Изменить данные");
                        Console.WriteLine("2. Ок");
                        break;
                }
            } while (current_client.main_menu() != 0);

        }
    }
}

    

