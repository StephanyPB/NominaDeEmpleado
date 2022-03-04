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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Tarea6Empresa.Consulta;
using Tarea6Empresa.UI.Registros;

namespace Tarea6Empresa
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

        private void rEmpleadosMenuItem_Click(object sender, RoutedEventArgs e)
        {
            RegistroEmpleado empleado = new RegistroEmpleado();
            empleado.Show();
        }

        private void rNominasMenuItem_Click(object sender, RoutedEventArgs e)
        {
            NominaRegistro nomina = new NominaRegistro();
            nomina.Show();
        }

        private void cEmpleadosMenuItem_Click(object sender, RoutedEventArgs e)
        {
            cEmpleado Empleado = new cEmpleado();
            Empleado.Show();
        }
    }
}
