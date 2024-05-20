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
    /// Логика взаимодействия для Добавить2.xaml
    /// </summary>
    public partial class Добавить2 : Window
    {
        public Добавить2()
        {
            InitializeComponent();
        }
        TovaryContext _db = new TovaryContext();
        Поступления _Postup;

        private void Fill_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (kodTov.Text.Length == 0) errors.AppendLine("Введите Код");
            if (Kolpost.Text.Length == 0) errors.AppendLine("Введите количество");
            if (Datapost.SelectedDate == null) errors.AppendLine("Введите дату");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            try
            {
                if (Data.Postup == null)
                {
                    _db.Поступленияs.Add(_Postup);
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
        private void Window_Loaded2(object sender, RoutedEventArgs e)
        {
            kodTov.ItemsSource = _db.Ценникs.ToList();
            kodTov.DisplayMemberPath = "КодТовара";
            if (Data.Postup == null)
            {
                WindowAddEdit.Title = "Добавление записи";
                btnAddEdit.Content = "Добавить товар";
                _Postup = new Поступления();
            }
            else
            {
                WindowAddEdit.Title = "Изменение записи";
                btnAddEdit.Content = "Изменить товар";
                _Postup = _db.Поступленияs.Find(Data.Postup.НомерНакладной);
            }
            WindowAddEdit.DataContext = _Postup;
        }
    }
}
