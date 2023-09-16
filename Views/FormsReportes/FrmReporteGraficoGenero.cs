﻿using BancoEstatal.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BancoEstatal.Views.FormsReportes
{
    public partial class FrmReporteGraficoGenero : Form
    {
        private void FillGrid()
        {
            //EmpleadosDTOBindingSource.DataSource = UnitOfWork.EmpleadosS.ge
        }
        public FrmReporteGraficoGenero()
        {
            InitializeComponent();
        }
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
        private void ButtonX(object sender, EventArgs e)
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

        private void lblExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FrmReporteGraficoGenero_Load(object sender, EventArgs e)
        {
            EmpleadosDTOBindingSource.DataSource = UnitOfWork.EmpleadosS.GetAllDTO();
            reportViewer1.RefreshReport();
            
        }
    }
}
