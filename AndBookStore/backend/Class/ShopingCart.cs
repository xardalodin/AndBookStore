using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// only used to move to notifications form,, could probably be removed
namespace bookstore.backend.Class
{
    public class ShopingCart
    {
        private List<backend.Class.IBooksWithInterface> booksInCart;
        private decimal totalCostOFBooksInCart;

        public List<backend.Class.IBooksWithInterface> BooksInCart
        {
            get { return booksInCart; }
            set { booksInCart = BooksInCart;}
        }
        public decimal TotalCostOFBooksInCart { get { return totalCostOFBooksInCart; } }

        public ShopingCart(List<backend.Class.IBooksWithInterface> booksInCart)
        {
            this.booksInCart = booksInCart;

        }
        public ShopingCart(List<backend.Class.IBooksWithInterface> booksInCart,decimal total)
        {
            this.booksInCart = booksInCart;
            this.totalCostOFBooksInCart = total;
        }
        public void TotalCost()  // can be used to calculate total price of books in a list.
        {
            decimal totalcost = 0;
            foreach (var book in booksInCart)
            {
                totalcost += book.Price * book.NumberOfThisBookIncart;
            }

            totalCostOFBooksInCart = totalcost;
        }
        /// <summary>
        /// returns missing from order or 
        /// -1 if still in stock() so != -1 add to missing from order
        /// </summary>
        /// <param name="instock"></param>
        /// <param name="orderd"></param>
        /// <returns></returns>
        public static int outofstock(int instock, int orderd)
        {
            int orderstatus = instock - orderd;
            if (orderstatus < 0)// ordered more than instock
            {
                return orderd - instock; // missing
            }
            else { return -1; } // still left in stock  
        }
        /// <summary>
        /// returns instock if you ordered more than in stock
        /// returns ordered if if not more than instock
        /// </summary>
        /// <param name="instock"></param>
        /// <param name="orderd"></param>
        /// <returns></returns>
        public static int check(int instock, int orderd)
        {
            int orderstatus = instock - orderd;
            if (orderstatus < 0)// ordered more than instock
            {
                return instock;
            }
            else
            {
                return orderd;
            }
        }

        public static decimal TotalCost(decimal Total,decimal price, int OrderAmount)
        {
            return Total + (price * OrderAmount);
        }

        public static decimal ADD(decimal one,decimal two)
        {
            return one + two;
        }
        public static decimal Sub(decimal one, decimal two)
        {
            return one - two;
        }
    }
}
