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
    public partial class FrmReporteTodasSedes : Form
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
        public FrmReporteTodasSedes()
        {
            InitializeComponent();
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
        private void FillGrid()
        {
            SedesDTOBindingSource.DataSource = UnitOfWork.SedeS.GetAllDTO();
            reportViewer1.RefreshReport();
        }
        private void FrmReporteTodasSedes_Load(object sender, EventArgs e)
        {

            FillGrid();
        }

        private void lblExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
