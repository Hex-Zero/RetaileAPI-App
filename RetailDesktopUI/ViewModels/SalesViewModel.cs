using Caliburn.Micro;
using RMDesktopUI.Library.Api;
using RMDesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailDesktopUI.ViewModels
{
    public class SalesViewModel : Screen
    {
		IProductEndpoint _productEndpoint;
		public SalesViewModel(IProductEndpoint productEndpoint)
		{
			_productEndpoint = productEndpoint;
		}
		protected override async void OnViewLoaded(object view)
		{
			base.OnViewLoaded(view);
			await LoadProducts();
		}
		public async Task LoadProducts()
		{
			var productList = await _productEndpoint.GetAll();
			Products = new BindingList<ProductModel>(productList);
		}
        private BindingList<ProductModel> _products;

		public BindingList<ProductModel> Products
		{
			get { return _products; }
			set 
			{
				_products = value;
				NotifyOfPropertyChange(() => Products);
			}
		}

		private ProductModel _selectedProduct;

		public ProductModel SelectedProduct
		{
			get { return _selectedProduct; }
			set 
			{ 
				_selectedProduct = value;
				NotifyOfPropertyChange(() => SelectedProduct);
				NotifyOfPropertyChange(() => CanAddToCart);
			}
		}



		private BindingList<CartItemModel> _cart = new BindingList<CartItemModel>();

		public BindingList<CartItemModel> Cart
		{
			get { return _cart; }
			set 
			{
				_cart = value;
				NotifyOfPropertyChange(() => Cart);
			}
		}

		private int _itemQuantity;

		public int ItemQuantity
		{
			get { return _itemQuantity; }
			set 
			{
				_itemQuantity = value;
				NotifyOfPropertyChange(() => ItemQuantity);
				NotifyOfPropertyChange(() => CanAddToCart);
			}
		}
		public string SubTotal
		{
			get
			{
				return "$0.00";
			}
		}
		public string Tax
		{
			get
			{
				return "$0.00";
			}
		}
		public string Total
		{
			get
			{
				return "$0.00";
			}
		}
		public bool CanAddToCart
		{
			get
			{
				bool output = false;
				if(ItemQuantity > 0 && SelectedProduct?.QuantityInStock >= ItemQuantity )
				{
					output = true;
				}

				return output;
			}
		}
		public void AddToCart()
		{
			CartItemModel Item = new CartItemModel
			{
				Product = SelectedProduct,
				QuantityInCart = ItemQuantity
			};
			Cart.Add(Item);
		}
		public bool CanRemoveFromCart
		{
			get
			{
				bool output = false;


				return output;
			}
		}
		public void RemoveFromCart()
		{

		}
		public bool CanCheckOut
		{
			get
			{
				bool output = false;


				return output;
			}
		}
		public void CheckOut()
		{

		}
	}
}
