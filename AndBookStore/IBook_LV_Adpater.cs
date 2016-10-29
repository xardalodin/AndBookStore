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
using bookstore.backend;

namespace AndBookStore
{
    class IBook_LV_Adpater:  BaseAdapter<bookstore.backend.Class.IBooksWithInterface>
    {
        private List<bookstore.backend.Class.IBooksWithInterface> mIBooks;
        private Context mContext;

        public IBook_LV_Adpater(Context context, List<bookstore.backend.Class.IBooksWithInterface> items)
        {
            mIBooks = items;
            mContext = context;
        }

        public override int Count
        {
            get
            {
                return mIBooks.Count;
            }

        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override bookstore.backend.Class.IBooksWithInterface this[int position]
        {
            get
            {
                return mIBooks[position];
            }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;

            if (row == null)
            {
                row = LayoutInflater.From(mContext).Inflate(Resource.Layout.Book_Listview_row, null, false);

            }

            TextView txtTitle = row.FindViewById<TextView>(Resource.Id.txtTitle);
            txtTitle.Text = mIBooks[position].Title;

            TextView txtAuthor = row.FindViewById<TextView>(Resource.Id.txtAuthor);
            txtAuthor.Text = mIBooks[position].Author;

            TextView txtPrice = row.FindViewById<TextView>(Resource.Id.txtPrice);
            txtPrice.Text = mIBooks[position].Price.ToString();

            TextView txtInStock = row.FindViewById<TextView>(Resource.Id.txtInstock);
            txtInStock.Text = mIBooks[position].InStock.ToString();

            TextView txtInCart = row.FindViewById<TextView>(Resource.Id.txtInCart);
            txtInCart.Text = mIBooks[position].NumberOfThisBookIncart.ToString();

            return row;
        }

    }

}