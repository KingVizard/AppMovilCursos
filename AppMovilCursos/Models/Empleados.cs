using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppMovilCursos.Models
{
     public class Empleados
    {
        [PrimaryKey, AutoIncrement] public int IdEmp { get; set; }
        [MaxLength(150)] public string Nombre { get; set; }
        [MaxLength(50)] public string Direccion { get; set; }
        [MaxLength(15)] public string Telefono { get; set; }
        public int Edad { get; set; }
        [MaxLength(25)] public string Curp { get; set; }
        [MaxLength(10)] public string TipoEmpleado { get; set; }
        public byte[] imgContent { get; set; }
    }
}
