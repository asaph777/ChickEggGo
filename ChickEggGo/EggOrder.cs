using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickEggGo
{
    public class EggOrder
    {
        private static int countOrder = 0;
        private int quantity = 0;
        private int? quality = null;

        public EggOrder(int quantity)
        {
            this.quantity = quantity;
            Random rand = new Random();
            this.quality = rand.Next(1, 100);
            countOrder++;
        }

        public int GetQuantity()
        {
            return this.quantity;
        }

        public int? GetQuality()
        {
            if (countOrder % 2 == 0)
            {
                return null;
            }
            
            return this.quality;
        }

        public void Crack()
        {
            if (this.quality < 25)
            {
                throw new Exception("Rotten");
            }
            else
            {
                return;
            }
        }

        public void DiscardShell()
        {

        }

        public void Cook()
        {

        }
    }
}
