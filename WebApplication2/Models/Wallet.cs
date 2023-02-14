using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebApplication2.Dto;

namespace WebApplication2.Models
{
    public class Wallet
    {   
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string name { get; set; }
        public float balance { get; set; }
        public List<Coin> coins { get; set; } = new List<Coin>();
        public DateTime last_update { get; set; }

        public void AddCoin(Coin coin)
        {
            balance += coin.Amount * coin.Rate;
            last_update = DateTime.Now;
            coins.Add(coin);

        }
        public void UpDate(Coin coin, Vorodi body )
        {
            balance -= coin.Amount * coin.Rate;
            var COIN = coins.Where(a => a.Id == coin.Id).FirstOrDefault();
            COIN.Amount = body.Amount;
            COIN.Rate = body.Rate;
            COIN.Symbol = body.Symbol;
            COIN.Name = body.Name;
            balance += COIN.Rate * COIN.Amount;
        }
        public void DeletE(Coin coin)
        {
            balance -= coin.Amount * coin.Rate;
/*            Coin x = coin.Adapt<Coin>();
*/            Coin y = coins.Where(a => a.Name == coin.Name).FirstOrDefault();
            coins.Remove(y);
        }
    }
}
