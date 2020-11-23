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
    /// <summary>
    /// Delegado que permite metodos que devuelvan bool y que reciban un producto
    /// </summary>
    /// <param name="auxProd"></param>
    /// <returns></returns>
    public delegate bool Insert(Producto auxProd);
    public partial class FormPrincipal : Form
    {
        /// <summary>
        /// Hilo que se lanzara para que ejecute el metodo que actualice los DataGridView de forma constante
        /// </summary>
        Thread hiloRefrescar;
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.dtgSoftware.DataSource = Entidades.Stock.ListaProductosSoftware;
            this.dtgHardware.DataSource = Entidades.Stock.ListaProductosHardware;

            this.btn_Refrescar.Enabled = true;
            this.btn_CancelarRefresco.Enabled = false;
        }



        /// <summary>
        /// En este boton se lanza el hilo nuevo con el metodo para refrescar los DataGridView
        /// </summary>
        private void btn_Refrescar_Click(object sender, EventArgs e)
        {
            
            if (hiloRefrescar is null || !(hiloRefrescar.IsAlive))
            {
                this.btn_Refrescar.Enabled = false;
                this.btn_CancelarRefresco.Enabled = true;

                this.hiloRefrescar = new Thread(refrescarDataGridViewProductos);
                hiloRefrescar.Start();
            }
        }

        /// <summary>
        /// Se cancela el hilo de refresco automatico
        /// </summary>
        private void btn_CancelarRefresco_Click(object sender, EventArgs e)
        {
            if (hiloRefrescar.IsAlive)
            {
                this.btn_Refrescar.Enabled = true;
                this.btn_CancelarRefresco.Enabled = false;
                hiloRefrescar.Abort();
            }
        }

        /// <summary>
        /// Metodo que se ejecuta en un hilo secundario
        /// refresca los DataGridView cada 4 segundos
        /// trayendo la informacion de la base de datos
        /// </summary>
        private void refrescarDataGridViewProductos()
        {

            Stock.ActualizarListas();

            if (this.dtgSoftware.InvokeRequired || this.dtgHardware.InvokeRequired)
            {
                this.dtgSoftware.BeginInvoke((MethodInvoker)delegate ()
                {
                    this.dtgSoftware.DataSource = Stock.ListaProductosSoftware; 
                });
                this.dtgHardware.BeginInvoke((MethodInvoker)delegate ()
                {
                    this.dtgHardware.DataSource = Stock.ListaProductosHardware;
                });
            }
            else
            {
                this.dtgSoftware.BeginInvoke((MethodInvoker)delegate ()
                {
                    this.dtgSoftware.DataSource = Stock.ListaProductosSoftware;
                });
                this.dtgHardware.BeginInvoke((MethodInvoker)delegate ()
                {
                    this.dtgHardware.DataSource = Stock.ListaProductosHardware;
                });
            }

            Thread.Sleep(4000);
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

        }

        private void btn_Software_Click(object sender, EventArgs e)
        {
            FormInsertarSoftware formInsertarSoftware = new FormInsertarSoftware();

            if (formInsertarSoftware.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Producto insertado y agregado al log.txt");
            }
            else
            {
                MessageBox.Show("Se cancelo la operacion");
            }


        }

        private void btn_Hardware_Click(object sender, EventArgs e)
        {
            FormInsertarHardware formInsertarHardware = new FormInsertarHardware();

            if (formInsertarHardware.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Producto insertado y agregado al log.txt");
            }
            else
            {
                MessageBox.Show("Se cancelo la operacion");
            }
        }

        private void btn_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
