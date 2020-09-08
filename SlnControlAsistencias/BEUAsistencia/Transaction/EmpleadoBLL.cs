using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEUAsistencia.Transaction
{
    public class EmpleadoBLL
    {
        public static void Create(Empleado a)
        {
            using (Entities db = new Entities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Empleado.Add(a);
                        db.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public static Empleado Get(int? id)
        {
            Entities db = new Entities();
            return db.Empleado.Find(id);
        }

        public static void Update(Empleado empleado)
        {
            using (Entities db = new Entities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Empleado.Attach(empleado);
                        db.Entry(empleado).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }
        public static void Delete(int? id)
        {
            using (Entities db = new Entities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        Empleado empleado = db.Empleado.Find(id);
                        db.Entry(empleado).State = System.Data.Entity.EntityState.Deleted;
                        db.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public static List<Empleado> List()
        {
            Entities db = new Entities();
            return db.Empleado.ToList();
        }


        public static Empleado GetEmpleado(string cedula)
        {
            Entities db = new Entities();
            return db.Empleado.FirstOrDefault(x => x.cedula.EndsWith(cedula));
        }
    }
}

