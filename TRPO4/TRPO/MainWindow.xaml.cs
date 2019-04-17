using System;
using System.Collections.Generic;
using System.IO;
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

namespace TRPO_1._4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int num;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                num = int.Parse(nm.Text); //num присваивается значение входящих данных
            }
            catch(FormatException)
            {
                string st = "Вводится символ, не являющийся числом.";
                MessageBox.Show(st, "Error", MessageBoxButton.OK);
            }
            

            if (DigitSimple(num))
                lb.Items.Add(num);
        }

        private void Nm_TextChanged(object sender, TextChangedEventArgs e)
        {
            //num = int.Parse(nm.Text);
            //num присваивается значение входящих данных
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dialog = new Microsoft.Win32.SaveFileDialog
            {
                FileName = "Document",
                DefaultExt = ".txt",
                Filter = "Text documents (.txt)|*.txt"
            };
            dialog.ShowDialog();

            using (StreamWriter outputFile = new StreamWriter(dialog.FileName))
            {
                try
                {
                    foreach (string line in lb.Items) //System.InvalidCastException
                        outputFile.WriteLine(line);
                }
                catch (InvalidCastException)
                {

                }
            }
        }

        private void Load(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog
            {
                FileName = "Document"
            };
            dialog.ShowDialog();

            string line;
            StreamReader file = new StreamReader(@"C:\Users\Admin\Documents\Document.txt");
            while ((line = file.ReadLine()) != null)
            {
                if ((DigitSimple(num)==false))
                {
                    string st = "Некорректное содержимое файла.";
                    MessageBox.Show(st, "Error", MessageBoxButton.OK);
                }
                else
                    lb.Items.Add(line);
            }
            file.Close();
            //C:\Users\Администратор\Documents\Document.txt
        }

        private bool DigitSimple(int num)
        {
            if (num > 1)
            {
                int i;
                for (i = 2; i <= Math.Sqrt(num); i++)
                {
                    if ((num % i) == 0)
                    {
                        string st = "Число не является простым.";
                        MessageBox.Show(st, "Error", MessageBoxButton.OK);
                        return false;
                    }
                }
                return true;
            }
            else
            {
                string st = "Число не является простым.";
                MessageBox.Show(st, "Error", MessageBoxButton.OK);
                return false;
            }
        }
    }
}