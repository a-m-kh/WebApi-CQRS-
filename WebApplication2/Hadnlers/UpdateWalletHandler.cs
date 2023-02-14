using AutoMapper;
using MediatR;
using WebApplication2.Commands;
using WebApplication2.Contract;
using WebApplication2.Models;

namespace WebApplication2.Hadnlers
{
    public class UpdateWalletHandler : IRequestHandler<UpdateWalletCommand , ApiResponse>
    {
        private readonly IWalletRepository _walletRepository;
        private readonly IMapper _mapper;

        public UpdateWalletHandler(IWalletRepository walletRepository, IMapper mapper)
        {
            _walletRepository = walletRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse> Handle(UpdateWalletCommand request, CancellationToken cancellationToken)
        {
            var Response = new ApiResponse();
            var status = await _walletRepository.Search(request.id);
            if (!status)
            {
                Response.statusCode = System.Net.HttpStatusCode.NotFound;
                Response.Errors.Add("this Wallet is not Exist");
                Response.IsSuccess = false;
                return Response; 
            }
            Response.Result = await _walletRepository.Update(request.id, request.name);
           return(Response);
        }
    }
}
