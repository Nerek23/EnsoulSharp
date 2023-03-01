using System;
using System.Runtime.InteropServices;
using SharpDX.Direct3D;

namespace SharpDX.DXGI
{
	// Token: 0x02000008 RID: 8
	[Guid("3d3e0379-f9de-4d58-bb6c-18d62992f1a6")]
	public class DeviceChild : DXGIObject
	{
		// Token: 0x06000022 RID: 34 RVA: 0x000025F8 File Offset: 0x000007F8
		public T GetDevice<T>() where T : ComObject
		{
			IntPtr comObjectPtr;
			this.GetDevice(Utilities.GetGuidFromType(typeof(T)), out comObjectPtr);
			return CppObject.FromPointer<T>(comObjectPtr);
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000023 RID: 35 RVA: 0x00002624 File Offset: 0x00000824
		// (set) Token: 0x06000024 RID: 36 RVA: 0x00002674 File Offset: 0x00000874
		public unsafe string DebugName
		{
			get
			{
				byte* ptr = stackalloc byte[(UIntPtr)1024];
				int num = 1023;
				if (base.GetPrivateData(CommonGuid.DebugObjectName, ref num, new IntPtr((void*)ptr)).Failure)
				{
					return string.Empty;
				}
				ptr[num] = 0;
				return Marshal.PtrToStringAnsi(new IntPtr((void*)ptr));
			}
			set
			{
				if (string.IsNullOrEmpty(value))
				{
					base.SetPrivateData(CommonGuid.DebugObjectName, 0, IntPtr.Zero);
					return;
				}
				IntPtr dataRef = Utilities.StringToHGlobalAnsi(value);
				base.SetPrivateData(CommonGuid.DebugObjectName, value.Length, dataRef);
			}
		}

		// Token: 0x06000025 RID: 37 RVA: 0x00002165 File Offset: 0x00000365
		public DeviceChild(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000026 RID: 38 RVA: 0x000026B4 File Offset: 0x000008B4
		public new static explicit operator DeviceChild(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new DeviceChild(nativePtr);
			}
			return null;
		}

		// Token: 0x06000027 RID: 39 RVA: 0x000026CC File Offset: 0x000008CC
		public unsafe void GetDevice(Guid riid, out IntPtr deviceOut)
		{
			Result result;
			fixed (IntPtr* ptr = &deviceOut)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, &riid, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)7 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}
	}
}
