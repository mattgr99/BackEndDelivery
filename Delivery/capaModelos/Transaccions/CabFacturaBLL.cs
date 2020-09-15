using capaModelos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEUDelivery.Transactions
{
    public class CabFacturaBLL
    {
        public static void Create(CAB_FACTURA cf)
        {

            using (DeliveryEntidades1 db = new DeliveryEntidades1())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.CAB_FACTURA.Add(cf);
                        db.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("No se ha podido crear la  cabeza de factura " + ex.Message);
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public static CAB_FACTURA Get(int? id)
        {
            using (DeliveryEntidades1 db = new DeliveryEntidades1())
            {
                try
                {
                    return db.CAB_FACTURA.Find(id);
                }
                catch (Exception ex)
                {
                    // Console.WriteLine("No se ha podido retornar la cabeza de factura " + ex.Message);
                    throw ex;
                }
            }
        }

        public static void Update(CAB_FACTURA cf)
        {

            using (DeliveryEntidades1 db = new DeliveryEntidades1())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.CAB_FACTURA.Attach(cf);
                        db.Entry(cf).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("No se ha podido actualizar  la materia " + ex.Message);
                        transaction.Rollback();
                        throw ex;
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
                        CAB_FACTURA Materia = db.CAB_FACTURA.Find(id);
                        db.Entry(Materia).State = System.Data.Entity.EntityState.Deleted;
                        db.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("No se ha podido eliminar la cabeza de factura " + ex.Message);
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public static List<CAB_FACTURA> List()
        {
            using (DeliveryEntidades1 db = new DeliveryEntidades1())
            {
                try
                {
                    return db.CAB_FACTURA.ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("No se ha podido retornar la lista de cabezas de factura " + ex.Message);
                    throw ex;
                }
            }

        }

        public static CAB_FACTURA GetLastItem()
        {
            DeliveryEntidades1 db = new DeliveryEntidades1();
            List<CAB_FACTURA> resultado;
            resultado = db.CAB_FACTURA.ToList();
            CAB_FACTURA item = new CAB_FACTURA();
            if (resultado.Count > 0)
            {
                item = resultado[resultado.Count - 1];
            }
            return item;
        }
    }
}
