using FastType_Proskurin_Sideleva.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace FastType_Proskurin_Sideleva.AppData
{
    class UserSession
    {
        public static void CheckRegistration(TextBox name, TextBox email, PasswordBox password)
        {
            // Любые действия с БД нужно обрабатывать с помощью try, catch (обработка исключений)
            try
            {
                // 1. Создать объект (на основе класса таблицы куда нужно добавить запись)
                Users user = new Users()
                {
                    Name = name.Text,
                    Email = email.Text,
                    Password = password.Password
                };

                if (name.Text == "" || email.Text == "" || password.Password == "")
                {
                    MessageBox.Show("Введите все данные!");
                }
                else
                {
                    // 2. Добавить объект в табицу
                    ModelHelper.GetContext().Users.Add(user);

                    // 3. Сохранить изменения (из модели в БД)
                    ModelHelper.GetContext().SaveChanges();

                    // 4. Оповестить пользователя о добавлении в его в БД (регистрации)
                    MessageBox.Show("Пользователь зарегистрирован!");
                }
                
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

            
        }
    }
}
