using AutoMapper;
using MediatR;
using WebApplication2.Contract;
using WebApplication2.Models;
using WebApplication2.Queries;

namespace WebApplication2.Hadnlers
{
    public class GetWalletListHandler : IRequestHandler<GetWalletListQuery, ApiResponse>
    {
        private readonly IWalletRepository _walletRepository;
        private readonly IMapper _mapper;

        public GetWalletListHandler(IWalletRepository walletRepository , IMapper mapper)
        {
            _walletRepository = walletRepository;
            _mapper = mapper;
        }
        public async Task<ApiResponse> Handle(GetWalletListQuery request, CancellationToken cancellationToken)
        {
            var Response = new ApiResponse()
            {
                Result = await _walletRepository.Get()
            };
            return Response;
        }
    }
}
