using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x02000033 RID: 51
	[Guid("ea82e40d-51dc-4f33-93d4-db7c9125ae8c")]
	public class PixelShader : DeviceChild
	{
		// Token: 0x06000284 RID: 644 RVA: 0x0000AC98 File Offset: 0x00008E98
		public unsafe PixelShader(Device device, byte[] shaderBytecode, ClassLinkage linkage = null) : base(IntPtr.Zero)
		{
			if (shaderBytecode == null)
			{
				throw new ArgumentNullException("shaderBytecode", "ShaderBytecode cannot be null");
			}
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
				device.CreatePixelShader((IntPtr)value, shaderBytecode.Length, linkage, this);
			}
		}

		// Token: 0x06000285 RID: 645 RVA: 0x00002075 File Offset: 0x00000275
		public PixelShader(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000286 RID: 646 RVA: 0x0000ACF3 File Offset: 0x00008EF3
		public new static explicit operator PixelShader(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new PixelShader(nativePtr);
			}
			return null;
		}
	}
}
