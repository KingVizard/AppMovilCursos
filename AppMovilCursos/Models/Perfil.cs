using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppMovilCursos.Models
{
    public class Perfiles
    {
        [PrimaryKey, AutoIncrement] public int IdPerfil { get; set; }
        public byte[] ImagenPefil { get; set; }
    }
}
