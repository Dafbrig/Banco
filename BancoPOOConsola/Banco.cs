using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoPOOConsola
{
    public class Banco
    {
        private Cuenta[] clientes; // Define el vector de objetos tipo clase Cuenta, se va a manejar como una pila
        private int nElementos; // número de elementos de el vector
        private int posicion;  //Para saber hasta donde esta lleno el vector
        //Métodos Constructor  
        public Banco()  {   // Crear un vector de clientes con 10 elementos y 5 de inicilizacion
            nElementos = 10;
            clientes = new Cuenta[nElementos];
            Cuenta a = new CuentaAhorros("Juan", 100000);
            Cuenta c = new CuentaCorriente ("Pedro", 200000, 2000);
            clientes[0] = a;
            clientes[1] = c;
            a = new CuentaAhorros("Ana", 300000);
            c = new CuentaCorriente ("Luz", 400000, 1000);
            clientes[2] = a;
            clientes[3] = c;
            c = new CuentaCorriente ("Jose", 500000, 6000);
            clientes[4] = c;
            posicion = 5; //porque ingresamso 5 elementos al vector
        }
        public Banco(int tamano)  {   // Crear un vector de clientes por defecto vacio y del tamaño definido por el usuario 
            clientes = new Cuenta[tamano];
            nElementos=tamano;
            posicion = 0;
        }
        //Metodo para validar si el Vector esta vacio
        public bool vacio(){
             if (posicion == 0){
                 System.Windows.Forms .MessageBox.Show("No existen clientes"); 
                 return true;
             } else {
                 return false;
             }
        }
         //Metodo para validar si el Vector esta lleno
        public bool lleno(){
             if (posicion >= nElementos){
                 System.Windows.Forms .MessageBox.Show("No hay espacio"); 
                 return true;
             } else {
                 return false;
             }
        }
        // Buscar un cliente por nombre y devolver su posición
        public int buscar(String nom)  { 
            int pos = -1; //variable para retorna la posicion
             if (nom == null || nom == "") { //valido que ingrese un parametro valido
                 System.Windows.Forms .MessageBox.Show("Informacion no valida"); 
                 return -1;
             }
            if (vacio()) { //valido que existan elementos en el vector
                return -1;
            }
            for ( int i = 0; i < posicion ; i++ ) {
                if (nom == clientes[i].getNombre()) {
                    pos = i; // Que si nombre existe y retornamos la posicion
                    break;
                }
            }
         return pos;
        }
        // Buscar un cliente por numero y devolver su posición
        public int buscar(int num)  { 
            int pos = -1; //variable para retorna la posicion
             if (num <= 0) { //valido que ingrese un parametro valido
                 System.Windows.Forms .MessageBox.Show("Informacion no valida"); 
                 return -1;
             }
            if (vacio()) { //valido que existan elementos en el vector
                return -1;
            }
            for ( int i = 0; i < posicion ; i++ ) {
                if (num.Equals(clientes[i].getNumero())) {
                    pos = i; // Que si nombre existe y retornamos la posicion
                    break;
                }
            }
         return pos;
        }
        // Agrega un nuevo elemento el vector, un nuevo cliente
        public void insertarCliente( Cuenta objeto )  {   
            if (lleno()){ //valido que no este lleno
                System.Windows.Forms .MessageBox.Show("No se pudo guardar"); 
            } else {
                clientes[posicion] = objeto;
                System.Windows.Forms .MessageBox.Show("Cliente "+clientes[posicion].getNombre()+ " Guardado en el sistema");
			posicion = posicion + 1; //ojo incrementa la posicion
             }
        }
        public void EliminarCliente(Cuenta obj)
        {
            if (vacio())
            { // valido que no este vacio
                System.Windows.Forms.MessageBox.Show("No existen cliente");
                return;
            }
            else
            {
                int pos = buscar(obj.getNombre());
                if (pos == -1)
                {
                    System.Windows.Forms.MessageBox.Show("El cliente No existe ");
                    return;
                }
                else
                {
                    for (int i = pos; i < nElementos; i++)
                    {
                        clientes[i] = clientes[i + 1];
                    }
				posicion = posicion - 1;//ojo decrementa la posicion
                }
            }
        }
       public int numClientes(){
         return posicion ;
      }
        public Cuenta[] VecClientes()
        {
            return clientes;
        } 
    }
}
 

  
  
  

