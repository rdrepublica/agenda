using System;
using System.ComponentModel.DataAnnotations;

namespace Contacts.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Apellido")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Direccion")]
        public string Address { get; set; }

        [Required]
        [MinLength(10)]
        [Display(Name = "Telefono")]
        public string Phone { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Correo")]
        public string Email { get; set; }

    }
}
