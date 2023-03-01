using System;
using System.Runtime.InteropServices;

namespace SharpDX.WIC
{
	// Token: 0x0200007F RID: 127
	public struct RawToneCurve
	{
		// Token: 0x17000065 RID: 101
		// (get) Token: 0x06000269 RID: 617 RVA: 0x00009DE0 File Offset: 0x00007FE0
		// (set) Token: 0x0600026A RID: 618 RVA: 0x00009E06 File Offset: 0x00008006
		public RawToneCurvePoint[] APoints
		{
			get
			{
				RawToneCurvePoint[] result;
				if ((result = this._APoints) == null)
				{
					result = (this._APoints = new RawToneCurvePoint[1]);
				}
				return result;
			}
			private set
			{
				this._APoints = value;
			}
		}

		// Token: 0x0600026B RID: 619 RVA: 0x00009E0F File Offset: 0x0000800F
		internal void __MarshalFree(ref RawToneCurve.__Native @ref)
		{
		}

		// Token: 0x0600026C RID: 620 RVA: 0x00009E14 File Offset: 0x00008014
		internal unsafe void __MarshalFrom(ref RawToneCurve.__Native @ref)
		{
			this.CPoints = @ref.CPoints;
			fixed (RawToneCurvePoint* ptr = &this.APoints[0])
			{
				void* value = (void*)ptr;
				fixed (RawToneCurvePoint* ptr2 = &@ref.APoints)
				{
					void* value2 = (void*)ptr2;
					Utilities.CopyMemory((IntPtr)value, (IntPtr)value2, sizeof(RawToneCurvePoint));
					ptr = null;
				}
			}
		}

		// Token: 0x0600026D RID: 621 RVA: 0x00009E64 File Offset: 0x00008064
		internal unsafe void __MarshalTo(ref RawToneCurve.__Native @ref)
		{
			@ref.CPoints = this.CPoints;
			fixed (RawToneCurvePoint* ptr = &this.APoints[0])
			{
				void* value = (void*)ptr;
				fixed (RawToneCurvePoint* ptr2 = &@ref.APoints)
				{
					void* value2 = (void*)ptr2;
					Utilities.CopyMemory((IntPtr)value2, (IntPtr)value, sizeof(RawToneCurvePoint));
					ptr = null;
				}
			}
		}

		// Token: 0x04000207 RID: 519
		public int CPoints;

		// Token: 0x04000208 RID: 520
		internal RawToneCurvePoint[] _APoints;

		// Token: 0x02000080 RID: 128
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		internal struct __Native
		{
			// Token: 0x04000209 RID: 521
			public int CPoints;

			// Token: 0x0400020A RID: 522
			public RawToneCurvePoint APoints;
		}
	}
}
