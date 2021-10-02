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


namespace taller_estadistica_lista_y_grafico{
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
            String[] comboBoxList = new[] {"ANTIOQUIA", "ATLANTICO", "BOGOTA", "BOLIVAR", "BOYACA", "CAUCA", "CALDAS", "CAQUETA", "CESAR", "CORDOBA", "CUNDINAMARCA", "CHOCO", "HUILA",
                "LA GUAJIRA", "MAGDALENA", "META", "NARIÑO", "NORTE DE SANTANDER", "QUINDIO", "RISARALDA", "SANTANDER", "SUCRE", "TOLIMA", "VALLE DEL CAUCA", "CASANARE", "ARAUCA",
                "PUTUMAYO", "ARCHIPIELAGO DE SAN ANDRES. PROVIDENCIA Y SANTA CATALINA", "AMAZONAS", "GUAINIA", "VAUPES", "GUAVIARE", "VICHADA" };
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
            String selected = comboBoxDepartamento.SelectedItem.ToString();
            
            cargar(filtroPorDepas(selected));
        }

        private void cargar(List<Departamento> filtro)
        {
            ListTableDepa.Items.Clear();
            foreach(Departamento d in filtro)
            {
                ListTableDepa.Items.Add(d);
            }
        }

        private List<Departamento> filtroPorDepas(String depar)
        {
            List<Departamento> filtroPorDepas = new List<Departamento>();

            foreach (Departamento d in depas)
            {
                if (d.nameDepartamento.Equals(depar))
                {
                    filtroPorDepas.Add(d);
                }
                Console.WriteLine(filtroPorDepas);
            }

            return filtroPorDepas;
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
