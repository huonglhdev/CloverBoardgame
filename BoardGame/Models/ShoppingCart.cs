using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGame.Models
{
    public class ShoppingCart
    {
        private int total;
        public string customerName { get; set; }
        public Dictionary<int, tblOrdergame> cart { get; set; }

        public ShoppingCart()
        {
            cart = new Dictionary<int, tblOrdergame>();
        }

        public void addToCart(tblOrdergame detail)
        {
            if (this.cart.ContainsKey(detail.gameID))
            {
                int quantity = this.cart[detail.gameID].numOfgame.Value + 1;
                detail.numOfgame = quantity;
            }
            this.cart[detail.gameID] = detail;
        }

        public void remove(int gameID)
        {
            if (this.cart.ContainsKey(gameID))
            {
                this.cart.Remove(gameID);
            }
        }

        public void reduceQuantity(tblOrdergame detail)
        {
            if (this.cart.ContainsKey(detail.gameID))
            {
                if (this.cart[detail.gameID].numOfgame != 1)
                {
                    int quantity = this.cart[detail.gameID].numOfgame.Value - 1;
                    detail.numOfgame = quantity;
                }
            }
            this.cart[detail.gameID] = detail;
        }
        public void SetTotal(int total)
        {
            this.total = total;
        }
        public int GetTotal()
        {
            int result = 0;
            foreach (tblOrdergame detail in cart.Values)
            {
                result += detail.tblGame.gamePrice * detail.numOfgame.Value;
            }
            return result;
        }
    }
}
