using Microsoft.EntityFrameworkCore;
using Pract20_21.Model;
using System.Drawing;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Pract20_21
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        void LoadDBIDataGrid()
        {
            using (TovaryContext _db = new TovaryContext())
            {
                int selectedIndex = DataGrid.SelectedIndex;

                DataGrid.ItemsSource = _db.СправочникГруппТоваровs.ToList();
                if (selectedIndex != -1)
                {
                    if (selectedIndex == DataGrid.Items.Count) selectedIndex--;
                    DataGrid.SelectedIndex = selectedIndex;
                    DataGrid.ScrollIntoView(DataGrid.SelectedItem);
                }
                DataGrid.Focus();
            }
            using (TovaryContext _db = new TovaryContext())
            {
                int selectedIndex = DataGrid1.SelectedIndex;
                DataGrid1.ItemsSource = _db.Ценникs.ToList();
                if (selectedIndex != -1)
                {
                    if (selectedIndex == DataGrid1.Items.Count) selectedIndex--;
                    DataGrid1.SelectedIndex = selectedIndex;
                    DataGrid1.ScrollIntoView(DataGrid1.SelectedItem);
                }
                DataGrid1.Focus();
            }
            using (TovaryContext _db = new TovaryContext())
            {
                int selectedIndex = DataGrid2.SelectedIndex;
                DataGrid2.ItemsSource = _db.Поступленияs.ToList();
                if (selectedIndex != -1)
                {
                    if (selectedIndex == DataGrid2.Items.Count) selectedIndex--;
                    DataGrid2.SelectedIndex = selectedIndex;
                    DataGrid2.ScrollIntoView(DataGrid2.SelectedItem);
                }
                DataGrid2.Focus();
            }
            using (TovaryContext _db = new TovaryContext())
            {
                int selectedIndex = DataGrid3.SelectedIndex;
                DataGrid3.ItemsSource = _db.Продажиs.ToList();
                if (selectedIndex != -1)
                {
                    if (selectedIndex == DataGrid3.Items.Count) selectedIndex--;
                    DataGrid3.SelectedIndex = selectedIndex;
                    DataGrid3.ScrollIntoView(DataGrid3.SelectedItem);
                }
                DataGrid3.Focus();
            }
            using (TovaryContext _db = new TovaryContext())
            {
                int selectedIndex = DataGrid4.SelectedIndex;
                DataGrid4.ItemsSource = _db.Поставщикs.ToList();
                if (selectedIndex != -1)
                {
                    if (selectedIndex == DataGrid4.Items.Count) selectedIndex--;
                    DataGrid4.SelectedIndex = selectedIndex;
                    DataGrid4.ScrollIntoView(DataGrid4.SelectedItem);
                }
                DataGrid4.Focus();
            }
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Data.Tovar = null;
            Добавить f = new Добавить();
            f.Owner = this;
            f.ShowDialog();
            LoadDBIDataGrid();
        }
        private void Redact_Click(object sender, RoutedEventArgs e)
        {
            if (DataGrid.SelectedItem != null)
            {
                Data.Tovar = (СправочникГруппТоваров)DataGrid.SelectedItem;
                Добавить f = new Добавить();
                f.Owner = this;
                f.ShowDialog();
                LoadDBIDataGrid();
            }

        }
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result;
            result = MessageBox.Show("Удалить запись?", "Удаление записи", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    СправочникГруппТоваров row = (СправочникГруппТоваров)DataGrid.SelectedItem;
                    if (row != null)
                    {
                        using (TovaryContext _db = new TovaryContext())
                        {
                            _db.СправочникГруппТоваровs.Remove(row);
                            _db.SaveChanges();
                        }
                        LoadDBIDataGrid();
                    }
                }
                catch
                {
                    MessageBox.Show("Ошибка удаления");
                }
            }
            else DataGrid.Focus();
        }
        private void Add_Click1(object sender, RoutedEventArgs e)
        {
            Data.Cena = null;
            Добавить1 f = new Добавить1();
            f.Owner = this;
            f.ShowDialog();
            LoadDBIDataGrid();
        }
        private void Redact_Click1(object sender, RoutedEventArgs e)
        {
            if (DataGrid1.SelectedItem != null)
            {
                Data.Cena = (Ценник)DataGrid1.SelectedItem;
                Добавить1 f = new Добавить1();
                f.Owner = this;
                f.ShowDialog();
                LoadDBIDataGrid();
            }
        }
        private void Clear_Click1(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result1;
            result1 = MessageBox.Show("Удалить запись?", "Удаление записи", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result1 == MessageBoxResult.Yes)
            {
                try
                {
                    Ценник row1 = (Ценник)DataGrid1.SelectedItem;
                    if (row1 != null)
                    {
                        using (TovaryContext _db = new TovaryContext())
                        {
                            _db.Ценникs.Remove(row1);
                            _db.SaveChanges();
                        }
                        LoadDBIDataGrid();
                    }
                }
                catch
                {
                    MessageBox.Show("Ошибка удаления");
                }
            }
            else DataGrid1.Focus();
        }
        private void Add_Click2(object sender, RoutedEventArgs e)
        {
            Data.Postup = null;
            Добавить2 f = new Добавить2();
            f.Owner = this;
            f.ShowDialog();
            LoadDBIDataGrid();
        }
        private void Redact_Click2(object sender, RoutedEventArgs e)
        {
            if (DataGrid2.SelectedItem != null)
            {
                Data.Postup = (Поступления)DataGrid2.SelectedItem;
                Добавить2 f = new Добавить2();
                f.Owner = this;
                f.ShowDialog();
                LoadDBIDataGrid();
            }
        }
        private void Clear_Click2(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result1;
            result1 = MessageBox.Show("Удалить запись?", "Удаление записи", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result1 == MessageBoxResult.Yes)
            {
                try
                {
                    Поступления row1 = (Поступления)DataGrid2.SelectedItem;
                    if (row1 != null)
                    {
                        using (TovaryContext _db = new TovaryContext())
                        {
                            _db.Поступленияs.Remove(row1);
                            _db.SaveChanges();
                        }
                        LoadDBIDataGrid();
                    }
                }
                catch
                {
                    MessageBox.Show("Ошибка удаления");
                }
            }
            else DataGrid2.Focus();
        }
        private void Add_Click3(object sender, RoutedEventArgs e)
        {
            Data.Prod = null;
            Добавить3 f = new Добавить3();
            f.Owner = this;
            f.ShowDialog();
            LoadDBIDataGrid();
        }
        private void Redact_Click3(object sender, RoutedEventArgs e)
        {
            if (DataGrid3.SelectedItem != null)
            {
                Data.Prod = (Продажи)DataGrid3.SelectedItem;
                Добавить3 f = new Добавить3();
                f.Owner = this;
                f.ShowDialog();
                LoadDBIDataGrid();
            }
        }
        private void Clear_Click3(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result1;
            result1 = MessageBox.Show("Удалить запись?", "Удаление записи", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result1 == MessageBoxResult.Yes)
            {
                try
                {
                    Продажи row1 = (Продажи)DataGrid3.SelectedItem;
                    if (row1 != null)
                    {
                        using (TovaryContext _db = new TovaryContext())
                        {
                            _db.Продажиs.Remove(row1);
                            _db.SaveChanges();
                        }
                        LoadDBIDataGrid();
                    }
                }
                catch
                {
                    MessageBox.Show("Ошибка удаления");
                }
            }
            else DataGrid3.Focus();
        }
        private void Add_Click4(object sender, RoutedEventArgs e)
        {
            Data.Postav = null;
            Добавить4 f = new Добавить4();
            f.Owner = this;
            f.ShowDialog();
            LoadDBIDataGrid();
        }
        private void Redact_Click4(object sender, RoutedEventArgs e)
        {
            if (DataGrid4.SelectedItem != null)
            {
                Data.Postav = (Поставщик)DataGrid4.SelectedItem;
                Добавить4 f = new Добавить4();
                f.Owner = this;
                f.ShowDialog();
                LoadDBIDataGrid();
            }
        }
        private void Clear_Click4(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result1;
            result1 = MessageBox.Show("Удалить запись?", "Удаление записи", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result1 == MessageBoxResult.Yes)
            {
                try
                {
                    Поставщик row1 = (Поставщик)DataGrid4.SelectedItem;
                    if (row1 != null)
                    {
                        using (TovaryContext _db = new TovaryContext())
                        {
                            _db.Поставщикs.Remove(row1);
                            _db.SaveChanges();
                        }
                        LoadDBIDataGrid();
                    }
                }
                catch
                {
                    MessageBox.Show("Ошибка удаления");
                }
            }
            else DataGrid4.Focus();
        }
        private void Zapros1(object sender, RoutedEventArgs e)
        {
            using (TovaryContext _db = new TovaryContext())
            {
                var january = new DateTime(DateTime.Now.Year, 1, 1);
                var p = from x1 in _db.Ценникs
                        join x2 in _db.Поступленияs on x1.КодТовара equals x2.КодТовара
                        where x2.ДатаПоступления.Month == january.Month
                        group x2 by x1.НаименованиеТовара into группа
                        select new
                        {
                            НаименованиеТовара = группа.Key,
                            КоличествоПоступило = группа.Sum(p => p.КоличествоПоступления)
                        };
                List1.ItemsSource = p.ToList();
            }
        }
        private void Zapros2(object sender, RoutedEventArgs e)
        {
            using (TovaryContext _db = new TovaryContext())
            {
                var x = from p1 in _db.Ценникs
                        join p2 in _db.Продажиs on p1.КодТовара equals p2.КодТовара into ps
                        from p2 in ps.DefaultIfEmpty()
                        join p3 in _db.Поступленияs on p1.КодТовара equals p3.КодТовара into ps1
                        from p3 in ps1.DefaultIfEmpty()
                        where (p2 == null ? 0 : p2.КоличествоПродано) - p3.КоличествоПоступления < 0
                        select new
                        {
                            НаименованиеТовара = p1.НаименованиеТовара,
                            КоличествоПродано = (p2 == null ? 0 : p2.КоличествоПродано)
                        };
                List2.ItemsSource = x.ToList();
            }
        }
        private void Zapros3(object sender, RoutedEventArgs e)
        {
            using (var TovaryContext = new TovaryContext())
            {
                Поставщик newSupplier = new Поставщик
                {
                    КодТовара = 2,
                    Адрес = "дом хз какой пусть будет",
                    Телефон = "89209548890"
                };
                TovaryContext.Поставщикs.Add(newSupplier);
                TovaryContext.SaveChanges();
            }
        }
        private void Zapros4(object sender, RoutedEventArgs e)
        {
            using (TovaryContext _db = new TovaryContext())
            {
                var c = from p1 in _db.Поставщикs
                        join p2 in _db.Поступленияs on p1.КодТовара equals p2.КодТовара
                        join p3 in _db.Ценникs on p1.КодТовара equals p3.КодТовара 
                        group new { p1, p2, p3} by p1.КодПоставщика into группа
                        select new
                        {
                            НаименованиеПоставщика = группа.FirstOrDefault().p1.КодПоставщика,
                            ОбщаяСтоимость = группа.Sum(x => x.p2.КоличествоПоступления * x.p3.Цена)
                        };
                List3.ItemsSource = c.ToList();
            }
        }
        private void Zapros5(object sender, RoutedEventArgs e)
        {
            using (TovaryContext _db = new TovaryContext())
            {
                List4.ItemsSource = _db.B1s.ToList();
            }
        }
        private void Zapros6(object sender, RoutedEventArgs e)
        {
            using (TovaryContext _db = new TovaryContext())
            {
                var b = from f1 in _db.Ценникs
                        let f2 = _db.Поступленияs.Where(p => p.КодТовара == f1.КодТовара).Sum(p => p.КоличествоПоступления)
                        let f3 = _db.Продажиs.Where(p => p.КодТовара == f1.КодТовара).Sum(p => p.КоличествоПродано)
                        select new
                        {
                            НаименованиеТовара = f1.НаименованиеТовара,
                            ОстаточнаяСтоимость = (f2 - f3) * f1.Цена
                        };
                List5.ItemsSource = b.ToList();
            }
        }
        private void Zapros7(object sender, RoutedEventArgs e)
        {
            using (TovaryContext context = new TovaryContext())
            {
                var october = new DateTime();
                var result = context.Ценникs.Include(x => x.Продажиs).Select(x => new
                {
                    НаименованиеТовара = x.НаименованиеТовара,
                    КоличествоПроданоЗаМесяц = x.Продажиs.Where(x => x.ДатаПродажи.Month == october.Month && x.ДатаПродажи.Year == october.Year).Sum(p => p.КоличествоПродано)
                });
                List6.ItemsSource = result.ToList();
            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDBIDataGrid();
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Info_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Практическая работа №20\n" +
         "Создание многотабличного приложения Товары и сделать 2 запроса: 1) Составить SQL-запрос, подсчитывающий в каком количестве каждый товар \r\nпоступил в магазин в январе. Запрос должен содержать следующие поля: Наименование \r\nтовара, Количество поступило. 2) С помощью SQL-запроса вывести наименование товара, остаток которого \r\nравен нулю.",
         "О программе", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}