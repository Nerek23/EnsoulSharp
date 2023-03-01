using System;
using System.Runtime.InteropServices;
using SharpDX.DirectWrite;

namespace SharpDX.Direct2D1
{
	// Token: 0x020001D4 RID: 468
	[Guid("689f1f85-c72e-4e33-8f19-85754efd5ace")]
	public class DrawingStateBlock1 : DrawingStateBlock
	{
		// Token: 0x0600097D RID: 2429 RVA: 0x0001B724 File Offset: 0x00019924
		public DrawingStateBlock1(Factory1 factory) : base(IntPtr.Zero)
		{
			factory.CreateDrawingStateBlock(null, null, this);
		}

		// Token: 0x0600097E RID: 2430 RVA: 0x0001B74D File Offset: 0x0001994D
		public DrawingStateBlock1(Factory1 factory, DrawingStateDescription1 drawingStateDescription) : this(factory, drawingStateDescription, null)
		{
		}

		// Token: 0x0600097F RID: 2431 RVA: 0x0001B758 File Offset: 0x00019958
		public DrawingStateBlock1(Factory1 factory, RenderingParams textRenderingParams) : base(IntPtr.Zero)
		{
			factory.CreateDrawingStateBlock(null, textRenderingParams, this);
		}

		// Token: 0x06000980 RID: 2432 RVA: 0x0001B781 File Offset: 0x00019981
		public DrawingStateBlock1(Factory1 factory, DrawingStateDescription1 drawingStateDescription, RenderingParams textRenderingParams) : base(IntPtr.Zero)
		{
			factory.CreateDrawingStateBlock(new DrawingStateDescription1?(drawingStateDescription), textRenderingParams, this);
		}

		// Token: 0x06000981 RID: 2433 RVA: 0x0001B79C File Offset: 0x0001999C
		public DrawingStateBlock1(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000982 RID: 2434 RVA: 0x0001B7A5 File Offset: 0x000199A5
		public new static explicit operator DrawingStateBlock1(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new DrawingStateBlock1(nativePtr);
			}
			return null;
		}

		// Token: 0x1700015A RID: 346
		// (get) Token: 0x06000983 RID: 2435 RVA: 0x0001B7BC File Offset: 0x000199BC
		// (set) Token: 0x06000984 RID: 2436 RVA: 0x0001B7D2 File Offset: 0x000199D2
		public new DrawingStateDescription1 Description
		{
			get
			{
				DrawingStateDescription1 result;
				this.GetDescription(out result);
				return result;
			}
			set
			{
				this.SetDescription(ref value);
			}
		}

		// Token: 0x06000985 RID: 2437 RVA: 0x0001B7DC File Offset: 0x000199DC
		internal unsafe void GetDescription(out DrawingStateDescription1 stateDescription)
		{
			stateDescription = default(DrawingStateDescription1);
			fixed (DrawingStateDescription1* ptr = &stateDescription)
			{
				void* ptr2 = (void*)ptr;
				calli(System.Void(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*)));
			}
		}

		// Token: 0x06000986 RID: 2438 RVA: 0x0001B818 File Offset: 0x00019A18
		internal unsafe void SetDescription(ref DrawingStateDescription1 stateDescription)
		{
			fixed (DrawingStateDescription1* ptr = &stateDescription)
			{
				void* ptr2 = (void*)ptr;
				calli(System.Void(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)9 * (IntPtr)sizeof(void*)));
			}
		}
	}
}
