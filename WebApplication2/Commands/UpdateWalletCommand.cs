using MediatR;
using WebApplication2.Models;

namespace WebApplication2.Commands
{
    public class UpdateWalletCommand : IRequest<ApiResponse>
    {
        public int id { get; set; }
        public string name { get; set; }
        public DateTime last_update { get; set; }

        public UpdateWalletCommand(int id, string name)
        {
            this.id = id;
            this.name = name;
            this.last_update = DateTime.Now;
        }
    }
}
