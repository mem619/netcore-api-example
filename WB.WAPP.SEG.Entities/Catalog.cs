using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WB.WAPP.SEG.Entities
{
    public abstract class Catalog
    {
        /// <summary>
        /// Fecha de creación del registro
        /// </summary>
        [Column("CREATED_DATE")]
        [Required]
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Fecha de actualización del registro
        /// </summary>
        [Column("UPDATED_DATE")]
        public DateTime? UpdatedDate { get; set; }

        /// <summary>
        /// Usuario de creación del registro
        /// </summary>
        [Column("USER_CREATED")]
        [Required]
        public string UserCreated { get; set; }

        /// <summary>
        /// Usuario de actualización del registro
        /// </summary>
        [Column("USER_UPDATED")]
        public string UserUpdated { get; set; }
    }
}
