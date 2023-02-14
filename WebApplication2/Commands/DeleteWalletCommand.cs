using MediatR;
using WebApplication2.Models;

namespace WebApplication2.Commands
{
    public class DeleteWalletCommand : IRequest<ApiResponse>
    {
        public int Id { get; set; }

        public DeleteWalletCommand(int id)
        {
            Id = id;
        }
    }
}
