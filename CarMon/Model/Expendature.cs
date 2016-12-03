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
	public class Expendature
	{
		/// <summary>
		/// Empty contructor. For SQLite construction.
		/// </summary>
		public Expendature()
		{

		}

		public Expendature( string type, int distanceCovered, int payment )
		{
			this.Text = type;
			this.DistanceCovered = distanceCovered;
			this.Cost = payment;
		}

		public int DistanceCovered { get; set; }
		public string Text { get; set; }
		public int Cost { get; set; }

		public override string ToString()
		{
			return $"{this.Text}, DISTANCE {this.DistanceCovered}, COST {this.Cost} €";
		}
	}
}