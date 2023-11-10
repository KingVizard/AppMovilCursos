using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using AppMovilCursos.Models;
using System.Threading.Tasks;

namespace AppMovilCursos.Data
{
    public class SQLiteHelper
    {
        SQLiteAsyncConnection db;

        public SQLiteHelper(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<Empleados>().Wait();
            db.CreateTableAsync<Cursos>().Wait();
            db.CreateTableAsync<Usuarios>().Wait();
            db.CreateTableAsync<Perfiles>().Wait();

        }

        //GUARDAR EMPLEADOS ++ ACTUALIZAR
        public Task<int> SaveEmpleadoAsync(Empleados emple)
        {
            //if(emple.IdEmp == 0)
            if (emple.IdEmp != 0)
            {
                //return db.InsertAsync(emple);
                return db.UpdateAsync(emple);
            } else
            {
                //return null;
                return db.InsertAsync(emple);

            }
        }

        //ELIMINAR EMPLEADOS
        public Task<int> DeleteEmpleadoAsync(Empleados emple)
        {
            return db.DeleteAsync(emple);
        }

        //MOSTRAR EMPLEADOS
        public Task<List<Empleados>> GetEmpleadosAsync()
        {
            return db.Table<Empleados>().ToListAsync();
        }

        //CONSULTA EMPLEADO
        public Task<Empleados> GetEmpleadoIdAsync(int personId)
        {
            return db.Table<Empleados>().Where(i => i.IdEmp == personId).FirstOrDefaultAsync();
        }

        //ACTUALIZAR EMPLEADO


        //GUARDAR CURSOS
        public Task<int> SaveCursoAsync(Cursos cur)
        {
            if (cur.IdCur == 0)
            {
                return db.InsertAsync(cur);
            } else
            {
                return null;
            }
        }

        //MOSTRAR CURSOS
        public Task<List<Cursos>> GetCursosAsync()
        {
            return db.Table<Cursos>().ToListAsync();
        }

        /////////////////////////////////////////////////
        public Task<int> SaveUsuario(Usuarios usr)
        {
            if (usr.IdUsuario != 0)
            {
                return db.UpdateAsync(usr);
            }
            else
            {
                return db.InsertAsync(usr);
            }
        }
        /////////////////////////////////////////////////

        //public Task<List<Usuarios>> GetUsuariosAsyncValidate(string email, string password)
        //{
        //    return db.QueryAsync<Usuarios>("SELECT Email, Clave FROM Usuarios WHERE Email=" + email + " AND Clave=" + password);
        //    return db.QueryAsync<Usuarios>("SELECT Email, Clave FROM Usuarios WHERE Email='" + email + "'" + " AND Clave='" + password + "'");
        //}


        public IEnumerable<Usuarios> GetUsuariosAsyncValidate(string email, string password)
        {
            //return db.QueryAsync<Usuarios>("SELECT Email, Clave FROM Usuarios WHERE Email=" + email + " AND Clave=" + password); 
            //return db.QueryAsync<Usuarios>("SELECT Email, Clave FROM Usuarios WHERE Email='" + email + "'" + " AND Clave='" + password + "'");
            //return db.QueryAsync<Usuarios>("SELECT Email, Clave FROM Usuarios WHERE Email='" + email + "'" + " AND Clave='" + password + "'").Result;
            return db.QueryAsync<Usuarios>("SELECT Email, Clave FROM Usuarios WHERE Email=? AND Clave=?", email, password).Result;

        }
    }
}
