/*using System.Collections.Generic;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WebApplication2.Models;
using WebApplication2.Dto;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WebApplication2.Repository;
using System.Net;
using WebApplication2.Contract;

namespace WebApplication2.Service
{
    public class WalletService : IWalletService
    {
        private string id()
        {
            Guid id = Guid.NewGuid();
            return id.ToString();
        }
        //private readonly DBContext _context;
        private readonly IWalletRepository _repository;
        private readonly ILogger<WalletService> _logger;
        private readonly ApiResponse _res;
        public WalletService(IWalletRepository repository, ILogger<WalletService> logger , ApiResponse res)
        {
            _repository = repository;
            _logger = logger;
            _res = res;
        }


        public async Task<ALL> GetWallet()
        {
            ALL all = new ALL();           
            string ID = id();
            _logger.LogInformation("Id : " +ID + ";" + " Request : Get All of Wallets;" );
            try
            {
               all =  await _repository.Get();
            }catch (Exception ex)
            {
                _logger.LogError("Id : " + ID + "; " + ex.Message);
                return null; 
            }
            _logger.LogInformation("Id : " + ID + ";" + " Response is Send");                       
            return all;
        }
        public async Task<ApiResponse> BuldNewWallet(string name)
        {
            //ApiResponse res = new ApiResponse();
            string ID = id();
            _logger.LogInformation("Id : " + ID + ";" + " Request : Build a new Wallet ");
            try {

                bool status =await _repository.Search(name);
                if (!status)
                {
                    WalletDto wallet =  await _repository.Create(name);
                    _res.Result = wallet;
                    _logger.LogInformation("Id : " + ID + "; " + " Build");
                }
                else
                {
                    _res.statusCode = HttpStatusCode.BadRequest;
                    _res.IsSuccess = false;
                    _res.Errors.Add("This name is exist");
                    _logger.LogInformation("Id : " + ID + ";" + "Name : " + name + " is dublicated");
                }
                return _res;
            }
            catch(Exception ex)
                {
                    _logger.LogError("Id : "+ ID + ";" + ex.Message);
                    _res.statusCode = HttpStatusCode.BadRequest;
                    _res.IsSuccess = false;
                    _res.Errors.Add("error : " + ex.Message);
                    return _res;
                }            
        }

        public async Task<ApiResponse> UpdateWallet(string name, vorodi Body)
        {
            //ApiResponse res = new ApiResponse();
            string ID = id();
            _logger.LogInformation("Id : " + ID + ";" + " Requset: Update Wallet ");
            try
            {
                bool status = await _repository.Search(name);
                if(status)
                {
                    WalletDto wd = await _repository.Update(name, Body.name);
                    _logger.LogInformation("Id : " + ID + ";" + "wallet is fined");
                    _res.Result = wd;
                    return _res;
                }
                _res.statusCode = HttpStatusCode.NotFound;
                _res.Errors.Add("This Wallet isnt exist.");
                _res.IsSuccess = false;

            }catch(Exception e)
            {
                _logger.LogError("Id : " + ID + "; "+ e.Message);
                _res.statusCode = HttpStatusCode.InternalServerError;
                _res.IsSuccess = false;
            }
            return _res;
        }
        public async Task<ApiResponse> DeleteWallet(string name)
        {
            string ID = id();
            _logger.LogInformation("Id : " + ID + ";" + " Request : Delete a wallet");
            try
            {
                bool status = await _repository.Search(name);
                if (status)
                {
                    WalletDto wd = await _repository.Delete(name);
                    _logger.LogInformation("Id : " + ID + ";" + " Wallet is removed");
                    _res.Result = wd;
                    return _res;
                }
                _res.statusCode= HttpStatusCode.NotFound;
                _res.IsSuccess = false;
                _res.Errors.Add("not found wallet");
                return _res;
            }catch(Exception e)
            {
                _logger.LogError("Id : " + ID + ";" + e.Message);
                _res.statusCode = HttpStatusCode.InternalServerError;
                _res.IsSuccess = false;
                _res.Errors.Add("error : " + e.Message);
            }
            return _res;                      
        }
    }
}
*/