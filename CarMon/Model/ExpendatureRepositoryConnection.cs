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
using SQLite;
using System.IO;

namespace CarMon.Model
{
	public class ExpendatureRepositoryConnection
	{
		private SQLiteConnection db;
		string dbPath = Path.Combine( System.Environment.GetFolderPath( System.Environment.SpecialFolder.Personal ), "carmon.db3" );
		public ExpendatureRepositoryConnection()
		{
			db = new SQLiteConnection( dbPath );
			db.CreateTable<Expendature>();
		}

		public int Add( Expendature expendature )
		{
			int uid = db.Insert( expendature );
			return uid;
		}

		public IEnumerable< Expendature > Fetch()
		{
			return db.Table< Expendature >();
		}

		public int GetMaxDistance()
		{
			var table = db.Table< Expendature >();
			if( table.Any() )
				return table.Aggregate( ( currentMax, x ) => ( currentMax == null || ( x.DistanceCovered > currentMax.DistanceCovered ) ) ? x : currentMax ).DistanceCovered;
			else
				return 0;
		}

		public void Clear()
		{
			db.DeleteAll<Expendature>();
		}
	}
}