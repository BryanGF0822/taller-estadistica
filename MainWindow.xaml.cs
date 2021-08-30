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

                ReadCSV(fileSearch);
                ListViewDepartamentos.ItemsSource = ReadCSV(fileSearch);

            }

        }
        private void btnEjecutarFiltro_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnBorrarFiltro_Click(object sender, RoutedEventArgs e)
        {

        }

        private static IEnumerable<Departamento> ReadCSV(string fileName)
        {
            // We change file extension here to make sure it's a .csv file.
            // TODO: Error checking.
            string[] lines = File.ReadAllLines(System.IO.Path.ChangeExtension(fileName, ".csv"));

            // lines.Select allows me to project each line as a Person. 
            // This will give me an IEnumerable<Departamento> back.
            return lines.Select(line =>
            {
                string[] data = line.Split(',');

                // We return a person with the data in order.
                return new Departamento(Convert.ToInt32(data[0]), Convert.ToInt32(data[1]), data[2], data[3], data[4]);
            });
        }

        public class Departamento
        {
            public int CodeDepartamento { get; set; }
            public int CodeMunicipio { get; set; }
            public string NameDepartamento { get; set; }
            public string NameMunicipio { get; set; }
            public string TypeMunicipio { get; set; }


            public Departamento(int codeDepa, int codeMuni, string nameDepa, string nameMuni, string typeMuni)
            {

                CodeDepartamento = codeDepa;
                CodeMunicipio = codeMuni;
                NameDepartamento = nameDepa;
                NameMunicipio = nameMuni;
                TypeMunicipio = typeMuni;
            }
        }
    }
}
