using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using bookstore.backend.Class;
using bookstore.backend;

namespace AndBookStore
{
    class dialog_booksBought : DialogFragment
    {
        private bookstore.backend.Class.ShopingCart InCart;
        private ListView fragLVbooksBought;
        private ListView fragLVbooksNonBought;
        private EditText fragtxtTotalcost;
        //private List<bookstore.backend.Class.IBooksWithInterface> temList;
        private Context thiscontext;
        public dialog_booksBought(bookstore.backend.Class.ShopingCart cart)
        {
            InCart = cart;  // hope this works
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.Book_Fragment_Display, container, false);

            fragLVbooksBought = view.FindViewById<ListView>(Resource.Id.fraglvBooksBought);
            fragLVbooksNonBought = view.FindViewById<ListView>(Resource.Id.fraglvBooksNotBought);
            fragtxtTotalcost = view.FindViewById <EditText>(Resource.Id.fragtxtTotalcost);

            //thiscontext = container.Context;
            return view;
        }



        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            Dialog.Window.RequestFeature(WindowFeatures.NoTitle); // sets the title bar to invisable
            base.OnActivityCreated(savedInstanceState);
            Dialog.Window.Attributes.WindowAnimations = Resource.Style.dialog_animation;

            List<bookstore.backend.Class.IBooksWithInterface>  temList = new List<IBooksWithInterface>();
            decimal totalcost = 0;
            foreach (var book in InCart.BooksInCart)
            {
              
                int status = bookstore.backend.Class.ShopingCart.check(book.InStock, book.NumberOfThisBookIncart);
                if (status != 0)
                {
                    totalcost = bookstore.backend.Class.ShopingCart.TotalCost(totalcost, book.Price, status);
                    IBooksWithInterface temp = new IBooksWithInterface(book.Title,book.Author,book.Price,book.InStock);
                    temp.NumberOfThisBookIncart = status;
                    temList.Add(temp);
                }
                                                                                                                                                                                                                                                                                            
            }
            IBook_LV_Adpater adapterBooksBought = new IBook_LV_Adpater(this.Activity, temList);
            fragLVbooksBought.Adapter = adapterBooksBought;                                                         

            List<bookstore.backend.Class.IBooksWithInterface> temList2 = new List<IBooksWithInterface>();

            foreach (var book in InCart.BooksInCart)
            {
                int status = bookstore.backend.Class.ShopingCart.outofstock(book.InStock, book.NumberOfThisBookIncart);
                if (status != -1)
                {
                    IBooksWithInterface temp = new IBooksWithInterface(book.Title, book.Author, book.Price, book.InStock);
                    temp.NumberOfThisBookIncart = status;
                    temList2.Add(temp);
                }
               

            }
            fragtxtTotalcost.Text ="Totalcost: " + totalcost.ToString();

            IBook_LV_Adpater adapterBooksNotBought = new IBook_LV_Adpater(this.Activity, temList2);
            fragLVbooksNonBought.Adapter = adapterBooksNotBought;
        }
    }
}