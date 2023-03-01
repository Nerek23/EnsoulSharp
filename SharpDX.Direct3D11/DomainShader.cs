using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x02000025 RID: 37
	[Guid("f582c508-0f36-490c-9977-31eece268cfa")]
	public class DomainShader : DeviceChild
	{
		// Token: 0x06000221 RID: 545 RVA: 0x00009B3C File Offset: 0x00007D3C
		public unsafe DomainShader(Device device, byte[] shaderBytecode, ClassLinkage linkage = null) : base(IntPtr.Zero)
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
				device.CreateDomainShader((IntPtr)value, shaderBytecode.Length, linkage, this);
			}
		}

		// Token: 0x06000222 RID: 546 RVA: 0x00002075 File Offset: 0x00000275
		public DomainShader(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000223 RID: 547 RVA: 0x00009B97 File Offset: 0x00007D97
		public new static explicit operator DomainShader(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new DomainShader(nativePtr);
			}
			return null;
		}
	}
}
