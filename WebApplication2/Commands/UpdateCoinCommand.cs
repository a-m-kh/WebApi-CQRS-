using MediatR;
using WebApplication2.Models;

namespace WebApplication2.Commands
{
    public class UpdateCoinCommand : IRequest<ApiResponse>
    {
        public int IdCoin { get; set; }
        public int IdWallet { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public float Amount { get; set; }
        public float Rate { get; set; }

        public UpdateCoinCommand(int idCoin, int idWallet, string name, string symbol, float amount, float rate)
        {
            IdCoin = idCoin;
            IdWallet = idWallet;
            Name = name;
            Symbol = symbol;
            Amount = amount;
            Rate = rate;
        }



    }
}
