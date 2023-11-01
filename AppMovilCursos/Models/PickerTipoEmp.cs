using System;
using System.Collections.Generic;
using System.Text;

namespace AppMovilCursos.Models
{
    public class PickerTipoEmp
    {
        public List<ModelPicker> TipoEmps { get; set; }


        private ModelPicker selectedTipo { get; set; }
        public ModelPicker SelectedTipo
        {
            get { return SelectedTipo; }

            set
            {
                if (selectedTipo != value)
                {
                    selectedTipo = value;
                }
            }
        }

        public List<ModelPicker> GetTipos()
        {
            var Tipos = new List<ModelPicker>()
            {
                new ModelPicker() {Id = 1, Tipo = "Planta"},
                new ModelPicker() {Id = 2, Tipo = "Temporal"}
            };
            return Tipos;
        }
    }

        public class ModelPicker
        {
            public int Id { get; set; }
            public string Tipo { get; set; }
        }


}
