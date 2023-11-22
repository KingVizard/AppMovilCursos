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
            db.CreateTableAsync<SeguimientoCursos>().Wait();

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

        //--------------------------------------------------
        //--------------------------------------------------
        //--------------------------------------------------

        //GUARDAR CURSOS
        public Task<int> SaveCursoAsync(Cursos cur)
        {
            if (cur.IdCur != 0)
            {
                return db.UpdateAsync(cur);
            } else
            {
                return db.InsertAsync(cur);
            }
        }

        //MOSTRAR CURSOS
        public Task<List<Cursos>> GetCursosAsync()
        {
            return db.Table<Cursos>().ToListAsync();
        }

        //CONSULTA CURSOS
        public Task<Cursos> GetCursosIdAsync(int cursoId)
        {
            return db.Table<Cursos>().Where(i => i.IdCur == cursoId).FirstOrDefaultAsync();
        }

        //GUARDAR CURSOS ++ ACTUALIZAR
        public Task<int> SaveCursosAsync(Cursos curso)
        {
            //if(emple.IdEmp == 0)
            if (curso.IdCur != 0)
            {
                //return db.InsertAsync(emple);
                return db.UpdateAsync(curso);
            }
            else
            {
                //return null;
                return db.InsertAsync(curso);
            }
        }

        //ELIMINAR CURSOS
        public Task<int> DeleteCursoAsync(Cursos cursos)
        {
            return db.DeleteAsync(cursos);
        }

        //--------------------------------------------------
        //--------------------------------------------------
        //--------------------------------------------------
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

        //--------------------------------------------------
        //--------------------------------------------------
        //--------------------------------------------------

        //GUARDAR Seguimiento ++ ACTUALIZAR
        public Task<int> SaveSeguimientoAsync(SeguimientoCursos seg)
        {
            //if(emple.IdEmp == 0)
            if (seg.Id != 0)
            {
                //return db.InsertAsync(emple);
                return db.UpdateAsync(seg);
            }
            else
            {
                //return null;
                return db.InsertAsync(seg);

            }
        }

        //CONSULTA EMPLEADO
        public Task<SeguimientoCursos> GetSegIdAsync(int SegId)
        {
            return db.Table<SeguimientoCursos>().Where(i => i.Id == SegId).FirstOrDefaultAsync();
        }


        //CONSULTAR SEGUIMIENTO
        public Task<List<SeguimientoCursos>> GetSeguimientoAsync()
        {
            return db.Table<SeguimientoCursos>().ToListAsync();
        }

        //ELIMINAR SEGUIMIENTO
        public Task<int> DeleteSeguimientoAsync(SeguimientoCursos segui)
        {
            return db.DeleteAsync(segui);
        }
    }
}
