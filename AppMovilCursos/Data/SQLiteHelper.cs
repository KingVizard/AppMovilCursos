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
        }

        //GUARDAR EMPLEADOS
        public Task<int> SaveEmpleadoAsync(Empleados emple) 
        {
            if(emple.IdEmp == 0)
            {
                return db.InsertAsync(emple);
            } else
            {
                return null;
            }
        }

        //MOSTRAR EMPLEADOS
        public Task<List<Empleados>> GetEmpleadosAsync() 
        {
            return db.Table<Empleados>().ToListAsync();
        }
    }
}
