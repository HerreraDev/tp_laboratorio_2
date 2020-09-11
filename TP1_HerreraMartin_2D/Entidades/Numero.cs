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

            return retorno;

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
            if (n2.numero == 0)
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
                if (cadenaBinaria[i] != '0' && cadenaBinaria[i] != '1')
                {
                    exito = false;
                    break;
                }
            }
            return exito;
        }

        public string BinarioDecimal(string binario)
        {
            string strResultado = "Valor invalido";

            if (EsBinario(binario))
            {
                char[] charBinario = binario.ToCharArray();
                Array.Reverse(charBinario);

                double acumuladorResultado = 0;

                for (int i = 0; i < charBinario.Length; i++)
                {
                    if (charBinario[i] == '1')
                    {
                        if (i == 0)
                        {
                            acumuladorResultado += 1;

                        }
                        else
                        {
                            acumuladorResultado += (int)Math.Pow(2, i);
                        }
                    }

                }
                strResultado = Convert.ToString(acumuladorResultado);
            }
            return strResultado;
        }


        public static string DecimalBinario(double numero)
        {
            string strBinario = "";
            int enteroDelNumero = (int)(numero);

            if (enteroDelNumero > 0)
            {
                while (enteroDelNumero > 1)
                {
                    int remainder = enteroDelNumero % 2;
                    strBinario = Convert.ToString(remainder) + strBinario;
                    enteroDelNumero /= 2;
                }
                strBinario = Convert.ToString(enteroDelNumero) + strBinario;

            }
            else
            {
                if (enteroDelNumero == 0)
                {
                    strBinario = "0";
                }
                else
                {
                    strBinario = "Valor invalido";
                }
            }

            return strBinario;
        }

        public static string DecimalBinario(string numero)
        {
            double auxConversion;
            string strConversion = "";
            if(double.TryParse(numero, out auxConversion))
            {
                strConversion = DecimalBinario(auxConversion);
            }
                
            return strConversion;
        }




    }
}
