using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppMovilCursos.Models
{
    public class Cursos
    {
        [PrimaryKey, AutoIncrement] public int IdCur { get; set; }
        [MaxLength(70)] public string NombreCurso { get; set; }
        [MaxLength(70)] public string TipoCurso { get; set; }
        [MaxLength(120)] public string DescCurso { get; set; }
        public int CantidadHoras { get; set; }

    }
}
