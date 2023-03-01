using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.DirectWrite
{
	// Token: 0x020000AD RID: 173
	[Guid("8339FDE3-106F-47ab-8373-1C6295EB10B3")]
	public class InlineObjectNative : ComObject, InlineObject, IUnknown, ICallbackable, IDisposable
	{
		// Token: 0x0600036B RID: 875 RVA: 0x0000CB60 File Offset: 0x0000AD60
		public void Draw(object clientDrawingContext, TextRenderer renderer, float originX, float originY, bool isSideways, bool isRightToLeft, ComObject clientDrawingEffect)
		{
			GCHandle value = GCHandle.Alloc(clientDrawingContext);
			IntPtr iunknownForObject = Utilities.GetIUnknownForObject(clientDrawingEffect);
			try
			{
				this.Draw_(GCHandle.ToIntPtr(value), renderer, originX, originY, isSideways, isRightToLeft, iunknownForObject);
			}
			finally
			{
				if (value.IsAllocated)
				{
					value.Free();
				}
				if (iunknownForObject != IntPtr.Zero)
				{
					Marshal.Release(iunknownForObject);
				}
			}
		}

		// Token: 0x17000083 RID: 131
		// (get) Token: 0x0600036C RID: 876 RVA: 0x0000CBD4 File Offset: 0x0000ADD4
		public InlineObjectMetrics Metrics
		{
			get
			{
				InlineObjectMetrics result;
				this.GetMetrics_(out result);
				return result;
			}
		}

		// Token: 0x17000084 RID: 132
		// (get) Token: 0x0600036D RID: 877 RVA: 0x0000CBEC File Offset: 0x0000ADEC
		public OverhangMetrics OverhangMetrics
		{
			get
			{
				OverhangMetrics result;
				this.GetOverhangMetrics_(out result);
				return result;
			}
		}

		// Token: 0x0600036E RID: 878 RVA: 0x0000CC02 File Offset: 0x0000AE02
		public void GetBreakConditions(out BreakCondition breakConditionBefore, out BreakCondition breakConditionAfter)
		{
			this.GetBreakConditions_(out breakConditionBefore, out breakConditionAfter);
		}

		// Token: 0x0600036F RID: 879 RVA: 0x00002A7F File Offset: 0x00000C7F
		public InlineObjectNative(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000370 RID: 880 RVA: 0x0000CC0C File Offset: 0x0000AE0C
		public new static explicit operator InlineObjectNative(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new InlineObjectNative(nativePtr);
			}
			return null;
		}

		// Token: 0x17000085 RID: 133
		// (get) Token: 0x06000371 RID: 881 RVA: 0x0000CC24 File Offset: 0x0000AE24
		public InlineObjectMetrics Metrics_
		{
			get
			{
				InlineObjectMetrics result;
				this.GetMetrics_(out result);
				return result;
			}
		}

		// Token: 0x17000086 RID: 134
		// (get) Token: 0x06000372 RID: 882 RVA: 0x0000CC3C File Offset: 0x0000AE3C
		public OverhangMetrics OverhangMetrics_
		{
			get
			{
				OverhangMetrics result;
				this.GetOverhangMetrics_(out result);
				return result;
			}
		}

		// Token: 0x06000373 RID: 883 RVA: 0x0000CC54 File Offset: 0x0000AE54
		internal unsafe void Draw_(IntPtr clientDrawingContext, TextRenderer renderer, float originX, float originY, RawBool isSideways, RawBool isRightToLeft, IntPtr clientDrawingEffect)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<TextRenderer>(renderer);
			calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Single,System.Single,SharpDX.Mathematics.Interop.RawBool,SharpDX.Mathematics.Interop.RawBool,System.Void*), this._nativePointer, (void*)clientDrawingContext, (void*)value, originX, originY, isSideways, isRightToLeft, (void*)clientDrawingEffect, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000374 RID: 884 RVA: 0x0000CCB4 File Offset: 0x0000AEB4
		internal unsafe void GetMetrics_(out InlineObjectMetrics metrics)
		{
			metrics = default(InlineObjectMetrics);
			Result result;
			fixed (InlineObjectMetrics* ptr = &metrics)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x06000375 RID: 885 RVA: 0x0000CCFC File Offset: 0x0000AEFC
		internal unsafe void GetOverhangMetrics_(out OverhangMetrics overhangs)
		{
			overhangs = default(OverhangMetrics);
			Result result;
			fixed (OverhangMetrics* ptr = &overhangs)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x06000376 RID: 886 RVA: 0x0000CD44 File Offset: 0x0000AF44
		internal unsafe void GetBreakConditions_(out BreakCondition breakConditionBefore, out BreakCondition breakConditionAfter)
		{
			Result result;
			fixed (BreakCondition* ptr = &breakConditionAfter)
			{
				void* ptr2 = (void*)ptr;
				fixed (BreakCondition* ptr3 = &breakConditionBefore)
				{
					void* ptr4 = (void*)ptr3;
					result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, ptr4, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)6 * (IntPtr)sizeof(void*)));
				}
			}
			result.CheckError();
		}
	}
}
