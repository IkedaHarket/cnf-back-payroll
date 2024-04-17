using Backend.ProyectName.API.Infraestructure.Interfaces;
using Backend.ProyectName.API.Infraestructure.Models.CustomerAccount;
using System.Threading.Tasks;

namespace Backend.ProyectName.API.Infraestructure.Services
{
    public class CustomerAccountService : ICustomerAccountService
    {
        public Task<AuthenticationResult> Authenticate(string taxId, string password)
        {
            throw new System.NotImplementedException();
        }
    }
}
