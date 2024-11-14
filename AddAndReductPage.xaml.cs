using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FloorMaster
{
    /// <summary>
    /// Логика взаимодействия для AddAndReductPage.xaml
    /// </summary>
    public partial class AddAndReductPage : Page
    {
        private Partners _currentLit;
        public AddAndReductPage(Partners SelectedPart)
        {
            InitializeComponent();
            _currentLit = SelectedPart ?? new Partners();
            
            if (SelectedPart != null)
            {
                TypePathers.SelectedIndex = SelectedPart.TypeID - 1;
            }
            DataContext = _currentLit;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            // Собираем все ошибки в строку
            string errorMessages = string.Empty;

            // Проверка наименования компании
            if (string.IsNullOrWhiteSpace(NameTB.Text))
            {
                errorMessages += "Введите наименование компании.\n";
            }

            // Проверка типа компании
            if (TypePathers.SelectedIndex < 0)
            {
                errorMessages += "Выберите тип компании.\n";
            }

            // Проверка рейтинга
            if (string.IsNullOrWhiteSpace(RankTB.Text) || !int.TryParse(RankTB.Text, out int rating))
            {
                errorMessages += "Введите корректный рейтинг (целое число).\n";
            }

            // Проверка email
            if (string.IsNullOrWhiteSpace(EmailTb.Text) || !IsValidEmail(EmailTb.Text))
            {
                errorMessages += "Введите корректный email.\n";
            }

            // Проверка телефона
            if (string.IsNullOrWhiteSpace(PhoneTB.Text) || !IsValidPhoneNumber(PhoneTB.Text))
            {
                errorMessages += "Введите корректный номер телефона.\n";
            }

            if (string.IsNullOrWhiteSpace(INN.Text) || !IsValidINN(INN.Text))
            {
                errorMessages += "Введите корректный ИНН.\n";
            }

            // Если есть ошибки, выводим их
            if (!string.IsNullOrEmpty(errorMessages))
            {
                MessageBox.Show(errorMessages, "Ошибки ввода", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Присвоение значений свойствам
            _currentLit.CompanyName = NameTB.Text;
            _currentLit.TypeID = TypePathers.SelectedIndex + 1;
            _currentLit.Rating = int.Parse(RankTB.Text);
            _currentLit.SurnameDirector = FioTB.Text;
            _currentLit.NameDirector = NameDirectorTB.Text;
            _currentLit.PatronomycDirector = PatronomycTB.Text;
            _currentLit.LegalAdress = AdresTb.Text;
            _currentLit.Email = EmailTb.Text;
            _currentLit.TelephoneNumber = PhoneTB.Text;
            _currentLit.INN = INN.Text;



            if (_currentLit.Id == 0)
            {
                FloorMasterEntities.GetContext().Partners.Add(_currentLit);
            }
            try
            {
                FloorMasterEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");
                Manager.MainFrame.GoBack();
            }
            catch (DbEntityValidationException ex)
            {
                // Обработка ошибок валидации
                StringBuilder validationErrors = new StringBuilder("Ошибка сохранения данных:\n");

                foreach (var entityError in ex.EntityValidationErrors)
                {
                    foreach (var error in entityError.ValidationErrors)
                    {
                        validationErrors.AppendLine($"Сущность: {entityError.Entry.Entity.GetType().Name}, Свойство: {error.PropertyName}, Ошибка: {error.ErrorMessage}");
                    }
                }

                // Выводим все ошибки валидации
                MessageBox.Show(validationErrors.ToString(), "Ошибки валидации", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());

            }

        }

        // Валидация Email
        private bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        // Валидация номера телефона
        private bool IsValidPhoneNumber(string phone)
        {
            return Regex.IsMatch(phone, @"^\+?\d{10,13}$");
        }
        private bool IsValidINN(string Inn)
        {
            return Regex.IsMatch(Inn,@"\d{10}");
        }


        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.GoBack();
        }
    }
}
