using MediatR;
using WebApplication2.Contract;
using WebApplication2.Models;
using WebApplication2.Queries;

namespace WebApplication2.PipLines
{
    public class ValidateGetWalletListBehavior : IPipelineBehavior<GetWalletListQuery, ApiResponse>
    {
        private readonly IWalletRepository _walletRepository;
        private readonly ILogger<ValidateGetWalletListBehavior> _Logger;

        public ValidateGetWalletListBehavior(IWalletRepository walletRepository , ILogger<ValidateGetWalletListBehavior> logger)
        {
            _walletRepository = walletRepository;
           _Logger = logger;
        }
        public async Task<ApiResponse> Handle(GetWalletListQuery request, RequestHandlerDelegate<ApiResponse> next, CancellationToken cancellationToken)
        {
            Console.WriteLine("22");
            var wallet = await _walletRepository.Get();
            if (wallet == null)
            {
                _Logger.LogError("havent Wallet !  :|");
            }
            else
            {
                _Logger.LogInformation("good");
            }
            //var response = await next();
            _Logger.LogInformation("Finish");
            return null;
        }
    }
}
