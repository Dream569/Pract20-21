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
    /// Логика взаимодействия для Добавить3.xaml
    /// </summary>
    public partial class Добавить3 : Window
    {
        public Добавить3()
        {
            InitializeComponent();
        }
        TovaryContext _db = new TovaryContext();
        Продажи _Prodano;

        private void Fill_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (kodTov.Text.Length == 0) errors.AppendLine("Введите Код");
            if (Kolprod.Text.Length == 0) errors.AppendLine("Введите количество");
            if (Datapost.SelectedDate == null) errors.AppendLine("Введите дату");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            try
            {
                if (Data.Prod == null)
                {
                    _db.Продажиs.Add(_Prodano);
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
        private void Window_Loaded3(object sender, RoutedEventArgs e)
        {
            kodTov.ItemsSource = _db.Ценникs.ToList();
            kodTov.DisplayMemberPath = "КодТовара";
            if (Data.Prod == null)
            {
                WindowAddEdit.Title = "Добавление записи";
                btnAddEdit.Content = "Добавить товар";
                _Prodano = new Продажи();
            }
            else
            {
                WindowAddEdit.Title = "Изменение записи";
                btnAddEdit.Content = "Изменить товар";
                _Prodano = _db.Продажиs.Find(Data.Prod.НомерЧека);
            }
            WindowAddEdit.DataContext = _Prodano;
        }
    }
}
