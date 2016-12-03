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

namespace CarMon.Activities
{
	public class ExpendatureAdapter : BaseAdapter< Expendature >
	{
		
		private List< Expendature > Expendatures { get; set; } = new List<Expendature>();

		public override Expendature this[ int position ]
		{
			get
			{
				return this.Expendatures[ position ];
			}
		}

		public override int Count
		{
			get
			{
				return this.Expendatures.Count;
			}
		}

		public Activity Activity { get; private set; }

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="activity"></param>
		/// <param name="objects"></param>
		public ExpendatureAdapter( Activity activity, IEnumerable< Expendature > objects )
		{
			this.Activity = activity;
			this.Expendatures = objects.ToList();
		}

		public override long GetItemId( int position )
		{
			return position;
		}

		/// <summary>
		/// Gets the view.
		/// </summary>
		/// <param name="position"></param>
		/// <param name="convertView"></param>
		/// <param name="parent"></param>
		/// <returns></returns>
		public override View GetView( int position, View convertView, ViewGroup parent )
		{
			View view = convertView;
			if( view == null )
			{
				LayoutInflater inflater = LayoutInflater.From( this.Activity );
				view = inflater.Inflate( Resource.Layout.ListItem, null );
			}

			// Set the values.
			Expendature expendature = this.Expendatures[ position ];
			if( expendature != null )
			{
				// Set the values.

				// Get the value.
				view.FindViewById< TextView >( Resource.Id.expendatureTypeText ).Text = expendature.Text;
				view.FindViewById< TextView >( Resource.Id.expendatureCostText ).Text = expendature.Cost.ToString();
				view.FindViewById< TextView >( Resource.Id.expendatureDistanceText ).Text = expendature.DistanceCovered.ToString();
			}

			// Return the view.
			return view;
		}
	}
}