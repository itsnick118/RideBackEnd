using RideWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RideWebApi.Interfaces
{
    public interface IUserRepository
    {
        void Update(Appuser user);
        Task<bool> SaveAllAync();
        Task<IEnumerable<Appuser>> GetUsersAsync();
        Task<Appuser> GetUserByIdAsync(int id);
        Task<Appuser> GetUserByUsernameAsync(string username);
        
    }
}
