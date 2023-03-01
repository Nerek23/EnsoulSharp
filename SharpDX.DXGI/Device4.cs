using System;
using System.Runtime.InteropServices;

namespace SharpDX.DXGI
{
	// Token: 0x0200005E RID: 94
	[Guid("95B4F95F-D8DA-4CA4-9EE6-3B76D5968A10")]
	public class Device4 : Device3
	{
		// Token: 0x06000188 RID: 392 RVA: 0x00006851 File Offset: 0x00004A51
		public Device4(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000189 RID: 393 RVA: 0x0000685A File Offset: 0x00004A5A
		public new static explicit operator Device4(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new Device4(nativePtr);
			}
			return null;
		}

		// Token: 0x0600018A RID: 394 RVA: 0x00006874 File Offset: 0x00004A74
		public unsafe void OfferResources1(int numResources, Resource[] resourcesOut, OfferResourcePriority priority, int flags)
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
					ptr[(IntPtr)i * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)] = CppObject.ToCallbackPtr<Resource>(resourcesOut[i]);
				}
			}
			calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Int32,System.Int32), this._nativePointer, numResources, ptr, priority, flags, *(*(IntPtr*)this._nativePointer + (IntPtr)18 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x0600018B RID: 395 RVA: 0x000068EC File Offset: 0x00004AEC
		public unsafe void ReclaimResources1(int numResources, Resource[] resourcesOut, ReclaimResourceResults[] resultsRef)
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
					ptr[(IntPtr)i * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)] = CppObject.ToCallbackPtr<Resource>(resourcesOut[i]);
				}
			}
			Result result;
			fixed (ReclaimResourceResults[] array = resultsRef)
			{
				void* ptr2;
				if (resultsRef == null || array.Length == 0)
				{
					ptr2 = null;
				}
				else
				{
					ptr2 = (void*)(&array[0]);
				}
				result = calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Void*), this._nativePointer, numResources, ptr, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)19 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x0600018C RID: 396 RVA: 0x00006980 File Offset: 0x00004B80
		public unsafe void OfferResources1(int numResources, ComArray<Resource> resourcesOut, OfferResourcePriority priority, int flags)
		{
			calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Int32,System.Int32), this._nativePointer, numResources, (void*)((resourcesOut != null) ? resourcesOut.NativePointer : IntPtr.Zero), priority, flags, *(*(IntPtr*)this._nativePointer + (IntPtr)18 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x0600018D RID: 397 RVA: 0x000069D4 File Offset: 0x00004BD4
		private unsafe void OfferResources1(int numResources, IntPtr resourcesOut, OfferResourcePriority priority, int flags)
		{
			calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Int32,System.Int32), this._nativePointer, numResources, (void*)resourcesOut, priority, flags, *(*(IntPtr*)this._nativePointer + (IntPtr)18 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x0600018E RID: 398 RVA: 0x00006A18 File Offset: 0x00004C18
		public unsafe void ReclaimResources1(int numResources, ComArray<Resource> resourcesOut, ReclaimResourceResults[] resultsRef)
		{
			Result result;
			fixed (ReclaimResourceResults[] array = resultsRef)
			{
				void* ptr;
				if (resultsRef == null || array.Length == 0)
				{
					ptr = null;
				}
				else
				{
					ptr = (void*)(&array[0]);
				}
				result = calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Void*), this._nativePointer, numResources, (void*)((resourcesOut != null) ? resourcesOut.NativePointer : IntPtr.Zero), ptr, *(*(IntPtr*)this._nativePointer + (IntPtr)19 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x0600018F RID: 399 RVA: 0x00006A84 File Offset: 0x00004C84
		private unsafe void ReclaimResources1(int numResources, IntPtr resourcesOut, IntPtr resultsRef)
		{
			calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Void*), this._nativePointer, numResources, (void*)resourcesOut, (void*)resultsRef, *(*(IntPtr*)this._nativePointer + (IntPtr)19 * (IntPtr)sizeof(void*))).CheckError();
		}
	}
}
