using AutoMapper;
using WebApplication2.Dto;
using WebApplication2.Models;

namespace WebApplication2
{
    public class MappingConfig : Profile
    {
        public MappingConfig() 
        {
            CreateMap<Coin,CoinDto>().ReverseMap();
            CreateMap<ShowCoin, Models.Coin>().ReverseMap();
/*            CreateMap<Coin, UpdateCoinDto>().ReverseMap();
*/          CreateMap<Wallet, WalletDto>().ReverseMap();
            CreateMap<ShowWallet, WalletDto>().ReverseMap();
            CreateMap<Wallet, NewWalletDto>().ReverseMap();
            CreateMap<WalletDto , NewWalletDto>().ReverseMap();
            CreateMap<Vorodi, Coin>().ReverseMap();
/*            CreateMap<List<WalletDto>, List<Wallet>>().ReverseMap();
*/        }
    }
}
