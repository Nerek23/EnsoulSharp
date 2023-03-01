using System;
using System.Runtime.InteropServices;
using SharpDX.DXGI;

namespace SharpDX.WIC
{
	// Token: 0x02000070 RID: 112
	[Guid("2F0C601F-D2C6-468C-ABFA-49495D983ED1")]
	public class JpegFrameEncode : ComObject
	{
		// Token: 0x06000242 RID: 578 RVA: 0x00002A7F File Offset: 0x00000C7F
		public JpegFrameEncode(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000243 RID: 579 RVA: 0x00009577 File Offset: 0x00007777
		public new static explicit operator JpegFrameEncode(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new JpegFrameEncode(nativePtr);
			}
			return null;
		}

		// Token: 0x06000244 RID: 580 RVA: 0x00009590 File Offset: 0x00007790
		public unsafe void GetAcHuffmanTable(int scanIndex, int tableIndex, out JpegAcHuffmanTable acHuffmanTableRef)
		{
			JpegAcHuffmanTable.__Native _Native = default(JpegAcHuffmanTable.__Native);
			acHuffmanTableRef = default(JpegAcHuffmanTable);
			Result result = calli(System.Int32(System.Void*,System.Int32,System.Int32,System.Void*), this._nativePointer, scanIndex, tableIndex, &_Native, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*)));
			acHuffmanTableRef.__MarshalFrom(ref _Native);
			result.CheckError();
		}

		// Token: 0x06000245 RID: 581 RVA: 0x000095E4 File Offset: 0x000077E4
		public unsafe void GetDcHuffmanTable(int scanIndex, int tableIndex, out JpegDeviceContextHuffmanTable dcHuffmanTableRef)
		{
			JpegDeviceContextHuffmanTable.__Native _Native = default(JpegDeviceContextHuffmanTable.__Native);
			dcHuffmanTableRef = default(JpegDeviceContextHuffmanTable);
			Result result = calli(System.Int32(System.Void*,System.Int32,System.Int32,System.Void*), this._nativePointer, scanIndex, tableIndex, &_Native, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*)));
			dcHuffmanTableRef.__MarshalFrom(ref _Native);
			result.CheckError();
		}

		// Token: 0x06000246 RID: 582 RVA: 0x00009638 File Offset: 0x00007838
		public unsafe void GetQuantizationTable(int scanIndex, int tableIndex, out JpegQuantizationTable quantizationTableRef)
		{
			JpegQuantizationTable.__Native _Native = default(JpegQuantizationTable.__Native);
			quantizationTableRef = default(JpegQuantizationTable);
			Result result = calli(System.Int32(System.Void*,System.Int32,System.Int32,System.Void*), this._nativePointer, scanIndex, tableIndex, &_Native, *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*)));
			quantizationTableRef.__MarshalFrom(ref _Native);
			result.CheckError();
		}

		// Token: 0x06000247 RID: 583 RVA: 0x0000968C File Offset: 0x0000788C
		public unsafe void WriteScan(int scanData, byte[] scanDataRef)
		{
			Result result;
			fixed (byte[] array = scanDataRef)
			{
				void* ptr;
				if (scanDataRef == null || array.Length == 0)
				{
					ptr = null;
				}
				else
				{
					ptr = (void*)(&array[0]);
				}
				result = calli(System.Int32(System.Void*,System.Int32,System.Void*), this._nativePointer, scanData, ptr, *(*(IntPtr*)this._nativePointer + (IntPtr)6 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}
	}
}
