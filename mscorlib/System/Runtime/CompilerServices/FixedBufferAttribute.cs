using System;

namespace System.Runtime.CompilerServices
{
	/// <summary>Indicates that a field should be treated as containing a fixed number of elements of the specified primitive type. This class cannot be inherited.</summary>
	// Token: 0x0200088A RID: 2186
	[AttributeUsage(AttributeTargets.Field, Inherited = false)]
	[__DynamicallyInvokable]
	public sealed class FixedBufferAttribute : Attribute
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.CompilerServices.FixedBufferAttribute" /> class.</summary>
		/// <param name="elementType">The type of the elements contained in the buffer.</param>
		/// <param name="length">The number of elements in the buffer.</param>
		// Token: 0x06005C8D RID: 23693 RVA: 0x00144C8A File Offset: 0x00142E8A
		[__DynamicallyInvokable]
		public FixedBufferAttribute(Type elementType, int length)
		{
			this.elementType = elementType;
			this.length = length;
		}

		/// <summary>Gets the type of the elements contained in the fixed buffer.</summary>
		/// <returns>The type of the elements.</returns>
		// Token: 0x17000FFD RID: 4093
		// (get) Token: 0x06005C8E RID: 23694 RVA: 0x00144CA0 File Offset: 0x00142EA0
		[__DynamicallyInvokable]
		public Type ElementType
		{
			[__DynamicallyInvokable]
			get
			{
				return this.elementType;
			}
		}

		/// <summary>Gets the number of elements in the fixed buffer.</summary>
		/// <returns>The number of elements in the fixed buffer.</returns>
		// Token: 0x17000FFE RID: 4094
		// (get) Token: 0x06005C8F RID: 23695 RVA: 0x00144CA8 File Offset: 0x00142EA8
		[__DynamicallyInvokable]
		public int Length
		{
			[__DynamicallyInvokable]
			get
			{
				return this.length;
			}
		}

		// Token: 0x0400295B RID: 10587
		private Type elementType;

		// Token: 0x0400295C RID: 10588
		private int length;
	}
}
