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
using CarMon.Model;
using CarMon.Activities;

namespace CarMon
{
	[Activity( Label = "NewEntryActivity" )]
	public class NewEntryActivity : Activity
	{
		/// <summary>
		/// Number formatter.
		/// </summary>
		private class DistancePickerConverter : Java.Lang.Object, NumberPicker.IFormatter
		{
			private int minChange = 10;
			public string Format( int value )
			{
				// Return the new string value.
				return this.ConvertToDistance( value ).ToString();
			}

			public int ConvertToDistance( int value )
			{
				return ( value * minChange );
			}

			public int ConvertToWidgetValue( int value )
			{
				return ( value / minChange );
			}
		}

		private DistancePickerConverter NumberConverter = null;

		public NewEntryActivity()
		{
			this.NumberConverter = new DistancePickerConverter();
		}

		/// <summary>
		/// Create the new entry activity.
		/// </summary>
		/// <param name="savedInstanceState"></param>
		protected override void OnCreate( Bundle savedInstanceState )
		{
			base.OnCreate( savedInstanceState );

			// Set the view.
			SetContentView( Resource.Layout.NewEntry );

			// Set the original value.
			var spinner = FindViewById< NumberPicker >( Resource.Id.Kilometers );
			spinner.MinValue = 0;
			spinner.MaxValue = 500000;
			spinner.SetFormatter( this.NumberConverter );
			spinner.WrapSelectorWheel = false;
			spinner.Value = this.NumberConverter.ConvertToWidgetValue( new ExpendatureRepository().GetMaxDistance() );

			// Set the add action.
			var createButton = FindViewById< Button >( Resource.Id.create );
			createButton.Click += CreateExpendature;
		}

		/// <summary>
		/// Creates a new expendature.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void CreateExpendature( object sender, EventArgs e )
		{
			// Get the value from the spinner.
			var picker = FindViewById< NumberPicker >( Resource.Id.Kilometers );
			int distanceCovered = this.NumberConverter.ConvertToDistance( picker.Value );

			// Get the payment.
			string value = FindViewById<EditText>( Resource.Id.InputNumber ).Text;
			if( !String.IsNullOrEmpty( value ) )
			{
				// Get the value.
				int payment = this.NumberConverter.ConvertToDistance( int.Parse( value ) );

				// Get the type.
				string type = FindViewById<EditText>( Resource.Id.EntryType ).Text;

				// Create the new value.
				var expendature = new Expendature( type, distanceCovered, payment );

				// Add to the database.
				new ExpendatureRepository().Add( expendature );

				// We are done. Stop the activity.
				Finish();
			}
			else
			{
				// No value, show an error dialog.
				ActivityUtilities.Inform( this, "Please enter a number." );
			}
		}
		
	}
}