using Microsoft.Win32;
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


namespace taller_estadistica_lista_y_grafico
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

        private void btnAbrir_Click(object sender, RoutedEventArgs e)
        {
            String fileSearch;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.DefaultExt = ".csv";
            openFileDialog.Filter = "Arichivos csv (.csv)|*.csv";
            if (openFileDialog.ShowDialog() == true)
            {
                fileSearch = openFileDialog.FileName;

            }
               
        }

        private void btnBorrarFiltro_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEjecutarFiltro_Click(object sender, RoutedEventArgs e)
        {

        }

        private void readerFile(String fileSearch)
        {
            string[] tokens;
            char[] separators = { ';' };
            string str = "";

            FileStream fs = new FileStream(@"D:\Dokumenter\Skole\6. semester\GUI\Exercises\Exercise2\02 deltagerliste.csv",
                                           FileMode.Open);
            StreamReader sr = new StreamReader(fs, Encoding.Default);

            while ((str = sr.ReadLine()) != null)
            {
                tokens = str.Split(separators, StringSplitOptions.RemoveEmptyEntries);

                Console.WriteLine(String.Format("{0,-20}", tokens[0]) +
                                  String.Format("{0,-15}", tokens[1]) +
                                  String.Format("{0,-15}", tokens[2]) +
                                  String.Format("{0,-15}", tokens[3]));
            }

            Console.ReadLine();
        }
    }
}
