using AutoMapper;
using MediatR;
using WebApplication2.Commands;
using WebApplication2.Contract;
using WebApplication2.Models;

namespace WebApplication2.Hadnlers
{
    public class CreateWalletHandler : IRequestHandler<CreateWalletCommand, ApiResponse>
    {
        private readonly IWalletRepository _walletRepository;
        private readonly IMapper _mapper;
        public CreateWalletHandler(IWalletRepository walletRepository , IMapper mapper)
        {
            _walletRepository = walletRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse> Handle(CreateWalletCommand request, CancellationToken cancellationToken)
        {
            ApiResponse response = new ApiResponse();
            response.Result = await _walletRepository.Create(request.name);
            return (response);
        }
    }
}
