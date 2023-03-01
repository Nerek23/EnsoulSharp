using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x0200000D RID: 13
	[Guid("4f5b196e-c2bd-495e-bd01-1fded38e4969")]
	public class ComputeShader : DeviceChild
	{
		// Token: 0x0600003A RID: 58 RVA: 0x00002C90 File Offset: 0x00000E90
		public unsafe ComputeShader(Device device, byte[] shaderBytecode, ClassLinkage linkage = null) : base(IntPtr.Zero)
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
				device.CreateComputeShader((IntPtr)value, shaderBytecode.Length, linkage, this);
			}
		}

		// Token: 0x0600003B RID: 59 RVA: 0x00002075 File Offset: 0x00000275
		public ComputeShader(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x0600003C RID: 60 RVA: 0x00002CEB File Offset: 0x00000EEB
		public new static explicit operator ComputeShader(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new ComputeShader(nativePtr);
			}
			return null;
		}
	}
}
