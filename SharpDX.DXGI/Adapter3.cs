using System;
using System.Runtime.InteropServices;

namespace SharpDX.DXGI
{
	// Token: 0x02000058 RID: 88
	[Guid("645967A4-1392-4310-A798-8053CE3E93FD")]
	public class Adapter3 : Adapter2
	{
		// Token: 0x06000159 RID: 345 RVA: 0x00006022 File Offset: 0x00004222
		public Adapter3(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x0600015A RID: 346 RVA: 0x0000602B File Offset: 0x0000422B
		public new static explicit operator Adapter3(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new Adapter3(nativePtr);
			}
			return null;
		}

		// Token: 0x0600015B RID: 347 RVA: 0x00006044 File Offset: 0x00004244
		public unsafe int RegisterHardwareContentProtectionTeardownStatusEvent(IntPtr hEvent)
		{
			int result;
			calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)hEvent, &result, *(*(IntPtr*)this._nativePointer + (IntPtr)12 * (IntPtr)sizeof(void*))).CheckError();
			return result;
		}

		// Token: 0x0600015C RID: 348 RVA: 0x00006086 File Offset: 0x00004286
		public unsafe void UnregisterHardwareContentProtectionTeardownStatus(int dwCookie)
		{
			calli(System.Void(System.Void*,System.Int32), this._nativePointer, dwCookie, *(*(IntPtr*)this._nativePointer + (IntPtr)13 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x0600015D RID: 349 RVA: 0x000060A8 File Offset: 0x000042A8
		public unsafe QueryVideoMemoryInformation QueryVideoMemoryInfo(int nodeIndex, MemorySegmentGroup memorySegmentGroup)
		{
			QueryVideoMemoryInformation result;
			calli(System.Int32(System.Void*,System.Int32,System.Int32,System.Void*), this._nativePointer, nodeIndex, memorySegmentGroup, &result, *(*(IntPtr*)this._nativePointer + (IntPtr)14 * (IntPtr)sizeof(void*))).CheckError();
			return result;
		}

		// Token: 0x0600015E RID: 350 RVA: 0x000060E8 File Offset: 0x000042E8
		public unsafe void SetVideoMemoryReservation(int nodeIndex, MemorySegmentGroup memorySegmentGroup, long reservation)
		{
			calli(System.Int32(System.Void*,System.Int32,System.Int32,System.Int64), this._nativePointer, nodeIndex, memorySegmentGroup, reservation, *(*(IntPtr*)this._nativePointer + (IntPtr)15 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x0600015F RID: 351 RVA: 0x00006124 File Offset: 0x00004324
		public unsafe int RegisterVideoMemoryBudgetChangeNotificationEvent(IntPtr hEvent)
		{
			int result;
			calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)hEvent, &result, *(*(IntPtr*)this._nativePointer + (IntPtr)16 * (IntPtr)sizeof(void*))).CheckError();
			return result;
		}

		// Token: 0x06000160 RID: 352 RVA: 0x00006166 File Offset: 0x00004366
		public unsafe void UnregisterVideoMemoryBudgetChangeNotification(int dwCookie)
		{
			calli(System.Void(System.Void*,System.Int32), this._nativePointer, dwCookie, *(*(IntPtr*)this._nativePointer + (IntPtr)17 * (IntPtr)sizeof(void*)));
		}
	}
}
