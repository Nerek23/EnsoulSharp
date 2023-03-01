using System;
using System.Runtime.InteropServices;

namespace SharpDX.DirectWrite
{
	// Token: 0x02000092 RID: 146
	internal class FontFileEnumeratorShadow : ComObjectShadow
	{
		// Token: 0x060002FC RID: 764 RVA: 0x0000BC94 File Offset: 0x00009E94
		public static IntPtr ToIntPtr(FontFileEnumerator callback)
		{
			return CppObject.ToCallbackPtr<FontFileEnumerator>(callback);
		}

		// Token: 0x17000078 RID: 120
		// (get) Token: 0x060002FD RID: 765 RVA: 0x0000BC9C File Offset: 0x00009E9C
		protected override CppObjectVtbl GetVtbl
		{
			get
			{
				return FontFileEnumeratorShadow.Vtbl;
			}
		}

		// Token: 0x04000214 RID: 532
		private static readonly FontFileEnumeratorShadow.FontFileEnumeratorVtbl Vtbl = new FontFileEnumeratorShadow.FontFileEnumeratorVtbl();

		// Token: 0x02000093 RID: 147
		private class FontFileEnumeratorVtbl : ComObjectShadow.ComObjectVtbl
		{
			// Token: 0x06000300 RID: 768 RVA: 0x0000BCAF File Offset: 0x00009EAF
			public FontFileEnumeratorVtbl() : base(2)
			{
				base.AddMethod(new FontFileEnumeratorShadow.FontFileEnumeratorVtbl.MoveNextDelegate(FontFileEnumeratorShadow.FontFileEnumeratorVtbl.MoveNextImpl));
				base.AddMethod(new FontFileEnumeratorShadow.FontFileEnumeratorVtbl.GetCurrentFontFileDelegate(FontFileEnumeratorShadow.FontFileEnumeratorVtbl.GetCurrentFontFileImpl));
			}

			// Token: 0x06000301 RID: 769 RVA: 0x0000BCDC File Offset: 0x00009EDC
			private static int MoveNextImpl(IntPtr thisPtr, out int hasCurrentFile)
			{
				hasCurrentFile = 0;
				try
				{
					FontFileEnumerator fontFileEnumerator = (FontFileEnumerator)CppObjectShadow.ToShadow<FontFileEnumeratorShadow>(thisPtr).Callback;
					hasCurrentFile = (fontFileEnumerator.MoveNext() ? 1 : 0);
				}
				catch (Exception ex)
				{
					return (int)Result.GetResultFromException(ex);
				}
				return Result.Ok.Code;
			}

			// Token: 0x06000302 RID: 770 RVA: 0x0000BD3C File Offset: 0x00009F3C
			private static int GetCurrentFontFileImpl(IntPtr thisPtr, out IntPtr fontFile)
			{
				fontFile = IntPtr.Zero;
				try
				{
					FontFileEnumerator fontFileEnumerator = (FontFileEnumerator)CppObjectShadow.ToShadow<FontFileEnumeratorShadow>(thisPtr).Callback;
					fontFile = fontFileEnumerator.CurrentFontFile.NativePointer;
				}
				catch (Exception ex)
				{
					return (int)Result.GetResultFromException(ex);
				}
				return Result.Ok.Code;
			}

			// Token: 0x02000094 RID: 148
			// (Invoke) Token: 0x06000304 RID: 772
			[UnmanagedFunctionPointer(CallingConvention.StdCall)]
			private delegate int MoveNextDelegate(IntPtr thisPtr, out int hasCurrentFile);

			// Token: 0x02000095 RID: 149
			// (Invoke) Token: 0x06000308 RID: 776
			[UnmanagedFunctionPointer(CallingConvention.StdCall)]
			private delegate int GetCurrentFontFileDelegate(IntPtr thisPtr, out IntPtr fontFile);
		}
	}
}
