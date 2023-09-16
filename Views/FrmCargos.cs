using BancoEstatal.Model;
using BancoEstatal.Services;
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
    public partial class FrmCargos : Form
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

        private void ClearText()
        {
            txtID.Text = "";
            txtCargo.Text = "";
            txtFuncion.Text = "";
        }

        private void FillGrid()
        {
            try
            {
                dgvDatosCargos.AutoGenerateColumns = true;
                dgvDatosCargos.DataSource = UnitOfWork.Cargo.GetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al llenar los datos.",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void FillText(int id)
        {
            try
            {
                cargos ob = UnitOfWork.Cargo.GetById(id);
                if (ob != null)
                {
                    txtID.Text = ob.caID.ToString();
                    txtCargo.Text = ob.caCargo;
                    txtFuncion.Text = ob.caFuncion;
                }
                else
                {
                    ClearText();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al llenar los datos.",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private bool ValidateData(bool isIDRequired = true)
        {
            if (isIDRequired)
            {
                if (String.IsNullOrEmpty(txtCargo.Text))
                    throw new Exception("Falta el nombre del cargo.");

                if (String.IsNullOrEmpty(txtFuncion.Text))
                    throw new Exception("Falta la funcion del cargo.");
            }

            return true;
        }

        private cargos CaptureData(bool isIDRequired = false)
        {
            cargos ob = new cargos();

            if (isIDRequired)
            {
                ob.caID = Convert.ToInt32(txtID.Text);
            }
            ob.caCargo = txtCargo.Text;
            ob.caFuncion = txtFuncion.Text;
            return ob;
        }

        private void InsertData()
        {
            try
            {
                if (ValidateData(true))
                {
                    DialogResult r = MessageBox.Show("¿Los datos estan correctos?",
                        "Tipo de cargo",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
                    if (r == DialogResult.Yes)
                    {
                        cargos ob = CaptureData();
                        UnitOfWork.Cargo.Add(ob);
                        ClearText();
                        FillGrid();

                        MessageBox.Show("Los datos se guardaron exitosamente!!",
                            "Guardado de datos",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        Refresh();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al guardar los datos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void UpdateData()
        {
            try
            {
                if (ValidateData(true))
                {
                    DialogResult r = MessageBox.Show("¿Los datos estan correctos?",
                        "Confirmacion",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
                    if (r == DialogResult.Yes)
                    {
                        cargos ob = CaptureData(true);
                        ob.caID = Convert.ToInt32(txtID.Text);
                        UnitOfWork.Cargo.Update(ob, ob.caID);
                        ClearText();
                        FillGrid();

                        MessageBox.Show("El registro ha sido actualizado",
                            "Actualizacion",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al actualizar los datos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void DeleteData()
        {
            try
            {
                if (ValidateData(true))
                {
                    DialogResult r = MessageBox.Show("¿Esta seguro de elimiar el registro?",
                        "Eliminar",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
                    if (r == DialogResult.Yes)
                    {
                        cargos ob = CaptureData(true);
                        UnitOfWork.Cargo.Delete(ob.caID);
                        ClearText();
                        FillGrid();

                        MessageBox.Show("El registro fue eliminado",
                            "Eliminar",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al eliminar los datos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        public FrmCargos()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            ClearText();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            InsertData();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            UpdateData();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DeleteData();
        }

        private void ClickX(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
                FillText(Convert.ToInt32(dgvDatosCargos[0, e.RowIndex].Value));
        }

        private void lblSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        private void FrmCargos_Load(object sender, EventArgs e)
        {
            FillGrid();
        }
    }
}
