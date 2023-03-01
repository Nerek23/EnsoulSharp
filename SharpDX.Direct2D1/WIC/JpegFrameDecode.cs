using System;
using System.Runtime.InteropServices;
using SharpDX.DXGI;
using SharpDX.Mathematics.Interop;

namespace SharpDX.WIC
{
	// Token: 0x0200006F RID: 111
	[Guid("8939F66E-C46A-4c21-A9D1-98B327CE1679")]
	public class JpegFrameDecode : ComObject
	{
		// Token: 0x06000235 RID: 565 RVA: 0x00002A7F File Offset: 0x00000C7F
		public JpegFrameDecode(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000236 RID: 566 RVA: 0x0000922E File Offset: 0x0000742E
		public new static explicit operator JpegFrameDecode(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new JpegFrameDecode(nativePtr);
			}
			return null;
		}

		// Token: 0x17000060 RID: 96
		// (get) Token: 0x06000237 RID: 567 RVA: 0x00009248 File Offset: 0x00007448
		public JpegFrameHeader FrameHeader
		{
			get
			{
				JpegFrameHeader result;
				this.GetFrameHeader(out result);
				return result;
			}
		}

		// Token: 0x06000238 RID: 568 RVA: 0x00009260 File Offset: 0x00007460
		public unsafe void DoesSupportIndexing(out RawBool fIndexingSupportedRef)
		{
			fIndexingSupportedRef = default(RawBool);
			Result result;
			fixed (RawBool* ptr = &fIndexingSupportedRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x06000239 RID: 569 RVA: 0x000092A8 File Offset: 0x000074A8
		public unsafe void SetIndexing(JpegIndexingOptions options, int horizontalIntervalSize)
		{
			calli(System.Int32(System.Void*,System.Int32,System.Int32), this._nativePointer, options, horizontalIntervalSize, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x0600023A RID: 570 RVA: 0x000092E4 File Offset: 0x000074E4
		public unsafe void ClearIndexing()
		{
			calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x0600023B RID: 571 RVA: 0x0000931C File Offset: 0x0000751C
		public unsafe void GetAcHuffmanTable(int scanIndex, int tableIndex, out JpegAcHuffmanTable acHuffmanTableRef)
		{
			JpegAcHuffmanTable.__Native _Native = default(JpegAcHuffmanTable.__Native);
			acHuffmanTableRef = default(JpegAcHuffmanTable);
			Result result = calli(System.Int32(System.Void*,System.Int32,System.Int32,System.Void*), this._nativePointer, scanIndex, tableIndex, &_Native, *(*(IntPtr*)this._nativePointer + (IntPtr)6 * (IntPtr)sizeof(void*)));
			acHuffmanTableRef.__MarshalFrom(ref _Native);
			result.CheckError();
		}

		// Token: 0x0600023C RID: 572 RVA: 0x00009370 File Offset: 0x00007570
		public unsafe void GetDcHuffmanTable(int scanIndex, int tableIndex, out JpegDeviceContextHuffmanTable dcHuffmanTableRef)
		{
			JpegDeviceContextHuffmanTable.__Native _Native = default(JpegDeviceContextHuffmanTable.__Native);
			dcHuffmanTableRef = default(JpegDeviceContextHuffmanTable);
			Result result = calli(System.Int32(System.Void*,System.Int32,System.Int32,System.Void*), this._nativePointer, scanIndex, tableIndex, &_Native, *(*(IntPtr*)this._nativePointer + (IntPtr)7 * (IntPtr)sizeof(void*)));
			dcHuffmanTableRef.__MarshalFrom(ref _Native);
			result.CheckError();
		}

		// Token: 0x0600023D RID: 573 RVA: 0x000093C4 File Offset: 0x000075C4
		public unsafe void GetQuantizationTable(int scanIndex, int tableIndex, out JpegQuantizationTable quantizationTableRef)
		{
			JpegQuantizationTable.__Native _Native = default(JpegQuantizationTable.__Native);
			quantizationTableRef = default(JpegQuantizationTable);
			Result result = calli(System.Int32(System.Void*,System.Int32,System.Int32,System.Void*), this._nativePointer, scanIndex, tableIndex, &_Native, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*)));
			quantizationTableRef.__MarshalFrom(ref _Native);
			result.CheckError();
		}

		// Token: 0x0600023E RID: 574 RVA: 0x00009418 File Offset: 0x00007618
		internal unsafe void GetFrameHeader(out JpegFrameHeader frameHeaderRef)
		{
			frameHeaderRef = default(JpegFrameHeader);
			Result result;
			fixed (JpegFrameHeader* ptr = &frameHeaderRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)9 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x0600023F RID: 575 RVA: 0x00009460 File Offset: 0x00007660
		public unsafe void GetScanHeader(int scanIndex, out JpegScanHeader scanHeaderRef)
		{
			scanHeaderRef = default(JpegScanHeader);
			Result result;
			fixed (JpegScanHeader* ptr = &scanHeaderRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Int32,System.Void*), this._nativePointer, scanIndex, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)10 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x06000240 RID: 576 RVA: 0x000094AC File Offset: 0x000076AC
		public unsafe void CopyScan(int scanIndex, int scanOffset, int scanData, byte[] scanDataRef, out int scanDataActualRef)
		{
			Result result;
			fixed (int* ptr = &scanDataActualRef)
			{
				void* ptr2 = (void*)ptr;
				fixed (byte[] array = scanDataRef)
				{
					void* ptr3;
					if (scanDataRef == null || array.Length == 0)
					{
						ptr3 = null;
					}
					else
					{
						ptr3 = (void*)(&array[0]);
					}
					result = calli(System.Int32(System.Void*,System.Int32,System.Int32,System.Int32,System.Void*,System.Void*), this._nativePointer, scanIndex, scanOffset, scanData, ptr3, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)11 * (IntPtr)sizeof(void*)));
				}
			}
			result.CheckError();
		}

		// Token: 0x06000241 RID: 577 RVA: 0x00009514 File Offset: 0x00007714
		public unsafe void CopyMinimalStream(int streamOffset, int streamData, byte[] streamDataRef, out int streamDataActualRef)
		{
			Result result;
			fixed (int* ptr = &streamDataActualRef)
			{
				void* ptr2 = (void*)ptr;
				fixed (byte[] array = streamDataRef)
				{
					void* ptr3;
					if (streamDataRef == null || array.Length == 0)
					{
						ptr3 = null;
					}
					else
					{
						ptr3 = (void*)(&array[0]);
					}
					result = calli(System.Int32(System.Void*,System.Int32,System.Int32,System.Void*,System.Void*), this._nativePointer, streamOffset, streamData, ptr3, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)12 * (IntPtr)sizeof(void*)));
				}
			}
			result.CheckError();
		}
	}
}
