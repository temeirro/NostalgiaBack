using Core.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IAccountsService
    {
        Task<string> Login(UserLoginDTO loginDTO);
        Task Registration(UserRegistrationDTO registrationDTO);

    }
}
