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

namespace CarMon.Model
{
	/// <summary>
	/// Handler for expendatures.
	/// </summary>
	public class ExpendatureHandler
	{
		public int MaxDistance { get; private set; }

		public List< Expendature > Expendatures { get; private set; }

		/// <summary>
		/// Constructor.
		/// </summary>
		public ExpendatureHandler()
		{
			// Get the maximum distance.
			var connection = new ExpendatureRepositoryConnection();
			this.MaxDistance = connection.GetMaxDistance();

			// Get all the values.
			this.Expendatures = connection.Fetch().ToList();
		}

		public void Add( Expendature expendature )
		{
			// Create a new connection and add it.
			new ExpendatureRepositoryConnection().Add( expendature );
			this.Expendatures.Add( expendature );
			this.MaxDistance = Math.Max( expendature.DistanceCovered, this.MaxDistance );
		}
	}
}