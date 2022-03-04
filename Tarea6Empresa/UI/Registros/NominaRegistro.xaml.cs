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

namespace Tarea6Empresa.UI.Registros
{
    /// <summary>
    /// Interaction logic for NominaRegistro.xaml
    /// </summary>
    public partial class NominaRegistro : Window
    {
        private Nomina nomina = new Nomina();
        public NominaRegistro()
        {
            InitializeComponent();
            LlenarCombo();
        }
        private void Cargar()
        {
            this.DataContext = null;
            this.DataContext = nomina;
        }
        private void LlenarCombo()
        {
            this.EmpleadoIdComboBox.ItemsSource = EmpleadoBLL.GetList(x => true);
            this.EmpleadoIdComboBox.SelectedValuePath = "Nombres";
            this.EmpleadoIdComboBox.DisplayMemberPath = "Nombres";

            if (EmpleadoIdComboBox.Items.Count > 0)
                EmpleadoIdComboBox.SelectedIndex = 0;
        }
        private void Limpiar()
        {
            this.nomina = new Nomina();
            this.DataContext = nomina;
        }
        private bool Validar()
        {
            bool Validado = true;
            if (NominaIdTextBox.Text.Length == 0)
            {
                Validado = false;
                MessageBox.Show("Transacción Fallida\n\nNo se pudo validar.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            if (NominaIdTextBox.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Asigne un Id al Contacto.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                NominaIdTextBox.Text = "0";
                NominaIdTextBox.Focus();
                NominaIdTextBox.SelectAll();
            }

            return Validado;
        }

        private void NominasIdTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (NominaIdTextBox.Text.Trim() != string.Empty)
                {
                    int.Parse(NominaIdTextBox.Text);
                }
            }
            catch
            {
                MessageBox.Show($"El valor digitado en el campo (Contacto Id) debe ser un número.\n\nPor favor, digite un número valido.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                NominaIdTextBox.Text = "0";
                NominaIdTextBox.Focus();
                NominaIdTextBox.SelectAll();
            }
        }

        private void SalarioMensualTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            CalcularSalario();
        }

        private void CalcularSalario()
        {
            if (SalarioMensualTextBox.Text == "0")
            {
                HorasExtraTextBox.IsEnabled = false;
            }
            else
            {
                HorasExtraTextBox.IsEnabled = true;
            }

            nomina.SalarioMensual = double.Parse(SalarioMensualTextBox.Text.ToString());
            nomina.SalarioMensual += nomina.HorasExtra * 200;


            double SFS = 0.0304;
            
            double AFP = 0.0287;

            double T_SFS = (nomina.SalarioMensual * SFS);
            double T_AFP = (nomina.SalarioMensual * AFP);
            double T_ISR = nomina.SalarioMensual * 0.10;
            double T_Descuentos = (T_SFS + T_AFP + T_ISR);

            SFSTextBox.Text = Convert.ToString(Math.Round(T_SFS, 2));
            AFPTextBox.Text = Convert.ToString(Math.Round(T_AFP, 2));
            ISRTextBox.Text = Convert.ToString(Math.Round(T_ISR, 2));

            SueldoTotalTextBox.Text = Convert.ToString(Math.Round(nomina.SalarioMensual, 2));
            TotalDecuentosTextBox.Text = Convert.ToString(Math.Round(nomina.SalarioMensual - T_Descuentos, 2));
        }

        private void HorasExtraTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            int HorasExtra = Convert.ToInt32(HorasExtraTextBox.Text);
            nomina.SalarioMensual += HorasExtra * 200;
            SalarioMensualTextBox.Text = nomina.SalarioMensual.ToString();
            CalcularSalario();

        }
        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            int.TryParse(NominaIdTextBox.Text, out int Id);
            var encontrado = NominaBLL.Buscar(Id);

            if (encontrado != null)
            {
                this.DataContext = null;
                this.DataContext = encontrado;
                //Cargar();
            }
            else
            {
                this.nomina = new Nomina();
                this.DataContext = this.nomina;

                MessageBox.Show($"Nomina no encontrado.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);

                Limpiar();
                NominaIdTextBox.SelectAll();
                NominaIdTextBox.Focus();
            }
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarBotton_Click(object sender, RoutedEventArgs e)
        {

            if (!Validar())
                return;

            var paso = NominaBLL.Guardar(this.nomina);
            if (paso)
            {
                Limpiar();
                MessageBox.Show("Transacion Exitosa.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("Transacion Fallida :(", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

    private void EliminarButton_Click(object sender, RoutedEventArgs e)
    {
                Nomina existe = NominaBLL.Buscar(this.nomina.NominaId);

            if (NominaBLL.Eliminar(this.nomina.NominaId))
            {
            Limpiar();
            MessageBox.Show("Registro Eliminado", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        else
            MessageBox.Show("No se pudo eliminar el registro", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

     }
   }
}
