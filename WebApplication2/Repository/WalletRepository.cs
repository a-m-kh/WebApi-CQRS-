using WebApplication2.Models;
using System.Threading.Tasks;
using System.Linq;
using WebApplication2.Dto;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using AutoMapper;
using WebApplication2.Contract;

namespace WebApplication2.Repository
{
    public class WalletRepository : IWalletRepository
    {
        private readonly DBContext _context;
        private readonly IMapper _mapper;
        public WalletRepository(DBContext context , IMapper mapper) 
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Wallet> Create(string wname)
        {
            NewWalletDto wallet = new NewWalletDto(wname);
            var w2 = await _context.wallets.AddAsync(_mapper.Map<Wallet>(wallet));
            await _context.SaveChangesAsync();
            var wFinal = _mapper.Map<Wallet>(wallet);
            wFinal.id = w2.Entity.id;
            return  wFinal;
        }

        public async  Task<Wallet> Delete(int Id)
        {
            Wallet? wallet = await _context.wallets.Include(a => a.coins).Where(a => a.id == Id).FirstOrDefaultAsync();
            _context.wallets.Remove(wallet);
            await _context.SaveChangesAsync();
            return wallet;
        }

        public async Task<ALL> Get()
        {
            List<Wallet> wallets = await _context.wallets.Include("coins").ToListAsync();
            int count = await _context.wallets.CountAsync();
            ALL all = new ALL();
            all.wallets = wallets;
            all.size = count;
            return all;
        }

        public async Task<bool> Search(int Id)
        {
            Wallet? wallet = await _context.wallets.Where(a => a.id == Id).FirstOrDefaultAsync();
            if(wallet == null)
            {
                return false;
            }
            return true;
        }

        public async Task<Wallet> Update(int id, string name)
        {
            Wallet wallets = await _context.wallets.Where(a => a.id == id).FirstOrDefaultAsync();
            wallets.name = name;
            await _context.SaveChangesAsync();
            return wallets;
            
        }
    }
}
