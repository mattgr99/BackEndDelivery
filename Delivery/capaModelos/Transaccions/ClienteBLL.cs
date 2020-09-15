
using capaModelos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEUDelivery.Transactions
{
    public class ClienteBLL
    {
        public static void Create(CLIENTE c)
        {
            using (DeliveryEntidades1 db = new DeliveryEntidades1())    //hace una conexion temporal a la bd
            {
                using (var transaction = db.Database.BeginTransaction())       //hace una transaccion 
                {
                    try
                    {
                        db.CLIENTE.Add(c);       //agrega a la tabla ALUMNO el objeto (a)
                        db.SaveChanges();       //guarda los cambios en la bd
                        transaction.Commit();   //confirma los cambios
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al crear cliente " + ex.Message);
                        transaction.Rollback(); //se revierte el estado de la bd a un estado anterior consistente en caso de error
                        throw ex;
                    }
                }
            }
        }

        public static CLIENTE Get(int? id)
        {
            using (DeliveryEntidades1 db = new DeliveryEntidades1())
            {
                try
                {
                    return db.CLIENTE.Find(id);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al obtener cliente " + ex.Message);
                    throw ex;
                }
            }

        }



        public static bool Update(CLIENTE cliente)
        {
            using (DeliveryEntidades1 db = new DeliveryEntidades1())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.CLIENTE.Attach(cliente);
                        db.Entry(cliente).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al actualizar alumno " + ex.Message);
                        return false;
                    }
                }
            }
        }


        public static void Delete(int? id)
        {
            using (DeliveryEntidades1 db = new DeliveryEntidades1())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        CLIENTE cliente = db.CLIENTE.Find(id);
                        db.Entry(cliente).State = System.Data.Entity.EntityState.Deleted;
                        db.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        Console.WriteLine("Error al eliminar " + ex.Message);
                        throw ex;

                    }
                }
            }
        }

        public static List<CLIENTE> List()
        {
            using (DeliveryEntidades1 db = new DeliveryEntidades1())
            {
                try
                {
                    return db.CLIENTE.ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al enviar la lista de clientes " + ex.Message);
                    throw ex;
                }
            }

        }

        public static List<CLIENTE> SearchCliente(string cedula)
        {
            DeliveryEntidades1 db = new DeliveryEntidades1();
            return db.CLIENTE.Where(x => x.documento.StartsWith(cedula)).ToList();

        }
    }
}
