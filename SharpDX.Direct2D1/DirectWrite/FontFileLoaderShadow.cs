using System;
using System.Runtime.InteropServices;

namespace SharpDX.DirectWrite
{
	// Token: 0x02000098 RID: 152
	internal class FontFileLoaderShadow : ComObjectShadow
	{
		// Token: 0x06000310 RID: 784 RVA: 0x0000BE39 File Offset: 0x0000A039
		public static IntPtr ToIntPtr(FontFileLoader callback)
		{
			return CppObject.ToCallbackPtr<FontFileLoader>(callback);
		}

		// Token: 0x17000079 RID: 121
		// (get) Token: 0x06000311 RID: 785 RVA: 0x0000BE41 File Offset: 0x0000A041
		protected override CppObjectVtbl GetVtbl
		{
			get
			{
				return FontFileLoaderShadow.Vtbl;
			}
		}

		// Token: 0x04000215 RID: 533
		private static readonly FontFileLoaderShadow.FontFileLoaderVtbl Vtbl = new FontFileLoaderShadow.FontFileLoaderVtbl();

		// Token: 0x02000099 RID: 153
		private class FontFileLoaderVtbl : ComObjectShadow.ComObjectVtbl
		{
			// Token: 0x06000314 RID: 788 RVA: 0x0000BE54 File Offset: 0x0000A054
			public FontFileLoaderVtbl() : base(1)
			{
				base.AddMethod(new FontFileLoaderShadow.FontFileLoaderVtbl.CreateStreamFromKeyDelegate(FontFileLoaderShadow.FontFileLoaderVtbl.CreateStreamFromKeyImpl));
			}

			// Token: 0x06000315 RID: 789 RVA: 0x0000BE70 File Offset: 0x0000A070
			private static int CreateStreamFromKeyImpl(IntPtr thisPtr, IntPtr fontFileReferenceKey, int fontFileReferenceKeySize, out IntPtr fontFileStreamPtr)
			{
				fontFileStreamPtr = IntPtr.Zero;
				try
				{
					FontFileStream callback = ((FontFileLoader)CppObjectShadow.ToShadow<FontFileLoaderShadow>(thisPtr).Callback).CreateStreamFromKey(new DataPointer(fontFileReferenceKey, fontFileReferenceKeySize));
					fontFileStreamPtr = FontFileStreamShadow.ToIntPtr(callback);
				}
				catch (Exception ex)
				{
					return (int)Result.GetResultFromException(ex);
				}
				return Result.Ok.Code;
			}

			// Token: 0x0200009A RID: 154
			// (Invoke) Token: 0x06000317 RID: 791
			[UnmanagedFunctionPointer(CallingConvention.StdCall)]
			private delegate int CreateStreamFromKeyDelegate(IntPtr thisPtr, IntPtr fontFileReferenceKey, int fontFileReferenceKeySize, out IntPtr fontFileStream);
		}
	}
}
