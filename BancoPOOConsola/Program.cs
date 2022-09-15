
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoPOOConsola
{
    class Program
    {
       
        static Banco objBanco;
        static int leaEntero(string men)
        {
            int valor = 0;
            try
            {
                valor = Int32.Parse(lea(men));
            }
            catch
            {
                imp(" ERROR... Valor no valido");
                valor = leaEntero(men);
            }
            return valor;
        }
        static string lea(string men)
        {
            imp(men);
            return System.Console.ReadLine();
        }
        static void imp(string men)
        {
            System.Console.WriteLine(men);
        }
        static void imp(Cuenta objCuenta)
        {
            imp("LOS DATOS de LA CUENTA " + objCuenta.getNumero() + " SON:");
            imp("Nombre = " + objCuenta.getNombre());
            imp("Saldo = " + objCuenta.decirSaldo());
         }
        static void Main(string[] args)
        {
            int op = 0, op1=0, pos = 0;
            string sw = "no";
            DateTime objFecha = DateTime.Now;
            Console.Title="Programa Banco POO    "+objFecha.Day+"/"+objFecha.Month+"/"+objFecha.Year;
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            do
            {
                imp("\t MENU PRINCIPAL\n");
                imp(" 1. Menu Inicio Banco");
                imp(" 2. Menu Manejo Clientes");
                imp(" 3. Menu Manejo Transacciones");
                imp(" 4. Informe de las Cuentas del Banco");
                imp(" 0. Salir programa Banco");
                imp("\t Seleccione una opcion...");
                op = leaEntero("Seleccione una opcion...");
                Console.Clear();
                switch (op)
                {
                    case 1:
                        Console.Clear();
                        imp("\t Menu Inicio Banco\n");
                        imp(" 1. Crear Clientes definidos" + "\n 2. Crear Clientes vacio");
                        op1 = leaEntero("Seleccione una opcion...");
                        Console.Clear();
                        switch (op1)
                        {
                            case 1: objBanco = new Banco(); sw = "si"; break;
                            case 2:
                                int tam = leaEntero("Digite la cantidad de Clientes...");
                                tam = Int32.Parse(lea("Digite la cantidad de Clientes..."));
                                objBanco = new Banco(tam);
                                sw = "si";
                                break;
                            default:
                                imp(" ERROR... Valor no valido");
                                imp("NO se ha cargado los Clientes");
                                break;
                        }
                        break;
                    case 2:
                        if (sw == "si")
                        {
                            do
                            {
                                imp("\t Menu Manejo Clientes");
                                imp(" 1. Buscar Clientes por Nombre" + "\n 2. Buscar Clientes por Cuenta");
                                imp(" 3. Eliminar Clientes por Nombre" + "\n 4. Eliminar C" +
                                    "lientes Cuenta");
                                imp(" 5. Agregar Clientes por Nombre" + "\n 0. Regresar la menu Ppal");
                                op1 = leaEntero("Seleccione una opcion...");
                                Console.Clear();
                                switch (op1)
                                {
                                    case 1:
                                        string nom = lea("Ingrese el nombre a buscar");
                                        pos = objBanco.buscar(nom);
                                        if (pos >= 0)
                                        {
                                            Cuenta[] clientes = objBanco.VecClientes();
                                            imp(clientes[pos]);
                                        }
                                        else
                                        {
                                            imp("Cliente no existe\n");
                                        }
                                        break;
                                    case 2:
                                        int num = leaEntero("Ingrese el numero de cuenta a buscar");
                                        pos = objBanco.buscar(num);
                                        if (pos >= 0)
                                        {
                                            Cuenta[] clientes = objBanco.VecClientes();
                                            imp(clientes[pos]);
                                        }
                                        else
                                        {
                                            imp("Cliente no existe\n");
                                        }
                                        break;
                                    case 3:
                                        nom = lea("Ingrese el nombre a Eliminar");
                                        pos = objBanco.buscar(nom);
                                        if (pos >= 0)
                                        {
                                            Cuenta[] clientes = objBanco.VecClientes();
                                            objBanco.EliminarCliente(clientes[pos]);
                                            Console.WriteLine("Cliente "+nom+" eliminado\n");
                                        }
                                        else
                                        {
                                            imp("Cliente no existe\n");
                                        }
                                        break;
                                    case 4:
                                        imp("NO implemetado, similar a caso 3");
                                        break;
                                    case 5:
                                        Cuenta obj;
                                        int tipo = leaEntero("Digite:\n 1. para cuenta de ahorro \n 2. para cuenta corriente");
                                        if (tipo == 1)
                                        {
                                            nom = lea("Ingrese el nombre de la cuenta");
                                            double saldo = Double.Parse(lea("Ingrese el saldo "));
                                            obj = new CuentaAhorros(nom, saldo);
                                            objBanco.insertarCliente(obj);

                                        }
                                        else if (tipo == 2)
                                        {
                                            nom = lea("Ingrese el nombre de la cuenta");
                                            double saldo = Double.Parse(lea("Ingrese el saldo "));
                                            double sobregiro = Double.Parse(lea("Ingrese el sobregiro "));
                                            obj = new CuentaCorriente(nom, saldo, sobregiro);
                                            objBanco.insertarCliente(obj);

                                        }
                                        else imp("Valor no valido");
                                        break;
                                    case 0: break;// No realiza nada  
                                    default:
                                        imp("ERROR... Opcion "+op1+" no valida");
                                        break;
                                }
                            } while (op1 != 0);
                        }
                        else imp("No se han creado los clientes");
                        break;
                    case 3:
                        if (sw == "si")
                        {
                            do
                            {
                                imp("\t Menu Manejo Transacciones");
                                imp(" 1. Consultar saldo por Nombre" + "\n 2. Consultar saldo por Cuenta");
                                imp(" 3. Consignar" + "\n 4. Retirar " + "\n 0. Regresar la menu Ppal");
                                op1 = leaEntero("Seleccione una opcion...");
                                Console.Clear();
                                switch (op1)
                                {
                                    case 1:
                                        int num = leaEntero("Ingrese el numero de cuenta");
                                        pos = objBanco.buscar(num);
                                        if (pos >= 0)
                                        {
                                            Cuenta[] clientes = objBanco.VecClientes();
                                            imp(clientes[pos]);
                                        }
                                        else
                                        {
                                            imp("Cliente no existe\n");
                                        }
                                        break;
                                    case 2:
                                        String nom = lea("Ingrese el nombre a consultar el saldo");
                                        pos = objBanco.buscar(nom);
                                        if (pos >= 0)
                                        {
                                            Cuenta[] clientes = objBanco.VecClientes();
                                            imp("El saldo de " + nom + " es: " + clientes[pos].decirSaldo());
                                        }
                                        else
                                        {
                                            imp("Cliente no existe\n");
                                        }
                                        break;
                                    case 3:
                                        nom = lea("Ingrese el nombre a buscar");
                                        pos = objBanco.buscar(nom);
                                        if (pos >= 0)
                                        {
                                            int clave = 0;
                                            clave=leaEntero("digite la calve...");
                                            if (clave == objBanco.VecClientes()[pos].getNumero()) ;
                                            double cant = Double.Parse(lea("digite la cantidad a consignar..."));
                                            objBanco.VecClientes()[pos].consignacion(cant);
                                            imp(objBanco.VecClientes()[pos]);
                                        }
                                        else
                                        {
                                            imp("Cliente no existe\n");
                                        }
                                        break;
                                    case 4:
                                        nom = lea("Ingrese el nombre a buscar");
                                        pos = objBanco.buscar(nom);
                                        if (pos >= 0)
                                        {
                                            int clave = leaEntero("digite la calve...");
                                            if (clave == objBanco.VecClientes()[pos].getNumero()) ;
                                            double cant = Double.Parse(lea("digite la cantidad a retirar..."));
                                            objBanco.VecClientes()[pos].retiro(cant);
                                            imp(objBanco.VecClientes()[pos]);
                                        }
                                        else
                                        {
                                            imp("Cliente no existe\n");
                                        }
                                        break;
                                    case 0: break;// No realiza nada  
                                    default:
                                        imp("ERROR... Opcion "+op1+" no valida");
                                        break;
                                }
                            } while (op1 != 0);
                        }
                        else imp("No se han creado los clientes");
                        break;
                    case 4:
                        Console.Clear();
                        imp("\t INFORME DE LAS CUENTAS DEL BANCO\n");
                        imp("CODIGO\t NOMBRE\t SALDO");
                        int numCliente = objBanco.numClientes();
                        for (int i = 0; i < numCliente; i++)
                        {
                            imp(objBanco.VecClientes()[i].getNumero() + "\t" +
                                objBanco.VecClientes()[i].getNombre() + "\t" +
                                objBanco.VecClientes()[i].decirSaldo());
                        }
                        break;
                    case 0:
                        imp("Fin del Programa");
                        break;
                    default:
                        imp("ERROR... Opcion "+op+" no valida");
                        break;
                }
                } while (op != 0);
            Console.ReadKey();
        }
    }
}
