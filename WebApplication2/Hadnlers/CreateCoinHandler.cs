using AutoMapper;
using MediatR;
using WebApplication2.Commands;
using WebApplication2.Contract;
using WebApplication2.Models;

namespace WebApplication2.Hadnlers
{
    public class CreateCoinHandler : IRequestHandler<CreateCoinCommand, ApiResponse>
    {
        private readonly ICoinRepository _coinRepository;
        private readonly IMapper _mapper;

        public CreateCoinHandler(ICoinRepository coinRepository, IMapper mapper)
        {
            _coinRepository = coinRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse> Handle(CreateCoinCommand request, CancellationToken cancellationToken)
        {
            ApiResponse response = new ApiResponse();
            var newCoin = new Vorodi()
            {
                Name = request.Name,
                Symbol = request.Symbol,
                Amount = request.Amount,
                Rate = request.Rate
            };

            var status = await _coinRepository.SearchW(request.walletId);
            if (!status)
            {
                response.statusCode = System.Net.HttpStatusCode.NotFound;
                response.Errors.Add("this Wallet is not exist");
                response.IsSuccess = false;
                return(response);
            }
            response.Result = await _coinRepository.BuildNewCoin(request.walletId, newCoin);
            return (response);
        }
    }
}
