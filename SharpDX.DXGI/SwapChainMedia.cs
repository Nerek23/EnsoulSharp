using System;
using System.Runtime.InteropServices;

namespace SharpDX.DXGI
{
	// Token: 0x02000071 RID: 113
	[Guid("dd95b90b-f05f-4f6a-bd65-25bfb264bd84")]
	public class SwapChainMedia : ComObject
	{
		// Token: 0x060001E4 RID: 484 RVA: 0x0000272E File Offset: 0x0000092E
		public SwapChainMedia(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060001E5 RID: 485 RVA: 0x00007758 File Offset: 0x00005958
		public new static explicit operator SwapChainMedia(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new SwapChainMedia(nativePtr);
			}
			return null;
		}

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x060001E6 RID: 486 RVA: 0x00007770 File Offset: 0x00005970
		public FrameStatisticsMedia FrameStatisticsMedia
		{
			get
			{
				FrameStatisticsMedia result;
				this.GetFrameStatisticsMedia(out result);
				return result;
			}
		}

		// Token: 0x1700003A RID: 58
		// (set) Token: 0x060001E7 RID: 487 RVA: 0x00007786 File Offset: 0x00005986
		public int PresentDuration
		{
			set
			{
				this.SetPresentDuration(value);
			}
		}

		// Token: 0x060001E8 RID: 488 RVA: 0x00007790 File Offset: 0x00005990
		internal unsafe void GetFrameStatisticsMedia(out FrameStatisticsMedia statsRef)
		{
			statsRef = default(FrameStatisticsMedia);
			Result result;
			fixed (FrameStatisticsMedia* ptr = &statsRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x060001E9 RID: 489 RVA: 0x000077D8 File Offset: 0x000059D8
		internal unsafe void SetPresentDuration(int duration)
		{
			calli(System.Int32(System.Void*,System.Int32), this._nativePointer, duration, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060001EA RID: 490 RVA: 0x00007810 File Offset: 0x00005A10
		public unsafe void CheckPresentDurationSupport(int desiredPresentDuration, out int closestSmallerPresentDurationRef, out int closestLargerPresentDurationRef)
		{
			Result result;
			fixed (int* ptr = &closestLargerPresentDurationRef)
			{
				void* ptr2 = (void*)ptr;
				fixed (int* ptr3 = &closestSmallerPresentDurationRef)
				{
					void* ptr4 = (void*)ptr3;
					result = calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Void*), this._nativePointer, desiredPresentDuration, ptr4, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*)));
				}
			}
			result.CheckError();
		}
	}
}
