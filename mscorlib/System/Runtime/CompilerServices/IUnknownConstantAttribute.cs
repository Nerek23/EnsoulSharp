using System;
using System.Runtime.InteropServices;

namespace System.Runtime.CompilerServices
{
	/// <summary>Indicates that the default value for the attributed field or parameter is an instance of <see cref="T:System.Runtime.InteropServices.UnknownWrapper" />, where the <see cref="P:System.Runtime.InteropServices.UnknownWrapper.WrappedObject" /> is <see langword="null" />. This class cannot be inherited.</summary>
	// Token: 0x020008D0 RID: 2256
	[AttributeUsage(AttributeTargets.Field | AttributeTargets.Parameter, Inherited = false)]
	[ComVisible(true)]
	[Serializable]
	public sealed class IUnknownConstantAttribute : CustomConstantAttribute
	{
		/// <summary>Gets the <see langword="IUnknown" /> constant stored in this attribute.</summary>
		/// <returns>The <see langword="IUnknown" /> constant stored in this attribute. Only <see langword="null" /> is allowed for an <see langword="IUnknown" /> constant value.</returns>
		// Token: 0x1700101A RID: 4122
		// (get) Token: 0x06005D37 RID: 23863 RVA: 0x00146A0B File Offset: 0x00144C0B
		public override object Value
		{
			get
			{
				return new UnknownWrapper(null);
			}
		}
	}
}
