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
using Archivos;
using Excepciones;
using Validaciones;

namespace Formularios
{
    /// <summary>
    /// Delegado que permite metodos que devuelvan bool y que reciban un producto
    /// </summary>
    /// <param name="auxHard"></param>
    /// <returns></returns>
    public delegate bool Insert(Producto auxHard);

    public partial class FormInsertarHardware : Form
    {
        /// <summary>
        /// Evento del tipo de delegado Insert
        /// Insertara el producto en la base y lo agregara al log de productos agregados
        /// </summary>
        public static event Insert realizarInsert;

        public FormInsertarHardware()
        {
            InitializeComponent();
            realizarInsert += InsertarProducto;
            realizarInsert += Producto.Guardar;
        }



        private void btn_Aceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (double.TryParse(this.txt_Precio.Text, out double precio) && int.TryParse(this.txt_Cantidad.Text, out int cantidad) && int.TryParse(this.txt_Cantidad.Text, out int numeroDeParte))
                {
                    Hardware auxHard = new Hardware(this.txt_Nombre.Text, precio, cantidad, numeroDeParte);

                    if(realizarInsert.Invoke(auxHard))
                    {
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else
                {
                    MessageBox.Show("Verifique que no haya campos vacios");
                }


            }
            catch (DatosErroneosException errorDatosCargados)
            {
                MessageBox.Show(errorDatosCargados.Message);
            }
            catch (Exception errorGeneral)
            {
                MessageBox.Show(errorGeneral.Message);

            }
        }

        private bool InsertarProducto(Producto auxHard)
        {
            bool exito = false;
           
            try
            {
                if (Stock.ListaProductosHardware + (Hardware)auxHard)
                {
                   exito= true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return exito;
        }


        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

