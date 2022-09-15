using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoPOOConsola
{
    public class CuentaAhorros: Cuenta 
    {
        //No posee otras propiedades diferente a las cuenta
        //Metodo constructor
        public CuentaAhorros(string nombre, double saldo)
            : base( nombre, saldo)
        {
            System.Windows.Forms.MessageBox.Show("Cuenta de Ahorros de "+nombre+" creda "+getNumero() );
        }
       //Sobre escritura del metodo abstracto
        public override void retiro(double cantidad)
        {
            if (decirSaldo() >= cantidad)
            {
                saldo = saldo - cantidad;
                System.Windows.Forms.MessageBox.Show("Retiro efectuado \n Nuevo Saldo: " + saldo);
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Saldo insuficiente");
            }
        }
    }
}
