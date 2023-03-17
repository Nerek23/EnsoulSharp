﻿using System;
using System.Runtime.InteropServices;

namespace System.Reflection
{
	/// <summary>Represents a delegate that is used to filter a list of members represented in an array of <see cref="T:System.Reflection.MemberInfo" /> objects.</summary>
	/// <param name="m">The <see cref="T:System.Reflection.MemberInfo" /> object to which the filter is applied.</param>
	/// <param name="filterCriteria">An arbitrary object used to filter the list.</param>
	/// <returns>
	///   <see langword="true" /> to include the member in the filtered list; otherwise <see langword="false" />.</returns>
	// Token: 0x020005D3 RID: 1491
	// (Invoke) Token: 0x060045B4 RID: 17844
	[ComVisible(true)]
	[Serializable]
	public delegate bool MemberFilter(MemberInfo m, object filterCriteria);
}
