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
    public partial class FrmSedes : Form
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

        private void FillCbxCiudad()
        {
            cbxCiudad.DataSource = UnitOfWork.Ciudad.GetAll();
            cbxCiudad.DisplayMember = "ciCiudad";
            cbxCiudad.ValueMember = "ciID";
            cbxCiudad.Refresh();
        }

        private void ClearText()
        {
            txtID.Text = "";
            txtNombre.Text = "";
            txtTelefono.Text = "";
            //txtCiudad.Text = "";
            txtDireccion.Text = "";
            
        }

        private void FillGrid()
        {
            dgvDatosSedes.AutoGenerateColumns = true;
            try
            {
                dgvDatosSedes.DataSource = UnitOfWork.SedeS.GetAllDTO();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void FillText(int id)
        {
            try
            {
                var ob = UnitOfWork.Sede.GetById(id);
                if (ob != null)
                {
                    txtID.Text = ob.seID.ToString();
                    txtNombre.Text = ob.seNombre;
                    txtTelefono.Text = ob.seTelefono;
                    txtDireccion.Text = ob.seDireccion;
                    cbxCiudad.SelectedValue = ob.seCiudad_fk;
                }
                else
                {
                    ClearText();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private bool ValidateData(bool isIDRequired = false)
        {
            if (isIDRequired)
            {
                if (String.IsNullOrEmpty(txtNombre.Text))
                    throw new Exception("Falta la descripción");
            }

            return true;
        }

        private sedes CaptureData(bool isIDRequired = false)
        {
            sedes ob = new sedes();

            if (isIDRequired)
            {
                ob.seID = Convert.ToInt32(txtID.Text);
            }
            ob.seNombre = txtNombre.Text;
            ob.seTelefono = txtTelefono.Text;
            ob.seDireccion = txtDireccion.Text;
            ob.seCiudad_fk = Convert.ToInt32(cbxCiudad.SelectedValue);

            return ob;
        }

        private void InsertData()
        {
            try
            {
                if (ValidateData(false))
                {
                    DialogResult r = MessageBox.Show("¿Los datos son correctos?",
                        "Cargo",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
                    if (r == DialogResult.Yes)
                    {
                        sedes ob = CaptureData();
                        UnitOfWork.Sede.Add(ob);
                        ClearText();
                        FillGrid();

                        MessageBox.Show("El registro se insertó correctamente",
                            "Correcto",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        Refresh();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
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
                    DialogResult r = MessageBox.Show("¿Los datos son correctos?",
                        "Correcto",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
                    if (r == DialogResult.Yes)
                    {
                        sedes ob = CaptureData(true);
                        ob.seID = Convert.ToInt32(txtID.Text);
                        UnitOfWork.Sede.Update(ob, ob.seID);
                        ClearText();
                        FillGrid();

                        MessageBox.Show("El registro se actualizó correctamente",
                            "Correcto",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
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
                    DialogResult r = MessageBox.Show("¿Desea elimiar el registro?",
                        "Cargo",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
                    if (r == DialogResult.Yes)
                    {
                        sedes ob = CaptureData(true);
                        UnitOfWork.Sede.Delete(ob.seID);
                        ClearText();
                        FillGrid();

                        MessageBox.Show("El registro se eliminó correctamente",
                            "Cargo",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

        }

        public FrmSedes()
        {
            InitializeComponent();
        }

        private void FrmSedes_Load(object sender, EventArgs e)
        {
            FillGrid();
            FillCbxCiudad();
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

        private void clickX(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex > -1)
            {
                FillText(Convert.ToInt32(dgvDatosSedes[0, e.RowIndex].Value));
            }
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

        private void lblExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
