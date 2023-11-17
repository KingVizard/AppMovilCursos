using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppMovilCursos.Models
{
    public class SeguimientoCursos
    {
        [PrimaryKey, AutoIncrement] public int Id{ get; set; }
        [MaxLength(150)] public string NombreEmpleado { get; set; }
        [MaxLength(70)] public string NombreCurso { get; set; }
        [MaxLength(70)] public string Lugar { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan Horas { get; set; }
        [MaxLength(15)] public string Estatus { get; set; }
        public int Calificacion { get; set; }


    }
}
