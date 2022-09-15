using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoPOOConsola
{
    public abstract class Cuenta
    {
        //Propiedades o Variable miembro
        private string nombre;
        protected double saldo; //Para poder manejar saldo en las clases que heredan
        private int numero;
        private static int contador=0; //Estatica para que sea comun a todos los objetos Variable miembro de la clase
        //Metodo constructor: Solo uno porque posee todas las varibles que como minimo debe poseer una cuenta
        public Cuenta( string nombre, double saldo)
        {
            this.nombre = nombre;//Se igualan las variables locales a las miembro
            this.saldo = saldo;
            contador = contador + 1;
            numero = contador; //se va a manejar autoincremental

        }
        //Metodos para el manejo de variables
        public int getNumero()
        {
            return numero;
        }
        //public void setNumero(int numero) No va porque la asigna el sistema
        public string getNombre()
        {
            return nombre;
        }
        public void setNombre(string nombre)
        {
            this.nombre = nombre;
        }
        //Los metodos get y set para saldo no van por esta variable depende del manejo de la cuenta.
        //Metodos productivos
        public double decirSaldo()
        {
            return saldo;
        }
        public void consignacion(double cantidad)
        {
            saldo = saldo + cantidad; //Este es el nuevo saldo
            System.Windows.Forms.MessageBox.Show("Consignacion efectuada \n Nuevo Saldo: " + saldo);
        }
        public abstract void retiro(double cantidad); //Estatico porque es diferente para Cuestas corrientes y de Ahorro

    }
}
