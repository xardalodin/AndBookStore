using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using bookstore.backend.Class;
using bookstore.backend;

namespace AndBookStore
{
    [Activity(Label = "AndBookStore", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private Button mBuy;
        private Button mSearch;
        private List<bookstore.backend.Class.IBooksWithInterface> mIBook;
        private List<bookstore.backend.Class.IBooksWithInterface> mIBookCart;
        private ListView mLVSearch;
        private ListView mLVCart;
        private decimal TotalCost;
        private EditText totalcostString;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            mIBookCart = new List<bookstore.backend.Class.IBooksWithInterface>();
            // Set our view from the "main" layout resource
            TotalCost = 0;
            SetContentView(Resource.Layout.Main);

            totalcostString =(EditText)FindViewById(Resource.Id.txtTotalcost);

            mBuy = FindViewById<Button>(Resource.Id.button2);
            mBuy.Click += mBuy_Clicked;

            mLVSearch = FindViewById<ListView>(Resource.Id.lvBooksSearch);
            mLVSearch.ItemClick += mLVSearch_Click;

            mLVCart = FindViewById<ListView>(Resource.Id.lvBooksCart);
            mLVCart.ItemClick += mLVCart_Click;

            mSearch = FindViewById<Button>(Resource.Id.button1);
            mSearch.Click += button1_clicked;            

            // Get our button from the layout resource,
            // and attach an event to it
          //  Button button = FindViewById<Button>(Resource.Id.MyButton);

          //  button.Click += delegate { button.Text = string.Format("{0} clicks!", count++); };
        }

        private void mBuy_Clicked(object sender, EventArgs e)
        {
            FragmentTransaction transaction = FragmentManager.BeginTransaction();
            ShopingCart buying = new ShopingCart(mIBookCart, TotalCost); 
            dialog_booksBought signUpDialog = new dialog_booksBought(buying);
            signUpDialog.Show(transaction, "dialog fragment");
        }

        private void mLVCart_Click(object sender, AdapterView.ItemClickEventArgs e)
        {
            mIBookCart = bookstore.backend.Class.UITools.removeFromCart(TotalCost,
                                                                mIBookCart[e.Position].Title,
                                                                mIBookCart[e.Position].Author,
                                                                mIBookCart,
                                                                out TotalCost);
            updateCart();
        }
       
        private void updateCart()
        {
            //update totalcost
            string temp = TotalCost.ToString();
            totalcostString.Text = temp;
            // update cart
            mLVCart = FindViewById<ListView>(Resource.Id.lvBooksCart);

            IBook_LV_Adpater adapterCart = new IBook_LV_Adpater(this, mIBookCart);

            mLVCart.Adapter = adapterCart;
        }

        private void mLVSearch_Click(object sender, AdapterView.ItemClickEventArgs e)
        {         
            // add to cart 
            mIBookCart = bookstore.backend.Class.UITools.checkIFExistInCart(TotalCost,
                                                               mIBook[e.Position],
                                                               mIBookCart, out TotalCost);
            updateCart();
        }

        private async void button1_clicked(object sender, EventArgs e)
        {
            EditText search =(EditText)FindViewById(Resource.Id.txtSearch);
            string search2 = search.Text;
            mLVSearch = FindViewById<ListView>(Resource.Id.lvBooksSearch);
            bookstore.backend.Class.IBookstoreService s = new bookstore.backend.Class.IBookstoreService();
            IEnumerable<bookstore.backend.IBook> result = await s.GetBooksAsync(search2);

            mIBook = new List<bookstore.backend.Class.IBooksWithInterface>();

            foreach (bookstore.backend.Class.IBooksWithInterface t in result)
            {
                mIBook.Add(t);
            }

            //write adapter for result
            IBook_LV_Adpater adapter = new IBook_LV_Adpater(this, mIBook);
            
            mLVSearch.Adapter = adapter; 

         
        }
    }
}

