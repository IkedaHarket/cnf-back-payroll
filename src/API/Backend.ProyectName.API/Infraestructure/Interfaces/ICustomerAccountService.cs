using Backend.ProyectName.API.Infraestructure.Models.CustomerAccount;
using System.Threading.Tasks;

namespace Backend.ProyectName.API.Infraestructure.Interfaces
{
    public interface ICustomerAccountService
    {
        Task<AuthenticationResult> Authenticate(string taxId, string password);
    }
}
