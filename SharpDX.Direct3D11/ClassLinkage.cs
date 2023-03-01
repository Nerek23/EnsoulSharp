using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x0200000C RID: 12
	[Guid("ddf57cba-9543-46e4-a12b-f207a0fe7fed")]
	public class ClassLinkage : DeviceChild
	{
		// Token: 0x06000035 RID: 53 RVA: 0x00002B8E File Offset: 0x00000D8E
		public ClassLinkage(Device device) : base(IntPtr.Zero)
		{
			device.CreateClassLinkage(this);
		}

		// Token: 0x06000036 RID: 54 RVA: 0x00002075 File Offset: 0x00000275
		public ClassLinkage(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000037 RID: 55 RVA: 0x00002BA2 File Offset: 0x00000DA2
		public new static explicit operator ClassLinkage(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new ClassLinkage(nativePtr);
			}
			return null;
		}

		// Token: 0x06000038 RID: 56 RVA: 0x00002BBC File Offset: 0x00000DBC
		public unsafe ClassInstance GetClassInstance(string classInstanceNameRef, int instanceIndex)
		{
			IntPtr zero = IntPtr.Zero;
			IntPtr intPtr = Marshal.StringToHGlobalAnsi(classInstanceNameRef);
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Int32,System.Void*), this._nativePointer, (void*)intPtr, instanceIndex, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)7 * (IntPtr)sizeof(void*)));
			ClassInstance result2;
			if (zero != IntPtr.Zero)
			{
				result2 = new ClassInstance(zero);
			}
			else
			{
				result2 = null;
			}
			Marshal.FreeHGlobal(intPtr);
			result.CheckError();
			return result2;
		}

		// Token: 0x06000039 RID: 57 RVA: 0x00002C2C File Offset: 0x00000E2C
		internal unsafe void CreateClassInstance(string classTypeNameRef, int constantBufferOffset, int constantVectorOffset, int textureOffset, int samplerOffset, ClassInstance instanceOut)
		{
			IntPtr zero = IntPtr.Zero;
			IntPtr intPtr = Marshal.StringToHGlobalAnsi(classTypeNameRef);
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Int32,System.Int32,System.Int32,System.Int32,System.Void*), this._nativePointer, (void*)intPtr, constantBufferOffset, constantVectorOffset, textureOffset, samplerOffset, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*)));
			instanceOut.NativePointer = zero;
			Marshal.FreeHGlobal(intPtr);
			result.CheckError();
		}
	}
}
