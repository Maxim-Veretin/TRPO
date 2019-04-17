using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
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
                if (DigitSimple(num) == true)
                    lb.Items.Add(Convert.ToString(num));
                else
                {
                    throw new ArgumentException("Число не является простым.");
                }
            }
            catch (FormatException)
            {
                string st = "Вводится символ, не являющийся числом.";
                MessageBox.Show(st, "Error", MessageBoxButton.OK);
            }
            catch (ArgumentException)
            {
                string st1 = "Число не является простым.";
                MessageBox.Show(st1, "Error", MessageBoxButton.OK);
            }
        }

        private void Nm_TextChanged(object sender, TextChangedEventArgs e)
        {
            //try
            //{
            //    num = int.Parse(nm.Text); //num присваивается значение входящих данных
            //}
            //catch (FormatException)
            //{
            //    string st = "Вводится символ, не являющийся числом.";
            //    MessageBox.Show(st, "Error", MessageBoxButton.OK);
            //}
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
                    foreach (string line in lb.Items)
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
            try
            {
                StreamReader file = new StreamReader(@"C:\Document.txt");

                while ((line = file.ReadLine()) != null)
                {
                    try
                    {
                        if ((DigitSimple(int.Parse(line)) == false))
                        {
                            throw new InvalidFileContent("Некорректное содержимое файла. \nВ файле содержатся не только простые числа.");
                        }
                        else
                            lb.Items.Add(line);
                    }
                    catch
                    {
                        string st1 = "Некорректное содержимое файла. \nВ файле содержатся не только простые числа.";
                        MessageBox.Show(st1, "Error", MessageBoxButton.OK);
                        break;
                    }
                }

                file.Close();
            }
            catch (FileNotFoundException)
            {
                string st = "Файл 'C:/Document.txt' не найден.";
                MessageBox.Show(st, "Error", MessageBoxButton.OK);
            }
            //C:\Users\Admin\Documents\Document.txt
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
                        return false;
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public class InvalidFileContent : ApplicationException
    {
        public InvalidFileContent() { }

        public InvalidFileContent(string message) : base(message) { }

        public InvalidFileContent(string message, Exception inner) : base(message, inner) { }

        protected InvalidFileContent(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}