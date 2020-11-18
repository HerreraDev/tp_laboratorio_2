using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using Validaciones;
using Excepciones;
using System.Threading;

namespace Formularios
{
    public partial class FormularioProductos : Form
    {
        Thread hiloRefrescar;
        public FormularioProductos()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.dtgProductos.DataSource = Entidades.Stock.ListaProductos;
        }

        private void btn_Aceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ckbx_Software.Checked && !(this.ckbx_Hardware.Checked) && this.txt_Nombre.Text !=string.Empty)
                {
                    Software auxSoft = new Software(this.ObtenerUltimoId() + 1,
                        this.txt_Nombre.Text, 
                        Validar.ValidarPrecio(this.txt_Precio.Text), 
                        Validar.ValidarCantidad(this.txt_Cantidad.Text), 
                        Producto.ETipoDeProducto.software);

                    //Inserto a la base
                    if (Stock.ListaProductos + auxSoft)
                    {
                        MessageBox.Show("Producto insertado");
                    }

                    //Guardo el producto en un txt
                    Producto.Guardar(auxSoft);
                }
                else if (this.ckbx_Hardware.Checked && !(this.ckbx_Software.Checked) && this.txt_Nombre.Text != string.Empty)
                {
                    Hardware auxHard = new Hardware(this.ObtenerUltimoId() + 1,
                        this.txt_Nombre.Text, Validar.ValidarPrecio(this.txt_Precio.Text), 
                        Validar.ValidarCantidad(this.txt_Cantidad.Text),
                        Producto.ETipoDeProducto.hardware);

                    //Inserto a la base
                    if (Stock.ListaProductos + auxHard)
                    {
                        MessageBox.Show("Producto insertado");
                    }

                    //Guardo el producto en un txt
                    Producto.Guardar(auxHard);

                }
                else
                {
                    MessageBox.Show("Verifique que no esten marcados los dos checkbox");
                }
            }
            catch (DatosErroneosException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (ArchivosException archivoError)
            {
                MessageBox.Show(archivoError.Message);
            }
            catch (Exception exGeneral)
            {
                MessageBox.Show(exGeneral.Message);
            }


        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private int ObtenerUltimoId()
        {
            List<Producto> auxLista = ManejoBaseDeDatos.TraerProductos();

            int auxLargo = auxLista.Count - 1;
            int auxIndice = -1;

            if (auxLargo == -1)
            {
                auxIndice = 0;
            }
            else
            {
                auxIndice = auxLista[auxLargo].IdProducto;

            }
            return auxIndice;

        }

        private void btn_Refrescar_Click(object sender, EventArgs e)
        {
            if (hiloRefrescar is null || !(hiloRefrescar.IsAlive))
            {
                this.hiloRefrescar = new Thread(refrescarDataGridViewProductos);
                hiloRefrescar.Start();
            }
        }

        private void btn_CancelarRefresco_Click(object sender, EventArgs e)
        {
            if (hiloRefrescar.IsAlive)
            {
                hiloRefrescar.Abort();
            }
        }

        private void refrescarDataGridViewProductos()
        {
            List<Producto> productos = ManejoBaseDeDatos.TraerProductos();

            if (this.dtgProductos.InvokeRequired)
            {
                this.dtgProductos.BeginInvoke((MethodInvoker)delegate ()
                {
                    this.dtgProductos.DataSource = null;
                    this.dtgProductos.DataSource = productos;
                });
            }
            else
            {
                this.dtgProductos.DataSource = null;
                this.dtgProductos.DataSource = productos;
            }

            Thread.Sleep(2000);
            refrescarDataGridViewProductos();
        }

        private void FormularioProductos_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(hiloRefrescar != null)
            {
                this.hiloRefrescar.Abort();
            }
        }

        private void dtgProductos_DoubleClick(object sender, EventArgs e)
        {
            //string nombreProducto = (string)dtgProductos.CurrentRow.Cells["NombreProducto"].Value.ToString();

            //for (int i = 0; i < Stock.ListaProductos.Count; i++)
            //{
            //    if (Stock.ListaProductos[i].NombreProducto == nombreProducto)
            //    {
            //        ManejoBaseDeDatos.EliminarProducto(Stock.ListaProductos[i]);
            //        break;
            //    }
            //}
        }
    }
}
