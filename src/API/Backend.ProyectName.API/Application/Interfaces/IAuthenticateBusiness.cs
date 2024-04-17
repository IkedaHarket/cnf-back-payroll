using Backend.ProyectName.API.Application.DTO.Response;
using System.Threading.Tasks;

namespace Backend.ServiceName.API.Application.Interfaces
{
    public interface IAuthenticateBusiness
    {
        Task<AuthenticationResult> AuthenticateUser(string taxId, string password);
    }
}