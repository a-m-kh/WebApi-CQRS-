using AutoMapper;
using MediatR;
using WebApplication2.Contract;
using WebApplication2.Models;
using WebApplication2.Queries;

namespace WebApplication2.Hadnlers
{
    public class GetCoinListHandler : IRequestHandler<GetCoinListQuery, ApiResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICoinRepository _coinRepository;

        public GetCoinListHandler(IMapper mapper, ICoinRepository coinRepository)
        {
            _mapper = mapper;
            _coinRepository = coinRepository;
        }
        public async Task<ApiResponse> Handle(GetCoinListQuery request, CancellationToken cancellationToken)
        {
            Console.WriteLine("1");
            var Response = new ApiResponse();
            var status = await _coinRepository.SearchW(request.Id);
            if(!status)
            {
                Response.statusCode = System.Net.HttpStatusCode.NotFound;
                Response.IsSuccess = false;
                Response.Errors.Add("this Wallet is not exist");
                return Response;
            }
            Response.Result = _mapper.Map<Wallet>(await _coinRepository.GetCoinsAsync(request.Id));
            return (Response);
        }
    }
}
