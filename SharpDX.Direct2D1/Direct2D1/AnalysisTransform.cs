using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct2D1
{
	// Token: 0x02000173 RID: 371
	[Guid("0359dc30-95e6-4568-9055-27720d130e93")]
	public class AnalysisTransform : ComObject
	{
		// Token: 0x0600068F RID: 1679 RVA: 0x00014FDA File Offset: 0x000131DA
		public void ProcessAnalysisResults(DataStream analysisData)
		{
			this.ProcessAnalysisResults(analysisData.DataPointer, (int)analysisData.Length);
		}

		// Token: 0x06000690 RID: 1680 RVA: 0x00014FF0 File Offset: 0x000131F0
		public unsafe void ProcessAnalysisResults<T>(T analysisData) where T : struct
		{
			fixed (T* value = &analysisData)
			{
				this.ProcessAnalysisResults((IntPtr)((void*)value), Utilities.SizeOf<T>());
			}
		}

		// Token: 0x06000691 RID: 1681 RVA: 0x00015014 File Offset: 0x00013214
		public unsafe void ProcessAnalysisResults<T>(T[] analysisData) where T : struct
		{
			fixed (T* value = &analysisData[0])
			{
				this.ProcessAnalysisResults((IntPtr)((void*)value), Utilities.SizeOf<T>() * analysisData.Length);
			}
		}

		// Token: 0x06000692 RID: 1682 RVA: 0x00002A7F File Offset: 0x00000C7F
		public AnalysisTransform(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000693 RID: 1683 RVA: 0x0001503E File Offset: 0x0001323E
		public new static explicit operator AnalysisTransform(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new AnalysisTransform(nativePtr);
			}
			return null;
		}

		// Token: 0x06000694 RID: 1684 RVA: 0x00015058 File Offset: 0x00013258
		internal unsafe void ProcessAnalysisResults(IntPtr analysisData, int analysisDataCount)
		{
			calli(System.Int32(System.Void*,System.Void*,System.Int32), this._nativePointer, (void*)analysisData, analysisDataCount, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*))).CheckError();
		}
	}
}
