using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.DXGI
{
	// Token: 0x0200005C RID: 92
	[Guid("05008617-fbfd-4051-a790-144884b4f6a9")]
	public class Device2 : Device1
	{
		// Token: 0x0600017C RID: 380 RVA: 0x00006565 File Offset: 0x00004765
		public Device2(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x0600017D RID: 381 RVA: 0x0000656E File Offset: 0x0000476E
		public new static explicit operator Device2(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new Device2(nativePtr);
			}
			return null;
		}

		// Token: 0x0600017E RID: 382 RVA: 0x00006588 File Offset: 0x00004788
		public unsafe void OfferResources(int numResources, Resource[] resourcesOut, OfferResourcePriority priority)
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
			calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Int32), this._nativePointer, numResources, ptr, priority, *(*(IntPtr*)this._nativePointer + (IntPtr)14 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x0600017F RID: 383 RVA: 0x000065FC File Offset: 0x000047FC
		public unsafe void ReclaimResources(int numResources, Resource[] resourcesOut, RawBool[] discardedRef)
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
			fixed (RawBool[] array = discardedRef)
			{
				void* ptr2;
				if (discardedRef == null || array.Length == 0)
				{
					ptr2 = null;
				}
				else
				{
					ptr2 = (void*)(&array[0]);
				}
				result = calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Void*), this._nativePointer, numResources, ptr, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)15 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x06000180 RID: 384 RVA: 0x00006690 File Offset: 0x00004890
		public unsafe void EnqueueSetEvent(IntPtr hEvent)
		{
			calli(System.Int32(System.Void*,System.Void*), this._nativePointer, (void*)hEvent, *(*(IntPtr*)this._nativePointer + (IntPtr)16 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000181 RID: 385 RVA: 0x000066D0 File Offset: 0x000048D0
		public unsafe void OfferResources(int numResources, ComArray<Resource> resourcesOut, OfferResourcePriority priority)
		{
			calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Int32), this._nativePointer, numResources, (void*)((resourcesOut != null) ? resourcesOut.NativePointer : IntPtr.Zero), priority, *(*(IntPtr*)this._nativePointer + (IntPtr)14 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000182 RID: 386 RVA: 0x00006720 File Offset: 0x00004920
		private unsafe void OfferResources(int numResources, IntPtr resourcesOut, OfferResourcePriority priority)
		{
			calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Int32), this._nativePointer, numResources, (void*)resourcesOut, priority, *(*(IntPtr*)this._nativePointer + (IntPtr)14 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000183 RID: 387 RVA: 0x00006760 File Offset: 0x00004960
		public unsafe void ReclaimResources(int numResources, ComArray<Resource> resourcesOut, RawBool[] discardedRef)
		{
			Result result;
			fixed (RawBool[] array = discardedRef)
			{
				void* ptr;
				if (discardedRef == null || array.Length == 0)
				{
					ptr = null;
				}
				else
				{
					ptr = (void*)(&array[0]);
				}
				result = calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Void*), this._nativePointer, numResources, (void*)((resourcesOut != null) ? resourcesOut.NativePointer : IntPtr.Zero), ptr, *(*(IntPtr*)this._nativePointer + (IntPtr)15 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x06000184 RID: 388 RVA: 0x000067CC File Offset: 0x000049CC
		private unsafe void ReclaimResources(int numResources, IntPtr resourcesOut, IntPtr discardedRef)
		{
			calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Void*), this._nativePointer, numResources, (void*)resourcesOut, (void*)discardedRef, *(*(IntPtr*)this._nativePointer + (IntPtr)15 * (IntPtr)sizeof(void*))).CheckError();
		}
	}
}
