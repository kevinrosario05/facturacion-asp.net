using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace proyecto.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the proyectoUser class
    public class proyectoUser : IdentityUser
    {

        [PersonalData]
        [Column(TypeName = "Nvarchar(100)")]
        public string cedula { get; set; }

        [PersonalData]
        [Column(TypeName = "Nvarchar(100)")]
        public string correo { get; set; }

        [PersonalData]
        [Column(TypeName = "Nvarchar(100)")]
        public string nombre { get; set; }

        [PersonalData]
        [Column(TypeName = "Nvarchar(100)")]
        public string apellido { get; set; }

        [PersonalData]
        [Column(TypeName = "Nvarchar(100)")]
        public string nombrecomercial { get; set; }

        [PersonalData]
        [Column(TypeName = "Nvarchar(100)")]
        public string telefono { get; set; }


        [PersonalData]
        [Column(TypeName = "Nvarchar(100)")]
        public string direccion { get; set; }

        [PersonalData]
        [Column(TypeName = "Nvarchar(100)")]
        public string paginaweb { get; set; }

        [PersonalData]
        [Column(TypeName = "Nvarchar(100)")]
        public string contraseña { get; set; }



       

        }
    }