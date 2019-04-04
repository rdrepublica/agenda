using System;
using System.ComponentModel.DataAnnotations;

namespace Contacts.Models
{
    public class LocalEvent
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Descripcion")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Fecha")]
        public DateTime Date { get; set; }

        [Required]
        [Display(Name = "Direccion")]
        public string Address { get; set; }
    }
}
