using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D9
{
	// Token: 0x020000C5 RID: 197
	[Guid("91886CAF-1C3D-4d2e-A0AB-3E4C7D8D3303")]
	public class SwapChain9Ex : SwapChain
	{
		// Token: 0x06000638 RID: 1592 RVA: 0x00016510 File Offset: 0x00014710
		public SwapChain9Ex(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000639 RID: 1593 RVA: 0x00016519 File Offset: 0x00014719
		public new static explicit operator SwapChain9Ex(IntPtr nativePointer)
		{
			if (!(nativePointer == IntPtr.Zero))
			{
				return new SwapChain9Ex(nativePointer);
			}
			return null;
		}

		// Token: 0x1700008E RID: 142
		// (get) Token: 0x0600063A RID: 1594 RVA: 0x00016530 File Offset: 0x00014730
		public int LastPresentCount
		{
			get
			{
				int result;
				this.GetLastPresentCount(out result);
				return result;
			}
		}

		// Token: 0x1700008F RID: 143
		// (get) Token: 0x0600063B RID: 1595 RVA: 0x00016548 File Offset: 0x00014748
		public PresentationStatistics PresentStats
		{
			get
			{
				PresentationStatistics result;
				this.GetPresentStats(out result);
				return result;
			}
		}

		// Token: 0x0600063C RID: 1596 RVA: 0x00016560 File Offset: 0x00014760
		internal unsafe void GetLastPresentCount(out int lastPresentCountRef)
		{
			Result result;
			fixed (int* ptr = &lastPresentCountRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)10 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x0600063D RID: 1597 RVA: 0x000165A4 File Offset: 0x000147A4
		internal unsafe void GetPresentStats(out PresentationStatistics presentationStatisticsRef)
		{
			presentationStatisticsRef = default(PresentationStatistics);
			Result result;
			fixed (PresentationStatistics* ptr = &presentationStatisticsRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)11 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x0600063E RID: 1598 RVA: 0x000165EC File Offset: 0x000147EC
		public unsafe void GetDisplayModeEx(out DisplayModeEx modeRef, out DisplayRotation rotationRef)
		{
			DisplayModeEx.__Native _Native = DisplayModeEx.__NewNative();
			Result result;
			fixed (DisplayRotation* ptr = &rotationRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, &_Native, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)12 * (IntPtr)sizeof(void*)));
			}
			modeRef = new DisplayModeEx();
			modeRef.__MarshalFrom(ref _Native);
			result.CheckError();
		}
	}
}
