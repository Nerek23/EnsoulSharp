using System;
using System.Runtime.InteropServices;

namespace SharpDX.WIC
{
	// Token: 0x0200006B RID: 107
	[Guid("5cacdb4c-407e-41b3-b936-d0f010cd6732")]
	public class DdsEncoder : ComObject
	{
		// Token: 0x060001EB RID: 491 RVA: 0x00002A7F File Offset: 0x00000C7F
		public DdsEncoder(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060001EC RID: 492 RVA: 0x000084E7 File Offset: 0x000066E7
		public new static explicit operator DdsEncoder(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new DdsEncoder(nativePtr);
			}
			return null;
		}

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x060001ED RID: 493 RVA: 0x00008500 File Offset: 0x00006700
		// (set) Token: 0x060001EE RID: 494 RVA: 0x00008516 File Offset: 0x00006716
		public DdsParameters Parameters
		{
			get
			{
				DdsParameters result;
				this.GetParameters(out result);
				return result;
			}
			set
			{
				this.SetParameters(ref value);
			}
		}

		// Token: 0x060001EF RID: 495 RVA: 0x00008520 File Offset: 0x00006720
		internal unsafe void SetParameters(ref DdsParameters parametersRef)
		{
			Result result;
			fixed (DdsParameters* ptr = &parametersRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x060001F0 RID: 496 RVA: 0x00008560 File Offset: 0x00006760
		internal unsafe void GetParameters(out DdsParameters parametersRef)
		{
			parametersRef = default(DdsParameters);
			Result result;
			fixed (DdsParameters* ptr = &parametersRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x060001F1 RID: 497 RVA: 0x000085A8 File Offset: 0x000067A8
		public unsafe void CreateNewFrame(out BitmapFrameEncode frameEncodeOut, out int arrayIndexRef, out int mipLevelRef, out int sliceIndexRef)
		{
			IntPtr zero = IntPtr.Zero;
			Result result;
			fixed (int* ptr = &sliceIndexRef)
			{
				void* ptr2 = (void*)ptr;
				fixed (int* ptr3 = &mipLevelRef)
				{
					void* ptr4 = (void*)ptr3;
					fixed (int* ptr5 = &arrayIndexRef)
					{
						void* ptr6 = (void*)ptr5;
						result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, &zero, ptr6, ptr4, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*)));
					}
				}
			}
			if (zero != IntPtr.Zero)
			{
				frameEncodeOut = new BitmapFrameEncode(zero);
			}
			else
			{
				frameEncodeOut = null;
			}
			result.CheckError();
		}
	}
}
