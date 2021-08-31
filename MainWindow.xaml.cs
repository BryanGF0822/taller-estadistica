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

        public List<Departamento> depas { get; set; }
        public MainWindow()
        {
            InitializeComponent();

            depas = new List<Departamento>();
            String[] comboBoxList = new[] {"Amazonas", "Antioquia", "Arauca", "Atlantico", "Bogota", "Bolivar", "Boyaca", "Caldas", "Caqueta", "Casanare", "Cauca", "Cesar",
            "Choco", "Cordoba", "Cundinamarca", "Guainia", "Guaviare", "huila", "Guajira", "Magdalena", "Meta", "Narino", "Norte de santander", "Putumayo", "Quindio", "Risaralda",
            "San Andres", "Santander", "Sucre", "Tolima", "Valle del cauca", "Vaupés", "Vichada"};
            comboBoxDepartamento.ItemsSource = comboBoxList;
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
                ListTableDepa.Items.Clear();
                readCSV(fileSearch);

            }

        }
        private void btnEjecutarFiltro_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnBorrarFiltro_Click(object sender, RoutedEventArgs e)
        {
            ListTableDepa.Items.Clear();
        }
       
        private void readCSV(String fileName)
        {
            String[] rows = File.ReadAllLines(fileName);

            foreach(String line in rows)
            {
                String[] datos = line.Split(',');

                int aux;
                if(int.TryParse(datos[0], out aux))
                {
                    Departamento dep = new Departamento() { codeDepartamento = datos[0], codeMunicipio = datos[1], nameDepartamento = datos[2], nameMunicipio = datos[3], typeMunicipio = datos[4] };
                    depas.Add(dep);
                    ListTableDepa.Items.Add(dep);
                }
            }
        }

        public class Departamento
        {
            public String codeDepartamento { get; set; }
            public String codeMunicipio { get; set; }
            public String nameDepartamento { get; set; }
            public String nameMunicipio { get; set; }
            public String typeMunicipio { get; set; }

        }
    }
}
