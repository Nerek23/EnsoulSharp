using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct2D1
{
	// Token: 0x0200018A RID: 394
	[Guid("3bab440e-417e-47df-a2e2-bc0be6a00916")]
	internal class CommandSink2Native : CommandSink1Native, CommandSink2, CommandSink1, CommandSink, IUnknown, ICallbackable, IDisposable
	{
		// Token: 0x06000765 RID: 1893 RVA: 0x000165B8 File Offset: 0x000147B8
		public void DrawInk(Ink ink, Brush brush, InkStyle inkStyle)
		{
			this.DrawInk_(ink, brush, inkStyle);
		}

		// Token: 0x06000766 RID: 1894 RVA: 0x000165C3 File Offset: 0x000147C3
		public void DrawGradientMesh(GradientMesh gradientMesh)
		{
			this.DrawGradientMesh_(gradientMesh);
		}

		// Token: 0x06000767 RID: 1895 RVA: 0x000165CC File Offset: 0x000147CC
		public void DrawGdiMetafile(GdiMetafile gdiMetafile, RawRectangleF? destinationRectangle, RawRectangleF? sourceRectangle)
		{
			this.DrawGdiMetafile_(gdiMetafile, destinationRectangle, sourceRectangle);
		}

		// Token: 0x06000768 RID: 1896 RVA: 0x000165D7 File Offset: 0x000147D7
		public CommandSink2Native(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000769 RID: 1897 RVA: 0x000165E0 File Offset: 0x000147E0
		public new static explicit operator CommandSink2Native(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new CommandSink2Native(nativePtr);
			}
			return null;
		}

		// Token: 0x0600076A RID: 1898 RVA: 0x000165F8 File Offset: 0x000147F8
		internal unsafe void DrawInk_(Ink ink, Brush brush, InkStyle inkStyle)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr value2 = IntPtr.Zero;
			IntPtr value3 = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<Ink>(ink);
			value2 = CppObject.ToCallbackPtr<Brush>(brush);
			value3 = CppObject.ToCallbackPtr<InkStyle>(inkStyle);
			calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)value, (void*)value2, (void*)value3, *(*(IntPtr*)this._nativePointer + (IntPtr)29 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x0600076B RID: 1899 RVA: 0x0001666C File Offset: 0x0001486C
		internal unsafe void DrawGradientMesh_(GradientMesh gradientMesh)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<GradientMesh>(gradientMesh);
			calli(System.Int32(System.Void*,System.Void*), this._nativePointer, (void*)value, *(*(IntPtr*)this._nativePointer + (IntPtr)30 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x0600076C RID: 1900 RVA: 0x000166B8 File Offset: 0x000148B8
		internal unsafe void DrawGdiMetafile_(GdiMetafile gdiMetafile, RawRectangleF? destinationRectangle, RawRectangleF? sourceRectangle)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<GdiMetafile>(gdiMetafile);
			RawRectangleF value2;
			if (destinationRectangle != null)
			{
				value2 = destinationRectangle.Value;
			}
			RawRectangleF value3;
			if (sourceRectangle != null)
			{
				value3 = sourceRectangle.Value;
			}
			calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)value, (destinationRectangle == null) ? null : (&value2), (sourceRectangle == null) ? null : (&value3), *(*(IntPtr*)this._nativePointer + (IntPtr)31 * (IntPtr)sizeof(void*))).CheckError();
		}
	}
}
