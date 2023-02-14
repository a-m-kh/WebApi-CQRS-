using System.Collections.Generic;
using WebApplication2.Dto;
namespace WebApplication2.Models
{
    public class ALL
    {
        public int size { get; set; } = 0;
        public List<Wallet> wallets { get; set; } = new List<Wallet>();
    }
}
