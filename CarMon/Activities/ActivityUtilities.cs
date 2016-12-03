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

namespace CarMon.Activities
{
	public static class ActivityUtilities
	{
		public static void Inform( Context context, string message )
		{
			AlertDialog.Builder dialogBuilder = new AlertDialog.Builder( context );
			dialogBuilder.SetMessage( message );
			dialogBuilder.SetPositiveButton( "OK", ( IDialogInterfaceOnClickListener )null );
			dialogBuilder.Create().Show();
		}
	}
}