using MediatR;
using WebApplication2.Models;

namespace WebApplication2.Queries
{
    public class GetCoinListQuery:IRequest<ApiResponse>
    {
        public int Id { get; set; }
        public GetCoinListQuery(int id) 
        {
            Id = id;
        }
    }
}
