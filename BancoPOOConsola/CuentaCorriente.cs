using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoPOOConsola
{
    public class CuentaCorriente : Cuenta
    {
        //Propiedades o Variable miembro
        private double sobregiro;
        //Metodo constructor
        public CuentaCorriente(string nombre, double saldo, double sobregiro)
            : base(nombre, saldo)
        {
            this.sobregiro = sobregiro;
            System.Windows.Forms.MessageBox.Show("Cuenta Corriente de " + nombre + " creda "+getNumero() );
        }
        //Metodos para el manejo de variables
        public double  getSobregiro()
        {
            return sobregiro ;
        }
        public void setSobregiro(double sobregiro)//Ojo es sobregiro
        {
            this.sobregiro = sobregiro;
        }
        //Sobre escritura del metodo abstracto
        public override void retiro(double cantidad)
        {
            double cantRetiro = saldo + sobregiro;
            if (cantRetiro >= cantidad)
            {
                saldo = saldo - cantidad;
                System.Windows.Forms.MessageBox.Show("Retiro efectuado \n Nuevo Saldo: " + saldo);
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Saldo y sobre giro insuficiente");
            }
        }
    }
}
