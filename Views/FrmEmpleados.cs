using BancoEstatal.Helpers;
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
    public partial class FrmEmpleados : Form
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
            txtCedula.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtCorreo.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            //PicFotoUsuario.Image = null;
        }

        private void SearchImage()
        {
            try
            {
                OpenFileDialog op = new OpenFileDialog();
                op.Filter = "Imagenes png|*.png|Imagenes jpg|*.jpg|Imagenes gif|*.gif";
                if (op.ShowDialog() != DialogResult.Cancel)
                {
                    PicFotoUsuario.Image = Image.FromFile(op.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void ClearImage()
        {
            PicFotoUsuario.Image = null;
        }

        private void fillGrid()
        {
            dgvDatosEmpleados.AutoGenerateColumns = false;
            try
            {
                dgvDatosEmpleados.DataSource = UnitOfWork.EmpleadosS.GetAllDTO();
                dgvDatosEmpleados.Refresh();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void FillCbxCargos()
        {
            cbxCargo.DataSource = UnitOfWork.Cargo.GetAll();
            cbxCargo.DisplayMember = "caCargo";
            cbxCargo.ValueMember = "caID";
            cbxCargo.Refresh();
        }

        private void FillCbxSedes()
        {
            cbxSede.DataSource = UnitOfWork.Sede.GetAll();
            cbxSede.DisplayMember = "seNombre";
            cbxSede.ValueMember = "seID";
            cbxSede.Refresh();
        }

        private void FillCbxGenero()
        {
            cbxGenero.DataSource = UnitOfWork.Genero.GetAll();
            cbxGenero.DisplayMember = "genGenero";
            cbxGenero.ValueMember = "geID";
            cbxGenero.Refresh();
        }

        private void FillText(string id)
        {
            try
            {
                var ob = UnitOfWork.EmpleadosS.GetById(id);
                if (ob != null)
                {
                    txtCedula.Text = ob.emCedula;
                    txtNombre.Text = ob.emNombre;
                    txtApellido.Text = ob.emApellido;
                    txtCorreo.Text = ob.emCorreo;
                    txtDireccion.Text = ob.emDireccion;
                    txtTelefono.Text = ob.emTelefono;

                    cbxCargo.SelectedValue = ob.emCargos_fk;
                    cbxSede.SelectedValue = ob.emSedes_fk;
                    cbxGenero.SelectedValue = ob.emGenero_fk;

                    if (ob.emFoto != null)
                    {
                        PicFotoUsuario.Image = WMImages.Byte2Image(ob.emFoto);
                    }
                    else
                    {
                        PicFotoUsuario.Image = null;
                    }
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
            if (String.IsNullOrEmpty(txtNombre.Text))
                throw new Exception("Falta la descripción");

            return true;
        }

        private empleados CaptureData()
        {
            empleados ob = new empleados();

            if (txtCedula.Text.Trim() != "")
            {
                ob.emCedula = txtCedula.Text;
            }
            ob.emNombre = txtNombre.Text;
            ob.emApellido = txtApellido.Text;
            ob.emCorreo = txtCorreo.Text;
            ob.emDireccion = txtDireccion.Text;
            ob.emTelefono = txtTelefono.Text;

            ob.emCargos_fk = Convert.ToInt32(cbxCargo.SelectedValue);
            ob.emSedes_fk = Convert.ToInt32(cbxSede.SelectedValue);
            ob.emGenero_fk = Convert.ToInt32(cbxGenero.SelectedValue);


            if (PicFotoUsuario.Image != null)
            {
                ob.emFoto = WMImages.Image2Byte(PicFotoUsuario.Image);
            }

            return ob;

        }

        private void InsertData()
        {
            try
            {
                DialogResult r = MessageBox.Show("¿Los datos son correctos?",
                    "Cargo",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);


                if (r == DialogResult.Yes)
                {
                    empleados ob = CaptureData();
                    UnitOfWork.Empleado.Add(ob);
                    ClearText();
                    fillGrid();

                    MessageBox.Show("El registro se insertó correctamente",
                        "Correcto",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    Refresh();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error d23",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void UpdateData()
        {
            try
            {
                if (ValidateData())
                {
                    DialogResult r = MessageBox.Show("¿Los datos son correctos?",
                        "Correcto",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
                    if (r == DialogResult.Yes)
                    {
                        empleados ob = CaptureData();
                        UnitOfWork.EmpleadosS.Update(ob, ob.emCedula);
                        ClearText();
                        fillGrid();

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
                if (ValidateData())
                {
                    DialogResult r = MessageBox.Show("¿Desea elimiar el registro?",
                        "Cargo",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
                    if (r == DialogResult.Yes)
                    {
                        UnitOfWork.EmpleadosS.Delete(CaptureData().emCedula);
                        ClearText();
                        fillGrid();

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

        public FrmEmpleados()
        {
            InitializeComponent();
        }

        private void FrmEmpleados_Load(object sender, EventArgs e)
        {
            fillGrid();
            FillCbxCargos();
            FillCbxSedes();
            FillCbxGenero();
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

        private void btnSubir_Click(object sender, EventArgs e)
        {
            SearchImage();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            ClearImage();
        }

        private void lblSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dgvDatosEmpleados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
                FillText(Convert.ToString(dgvDatosEmpleados[0, e.RowIndex].Value));
        }

        private void btnSalir_Click(object sender, EventArgs e)
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
