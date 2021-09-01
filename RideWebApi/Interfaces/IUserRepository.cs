using RideWebApi.DTO;
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
        Task<bool> SaveAllAsync();
        Task<IEnumerable<Appuser>> GetUsersAsync();
        Task<Appuser> GetUserByIdAsync(int id);
        Task<Appuser> GetUserByUsernameAsync(string username);
        Task<IEnumerable<MemberDto>> GetMembersAsync();
        Task<MemberDto> GetMemberAsync(string username);
        void Add(Appuser user);
    }
}
