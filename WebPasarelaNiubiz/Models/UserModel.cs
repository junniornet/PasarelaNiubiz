using System;
using System.ComponentModel.DataAnnotations;

namespace WebPasarelaNiubiz.Models
{
    public class UserModel
    {
        [Required(ErrorMessage = "El campo Nombres es obligatorio.")]
        [StringLength(30, ErrorMessage = "El campo Nombres no puede tener más de 30 caracteres.")]
        [RegularExpression(@"^[\p{L} ]{1,30}$", ErrorMessage = "El campo Nombres solo puede contener letras y espacios, con un máximo de 30 caracteres.")]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "El campo Apellidos es obligatorio.")]
        [StringLength(30, ErrorMessage = "El campo Apellidos no puede tener más de 30 caracteres.")]
        [RegularExpression(@"^[\p{L} ]{1,30}$", ErrorMessage = "El campo Nombres solo puede contener letras y espacios, con un máximo de 30 caracteres.")]
        public string Apellidos { get; set; }

        [Required(ErrorMessage = "El campo Tipo de documento es obligatorio.")]
        [StringLength(10, ErrorMessage = "El campo Tipo de documento no puede tener más de 10 caracteres.")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "El campo Tipo de documento solo debe contener letras.")]
        public string TipoDocumento { get; set; }

        [Required(ErrorMessage = "El campo Número de Documento es obligatorio.")]
        [StringLength(8, ErrorMessage = "El campo Número de Documento no puede tener más de 8 caracteres.")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "El campo Número de Documento solo debe contener números.")]
        public string NumeroDocumento { get; set; }

        [Required(ErrorMessage = "El campo Email es obligatorio.")]
        [EmailAddress(ErrorMessage = "El campo Email debe tener un formato de correo válido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El campo Celular es obligatorio.")]
        [StringLength(9, ErrorMessage = "El campo Celular no puede tener más de 9 caracteres.")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "El campo Celular solo debe contener números.")]
        public string Celular { get; set; }
    }
}

