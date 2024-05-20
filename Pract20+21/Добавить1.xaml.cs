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
    /// Логика взаимодействия для Добавить1.xaml
    /// </summary>
    public partial class Добавить1 : Window
    {
        public Добавить1()
        {
            InitializeComponent();
        }
        TovaryContext _db = new TovaryContext();
        Ценник _Cena;

        private void Fill_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (NameTovar.Text.Length == 0) errors.AppendLine("Введите Товар");
            if (Kodgroup.Text.Length == 0) errors.AppendLine("Выберите код");
            if (EdIsm.Text.Length == 0) errors.AppendLine("Введите Товар");
            if (Cena.Text.Length == 0) errors.AppendLine("Введите количество");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            try
            {
                if (Data.Cena == null)
                {
                    _db.Ценникs.Add(_Cena);
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
        private void Window_Loaded1(object sender, RoutedEventArgs e)
        {
            Kodgroup.ItemsSource = _db.СправочникГруппТоваровs.ToList();
            Kodgroup.DisplayMemberPath = "КодГруппы";
            if (Data.Cena == null)
            {
                WindowAddEdit.Title = "Добавление записи";
                btnAddEdit.Content = "Добавить товар";
                _Cena = new Ценник();
            }
            else
            {
                WindowAddEdit.Title = "Изменение записи";
                btnAddEdit.Content = "Изменить товар";
                _Cena = _db.Ценникs.Find(Data.Cena.КодТовара);
            }
            WindowAddEdit.DataContext = _Cena;
        }
    }
}
