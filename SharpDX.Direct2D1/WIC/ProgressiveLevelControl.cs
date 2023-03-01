using System;
using System.Runtime.InteropServices;

namespace SharpDX.WIC
{
	// Token: 0x02000076 RID: 118
	[Guid("DAAC296F-7AA5-4dbf-8D15-225C5976F891")]
	public class ProgressiveLevelControl : ComObject
	{
		// Token: 0x06000261 RID: 609 RVA: 0x00002A7F File Offset: 0x00000C7F
		public ProgressiveLevelControl(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000262 RID: 610 RVA: 0x00009CD6 File Offset: 0x00007ED6
		public new static explicit operator ProgressiveLevelControl(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new ProgressiveLevelControl(nativePtr);
			}
			return null;
		}

		// Token: 0x17000063 RID: 99
		// (get) Token: 0x06000263 RID: 611 RVA: 0x00009CF0 File Offset: 0x00007EF0
		public int LevelCount
		{
			get
			{
				int result;
				this.GetLevelCount(out result);
				return result;
			}
		}

		// Token: 0x17000064 RID: 100
		// (get) Token: 0x06000264 RID: 612 RVA: 0x00009D08 File Offset: 0x00007F08
		// (set) Token: 0x06000265 RID: 613 RVA: 0x00009D1E File Offset: 0x00007F1E
		public int CurrentLevel
		{
			get
			{
				int result;
				this.GetCurrentLevel(out result);
				return result;
			}
			set
			{
				this.SetCurrentLevel(value);
			}
		}

		// Token: 0x06000266 RID: 614 RVA: 0x00009D28 File Offset: 0x00007F28
		internal unsafe void GetLevelCount(out int levelsRef)
		{
			Result result;
			fixed (int* ptr = &levelsRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x06000267 RID: 615 RVA: 0x00009D68 File Offset: 0x00007F68
		internal unsafe void GetCurrentLevel(out int nLevelRef)
		{
			Result result;
			fixed (int* ptr = &nLevelRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x06000268 RID: 616 RVA: 0x00009DA8 File Offset: 0x00007FA8
		internal unsafe void SetCurrentLevel(int nLevel)
		{
			calli(System.Int32(System.Void*,System.Int32), this._nativePointer, nLevel, *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*))).CheckError();
		}
	}
}
