using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppMovilCursos.Models
{
    public class Usuarios
    {
        [PrimaryKey, AutoIncrement] public int IdUsuario { get; set; }
        [MaxLength(40)] public string Email { get; set; }
        [MaxLength(15)] public string Clave { get; set; }
        [MaxLength(150)] public string Nombre { get; set; }
        public int Edad { get; set;}
        public DateTime FechaCreacion { get; set; }
    }
}
