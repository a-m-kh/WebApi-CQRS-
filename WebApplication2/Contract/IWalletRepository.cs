using WebApplication2.Dto;
using WebApplication2.Models;
using System.Threading.Tasks;

namespace WebApplication2.Contract
{
    public interface IWalletRepository
    {
        Task<ALL> Get();
        Task<Wallet> Create(string wname);
        Task<Wallet> Update(int Id, string name);
        Task<Wallet> Delete(int Id);
        Task<bool> Search(int Id);
    }
}
