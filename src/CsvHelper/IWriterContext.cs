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
	/// Defines context information used by the <see cref="IWriter"/>.
	/// </summary>
	public interface IWriterContext
    {
		/// <summary>
		/// Gets the writer configuration.
		/// </summary>
		IWriterConfiguration WriterConfiguration { get; }

		Dictionary<string, Delegate> TypeActions { get; }

		Dictionary<Type, TypeConverterOptions> TypeConverterOptionsCache { get; }

		MemberMapData ReusableMemberMapData { get; set; }

		/// <summary>
		/// Gets a value indicating if a record has been written.
		/// </summary>
		bool HasRecordBeenWritten { get; set; }

		/// <summary>
		/// Gets a value indicating if the header has been written.
		/// </summary>
		bool HasHeaderBeenWritten { get; set; }

		/// <summary>
		/// Get the current record;
		/// </summary>
		List<string> Record { get; }

		/// <summary>
		/// Gets the current row.
		/// </summary>
		int Row { get; set; }

		/// <summary>
		/// Gets a value indicating if the <see cref="TextReader"/>
		/// should be left open when disposing.
		/// </summary>
		bool LeaveOpen { get; set; }

		/// <summary>
		/// Clears the specified caches.
		/// </summary>
		/// <param name="cache">The caches to clear.</param>
		void ClearCache( Caches cache );
	}
}
