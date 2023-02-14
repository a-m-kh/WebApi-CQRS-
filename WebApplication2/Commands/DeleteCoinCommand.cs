using MediatR;
using WebApplication2.Models;

namespace WebApplication2.Commands
{
    public class DeleteCoinCommand :IRequest<ApiResponse>
    {
        public int IdCoin { get; set; }
        public int IdWallet { get; set; }

        public DeleteCoinCommand(int idCoin, int idWallet)
        {
            IdCoin = idCoin;
            IdWallet = idWallet;
        }
    }
}
