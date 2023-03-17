using System;
using System.Collections.Generic;

namespace System.Runtime.CompilerServices
{
	/// <summary>Indicates that the use of a value tuple on a member is meant to be treated as a tuple with element names.</summary>
	// Token: 0x020008D1 RID: 2257
	[CLSCompliant(false)]
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event | AttributeTargets.Parameter | AttributeTargets.ReturnValue)]
	public sealed class TupleElementNamesAttribute : Attribute
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.CompilerServices.TupleElementNamesAttribute" /> class.</summary>
		/// <param name="transformNames">A string array that specifies, in a pre-order depth-first traversal of a type's construction, which value tuple occurrences are meant to carry element names.</param>
		// Token: 0x06005D38 RID: 23864 RVA: 0x00146A13 File Offset: 0x00144C13
		public TupleElementNamesAttribute(string[] transformNames)
		{
			if (transformNames == null)
			{
				throw new ArgumentNullException("transformNames");
			}
			this._transformNames = transformNames;
		}

		/// <summary>Specifies, in a pre-order depth-first traversal of a type's construction, which value tuple elements are meant to carry element names.</summary>
		/// <returns>An array that indicates which value tuple elements are meant to carry element names.</returns>
		// Token: 0x1700101B RID: 4123
		// (get) Token: 0x06005D39 RID: 23865 RVA: 0x00146A30 File Offset: 0x00144C30
		public IList<string> TransformNames
		{
			get
			{
				return this._transformNames;
			}
		}

		// Token: 0x0400299E RID: 10654
		private readonly string[] _transformNames;
	}
}
