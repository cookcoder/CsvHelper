using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CsvHelper.Tests
{
	[TestClass]
    public class EnumerateRecordsTests
    {
		[TestMethod]
        public void Test1()
		{
			using( var stream = new MemoryStream() )
			using( var reader = new StreamReader( stream ) )
			using( var writer = new StreamWriter( stream ) )
			using( var csv = new CsvReader( reader ) )
			{
				writer.WriteLine( "Id,Name" );
				writer.WriteLine( "1,one" );
				writer.WriteLine( "2,two" );
				writer.Flush();
				stream.Position = 0;

				csv.Configuration.HeaderValidatedCallback = null;
				csv.Configuration.MissingFieldFoundCallback = null;

				var record = new A
				{
					Id = -1,
					Name = "-one",
					UnUsed = "nothing",
				};

				Expression.New()
				Action<A> a = ( A r ) =>
				{
					r.Id = 1;
					r.Name = "one";
				};
				Expression<Action<A>> e = (Expression<Action<A>>)( x => a( x ) );
				//(Expression<Func<TClass, string>>)( x => convertExpression( x ) );

				foreach( var r in csv.EnumerateRecords( record ) )
				{
				}
			}
		}

		private class A
		{
			public int Id { get; set; }

			public string Name { get; set; }

			public string UnUsed { get; set; }
		}
    }
}
