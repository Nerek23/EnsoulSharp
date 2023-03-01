using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SharpDX.WIC
{
	// Token: 0x02000012 RID: 18
	[Guid("3C613A02-34B2-44ea-9A7C-45AEA9C6FD6D")]
	public class ColorContext : ComObject
	{
		// Token: 0x060000EE RID: 238 RVA: 0x000048DB File Offset: 0x00002ADB
		public ColorContext(ImagingFactory factory) : base(IntPtr.Zero)
		{
			factory.CreateColorContext(this);
		}

		// Token: 0x060000EF RID: 239 RVA: 0x000048EF File Offset: 0x00002AEF
		public void InitializeFromMemory(DataPointer dataPointer)
		{
			this.InitializeFromMemory(dataPointer.Pointer, dataPointer.Size);
		}

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x060000F0 RID: 240 RVA: 0x00004904 File Offset: 0x00002B04
		public DataStream Profile
		{
			get
			{
				int num;
				this.GetProfileBytes(0, IntPtr.Zero, out num);
				if (num == 0)
				{
					return null;
				}
				DataStream dataStream = new DataStream(num, true, true);
				this.GetProfileBytes(num, dataStream.DataPointer, out num);
				return dataStream;
			}
		}

		// Token: 0x060000F1 RID: 241 RVA: 0x00002A7F File Offset: 0x00000C7F
		public ColorContext(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060000F2 RID: 242 RVA: 0x0000493D File Offset: 0x00002B3D
		public new static explicit operator ColorContext(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new ColorContext(nativePtr);
			}
			return null;
		}

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x060000F3 RID: 243 RVA: 0x00004954 File Offset: 0x00002B54
		public ColorContextType TypeInfo
		{
			get
			{
				ColorContextType result;
				this.GetTypeInfo(out result);
				return result;
			}
		}

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x060000F4 RID: 244 RVA: 0x0000496C File Offset: 0x00002B6C
		public int ExifColorSpace
		{
			get
			{
				int result;
				this.GetExifColorSpace(out result);
				return result;
			}
		}

		// Token: 0x060000F5 RID: 245 RVA: 0x00004984 File Offset: 0x00002B84
		public unsafe void InitializeFromFilename(string filename)
		{
			Result result;
			fixed (string text = filename)
			{
				char* ptr = text;
				if (ptr != null)
				{
					ptr += RuntimeHelpers.OffsetToStringData / 2;
				}
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x060000F6 RID: 246 RVA: 0x000049D0 File Offset: 0x00002BD0
		internal unsafe void InitializeFromMemory(IntPtr bufferRef, int bufferSize)
		{
			calli(System.Int32(System.Void*,System.Void*,System.Int32), this._nativePointer, (void*)bufferRef, bufferSize, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060000F7 RID: 247 RVA: 0x00004A10 File Offset: 0x00002C10
		public unsafe void InitializeFromExifColorSpace(int value)
		{
			calli(System.Int32(System.Void*,System.Int32), this._nativePointer, value, *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060000F8 RID: 248 RVA: 0x00004A48 File Offset: 0x00002C48
		internal unsafe void GetTypeInfo(out ColorContextType typeRef)
		{
			Result result;
			fixed (ColorContextType* ptr = &typeRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)6 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x060000F9 RID: 249 RVA: 0x00004A88 File Offset: 0x00002C88
		internal unsafe void GetProfileBytes(int buffer, IntPtr bufferRef, out int actualRef)
		{
			Result result;
			fixed (int* ptr = &actualRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Void*), this._nativePointer, buffer, (void*)bufferRef, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)7 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x060000FA RID: 250 RVA: 0x00004AD0 File Offset: 0x00002CD0
		internal unsafe void GetExifColorSpace(out int valueRef)
		{
			Result result;
			fixed (int* ptr = &valueRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}
	}
}
