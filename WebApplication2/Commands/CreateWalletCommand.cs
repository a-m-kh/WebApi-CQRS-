using MediatR;
using WebApplication2.Models;

namespace WebApplication2.Commands
{
    public class CreateWalletCommand : IRequest<ApiResponse>
    {
        public string name { get; set; }
        public float balance { get; set; }
        public List<Coin> coins { get; set; } = new List<Coin>();
        public DateTime last_update { get; set; }

        public CreateWalletCommand(string name)
        {
            this.name = name;
            this.balance = 0;
            this.last_update = DateTime.Now;
        }
    }
}
