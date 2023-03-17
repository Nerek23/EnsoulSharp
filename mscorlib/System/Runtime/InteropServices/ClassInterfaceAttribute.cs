using System;

namespace System.Runtime.InteropServices
{
	/// <summary>Indicates the type of class interface to be generated for a class exposed to COM, if an interface is generated at all.</summary>
	// Token: 0x020008EA RID: 2282
	[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class, Inherited = false)]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	public sealed class ClassInterfaceAttribute : Attribute
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.InteropServices.ClassInterfaceAttribute" /> class with the specified <see cref="T:System.Runtime.InteropServices.ClassInterfaceType" /> enumeration member.</summary>
		/// <param name="classInterfaceType">One of the <see cref="T:System.Runtime.InteropServices.ClassInterfaceType" /> values that describes the type of interface that is generated for a class.</param>
		// Token: 0x06005EDF RID: 24287 RVA: 0x00146B77 File Offset: 0x00144D77
		[__DynamicallyInvokable]
		public ClassInterfaceAttribute(ClassInterfaceType classInterfaceType)
		{
			this._val = classInterfaceType;
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.InteropServices.ClassInterfaceAttribute" /> class with the specified <see cref="T:System.Runtime.InteropServices.ClassInterfaceType" /> enumeration value.</summary>
		/// <param name="classInterfaceType">Describes the type of interface that is generated for a class.</param>
		// Token: 0x06005EE0 RID: 24288 RVA: 0x00146B86 File Offset: 0x00144D86
		[__DynamicallyInvokable]
		public ClassInterfaceAttribute(short classInterfaceType)
		{
			this._val = (ClassInterfaceType)classInterfaceType;
		}

		/// <summary>Gets the <see cref="T:System.Runtime.InteropServices.ClassInterfaceType" /> value that describes which type of interface should be generated for the class.</summary>
		/// <returns>The <see cref="T:System.Runtime.InteropServices.ClassInterfaceType" /> value that describes which type of interface should be generated for the class.</returns>
		// Token: 0x170010BD RID: 4285
		// (get) Token: 0x06005EE1 RID: 24289 RVA: 0x00146B95 File Offset: 0x00144D95
		[__DynamicallyInvokable]
		public ClassInterfaceType Value
		{
			[__DynamicallyInvokable]
			get
			{
				return this._val;
			}
		}

		// Token: 0x040029B5 RID: 10677
		internal ClassInterfaceType _val;
	}
}
