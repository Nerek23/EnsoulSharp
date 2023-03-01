using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x02000027 RID: 39
	[Guid("38325b96-effb-4022-ba02-2e795b70275c")]
	public class GeometryShader : DeviceChild
	{
		// Token: 0x0600022B RID: 555 RVA: 0x00009CC8 File Offset: 0x00007EC8
		public unsafe GeometryShader(Device device, byte[] shaderBytecode, ClassLinkage linkage = null) : base(IntPtr.Zero)
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
				device.CreateGeometryShader((IntPtr)value, shaderBytecode.Length, linkage, this);
			}
		}

		// Token: 0x0600022C RID: 556 RVA: 0x00009D24 File Offset: 0x00007F24
		public unsafe GeometryShader(Device device, byte[] shaderBytecode, StreamOutputElement[] elements, int[] bufferedStrides, int rasterizedStream, ClassLinkage linkage = null) : base(IntPtr.Zero)
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
				device.CreateGeometryShaderWithStreamOutput((IntPtr)value, shaderBytecode.Length, elements, elements.Length, bufferedStrides, bufferedStrides.Length, rasterizedStream, linkage, this);
			}
		}

		// Token: 0x0600022D RID: 557 RVA: 0x00002075 File Offset: 0x00000275
		public GeometryShader(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x0600022E RID: 558 RVA: 0x00009D79 File Offset: 0x00007F79
		public new static explicit operator GeometryShader(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new GeometryShader(nativePtr);
			}
			return null;
		}

		// Token: 0x04000086 RID: 134
		public const int StreamOutputNoRasterizedStream = -1;

		// Token: 0x04000087 RID: 135
		public const int StreamOutputStreamCount = 4;

		// Token: 0x04000088 RID: 136
		public const int StreamOutputOutputComponentCount = 128;

		// Token: 0x04000089 RID: 137
		public const int StreamOutputBufferSlotCount = 4;
	}
}
