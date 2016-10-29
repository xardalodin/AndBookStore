using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bookstore.backend.Class
{
    public class UITools
    {
        // bad name 
        public static List<IBooksWithInterface> checkIFExistInCart(decimal InCost,IBooksWithInterface bookToMove,List<IBooksWithInterface> List,out decimal TotalCost)
        {
            
            foreach (var l in List)
            {
                if (l.Author.Contains(bookToMove.Author) && l.Title.Contains(bookToMove.Title))
                {
                    l.addtocart();
                    TotalCost = ShopingCart.ADD(InCost, l.Price);               
                    return List; 
                }

            }

            bookToMove.addtocart();
            TotalCost = ShopingCart.ADD(InCost, bookToMove.Price);
            List.Add(bookToMove);
                
            return List; 
        }

        public static List<IBooksWithInterface> removeFromCart(decimal InCost,string title,string author, List<IBooksWithInterface> List, out decimal TotalCost)
        {
            int i = 0;
            foreach (var l in List)
            {
                if(l.Author.Contains(author)&& l.Title.Contains(title))
                {
                    if (l.NumberOfThisBookIncart > 1)
                    {
                        l.subFromcart();
                        TotalCost = ShopingCart.Sub(InCost, l.Price);
                        return List;
                    }
                    else
                    {
                        l.subFromcart();
                        TotalCost = ShopingCart.Sub(InCost, l.Price);
                        List.RemoveAt(i);
                        return List;
                    }
                }
                i++;
            }
            TotalCost = 0; // if this happens its bad;
            return List;

            
        }
    }
}
