using System;
using System.Runtime.InteropServices;

namespace System.Collections
{
	/// <summary>Enumerates the elements of a nongeneric dictionary.</summary>
	// Token: 0x02000470 RID: 1136
	[ComVisible(true)]
	[__DynamicallyInvokable]
	public interface IDictionaryEnumerator : IEnumerator
	{
		/// <summary>Gets the key of the current dictionary entry.</summary>
		/// <returns>The key of the current element of the enumeration.</returns>
		/// <exception cref="T:System.InvalidOperationException">The <see cref="T:System.Collections.IDictionaryEnumerator" /> is positioned before the first entry of the dictionary or after the last entry.</exception>
		// Token: 0x1700085E RID: 2142
		// (get) Token: 0x06003798 RID: 14232
		[__DynamicallyInvokable]
		object Key { [__DynamicallyInvokable] get; }

		/// <summary>Gets the value of the current dictionary entry.</summary>
		/// <returns>The value of the current element of the enumeration.</returns>
		/// <exception cref="T:System.InvalidOperationException">The <see cref="T:System.Collections.IDictionaryEnumerator" /> is positioned before the first entry of the dictionary or after the last entry.</exception>
		// Token: 0x1700085F RID: 2143
		// (get) Token: 0x06003799 RID: 14233
		[__DynamicallyInvokable]
		object Value { [__DynamicallyInvokable] get; }

		/// <summary>Gets both the key and the value of the current dictionary entry.</summary>
		/// <returns>A <see cref="T:System.Collections.DictionaryEntry" /> containing both the key and the value of the current dictionary entry.</returns>
		/// <exception cref="T:System.InvalidOperationException">The <see cref="T:System.Collections.IDictionaryEnumerator" /> is positioned before the first entry of the dictionary or after the last entry.</exception>
		// Token: 0x17000860 RID: 2144
		// (get) Token: 0x0600379A RID: 14234
		[__DynamicallyInvokable]
		DictionaryEntry Entry { [__DynamicallyInvokable] get; }
	}
}
