using BancoEstatal.Views.FormsReportes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BancoEstatal.Views
{
    public partial class FrmMainReports : Form
    {
        private Form FrmActived = null;
        private void ShowForm(Form f)
        {
            if (FrmActived != null)
                FrmActived.Close();
            FrmActived = f;
            FrmActived.MdiParent = this.MdiParent;
            FrmActived.WindowState = FormWindowState.Normal;
            FrmActived.Show();
        }
        public FrmMainReports()
        {
            InitializeComponent();
        }
        private void ButtonX2(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            switch (b.Text)
            {
                case "Reporte de todos los empleados, cargos y sedes donde trabajan":
                    ShowForm(new FrmReporteEmpleados());
                    this.Hide();
                    break;

                case "Reporte de todos los cargos del banco":
                    ShowForm(new FrmReporteTodosCargos());
                    this.Hide();
                    break;

                case "Reporte de todas las sedes":
                    ShowForm(new FrmReporteTodasSedes());
                    this.Hide();
                    break;

                case "Buscar empleado  por cedula":
                    ShowForm(new FrmBuscarEmpleadoPorCedula());
                    this.Hide();
                    break;

                case "Listar empleados por su correo":
                    ShowForm(new FrmListarEmpleadosPorCorreo());
                    this.Hide();
                    break;

                case "Listar empleados por nombre de sede":
                    ShowForm(new FrmListarEmpleadosPorSede());
                    this.Hide();
                    break;

                case "Listar empleados por nombre de cargo":
                    ShowForm(new FrmListarEmpleadosPorCargo());
                    this.Hide();
                    break;

                case "Reporte grafico de genero":
                    ShowForm(new FrmReporteGraficoGenero());
                    this.Hide();
                    break;

                case "Reporte grafico de empleados por cargo":
                    ShowForm(new FrmReporteGraficoEmpleadosPorCargo());
                    this.Hide();
                    break;

                case "Reporte que presenta total de empleados por sedes":
                    ShowForm(new FrmReporteGraficoEmpleadosPorSede());
                    this.Hide();
                    break; 
            }
        }

        private void lblExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void ButttonX(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            switch (b.Text)
            {
                case "Sedes":
                    ShowForm(new FrmSedes());
                    this.Hide();
                    break;
                case "Cargos":
                    ShowForm(new FrmCargos());
                    this.Hide();
                    break;

                case "Empleados":
                    ShowForm(new FrmEmpleados());
                    this.Hide();
                    break;
                case "Reportes":
                    ShowForm(new FrmMainReports());
                    this.Hide();
                    break;
            }
        }
    }
}