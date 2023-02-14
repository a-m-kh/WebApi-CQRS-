using WebApplication2.Dto;
using WebApplication2.Models;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using AutoMapper;
using WebApplication2.Contract;

namespace WebApplication2.Repository
{
    public class CoinRepository : ICoinRepository 
    {
        private readonly DBContext _content;
        private readonly IMapper _mapper;
        public CoinRepository(DBContext dBContext , IMapper mapper)
        {
            _content = dBContext;
            _mapper = mapper;
        }
        public async Task<Models.Coin> BuildNewCoin(int walletId, Vorodi Body)
        {
            Wallet wallet = await _content.wallets.Include(a => a.coins).Where(a => a.id == walletId).FirstOrDefaultAsync();
            Models.Coin coin = wallet.coins.Where(a => a.Symbol == Body.Symbol).FirstOrDefault();
            if( coin == null)
            {
                Models.Coin NewCoin = _mapper.Map<Models.Coin>(Body);
                wallet.AddCoin(NewCoin);
                await _content.SaveChangesAsync();
                return NewCoin;
            }
            return null;
        }

        public async Task<Models.Coin> DeleteCoin(int walletId, int coinId)
        {
            Wallet? wallet = await _content.wallets.Include(a => a.coins).Where(a => a.id == walletId).FirstOrDefaultAsync();
            Models.Coin coin = _mapper.Map<Models.Coin>(wallet.coins.Where(a => a.Id == coinId).FirstOrDefault());
            if( coin != null)
            {
                wallet.DeletE(coin);
                await _content.SaveChangesAsync();
                return coin;
            }
            return null;

        }

        public async Task<Wallet> GetCoinsAsync(int walletId)
        {
            Wallet? wallet = await _content.wallets.Include(a => a.coins).Where(a => a.id == walletId).FirstOrDefaultAsync();
            //WalletDto wallet1 = _mapper.Map<WalletDto>(wallet);
            return wallet;
        }
        public async Task<Models.Coin> UpdateCoin(int walletId, int coinId, Vorodi Body)
        {
            Wallet? wallet = await _content.wallets.Include(a => a.coins).Where(a => a.id == walletId).FirstOrDefaultAsync();
            var coin = _mapper.Map<Models.Coin>(wallet.coins.Where(a => a.Id == coinId).FirstOrDefault());
            if(coin != null)
            {
                wallet.UpDate(coin, Body);
                await _content.SaveChangesAsync();
                return _mapper.Map<Models.Coin>(Body);
            }
            return null;


        }
        public async Task<bool> Search(int walletId, int coinId)
        {
            var wallet = await _content.wallets.Include(a=>a.coins).Where(a => a.id == walletId).FirstOrDefaultAsync();
            if( wallet == null )
            {
                return false;
            }
           var coin = wallet.coins.Where(a => a.Id == coinId).FirstOrDefault();
            if(coin == null )
            {
                return false;
            }
            return true;
        }
        public async Task<bool> SearchW(int Id)
        {
            var wallet = await _content.wallets.Where(a => a.id == Id).FirstOrDefaultAsync();
            if(wallet == null )
            {
                return false;
            }
            return true;
        }
    }
}
