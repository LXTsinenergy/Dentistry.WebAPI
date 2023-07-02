using Dentistry.BLL.Services.DoctorService;
using Dentistry.BLL.Services.PasswordService;
using Microsoft.AspNetCore.Components;

namespace Dentistry.API.Controllers
{
    [Route("[controller]/[action]")]
    public class DoctorController
    {
        private readonly IDoctorService _doctorService;
        private readonly IPasswordService _passwordService;

        public DoctorController(IDoctorService doctorService, IPasswordService passwordService)
        {
            _doctorService = doctorService;
            _passwordService = passwordService;
        }
    }
}
