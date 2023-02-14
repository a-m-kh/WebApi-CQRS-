using AutoMapper;
using MediatR;
using WebApplication2.Commands;
using WebApplication2.Contract;
using WebApplication2.Models;

namespace WebApplication2.Hadnlers
{
    public class DeleteWalletHandler : IRequestHandler<DeleteWalletCommand, ApiResponse>
    {
        private readonly IWalletRepository _walletRepository;
        private readonly IMapper _mapper;

        public DeleteWalletHandler(IWalletRepository walletRepository, IMapper mapper)
        {
            _walletRepository = walletRepository;
            _mapper = mapper;
        }
        public async Task<ApiResponse> Handle(DeleteWalletCommand request, CancellationToken cancellationToken)
        {
            var Response = new ApiResponse();
            var status =  await _walletRepository.Search(request.Id);
            if (!status)
            {
                Response.Errors.Add("this wallet is not exist");
                Response.IsSuccess = false;
                Response.statusCode = System.Net.HttpStatusCode.NotFound;
                return Response;
            }
            Response.Result = _mapper.Map<Wallet>(await _walletRepository.Delete(request.Id));
            return (Response);
        }
    }
}
