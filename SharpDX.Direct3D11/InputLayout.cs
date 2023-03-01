using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x0200002E RID: 46
	[Guid("e4819ddc-4cf0-4025-bd26-5de82a3e07b7")]
	public class InputLayout : DeviceChild
	{
		// Token: 0x0600027C RID: 636 RVA: 0x0000AB60 File Offset: 0x00008D60
		public unsafe InputLayout(Device device, byte[] shaderBytecode, InputElement[] elements) : base(IntPtr.Zero)
		{
			fixed (byte[] array = shaderBytecode)
			{
				void* value;
				if (shaderBytecode == null || array.Length == 0)
				{
					value = null;
				}
				else
				{
					value = (void*)(&array[0]);
				}
				device.CreateInputLayout(elements, elements.Length, (IntPtr)value, shaderBytecode.Length, this);
			}
		}

		// Token: 0x0600027D RID: 637 RVA: 0x00002075 File Offset: 0x00000275
		public InputLayout(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x0600027E RID: 638 RVA: 0x0000ABAB File Offset: 0x00008DAB
		public new static explicit operator InputLayout(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new InputLayout(nativePtr);
			}
			return null;
		}
	}
}
