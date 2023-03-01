using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x02000051 RID: 81
	[Guid("3b301d64-d678-4289-8897-22f8928b72f3")]
	public class VertexShader : DeviceChild
	{
		// Token: 0x0600031A RID: 794 RVA: 0x0000BFA0 File Offset: 0x0000A1A0
		public unsafe VertexShader(Device device, byte[] shaderBytecode, ClassLinkage linkage = null) : base(IntPtr.Zero)
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
				device.CreateVertexShader((IntPtr)value, shaderBytecode.Length, linkage, this);
			}
		}

		// Token: 0x0600031B RID: 795 RVA: 0x00002075 File Offset: 0x00000275
		public VertexShader(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x0600031C RID: 796 RVA: 0x0000BFFB File Offset: 0x0000A1FB
		public new static explicit operator VertexShader(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new VertexShader(nativePtr);
			}
			return null;
		}
	}
}
