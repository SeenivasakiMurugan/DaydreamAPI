using Daydream.BAL.Model;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Daydream.BAL.Service.Interface
{
    public interface IUserService
    {
        public Task<JsonResponse> AddUpdateUser(User user); 

        public Task<JsonResponse> Login(string? username, string? password);
    }
}
