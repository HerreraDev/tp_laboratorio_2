using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excepciones;
using Archivos;
using Entidades;

namespace Formularios
{

    public partial class FormInsertarSoftware : Form
    {
        /// <summary>
        /// Evento del tipo de delegado Insert
        /// Insertara el producto en la base y lo agregara al log de productos agregados
        /// </summary>
        public static event Insert realizarInsert;

        public FormInsertarSoftware()
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
                    Software auxSoft = new Software(this.txt_Nombre.Text, precio, cantidad, this.txt_Licencia.Text);


                    if (realizarInsert.Invoke(auxSoft))
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

        /// <summary>
        /// Intenta insertar el producto en la base de datos
        /// </summary>
        /// <param name="auxSoft"></param>
        /// <returns></returns>
        private bool InsertarProducto(Producto auxSoft)
        {
            bool exito = false;
            try
            {
                if (Stock.ListaProductosSoftware + (Software)auxSoft)
                {
                    exito = true;
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

