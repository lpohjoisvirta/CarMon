using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using CarMon.Model;
using System.Linq;

namespace CarMon
{
	[Activity( Label = "CarMon", MainLauncher = true, Icon = "@drawable/icon" )]
	public class MainActivity : Activity
	{
		
		protected override void OnCreate( Bundle bundle )
		{
			base.OnCreate( bundle );

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
					new ExpendatureRepository().Clear();
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
			string[] objects = new ExpendatureRepository().Fetch().Select( obj => obj.ToString() ).Take( itemsToShow ).ToArray();
			var adapter = new ArrayAdapter<string>( this, Android.Resource.Layout.SimpleListItem1, objects );
			FindViewById<ListView>( Resource.Id.ExpendatureList ).Adapter = adapter;
		}
	}


}

