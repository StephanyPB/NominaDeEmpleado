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
    /// Interaction logic for RegistroEmpleado.xaml
    /// </summary>
    public partial class RegistroEmpleado : Window
    {
        private Empleado Empleado = new Empleado();
        public RegistroEmpleado()
        {
            Empleado = new Empleado();  
            InitializeComponent();
            this.DataContext = Empleado;
            LlenarCombo();
            LlenarComboDepa();
        }
        private void LlenarCombo()
        {
            this.RolIdComboBox.ItemsSource = RolesBLL.GetList(x => true);
            this.RolIdComboBox.SelectedValuePath = "Descripcion";
            this.RolIdComboBox.DisplayMemberPath = "Descripcion";

            if (RolIdComboBox.Items.Count > 0)
                RolIdComboBox.SelectedIndex = 0;
        }
        private void LlenarComboDepa()
        {
            this.DepartamentoIdComboBox.ItemsSource = DepartamentoBLL.GetList(x => true);
            this.DepartamentoIdComboBox.SelectedValuePath = "Descripcion";
            this.DepartamentoIdComboBox.DisplayMemberPath = "Descripcion";

            if (DepartamentoIdComboBox.Items.Count > 0)
                DepartamentoIdComboBox.SelectedIndex = 0;
        }

        private void Cargar()
        {
            this.DataContext = null;
            this.DataContext = Empleado;
        }

        private void Limpiar()
        {
            this.Empleado = new Empleado();
            this.DataContext = Empleado;
        }

        private bool Validar()
        {
            bool Validado = true;
            if (EmpleadoIdTextBox.Text.Length == 0)
            {
                Validado = false;
                MessageBox.Show("Transacción Fallida", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            if (EmpleadoIdTextBox.Text.Trim() == string.Empty)
            {
                MessageBox.Show(" Asigne un Id al Contacto.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                EmpleadoIdTextBox.Text = "0";
                EmpleadoIdTextBox.Focus();
                EmpleadoIdTextBox.SelectAll();

            }

            if (NombresTextBox.Text.Trim() == string.Empty)
            {
                MessageBox.Show(" Asigne un Nombre al Contacto.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                NombresTextBox.Clear();
                NombresTextBox.Focus();

            }

            if (TelefonoTextBox.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Asigne un Teléfono al Empleado.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                TelefonoTextBox.Text = "0";
                TelefonoTextBox.Focus();
                TelefonoTextBox.SelectAll();

            }
            if (TelefonoTextBox.Text.Length != 10)
            {
                MessageBox.Show($"El Teféfono no es válido.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                TelefonoTextBox.Focus();

            }
            return Validado;
        }
        private void EmpleadoIdTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (EmpleadoIdTextBox.Text.Trim() != string.Empty)
                {
                    int.Parse(EmpleadoIdTextBox.Text);
                }
            }
            catch
            {
                MessageBox.Show($"El valor digitado en el campo (Contacto Id) debe ser un número.\n\nPor favor, digite un número valido.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                EmpleadoIdTextBox.Text = "0";
                EmpleadoIdTextBox.Focus();
                EmpleadoIdTextBox.SelectAll();
            }
        }
        private void TelefonoTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (TelefonoTextBox.Text.Trim() != string.Empty)
                {
                    long.Parse(TelefonoTextBox.Text);
                }

                if (TelefonoTextBox.Text.Length != 10)
                {
                    TelefonoTextBox.Foreground = Brushes.Red;
                }
                else
                {
                    TelefonoTextBox.Foreground = Brushes.Green;
                }
            }
            catch
            {
                MessageBox.Show("El valor digitado en el campo (Teléfono) no es un número.\n\nPor favor, digite un número.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                TelefonoTextBox.Text = "0";
                TelefonoTextBox.Focus();
                TelefonoTextBox.SelectAll();
            }
        }

        private void BuscarId_Click(object sender, RoutedEventArgs e)
        {

            int.TryParse(EmpleadoIdTextBox.Text, out int Id);
            var Empleado = EmpleadoBLL.Buscar(Id);

            if (Empleado != null)
            {
                this.Empleado = Empleado;
                RolIdComboBox.Text = RolIdComboBox.Text;
                DepartamentoIdComboBox.Text = DepartamentoIdComboBox.Text;
                Cargar();
            }
            else
            {
                this.Empleado = new Empleado();
                this.DataContext = this.Empleado;

                MessageBox.Show($"Contacto no encontrado.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);

                Limpiar();
                EmpleadoIdTextBox.SelectAll();
                EmpleadoIdTextBox.Focus();
            }
        }

        private void NButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
                return;
            var paso = EmpleadoBLL.Guardar(this.Empleado);

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Transaccion Exitosa!", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("Transaccion Fallida!", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);


        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            Empleado existe = EmpleadoBLL.Buscar(this.Empleado.Id);

            if (EmpleadoBLL.Eliminar(this.Empleado.Id))
            {
                Limpiar();
                MessageBox.Show("Registro Eliminado", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("No se pudo eliminar el registro", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

        }
    }
}
