using System;
using System.Runtime.InteropServices;

namespace System.Collections
{
	/// <summary>Defines a dictionary key/value pair that can be set or retrieved.</summary>
	// Token: 0x0200046C RID: 1132
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public struct DictionaryEntry
	{
		/// <summary>Initializes an instance of the <see cref="T:System.Collections.DictionaryEntry" /> type with the specified key and value.</summary>
		/// <param name="key">The object defined in each key/value pair.</param>
		/// <param name="value">The definition associated with <paramref name="key" />.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="key" /> is <see langword="null" /> and the .NET Framework version is 1.0 or 1.1.</exception>
		// Token: 0x06003783 RID: 14211 RVA: 0x000D5233 File Offset: 0x000D3433
		[__DynamicallyInvokable]
		public DictionaryEntry(object key, object value)
		{
			this._key = key;
			this._value = value;
		}

		/// <summary>Gets or sets the key in the key/value pair.</summary>
		/// <returns>The key in the key/value pair.</returns>
		// Token: 0x17000854 RID: 2132
		// (get) Token: 0x06003784 RID: 14212 RVA: 0x000D5243 File Offset: 0x000D3443
		// (set) Token: 0x06003785 RID: 14213 RVA: 0x000D524B File Offset: 0x000D344B
		[__DynamicallyInvokable]
		public object Key
		{
			[__DynamicallyInvokable]
			get
			{
				return this._key;
			}
			[__DynamicallyInvokable]
			set
			{
				this._key = value;
			}
		}

		/// <summary>Gets or sets the value in the key/value pair.</summary>
		/// <returns>The value in the key/value pair.</returns>
		// Token: 0x17000855 RID: 2133
		// (get) Token: 0x06003786 RID: 14214 RVA: 0x000D5254 File Offset: 0x000D3454
		// (set) Token: 0x06003787 RID: 14215 RVA: 0x000D525C File Offset: 0x000D345C
		[__DynamicallyInvokable]
		public object Value
		{
			[__DynamicallyInvokable]
			get
			{
				return this._value;
			}
			[__DynamicallyInvokable]
			set
			{
				this._value = value;
			}
		}

		// Token: 0x04001845 RID: 6213
		private object _key;

		// Token: 0x04001846 RID: 6214
		private object _value;
	}
}
