using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.DXGI
{
	// Token: 0x0200001E RID: 30
	[Guid("191cfac3-a341-470d-b26e-a864f428319c")]
	public class OutputDuplication : DXGIObject
	{
		// Token: 0x060000D3 RID: 211 RVA: 0x000046E0 File Offset: 0x000028E0
		public DataRectangle MapDesktopSurface()
		{
			MappedRectangle mappedRectangle;
			this.MapDesktopSurface(out mappedRectangle);
			return new DataRectangle(mappedRectangle.PBits, mappedRectangle.Pitch);
		}

		// Token: 0x060000D4 RID: 212 RVA: 0x00004708 File Offset: 0x00002908
		public void AcquireNextFrame(int timeoutInMilliseconds, out OutputDuplicateFrameInformation frameInfoRef, out Resource desktopResourceOut)
		{
			this.TryAcquireNextFrame(timeoutInMilliseconds, out frameInfoRef, out desktopResourceOut).CheckError();
		}

		// Token: 0x060000D5 RID: 213 RVA: 0x00002165 File Offset: 0x00000365
		public OutputDuplication(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060000D6 RID: 214 RVA: 0x00004726 File Offset: 0x00002926
		public new static explicit operator OutputDuplication(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new OutputDuplication(nativePtr);
			}
			return null;
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x060000D7 RID: 215 RVA: 0x00004740 File Offset: 0x00002940
		public OutputDuplicateDescription Description
		{
			get
			{
				OutputDuplicateDescription result;
				this.GetDescription(out result);
				return result;
			}
		}

		// Token: 0x060000D8 RID: 216 RVA: 0x00004758 File Offset: 0x00002958
		internal unsafe void GetDescription(out OutputDuplicateDescription descRef)
		{
			descRef = default(OutputDuplicateDescription);
			fixed (OutputDuplicateDescription* ptr = &descRef)
			{
				void* ptr2 = (void*)ptr;
				calli(System.Void(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)7 * (IntPtr)sizeof(void*)));
			}
		}

		// Token: 0x060000D9 RID: 217 RVA: 0x00004794 File Offset: 0x00002994
		public unsafe Result TryAcquireNextFrame(int timeoutInMilliseconds, out OutputDuplicateFrameInformation frameInfoRef, out Resource desktopResourceOut)
		{
			frameInfoRef = default(OutputDuplicateFrameInformation);
			IntPtr zero = IntPtr.Zero;
			Result result;
			fixed (OutputDuplicateFrameInformation* ptr = &frameInfoRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Void*), this._nativePointer, timeoutInMilliseconds, ptr2, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*)));
			}
			if (zero != IntPtr.Zero)
			{
				desktopResourceOut = new Resource(zero);
				return result;
			}
			desktopResourceOut = null;
			return result;
		}

		// Token: 0x060000DA RID: 218 RVA: 0x000047F8 File Offset: 0x000029F8
		public unsafe void GetFrameDirtyRects(int dirtyRectsBufferSize, RawRectangle[] dirtyRectsBufferRef, out int dirtyRectsBufferSizeRequiredRef)
		{
			Result result;
			fixed (int* ptr = &dirtyRectsBufferSizeRequiredRef)
			{
				void* ptr2 = (void*)ptr;
				fixed (RawRectangle[] array = dirtyRectsBufferRef)
				{
					void* ptr3;
					if (dirtyRectsBufferRef == null || array.Length == 0)
					{
						ptr3 = null;
					}
					else
					{
						ptr3 = (void*)(&array[0]);
					}
					result = calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Void*), this._nativePointer, dirtyRectsBufferSize, ptr3, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)9 * (IntPtr)sizeof(void*)));
				}
			}
			result.CheckError();
		}

		// Token: 0x060000DB RID: 219 RVA: 0x0000485C File Offset: 0x00002A5C
		public unsafe void GetFrameMoveRects(int moveRectsBufferSize, OutputDuplicateMoveRectangle[] moveRectBufferRef, out int moveRectsBufferSizeRequiredRef)
		{
			Result result;
			fixed (int* ptr = &moveRectsBufferSizeRequiredRef)
			{
				void* ptr2 = (void*)ptr;
				fixed (OutputDuplicateMoveRectangle[] array = moveRectBufferRef)
				{
					void* ptr3;
					if (moveRectBufferRef == null || array.Length == 0)
					{
						ptr3 = null;
					}
					else
					{
						ptr3 = (void*)(&array[0]);
					}
					result = calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Void*), this._nativePointer, moveRectsBufferSize, ptr3, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)10 * (IntPtr)sizeof(void*)));
				}
			}
			result.CheckError();
		}

		// Token: 0x060000DC RID: 220 RVA: 0x000048C0 File Offset: 0x00002AC0
		public unsafe void GetFramePointerShape(int pointerShapeBufferSize, IntPtr pointerShapeBufferRef, out int pointerShapeBufferSizeRequiredRef, out OutputDuplicatePointerShapeInformation pointerShapeInfoRef)
		{
			pointerShapeInfoRef = default(OutputDuplicatePointerShapeInformation);
			Result result;
			fixed (OutputDuplicatePointerShapeInformation* ptr = &pointerShapeInfoRef)
			{
				void* ptr2 = (void*)ptr;
				fixed (int* ptr3 = &pointerShapeBufferSizeRequiredRef)
				{
					void* ptr4 = (void*)ptr3;
					result = calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Void*,System.Void*), this._nativePointer, pointerShapeBufferSize, (void*)pointerShapeBufferRef, ptr4, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)11 * (IntPtr)sizeof(void*)));
				}
			}
			result.CheckError();
		}

		// Token: 0x060000DD RID: 221 RVA: 0x00004920 File Offset: 0x00002B20
		internal unsafe void MapDesktopSurface(out MappedRectangle lockedRectRef)
		{
			lockedRectRef = default(MappedRectangle);
			Result result;
			fixed (MappedRectangle* ptr = &lockedRectRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)12 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x060000DE RID: 222 RVA: 0x00004968 File Offset: 0x00002B68
		public unsafe void UnMapDesktopSurface()
		{
			calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)13 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060000DF RID: 223 RVA: 0x000049A0 File Offset: 0x00002BA0
		public unsafe void ReleaseFrame()
		{
			calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)14 * (IntPtr)sizeof(void*))).CheckError();
		}
	}
}
