using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        double numero;

        public string SetNumero
        {
            set { this.numero = ValidarNumero(value); }
        }

        public Numero()
        {
            this.numero = 0;
        }
        public Numero(double numero)
        {
            this.numero = numero;
        }

        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }

        private double ValidarNumero(string strNumero)
        {
            double exito;
            if (double.TryParse(strNumero, out exito))
            {
                exito = 0;
            }
            return exito;
        }

        public static double operator +(Numero n1, Numero n2)
        {
            double retorno = 0;

            retorno = n1.numero + n2.numero;

            return retorno

        }

        public static double operator -(Numero n1, Numero n2)
        {
            double retorno = 0;

            retorno = n1.numero - n2.numero;

            return retorno;
        }

        public static double operator *(Numero n1, Numero n2)
        {
            double retorno = 0;

            retorno = n1.numero * n2.numero;

            return retorno;
        }
        public static double operator /(Numero n1, Numero n2)
        {
            double retorno = 0;
            if(n2.numero == 0)
            {
                retorno = double.MinValue;
            }
            else
            {
                retorno = n1.numero / n2.numero;
            }

            return retorno;
        }

        
        private bool EsBinario(string binario)
        {
            bool exito = true;

            char[] cadenaBinaria = binario.ToCharArray();

            for (int i = 0; i < cadenaBinaria.Length; i++)
            {
                if(cadenaBinaria[i] != '0' && cadenaBinaria[i] != '1')
                {
                    exito = false;
                    break;
                }
            }
            return exito;
        }





    }
}
