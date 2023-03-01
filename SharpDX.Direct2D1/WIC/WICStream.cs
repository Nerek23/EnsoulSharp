using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using SharpDX.IO;
using SharpDX.Win32;

namespace SharpDX.WIC
{
	// Token: 0x0200002E RID: 46
	[Guid("135FF860-22B7-4ddf-B0F6-218F4F299A43")]
	public class WICStream : ComStream
	{
		// Token: 0x060001C5 RID: 453 RVA: 0x0000785D File Offset: 0x00005A5D
		public WICStream(ImagingFactory factory, string fileName, NativeFileAccess fileAccess) : base(IntPtr.Zero)
		{
			factory.CreateStream(this);
			this.InitializeFromFilename(fileName, (int)fileAccess);
		}

		// Token: 0x060001C6 RID: 454 RVA: 0x00007879 File Offset: 0x00005A79
		public WICStream(ImagingFactory factory, Stream stream) : base(IntPtr.Zero)
		{
			factory.CreateStream(this);
			this.streamProxy = new ComStreamProxy(stream);
			this.InitializeFromIStream(this.streamProxy);
		}

		// Token: 0x060001C7 RID: 455 RVA: 0x000078A5 File Offset: 0x00005AA5
		public WICStream(ImagingFactory factory, DataPointer dataStream) : base(IntPtr.Zero)
		{
			factory.CreateStream(this);
			this.InitializeFromMemory(dataStream.Pointer, dataStream.Size);
		}

		// Token: 0x060001C8 RID: 456 RVA: 0x000078CB File Offset: 0x00005ACB
		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
			if (this.streamProxy != null)
			{
				this.streamProxy.Dispose();
				this.streamProxy = null;
			}
		}

		// Token: 0x060001C9 RID: 457 RVA: 0x000078EE File Offset: 0x00005AEE
		public WICStream(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060001CA RID: 458 RVA: 0x000078F7 File Offset: 0x00005AF7
		public new static explicit operator WICStream(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new WICStream(nativePtr);
			}
			return null;
		}

		// Token: 0x060001CB RID: 459 RVA: 0x00007910 File Offset: 0x00005B10
		internal unsafe void InitializeFromIStream(IStream streamRef)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<IStream>(streamRef);
			calli(System.Int32(System.Void*,System.Void*), this._nativePointer, (void*)value, *(*(IntPtr*)this._nativePointer + (IntPtr)14 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060001CC RID: 460 RVA: 0x0000795C File Offset: 0x00005B5C
		internal unsafe void InitializeFromFilename(string fileName, int desiredAccess)
		{
			Result result;
			fixed (string text = fileName)
			{
				char* ptr = text;
				if (ptr != null)
				{
					ptr += RuntimeHelpers.OffsetToStringData / 2;
				}
				result = calli(System.Int32(System.Void*,System.Void*,System.Int32), this._nativePointer, ptr, desiredAccess, *(*(IntPtr*)this._nativePointer + (IntPtr)15 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x060001CD RID: 461 RVA: 0x000079A8 File Offset: 0x00005BA8
		internal unsafe void InitializeFromMemory(IntPtr bufferRef, int bufferSize)
		{
			calli(System.Int32(System.Void*,System.Void*,System.Int32), this._nativePointer, (void*)bufferRef, bufferSize, *(*(IntPtr*)this._nativePointer + (IntPtr)16 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060001CE RID: 462 RVA: 0x000079E8 File Offset: 0x00005BE8
		internal unsafe void InitializeFromIStreamRegion(IStream streamRef, long ulOffset, long ulMaxSize)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<IStream>(streamRef);
			calli(System.Int32(System.Void*,System.Void*,System.Int64,System.Int64), this._nativePointer, (void*)value, ulOffset, ulMaxSize, *(*(IntPtr*)this._nativePointer + (IntPtr)17 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x04000078 RID: 120
		private ComStreamProxy streamProxy;
	}
}
