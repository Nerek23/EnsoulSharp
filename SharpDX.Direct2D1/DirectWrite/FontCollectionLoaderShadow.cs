using System;
using System.Runtime.InteropServices;

namespace SharpDX.DirectWrite
{
	// Token: 0x0200008B RID: 139
	internal class FontCollectionLoaderShadow : ComObjectShadow
	{
		// Token: 0x060002C6 RID: 710 RVA: 0x0000B370 File Offset: 0x00009570
		public static IntPtr ToIntPtr(FontCollectionLoader loader)
		{
			return CppObject.ToCallbackPtr<FontCollectionLoader>(loader);
		}

		// Token: 0x060002C7 RID: 711 RVA: 0x0000B378 File Offset: 0x00009578
		public static void SetFactory(FontCollectionLoader loader, Factory factory)
		{
			CppObjectShadow.ToShadow<FontCollectionLoaderShadow>(FontCollectionLoaderShadow.ToIntPtr(loader))._factory = factory;
		}

		// Token: 0x1700006F RID: 111
		// (get) Token: 0x060002C8 RID: 712 RVA: 0x0000B38B File Offset: 0x0000958B
		protected override CppObjectVtbl GetVtbl
		{
			get
			{
				return FontCollectionLoaderShadow.Vtbl;
			}
		}

		// Token: 0x0400020F RID: 527
		private static readonly FontCollectionLoaderShadow.FontCollectionLoaderVtbl Vtbl = new FontCollectionLoaderShadow.FontCollectionLoaderVtbl();

		// Token: 0x04000210 RID: 528
		private Factory _factory;

		// Token: 0x0200008C RID: 140
		private class FontCollectionLoaderVtbl : ComObjectShadow.ComObjectVtbl
		{
			// Token: 0x060002CB RID: 715 RVA: 0x0000B3A6 File Offset: 0x000095A6
			public FontCollectionLoaderVtbl() : base(1)
			{
				base.AddMethod(new FontCollectionLoaderShadow.FontCollectionLoaderVtbl.CreateEnumeratorFromKeyDelegate(FontCollectionLoaderShadow.FontCollectionLoaderVtbl.CreateEnumeratorFromKeyImpl));
			}

			// Token: 0x060002CC RID: 716 RVA: 0x0000B3C4 File Offset: 0x000095C4
			private static int CreateEnumeratorFromKeyImpl(IntPtr thisPtr, IntPtr factory, IntPtr collectionKey, int collectionKeySize, out IntPtr fontFileEnumerator)
			{
				fontFileEnumerator = IntPtr.Zero;
				try
				{
					FontCollectionLoaderShadow fontCollectionLoaderShadow = CppObjectShadow.ToShadow<FontCollectionLoaderShadow>(thisPtr);
					FontFileEnumerator callback = ((FontCollectionLoader)fontCollectionLoaderShadow.Callback).CreateEnumeratorFromKey(fontCollectionLoaderShadow._factory, new DataPointer(collectionKey, collectionKeySize));
					fontFileEnumerator = FontFileEnumeratorShadow.ToIntPtr(callback);
				}
				catch (Exception ex)
				{
					return (int)Result.GetResultFromException(ex);
				}
				return Result.Ok.Code;
			}

			// Token: 0x0200008D RID: 141
			// (Invoke) Token: 0x060002CE RID: 718
			[UnmanagedFunctionPointer(CallingConvention.StdCall)]
			private delegate int CreateEnumeratorFromKeyDelegate(IntPtr thisPtr, IntPtr factory, IntPtr collectionKey, int collectionKeySize, out IntPtr fontFileEnumerator);
		}
	}
}
