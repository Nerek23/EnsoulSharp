using System;
using System.Runtime.InteropServices;
using SharpDX.DirectWrite;

namespace SharpDX.Direct2D1
{
	// Token: 0x020001D3 RID: 467
	[Guid("28506e39-ebf6-46a1-bb47-fd85565ab957")]
	public class DrawingStateBlock : Resource
	{
		// Token: 0x0600096F RID: 2415 RVA: 0x0001B56C File Offset: 0x0001976C
		public DrawingStateBlock(Factory factory) : this(factory, null, null)
		{
		}

		// Token: 0x06000970 RID: 2416 RVA: 0x0001B58A File Offset: 0x0001978A
		public DrawingStateBlock(Factory factory, DrawingStateDescription drawingStateDescription) : this(factory, new DrawingStateDescription?(drawingStateDescription), null)
		{
		}

		// Token: 0x06000971 RID: 2417 RVA: 0x0001B59C File Offset: 0x0001979C
		public DrawingStateBlock(Factory factory, RenderingParams textRenderingParams) : this(factory, null, textRenderingParams)
		{
		}

		// Token: 0x06000972 RID: 2418 RVA: 0x0001B5BA File Offset: 0x000197BA
		public DrawingStateBlock(Factory factory, DrawingStateDescription? drawingStateDescription, RenderingParams textRenderingParams) : base(IntPtr.Zero)
		{
			factory.CreateDrawingStateBlock(drawingStateDescription, textRenderingParams, this);
		}

		// Token: 0x06000973 RID: 2419 RVA: 0x00016258 File Offset: 0x00014458
		public DrawingStateBlock(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000974 RID: 2420 RVA: 0x0001B5D0 File Offset: 0x000197D0
		public new static explicit operator DrawingStateBlock(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new DrawingStateBlock(nativePtr);
			}
			return null;
		}

		// Token: 0x17000158 RID: 344
		// (get) Token: 0x06000975 RID: 2421 RVA: 0x0001B5E8 File Offset: 0x000197E8
		// (set) Token: 0x06000976 RID: 2422 RVA: 0x0001B5FE File Offset: 0x000197FE
		public DrawingStateDescription Description
		{
			get
			{
				DrawingStateDescription result;
				this.GetDescription(out result);
				return result;
			}
			set
			{
				this.SetDescription(ref value);
			}
		}

		// Token: 0x17000159 RID: 345
		// (get) Token: 0x06000977 RID: 2423 RVA: 0x0001B608 File Offset: 0x00019808
		// (set) Token: 0x06000978 RID: 2424 RVA: 0x0001B61E File Offset: 0x0001981E
		public RenderingParams TextRenderingParams
		{
			get
			{
				RenderingParams result;
				this.GetTextRenderingParams(out result);
				return result;
			}
			set
			{
				this.SetTextRenderingParams(value);
			}
		}

		// Token: 0x06000979 RID: 2425 RVA: 0x0001B628 File Offset: 0x00019828
		internal unsafe void GetDescription(out DrawingStateDescription stateDescription)
		{
			stateDescription = default(DrawingStateDescription);
			fixed (DrawingStateDescription* ptr = &stateDescription)
			{
				void* ptr2 = (void*)ptr;
				calli(System.Void(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*)));
			}
		}

		// Token: 0x0600097A RID: 2426 RVA: 0x0001B664 File Offset: 0x00019864
		internal unsafe void SetDescription(ref DrawingStateDescription stateDescription)
		{
			fixed (DrawingStateDescription* ptr = &stateDescription)
			{
				void* ptr2 = (void*)ptr;
				calli(System.Void(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*)));
			}
		}

		// Token: 0x0600097B RID: 2427 RVA: 0x0001B698 File Offset: 0x00019898
		internal unsafe void SetTextRenderingParams(RenderingParams textRenderingParams)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<RenderingParams>(textRenderingParams);
			calli(System.Void(System.Void*,System.Void*), this._nativePointer, (void*)value, *(*(IntPtr*)this._nativePointer + (IntPtr)6 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x0600097C RID: 2428 RVA: 0x0001B6D8 File Offset: 0x000198D8
		internal unsafe void GetTextRenderingParams(out RenderingParams textRenderingParams)
		{
			IntPtr zero = IntPtr.Zero;
			calli(System.Void(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)7 * (IntPtr)sizeof(void*)));
			if (zero != IntPtr.Zero)
			{
				textRenderingParams = new RenderingParams(zero);
				return;
			}
			textRenderingParams = null;
		}
	}
}
