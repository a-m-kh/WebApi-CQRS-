using MediatR;
using WebApplication2.Models;

namespace WebApplication2.Commands
{
    public class CreateCoinCommand : IRequest<ApiResponse>
    {
/*        public int Id { get; set; }
*/
        public int walletId { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public float Amount { get; set; }
        public float Rate { get; set; }
        public CreateCoinCommand( int walletID , string name , string symbol , float amount , float rate)
        {
            Name = name;
            Symbol = symbol;
            Amount = amount;
            Rate = rate;
            walletId = walletID;
        }

    }
}
