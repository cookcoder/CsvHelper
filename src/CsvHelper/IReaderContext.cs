// Copyright 2009-2017 Josh Close and Contributors
// This file is a part of CsvHelper and is dual licensed under MS-PL and Apache 2.0.
// See LICENSE.txt for details or visit http://www.opensource.org/licenses/ms-pl.html for MS-PL and http://opensource.org/licenses/Apache-2.0 for Apache 2.0.
// https://github.com/JoshClose/CsvHelper
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using System;
using System.Collections.Generic;
using System.IO;

namespace CsvHelper
{
	/// <summary>
	/// Defines context information used by the <see cref="IReader"/>.
	/// </summary>
	public interface IReaderContext
    {
		IParserContext ParserContext { get; }

		Dictionary<string, List<int>> NamedIndexes { get; }

		Dictionary<string, Tuple<string, int>> NamedIndexCache { get; }

		Dictionary<Type, Delegate> RecordFuncs { get; }

		/// <summary>
		/// Gets the <see cref="CsvReader"/> configuration.
		/// </summary>
		IReaderConfiguration ReaderConfiguration { get; }

		Dictionary<Type, TypeConverterOptions> TypeConverterOptionsCache { get; }

		MemberMapData ReusableMemberMapData { get; }

		/// <summary>
		/// Gets the column count.
		/// </summary>
		int ColumnCount { get; set; }

		/// <summary>
		/// Gets the current index.
		/// </summary>
		int CurrentIndex { get; set; }

		/// <summary>
		/// Gets a value indicating if reading has begun.
		/// </summary>
		bool HasBeenRead { get; set; }

		/// <summary>
		/// Gets the header record.
		/// </summary>
		string[] HeaderRecord { get; set; }

		/// <summary>
		/// Gets the record.
		/// </summary>
		string[] Record { get; set; }

		/// <summary>
		/// Gets the row of the CSV file that the parser is currently on.
		/// </summary>
		int Row { get; set; }

		/// <summary>
		/// Clears the specified caches.
		/// </summary>
		/// <param name="cache">The caches to clear.</param>
		void ClearCache( Caches cache );

		/// <summary>
		/// Gets a value indicating if the <see cref="TextReader"/>
		/// should be left open when disposing.
		/// </summary>
		bool LeaveOpen { get; }
	}
}
