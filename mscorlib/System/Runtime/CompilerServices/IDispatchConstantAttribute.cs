using System;
using System.Runtime.InteropServices;

namespace System.Runtime.CompilerServices
{
	/// <summary>Indicates that the default value for the attributed field or parameter is an instance of <see cref="T:System.Runtime.InteropServices.DispatchWrapper" />, where the <see cref="P:System.Runtime.InteropServices.DispatchWrapper.WrappedObject" /> is <see langword="null" />.</summary>
	// Token: 0x020008CF RID: 2255
	[AttributeUsage(AttributeTargets.Field | AttributeTargets.Parameter, Inherited = false)]
	[ComVisible(true)]
	[Serializable]
	public sealed class IDispatchConstantAttribute : CustomConstantAttribute
	{
		/// <summary>Gets the <see langword="IDispatch" /> constant stored in this attribute.</summary>
		/// <returns>The <see langword="IDispatch" /> constant stored in this attribute. Only <see langword="null" /> is allowed for an <see langword="IDispatch" /> constant value.</returns>
		// Token: 0x17001019 RID: 4121
		// (get) Token: 0x06005D35 RID: 23861 RVA: 0x001469FB File Offset: 0x00144BFB
		public override object Value
		{
			get
			{
				return new DispatchWrapper(null);
			}
		}
	}
}
