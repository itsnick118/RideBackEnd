
using RideWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RideWebApi.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(Appuser user);
    }
}
