using System;
using System.Runtime.InteropServices;

namespace SharpDX.DXGI
{
	// Token: 0x02000007 RID: 7
	[Guid("54ec77fa-1377-44e6-8c32-88fd5f44c84c")]
	public class Device : DXGIObject
	{
		// Token: 0x06000017 RID: 23 RVA: 0x00002388 File Offset: 0x00000588
		public Residency[] QueryResourceResidency(params ComObject[] comObjects)
		{
			int num = comObjects.Length;
			Residency[] array = new Residency[num];
			this.QueryResourceResidency(comObjects, array, num);
			return array;
		}

		// Token: 0x06000018 RID: 24 RVA: 0x00002165 File Offset: 0x00000365
		public Device(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000019 RID: 25 RVA: 0x000023AC File Offset: 0x000005AC
		public new static explicit operator Device(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new Device(nativePtr);
			}
			return null;
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x0600001A RID: 26 RVA: 0x000023C4 File Offset: 0x000005C4
		public Adapter Adapter
		{
			get
			{
				Adapter result;
				this.GetAdapter(out result);
				return result;
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x0600001B RID: 27 RVA: 0x000023DC File Offset: 0x000005DC
		// (set) Token: 0x0600001C RID: 28 RVA: 0x000023F2 File Offset: 0x000005F2
		public int GPUThreadPriority
		{
			get
			{
				int result;
				this.GetGPUThreadPriority(out result);
				return result;
			}
			set
			{
				this.SetGPUThreadPriority(value);
			}
		}

		// Token: 0x0600001D RID: 29 RVA: 0x000023FC File Offset: 0x000005FC
		internal unsafe void GetAdapter(out Adapter adapterRef)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)7 * (IntPtr)sizeof(void*)));
			if (zero != IntPtr.Zero)
			{
				adapterRef = new Adapter(zero);
			}
			else
			{
				adapterRef = null;
			}
			result.CheckError();
		}

		// Token: 0x0600001E RID: 30 RVA: 0x00002458 File Offset: 0x00000658
		internal unsafe void CreateSurface(ref SurfaceDescription descRef, int numSurfaces, int usage, SharedResource? sharedResourceRef, out Surface surfaceOut)
		{
			IntPtr zero = IntPtr.Zero;
			SharedResource value;
			if (sharedResourceRef != null)
			{
				value = sharedResourceRef.Value;
			}
			Result result;
			fixed (SurfaceDescription* ptr = &descRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*,System.Int32,System.Int32,System.Void*,System.Void*), this._nativePointer, ptr2, numSurfaces, usage, (sharedResourceRef == null) ? null : (&value), &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*)));
			}
			if (zero != IntPtr.Zero)
			{
				surfaceOut = new Surface(zero);
			}
			else
			{
				surfaceOut = null;
			}
			result.CheckError();
		}

		// Token: 0x0600001F RID: 31 RVA: 0x000024E4 File Offset: 0x000006E4
		internal unsafe void QueryResourceResidency(IUnknown[] resourcesOut, Residency[] residencyStatusRef, int numResources)
		{
			IntPtr* ptr = null;
			if (resourcesOut != null)
			{
				ptr = stackalloc IntPtr[checked(unchecked((UIntPtr)resourcesOut.Length) * (UIntPtr)sizeof(IntPtr))];
			}
			if (resourcesOut != null)
			{
				for (int i = 0; i < resourcesOut.Length; i++)
				{
					ptr[(IntPtr)i * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)] = CppObject.ToCallbackPtr<IUnknown>(resourcesOut[i]);
				}
			}
			Result result;
			fixed (Residency[] array = residencyStatusRef)
			{
				void* ptr2;
				if (residencyStatusRef == null || array.Length == 0)
				{
					ptr2 = null;
				}
				else
				{
					ptr2 = (void*)(&array[0]);
				}
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Int32), this._nativePointer, ptr, ptr2, numResources, *(*(IntPtr*)this._nativePointer + (IntPtr)9 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x06000020 RID: 32 RVA: 0x00002578 File Offset: 0x00000778
		internal unsafe void SetGPUThreadPriority(int priority)
		{
			calli(System.Int32(System.Void*,System.Int32), this._nativePointer, priority, *(*(IntPtr*)this._nativePointer + (IntPtr)10 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000021 RID: 33 RVA: 0x000025B4 File Offset: 0x000007B4
		internal unsafe void GetGPUThreadPriority(out int priorityRef)
		{
			Result result;
			fixed (int* ptr = &priorityRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)11 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}
	}
}
