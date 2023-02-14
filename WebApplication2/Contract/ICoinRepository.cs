using WebApplication2.Models;
using WebApplication2.Dto;
using System.Threading.Tasks;

namespace WebApplication2.Contract
{
    public interface ICoinRepository
    {
        Task<Wallet> GetCoinsAsync(int walletId);
        Task<Coin> UpdateCoin(int walletId, int coinId, Vorodi Body);
        Task<Coin> DeleteCoin(int wlletId, int coinId);
        Task<Coin> BuildNewCoin(int walletId, Vorodi Body);
        Task<bool> Search(int walletId, int coinId);
        Task<bool> SearchW(int walletId);
    }
}
