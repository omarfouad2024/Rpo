using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Curds
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window

    {
        Db_companyEntities db = new Db_companyEntities();
        public MainWindow()
        {
            InitializeComponent();
            datagrid.ItemsSource = db.Employees.ToList();   
        }

        private void Insert(object sender, RoutedEventArgs e)
        {
            if(idtext.Text != "")
            {
                MessageBox.Show("Id created manully");
            }
            Employee employee = new Employee();
            employee.Name = nametext.Text;
            employee.Job = jobtext.Text;
            db.Employees.Add(employee);
            MessageBox.Show("Add created : ");
            db.SaveChanges();
            employee.Name = string.Empty;
            employee.Job = string.Empty;

            datagrid.ItemsSource = db.Employees.ToList();

        }

        private void Update(object sender, RoutedEventArgs e)
        {
            int emp = int.Parse(idtext.Text);
            Employee rec = new Employee();
            rec = db.Employees.FirstOrDefault(x=> x.ID ==  emp); 
            rec.Name = nametext.Text;
            rec.Job = jobtext.Text; 
            db.Employees.AddOrUpdate(rec);
            MessageBox.Show("Add created : ");
            
            db.SaveChanges();
            rec.Name = string.Empty;
            rec.Job = string.Empty;

            datagrid.ItemsSource = db.Employees.ToList();
          
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            int emps = int.Parse(idtext.Text);
            Employee employee  = db.Employees.FirstOrDefault(x => x.ID == emps);
            db.Employees.Remove(employee);  
            MessageBox.Show("REmove creeated: : ");
            db.SaveChanges();
            datagrid.ItemsSource = db.Employees.ToList();

          
        }

        private void SearchByName(object sender, RoutedEventArgs e)
        {

            string search = searchtext.Text;
            var fil = db.Employees.Where(emp => emp.Name.ToLower().Contains(search)).ToList();
                  datagrid.ItemsSource = fil;
        }
    }
}
