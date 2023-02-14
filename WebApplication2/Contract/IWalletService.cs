using System.Threading.Tasks;
using System.Collections.Generic;
using WebApplication2.Dto;
using WebApplication2.Models;

namespace WebApplication2.Contract
{
    public interface IWalletService
    {
        Task<ALL> GetWallet();
        Task<ApiResponse> BuldNewWallet(string name);
        Task<ApiResponse> UpdateWallet(string name, vorodi Body);
        Task<ApiResponse> DeleteWallet(string name);
    }
}
