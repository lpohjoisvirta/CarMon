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
	[Application]
	public class CarMonApp : Application
	{
		public ExpendatureHandler ExpendatureHandler { get; private set; }

		/// <summary>
		/// Constructor.
		/// </summary>
		public CarMonApp( IntPtr handle, JniHandleOwnership transfer )
			: base( handle, transfer )
		{

		}

		/// <summary>
		/// Initializes the application.
		/// </summary>
		public void Initialize()
		{
			this.ExpendatureHandler = new ExpendatureHandler();
		}
	}
}