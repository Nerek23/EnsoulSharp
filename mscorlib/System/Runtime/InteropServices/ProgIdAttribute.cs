using System;

namespace System.Runtime.InteropServices
{
	/// <summary>Allows the user to specify the ProgID of a class.</summary>
	// Token: 0x020008F0 RID: 2288
	[AttributeUsage(AttributeTargets.Class, Inherited = false)]
	[ComVisible(true)]
	public sealed class ProgIdAttribute : Attribute
	{
		/// <summary>Initializes a new instance of the <see langword="ProgIdAttribute" /> with the specified ProgID.</summary>
		/// <param name="progId">The ProgID to be assigned to the class.</param>
		// Token: 0x06005EEA RID: 24298 RVA: 0x00146BF7 File Offset: 0x00144DF7
		public ProgIdAttribute(string progId)
		{
			this._val = progId;
		}

		/// <summary>Gets the ProgID of the class.</summary>
		/// <returns>The ProgID of the class.</returns>
		// Token: 0x170010C1 RID: 4289
		// (get) Token: 0x06005EEB RID: 24299 RVA: 0x00146C06 File Offset: 0x00144E06
		public string Value
		{
			get
			{
				return this._val;
			}
		}

		// Token: 0x040029B9 RID: 10681
		internal string _val;
	}
}
