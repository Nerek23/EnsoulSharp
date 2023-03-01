using System;
using System.Runtime.InteropServices;

namespace SharpDX.DirectWrite
{
	// Token: 0x0200009D RID: 157
	internal class FontFileStreamShadow : ComObjectShadow
	{
		// Token: 0x0600032A RID: 810 RVA: 0x0000C05C File Offset: 0x0000A25C
		public static IntPtr ToIntPtr(FontFileStream callback)
		{
			return CppObject.ToCallbackPtr<FontFileStream>(callback);
		}

		// Token: 0x1700007C RID: 124
		// (get) Token: 0x0600032B RID: 811 RVA: 0x0000C064 File Offset: 0x0000A264
		protected override CppObjectVtbl GetVtbl
		{
			get
			{
				return FontFileStreamShadow.Vtbl;
			}
		}

		// Token: 0x04000216 RID: 534
		private static readonly FontFileStreamShadow.FontFileStreamVtbl Vtbl = new FontFileStreamShadow.FontFileStreamVtbl();

		// Token: 0x0200009E RID: 158
		private class FontFileStreamVtbl : ComObjectShadow.ComObjectVtbl
		{
			// Token: 0x0600032E RID: 814 RVA: 0x0000C078 File Offset: 0x0000A278
			public FontFileStreamVtbl() : base(4)
			{
				base.AddMethod(new FontFileStreamShadow.FontFileStreamVtbl.ReadFileFragmentDelegate(FontFileStreamShadow.FontFileStreamVtbl.ReadFileFragmentImpl));
				base.AddMethod(new FontFileStreamShadow.FontFileStreamVtbl.ReleaseFileFragmentDelegate(FontFileStreamShadow.FontFileStreamVtbl.ReleaseFileFragmentImpl));
				base.AddMethod(new FontFileStreamShadow.FontFileStreamVtbl.GetFileSizeDelegate(FontFileStreamShadow.FontFileStreamVtbl.GetFileSizeImpl));
				base.AddMethod(new FontFileStreamShadow.FontFileStreamVtbl.GetLastWriteTimeDelegate(FontFileStreamShadow.FontFileStreamVtbl.GetLastWriteTimeImpl));
			}

			// Token: 0x0600032F RID: 815 RVA: 0x0000C0D4 File Offset: 0x0000A2D4
			private static int ReadFileFragmentImpl(IntPtr thisPtr, out IntPtr fragmentStart, long fileOffset, long fragmentSize, out IntPtr fragmentContext)
			{
				fragmentStart = IntPtr.Zero;
				fragmentContext = IntPtr.Zero;
				try
				{
					((FontFileStream)CppObjectShadow.ToShadow<FontFileStreamShadow>(thisPtr).Callback).ReadFileFragment(out fragmentStart, fileOffset, fragmentSize, out fragmentContext);
				}
				catch (Exception ex)
				{
					return (int)Result.GetResultFromException(ex);
				}
				return Result.Ok.Code;
			}

			// Token: 0x06000330 RID: 816 RVA: 0x0000C138 File Offset: 0x0000A338
			private static void ReleaseFileFragmentImpl(IntPtr thisPtr, IntPtr fragmentContext)
			{
				((FontFileStream)CppObjectShadow.ToShadow<FontFileStreamShadow>(thisPtr).Callback).ReleaseFileFragment(fragmentContext);
			}

			// Token: 0x06000331 RID: 817 RVA: 0x0000C150 File Offset: 0x0000A350
			private static int GetFileSizeImpl(IntPtr thisPtr, out long fileSize)
			{
				fileSize = 0L;
				try
				{
					FontFileStream fontFileStream = (FontFileStream)CppObjectShadow.ToShadow<FontFileStreamShadow>(thisPtr).Callback;
					fileSize = fontFileStream.GetFileSize();
				}
				catch (Exception ex)
				{
					return (int)Result.GetResultFromException(ex);
				}
				return Result.Ok.Code;
			}

			// Token: 0x06000332 RID: 818 RVA: 0x0000C1A8 File Offset: 0x0000A3A8
			private static int GetLastWriteTimeImpl(IntPtr thisPtr, out long lastWriteTime)
			{
				lastWriteTime = 0L;
				try
				{
					FontFileStream fontFileStream = (FontFileStream)CppObjectShadow.ToShadow<FontFileStreamShadow>(thisPtr).Callback;
					lastWriteTime = fontFileStream.GetLastWriteTime();
				}
				catch (Exception ex)
				{
					return (int)Result.GetResultFromException(ex);
				}
				return Result.Ok.Code;
			}

			// Token: 0x0200009F RID: 159
			// (Invoke) Token: 0x06000334 RID: 820
			[UnmanagedFunctionPointer(CallingConvention.StdCall)]
			private delegate int ReadFileFragmentDelegate(IntPtr thisPtr, out IntPtr fragmentStart, long fileOffset, long fragmentSize, out IntPtr fragmentContext);

			// Token: 0x020000A0 RID: 160
			// (Invoke) Token: 0x06000338 RID: 824
			[UnmanagedFunctionPointer(CallingConvention.StdCall)]
			private delegate void ReleaseFileFragmentDelegate(IntPtr thisPtr, IntPtr fragmentContext);

			// Token: 0x020000A1 RID: 161
			// (Invoke) Token: 0x0600033C RID: 828
			[UnmanagedFunctionPointer(CallingConvention.StdCall)]
			private delegate int GetFileSizeDelegate(IntPtr thisPtr, out long fileSize);

			// Token: 0x020000A2 RID: 162
			// (Invoke) Token: 0x06000340 RID: 832
			[UnmanagedFunctionPointer(CallingConvention.StdCall)]
			private delegate int GetLastWriteTimeDelegate(IntPtr thisPtr, out long lastWriteTime);
		}
	}
}
