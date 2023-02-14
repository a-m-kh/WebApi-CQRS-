using System.Collections.Generic;
using WebApplication2.Models;
using System;
namespace WebApplication2.Dto
{
    public class WalletDto
    {
        public string name { get; set; }
        public float balance { get; set; }
        public List<Coin> coins { get; set; } = new List<Coin>();
        public DateTime last_update { get; set; }
    }
}
