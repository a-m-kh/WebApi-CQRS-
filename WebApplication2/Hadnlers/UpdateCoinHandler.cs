using AutoMapper;
using MediatR;
using WebApplication2.Commands;
using WebApplication2.Contract;
using WebApplication2.Models;

namespace WebApplication2.Hadnlers
{
    public class UpdateCoinHandler : IRequestHandler<UpdateCoinCommand, ApiResponse>
    {
        private readonly ICoinRepository _coinRepository;
        private readonly IMapper _mapper;

        public UpdateCoinHandler(ICoinRepository coinRepository, IMapper mapper)
        {
            _coinRepository = coinRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse> Handle(UpdateCoinCommand request, CancellationToken cancellationToken)
        {
            var Response = new ApiResponse();
            var status1 = await _coinRepository.SearchW(request.IdWallet);
            if (!status1)
            {
                Response.statusCode = System.Net.HttpStatusCode.NotFound;
                Response.IsSuccess = false;
                Response.Errors.Add("this Wallet is not exist");
                return Response;
            }
            var status = await _coinRepository.Search(request.IdWallet, request.IdCoin);
            if (!status)
            {
                Response.statusCode = System.Net.HttpStatusCode.NotFound;
                Response.IsSuccess = false;
                Response.Errors.Add("this coin is not exist");
                return Response;
            }
            var Update = new Vorodi()
            {
                Amount = request.Amount,
                Rate = request.Rate,
                Symbol = request.Symbol,
                Name = request.Name
            };
            Response.Result = await _coinRepository.UpdateCoin(request.IdWallet, request.IdCoin, Update);
            return (Response);
        }
    }
}
