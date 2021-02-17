using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WB.WAPP.SEG.Entities
{
    [Table("PARAMETER")]
    public class Parameter: Catalog
    {
        /// <summary>
        /// Identificador autoincrementable del parámetro
        /// </summary>
        [Key]
        [Column("ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Nombre del parámetro general
        /// </summary>
        [Column("NAME")]
        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        /// <summary>
        /// Valor del parámetro
        /// </summary>
        [Column("VALUE")]
        [Required]
        [StringLength(600)]
        public string Value { get; set; }

        /// <summary>
        /// Descripción del parámetro
        /// </summary>
        [Column("DESCRIPTION")]
        [Required]
        [StringLength(300)]
        public string Description { get; set; }

        /// <summary>
        /// Campo para saber si el parámetro esta activo o no
        /// </summary>
        [Column("STATUS")]
        [Required]
        public bool Status { get; set; }
    }
}
