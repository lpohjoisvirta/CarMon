using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using CarMon.Model;
using System.Linq;

namespace CarMon.Activities
{
	[Activity( Label = "CarMon", MainLauncher = true, Icon = "@drawable/icon" )]
	public class MainActivity : Activity
	{

		private CarMonApp CarMon { get { return ( CarMonApp )this.Application; } }

		/// <summary>
		/// Upon creation.
		/// </summary>
		/// <param name="bundle"></param>
		protected override void OnCreate( Bundle bundle )
		{
			base.OnCreate( bundle );

			// Initialize the application.
			this.CarMon.Initialize();

			// Set our view from the "main" layout resource
			SetContentView( Resource.Layout.Main );

			// Get our button from the layout resource,
			// and attach an event to it.
			Button button = FindViewById<Button>( Resource.Id.NewEntry );
			button.Click += delegate { StartActivity( typeof( NewEntryActivity ) ); };

			// Set up the list view.
			UpdateList();
		}

		public override bool OnCreateOptionsMenu( IMenu menu )
		{
			// Add the menu.
			MenuInflater.Inflate( Resource.Menu.menu, menu );
			return base.OnPrepareOptionsMenu( menu );
		}

		public override bool OnOptionsItemSelected( IMenuItem item )
		{
			switch( item.ItemId )
			{
				case Resource.Id.reset:
					new ExpendatureRepositoryConnection().Clear();
					break;
				case Resource.Id.help:
					break;
			}
			return base.OnOptionsItemSelected( item );
		}

		protected override void OnResume()
		{
			base.OnResume();

			// Update the list view.
			UpdateList();
		}

		private void UpdateList()
		{
			// Update the list with the specified number of items.
			int itemsToShow = 10;
			var objects = this.CarMon.ExpendatureHandler.Expendatures
					.Take( itemsToShow ).ToArray();
			var adapter = new ExpendatureAdapter( this, objects );
			FindViewById< ListView >( Resource.Id.ExpendatureList ).Adapter = adapter;
		}
	}


}

