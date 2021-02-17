using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WB.WAPP.SEG.VModel
{
    public class VParameter: VCatalog
    {
        public int? Id { get; set; }

        [MaxLength(150, ErrorMessage = "Maximo 150 caracteres en Name")]
        public string Name { get; set; }

        [MaxLength(600, ErrorMessage = "Maximo 600 caracteres en Value")]
        public string Value { get; set; }

        [MaxLength(300, ErrorMessage = "Maximo 300 caracteres en Description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Estatus Requerido")]
        public bool? Status { get; set; }
    }
}
