using AutoMapper;
using MediatR;
using WebApplication2.Commands;
using WebApplication2.Contract;
using WebApplication2.Models;

namespace WebApplication2.Hadnlers
{
    public class DeleteCoinHandler : IRequestHandler<DeleteCoinCommand, ApiResponse>
    {
        private readonly ICoinRepository _coinRepository;
        private readonly IMapper _mapper;

        public DeleteCoinHandler(ICoinRepository coinRepository, IMapper mapper)
        {
            _coinRepository = coinRepository;
            _mapper = mapper;
        }   

        public async Task<ApiResponse> Handle(DeleteCoinCommand request, CancellationToken cancellationToken)
        {
            var Response = new ApiResponse();
            var status1 = await _coinRepository.SearchW(request.IdWallet);
            if(!status1)
            {
                Response.statusCode = System.Net.HttpStatusCode.NotFound;
                Response.IsSuccess = false;
                Response.Errors.Add("this Wallet is not exist");
                return Response;
            }
            var status = await _coinRepository.Search(request.IdWallet, request.IdCoin);
            if(!status)
            {
                Response.statusCode = System.Net.HttpStatusCode.NotFound;
                Response.IsSuccess = false;
                Response.Errors.Add("this coin is not exist");
                return Response;
            }
            Response.Result = await _coinRepository.DeleteCoin(request.IdWallet, request.IdCoin);
            return (Response);
        }
    }
}
