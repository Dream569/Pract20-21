using Pract20_21.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Pract20_21
{
    /// <summary>
    /// Логика взаимодействия для Добавить4.xaml
    /// </summary>
    public partial class Добавить4 : Window
    {
        public Добавить4()
        {
            InitializeComponent();
        }
        TovaryContext _db = new TovaryContext();
        Поставщик _Postav;

        private void Fill_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (KodTov.Text.Length == 0) errors.AppendLine("Введите Код");
            if (Adres.Text.Length == 0) errors.AppendLine("Введите адрес");
            if (tel.Text.Length == 0) errors.AppendLine("Введите телефон");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            try
            {
                if (Data.Postav == null)
                {
                    _db.Поставщикs.Add(_Postav);
                    _db.SaveChanges();
                }
                else
                {
                    _db.SaveChanges();
                }
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void Cansel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Window_Loaded4(object sender, RoutedEventArgs e)
        {
            KodTov.ItemsSource = _db.Ценникs.ToList();
            KodTov.DisplayMemberPath = "КодТовара";
            if (Data.Postav == null)
            {
                WindowAddEdit.Title = "Добавление записи";
                btnAddEdit.Content = "Добавить поставщика";
                _Postav = new Поставщик();
            }
            else
            {
                WindowAddEdit.Title = "Изменение записи";
                btnAddEdit.Content = "Изменить поставщика";
                _Postav = _db.Поставщикs.Find(Data.Postav.КодПоставщика);
            }
            WindowAddEdit.DataContext = _Postav;
        }
    }
}
