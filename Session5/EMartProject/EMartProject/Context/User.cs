using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace EMartProject.Context
{
    public class User : IdentityUser
    {

        public string Location { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
