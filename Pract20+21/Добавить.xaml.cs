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
using System.Windows.Media.Media3D;
using System.Windows.Shapes;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Pract20_21
{
    /// <summary>
    /// Логика взаимодействия для Добавить.xaml
    /// </summary>
    public static class Data
    {
        public static СправочникГруппТоваров Tovar;
        public static Поступления Postup;
        public static Поставщик Postav;
        public static Продажи Prod;
        public static Ценник Cena;
    }
    public partial class Добавить : Window
    {
        public Добавить()
        {
            InitializeComponent();
        }
        TovaryContext _db = new TovaryContext();
        СправочникГруппТоваров _Tovar;
        private void Fill_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (NameGroup.Text.Length == 0) errors.AppendLine("Введите ФИО");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            try
            {
                if (Data.Tovar == null)
                {
                    _db.СправочникГруппТоваровs.Add(_Tovar);
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
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (Data.Tovar == null)
            {
                WindowAddEdit.Title = "Добавление записи";
                btnAddEdit.Content = "Добавить группу";
                _Tovar = new СправочникГруппТоваров();
            }
            else
            {
                WindowAddEdit.Title = "Изменение записи";
                btnAddEdit.Content = "Изменить группу";
                _Tovar = _db.СправочникГруппТоваровs.Find(Data.Tovar.КодГруппы);
            }
            WindowAddEdit.DataContext = _Tovar;
        }
    }
}
