/*using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Dto;
using WebApplication2.Models;
using System;
using WebApplication2.Repository;
using Microsoft.Extensions.Logging;
using AutoMapper;
using System.Net;
using WebApplication2.Contract;

namespace WebApplication2.Service
{
    public class CoinService : ICoinService
    {
        private string id()
        {
            Guid uniqe = Guid.NewGuid();
            return uniqe.ToString();
        }
        private readonly ILogger<WalletService> _logger ;
        private readonly ICoinRepository _repository;
        private readonly IMapper _mapper;
        private readonly IWalletRepository _walletRepository;
        private readonly ApiResponse _res;
        public CoinService(ICoinRepository repository , ILogger<WalletService> log , IMapper mapper , IWalletRepository walletRepository , ApiResponse res )
        {
            _repository = repository;
            _logger = log;
            _mapper = mapper;
            _walletRepository = walletRepository;
        }

        public async Task<ApiResponse> SearchWallet(string wName)
        {
            var res = new ApiResponse();
            var wallet = await _walletRepository.Search(wName);
            if (!wallet)
                res.Errors.Add("This Wallet is not exist");
                res.IsSuccess = false;
                res.statusCode = HttpStatusCode.NotFound;
            return res;
        }
        public void NotFoundCoin()
        {
            _res.statusCode = HttpStatusCode.NotFound;
            _res.Errors.Add("Coin is not Exist");
            _res.IsSuccess = false;
        }
        public void ErrorExeption(Exception Ex)
        {
            _res.statusCode = HttpStatusCode.BadRequest;
            _res.IsSuccess = false;
            _res.Errors.Add("error is : " + Ex.Message);
        }

        public async Task<ApiResponse> BuildNewCoin(string name , Vorodi Body)
        {
            string Id = id();
            _logger.LogInformation("Id : " + Id + ";" + " Request : Build a new Coin");
            var res = await this.SearchWallet(name);
            if (res.statusCode == HttpStatusCode.NotFound)
                return res; 
            var x = await _repository.Search(name, Body.Symbol);
            if(!x)
            {
                _logger.LogInformation("Id : " + Id + ";" + " coin was builded");
                this.NotFoundCoin();
                return _res;
            }
            try
            {
                Models.Coin coin = _mapper.Map<Models.Coin>(Body);
                Models.Coin Coin =  await _repository.BuildNewCoin(name, Body);
                _logger.LogInformation("Id : " + Id + ";" + " coin build");
                _res.Result = coin;
                return _res;
            }
            catch (Exception ex)
            {
                _logger.LogError("Id : " + Id + "; " + ex.Message);
                this.ErrorExeption(ex);
                return _res;
            }
        }

        public async Task<ApiResponse> GetCoinsAsync(string name)
        {
            string Id = id();
            _logger.LogInformation("Id : " + Id + "; " + "Request : Get Coins");
            try
            {
                var res = await this.SearchWallet(name);
                if(res.statusCode == HttpStatusCode.OK)
                {
                    WalletDto wd = await _repository.GetCoinsAsync(name);
                    _logger.LogInformation("Id : " + Id + "; " + "Succses");
                    _res.Result = wd;
                    return _res;
                }
                this.NotFoundCoin();
                return _res;
                
            }catch(Exception ex)
            {
                _logger.LogInformation("Id : " + Id + "; " + ex.Message);
                this.ErrorExeption(ex);
                return _res;
            }

        }

        public async Task<ApiResponse> UpdateCoin(string name, string symbol , Vorodi Body)
        {
            string Id = id();
            _logger.LogInformation("Id : " + Id + "; " + "Request is Update Coin");
            var res = await this.SearchWallet(name);
            if (res.statusCode == HttpStatusCode.NotFound)
                return res;
            var wallet = await _repository.Search(name , symbol);
            try
            {
                if(wallet)
                {
                    Models.Coin wd = await _repository.UpdateCoin(name, symbol, Body);
                    _res.Result = wd;
                }
                else
                {
                    this.NotFoundCoin();
                }
                return _res;
            }
            catch (Exception ex)
            {
                _logger.LogError("Id : " + Id + "; " + ex.Message);
                this.ErrorExeption(ex);
                return _res;
            }            
        }
        public async Task<ApiResponse> DeleteCoin(string name , string symbol)
        {
            string Id = id();

           _logger.LogInformation("Id : " + Id + "; " + "Request : Delete Coin");
            var res = await this.SearchWallet(name);
            if (res.statusCode == HttpStatusCode.NotFound)
                return res;
            var wallet = await _repository.Search(name , symbol);
            try
            {
                if (wallet)
                {
                    Models.Coin cd = await _repository.DeleteCoin(name, symbol);
                    _res.Result = cd;
                }
                else
                {
                    this.NotFoundCoin();
                }
                return _res;
            }catch(Exception ex)
            {
                _logger.LogError("Id : " + Id + "; " + ex.Message);
                this.ErrorExeption(ex);
                return _res;
            }
        }
    }
}
*/