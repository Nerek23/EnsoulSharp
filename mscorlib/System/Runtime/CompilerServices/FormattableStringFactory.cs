using System;

namespace System.Runtime.CompilerServices
{
	/// <summary>Provides a static method to create a <see cref="T:System.FormattableString" /> object from a composite format string and its arguments.</summary>
	// Token: 0x020008CE RID: 2254
	[__DynamicallyInvokable]
	public static class FormattableStringFactory
	{
		/// <summary>Creates a <see cref="T:System.FormattableString" /> instance from a composite format string and its arguments.</summary>
		/// <param name="format">A composite format string.</param>
		/// <param name="arguments">The arguments whose string representations are to be inserted in the result string.</param>
		/// <returns>The object that represents the composite format string and its arguments.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="format" /> is <see langword="null" />.  
		/// -or-  
		/// <paramref name="arguments" /> is <see langword="null" />.</exception>
		// Token: 0x06005D33 RID: 23859 RVA: 0x001469CE File Offset: 0x00144BCE
		[__DynamicallyInvokable]
		public static FormattableString Create(string format, params object[] arguments)
		{
			if (format == null)
			{
				throw new ArgumentNullException("format");
			}
			if (arguments == null)
			{
				throw new ArgumentNullException("arguments");
			}
			return new FormattableStringFactory.ConcreteFormattableString(format, arguments);
		}

		// Token: 0x02000C62 RID: 3170
		private sealed class ConcreteFormattableString : FormattableString
		{
			// Token: 0x06006FE5 RID: 28645 RVA: 0x001806E8 File Offset: 0x0017E8E8
			internal ConcreteFormattableString(string format, object[] arguments)
			{
				this._format = format;
				this._arguments = arguments;
			}

			// Token: 0x17001348 RID: 4936
			// (get) Token: 0x06006FE6 RID: 28646 RVA: 0x001806FE File Offset: 0x0017E8FE
			public override string Format
			{
				get
				{
					return this._format;
				}
			}

			// Token: 0x06006FE7 RID: 28647 RVA: 0x00180706 File Offset: 0x0017E906
			public override object[] GetArguments()
			{
				return this._arguments;
			}

			// Token: 0x17001349 RID: 4937
			// (get) Token: 0x06006FE8 RID: 28648 RVA: 0x0018070E File Offset: 0x0017E90E
			public override int ArgumentCount
			{
				get
				{
					return this._arguments.Length;
				}
			}

			// Token: 0x06006FE9 RID: 28649 RVA: 0x00180718 File Offset: 0x0017E918
			public override object GetArgument(int index)
			{
				return this._arguments[index];
			}

			// Token: 0x06006FEA RID: 28650 RVA: 0x00180722 File Offset: 0x0017E922
			public override string ToString(IFormatProvider formatProvider)
			{
				return string.Format(formatProvider, this._format, this._arguments);
			}

			// Token: 0x0400376E RID: 14190
			private readonly string _format;

			// Token: 0x0400376F RID: 14191
			private readonly object[] _arguments;
		}
	}
}
