using System.ComponentModel;
using System.Linq;
using ApiReader;

namespace BasketballPlayerSimulator
{
    public class PlayerBuilder
    {
        public PlayerBuilder()
        {
            NbaReader = new NbaReader();
        }

        public NbaReader NbaReader { get; set; }

        public void GetSimpleStats(Player player)
        {
            
        }
    }
}
