using FluentValidation;
using Prueba_Tecnica.Models;
using System.Data;

namespace Prueba_Tecnica.Validation
{
    public class EmpleadoValidator : AbstractValidator<Empleado>
    {
        public EmpleadoValidator()
        {
            RuleFor(x => x.Usuario).NotEmpty().WithMessage("El Usuario es requerido");
            RuleFor(x => x.Nombre).NotEmpty().WithMessage("El Nombre es requerido");
            RuleFor(x => x.ApellidoPaterno).NotEmpty().WithMessage("El Apellido Paterno es requerido");
            RuleFor(x => x.ApellidoMaterno).NotEmpty().WithMessage("El Apellido Materno es requerido");
            RuleFor(x => x.Teléfono).NotEmpty().WithMessage("El Teléfono es requerido").Length(10).WithMessage("El Teléfono tiene que tener 10 digitos"); ;
            RuleFor(x => x.CorreoElectrónico).NotEmpty().WithMessage("El usuario es requerido").EmailAddress().WithMessage("Formato de correo invalido");
            RuleFor(x => x.Puesto).NotEmpty().WithMessage("El Puesto es requerido");
            RuleFor(x => x.FechaIngreso).NotEmpty().WithMessage("La FechaIngreso es requerido").Must(BeAValidDate).WithMessage("Fecha invalida");
            RuleFor(x => x.Password).NotEmpty().WithMessage("La contraseña es requerido");
        }
        private bool BeAValidDate (DateTime date)
        {
            return ! date.Equals(default(DateTime));
        }
    }

}
