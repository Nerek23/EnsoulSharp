using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x02000028 RID: 40
	[Guid("8e5c6061-628a-4c8e-8264-bbe45cb3d5dd")]
	public class HullShader : DeviceChild
	{
		// Token: 0x0600022F RID: 559 RVA: 0x00009D90 File Offset: 0x00007F90
		public unsafe HullShader(Device device, byte[] shaderBytecode, ClassLinkage linkage = null) : base(IntPtr.Zero)
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
				device.CreateHullShader((IntPtr)value, shaderBytecode.Length, linkage, this);
			}
		}

		// Token: 0x06000230 RID: 560 RVA: 0x00002075 File Offset: 0x00000275
		public HullShader(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000231 RID: 561 RVA: 0x00009DEB File Offset: 0x00007FEB
		public new static explicit operator HullShader(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new HullShader(nativePtr);
			}
			return null;
		}
	}
}
