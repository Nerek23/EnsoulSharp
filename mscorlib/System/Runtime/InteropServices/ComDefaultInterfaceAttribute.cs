using System;

namespace System.Runtime.InteropServices
{
	/// <summary>Specifies a default interface to expose to COM. This class cannot be inherited.</summary>
	// Token: 0x020008E8 RID: 2280
	[AttributeUsage(AttributeTargets.Class, Inherited = false)]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	public sealed class ComDefaultInterfaceAttribute : Attribute
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.InteropServices.ComDefaultInterfaceAttribute" /> class with the specified <see cref="T:System.Type" /> object as the default interface exposed to COM.</summary>
		/// <param name="defaultInterface">A <see cref="T:System.Type" /> value indicating the default interface to expose to COM.</param>
		// Token: 0x06005EDD RID: 24285 RVA: 0x00146B60 File Offset: 0x00144D60
		[__DynamicallyInvokable]
		public ComDefaultInterfaceAttribute(Type defaultInterface)
		{
			this._val = defaultInterface;
		}

		/// <summary>Gets the <see cref="T:System.Type" /> object that specifies the default interface to expose to COM.</summary>
		/// <returns>The <see cref="T:System.Type" /> object that specifies the default interface to expose to COM.</returns>
		// Token: 0x170010BC RID: 4284
		// (get) Token: 0x06005EDE RID: 24286 RVA: 0x00146B6F File Offset: 0x00144D6F
		[__DynamicallyInvokable]
		public Type Value
		{
			[__DynamicallyInvokable]
			get
			{
				return this._val;
			}
		}

		// Token: 0x040029B0 RID: 10672
		internal Type _val;
	}
}
