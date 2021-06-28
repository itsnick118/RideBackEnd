using Runnnnnnnnnn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Runnnnnnnnnn.Interfaces
{
    interface ITokenService
    {
        string CreateToken(user user);
    }
}
