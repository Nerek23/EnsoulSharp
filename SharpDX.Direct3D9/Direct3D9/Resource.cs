using System;
using System.Runtime.InteropServices;
using SharpDX.Direct3D;

namespace SharpDX.Direct3D9
{
	// Token: 0x020000BE RID: 190
	[Guid("05EEC05D-8F7D-4362-B999-D1BAF357C704")]
	public class Resource : ComObject
	{
		// Token: 0x06000587 RID: 1415 RVA: 0x00002623 File Offset: 0x00000823
		public Resource(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000588 RID: 1416 RVA: 0x00014454 File Offset: 0x00012654
		public new static explicit operator Resource(IntPtr nativePointer)
		{
			if (!(nativePointer == IntPtr.Zero))
			{
				return new Resource(nativePointer);
			}
			return null;
		}

		// Token: 0x17000076 RID: 118
		// (get) Token: 0x06000589 RID: 1417 RVA: 0x0001446B File Offset: 0x0001266B
		public Device Device
		{
			get
			{
				if (this.Device__ == null)
				{
					this.GetDevice(out this.Device__);
				}
				return this.Device__;
			}
		}

		// Token: 0x17000077 RID: 119
		// (get) Token: 0x0600058A RID: 1418 RVA: 0x00014487 File Offset: 0x00012687
		public int Priority
		{
			get
			{
				return this.GetPriority();
			}
		}

		// Token: 0x17000078 RID: 120
		// (get) Token: 0x0600058B RID: 1419 RVA: 0x0001448F File Offset: 0x0001268F
		public ResourceType TypeInfo
		{
			get
			{
				return this.GetTypeInfo();
			}
		}

		// Token: 0x0600058C RID: 1420 RVA: 0x00014498 File Offset: 0x00012698
		internal unsafe void GetDevice(out Device deviceOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*)));
			deviceOut = ((zero == IntPtr.Zero) ? null : new Device(zero));
			result.CheckError();
		}

		// Token: 0x0600058D RID: 1421 RVA: 0x000144F0 File Offset: 0x000126F0
		public unsafe void SetPrivateData(Guid refguid, IntPtr dataRef, int sizeOfData, int flags)
		{
			calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Int32,System.Int32), this._nativePointer, &refguid, (void*)dataRef, sizeOfData, flags, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x0600058E RID: 1422 RVA: 0x00014534 File Offset: 0x00012734
		public unsafe Result GetPrivateData(Guid refguid, IntPtr dataRef, ref int sizeOfDataRef)
		{
			Result result;
			fixed (int* ptr = &sizeOfDataRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, &refguid, (void*)dataRef, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*)));
			}
			return result;
		}

		// Token: 0x0600058F RID: 1423 RVA: 0x00014578 File Offset: 0x00012778
		public unsafe void FreePrivateData(Guid refguid)
		{
			calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &refguid, *(*(IntPtr*)this._nativePointer + (IntPtr)6 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000590 RID: 1424 RVA: 0x000145B2 File Offset: 0x000127B2
		public unsafe int SetPriority(int priorityNew)
		{
			return calli(System.Int32(System.Void*,System.Int32), this._nativePointer, priorityNew, *(*(IntPtr*)this._nativePointer + (IntPtr)7 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000591 RID: 1425 RVA: 0x0001113E File Offset: 0x0000F33E
		internal unsafe int GetPriority()
		{
			return calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000592 RID: 1426 RVA: 0x000145D2 File Offset: 0x000127D2
		public unsafe void PreLoad()
		{
			calli(System.Void(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)9 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000593 RID: 1427 RVA: 0x000145F2 File Offset: 0x000127F2
		internal unsafe ResourceType GetTypeInfo()
		{
			return calli(SharpDX.Direct3D9.ResourceType(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)10 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x17000079 RID: 121
		// (get) Token: 0x06000594 RID: 1428 RVA: 0x00014614 File Offset: 0x00012814
		// (set) Token: 0x06000595 RID: 1429 RVA: 0x00014664 File Offset: 0x00012864
		public unsafe string DebugName
		{
			get
			{
				byte* ptr = stackalloc byte[(UIntPtr)1024];
				int num = 1023;
				if (this.GetPrivateData(CommonGuid.DebugObjectName, new IntPtr((void*)ptr), ref num).Failure)
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
					this.SetPrivateData(CommonGuid.DebugObjectName, IntPtr.Zero, 0, 0);
					return;
				}
				IntPtr dataRef = Marshal.StringToHGlobalAnsi(value);
				this.SetPrivateData(CommonGuid.DebugObjectName, dataRef, value.Length, 0);
			}
		}

		// Token: 0x06000596 RID: 1430 RVA: 0x000146A6 File Offset: 0x000128A6
		protected override void NativePointerUpdated(IntPtr oldNativePointer)
		{
			this.DisposeDevice();
			base.NativePointerUpdated(oldNativePointer);
		}

		// Token: 0x06000597 RID: 1431 RVA: 0x000146B5 File Offset: 0x000128B5
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				this.DisposeDevice();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000598 RID: 1432 RVA: 0x000146C7 File Offset: 0x000128C7
		private void DisposeDevice()
		{
			if (this.Device__ != null)
			{
				((IUnknown)this.Device__).Release();
				this.Device__ = null;
			}
		}

		// Token: 0x040009D1 RID: 2513
		protected internal Device Device__;
	}
}
