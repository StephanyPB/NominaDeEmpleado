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
using System.Windows.Shapes;
using Tarea6Empresa.Bll;
using Tarea6Empresa.Entidades;

namespace Tarea6Empresa.Consulta
{
    /// <summary>
    /// Interaction logic for cEmpleado.xaml
    /// </summary>
    public partial class cEmpleado : Window
    {
        public cEmpleado()
        {
            InitializeComponent();
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Empleado>();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0: //EmpleadoId
                        int.TryParse(CriterioTextBox.Text, out int EmpleadoId);
                        listado = EmpleadoBLL.GetList(a => a.Id == EmpleadoId);
                        break;

                    case 1: //Nombres
                        listado = EmpleadoBLL.GetList(a => a.Nombres.ToLower().Contains(CriterioTextBox.Text.ToLower()));
                        break;
                }
            }
            else
            {
                listado = EmpleadoBLL.GetList(c => true);
            }

            if (DesdeDataPicker.SelectedDate != null)
                listado = listado.Where(c => c.fechaIngreso.Date >= DesdeDataPicker.SelectedDate).ToList();

            if (HastaDatePicker.SelectedDate != null)
                listado = listado.Where(c => c.fechaIngreso.Date <= HastaDatePicker.SelectedDate).ToList();

            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = listado;

        }
    }
}
