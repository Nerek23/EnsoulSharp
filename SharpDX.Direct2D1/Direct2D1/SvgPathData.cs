using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct2D1
{
	// Token: 0x02000312 RID: 786
	[Guid("c095e4f4-bb98-43d6-9745-4d1b84ec9888")]
	public class SvgPathData : SvgAttribute
	{
		// Token: 0x06000DDF RID: 3551 RVA: 0x0002627D File Offset: 0x0002447D
		public SvgPathData(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000DE0 RID: 3552 RVA: 0x00026453 File Offset: 0x00024653
		public new static explicit operator SvgPathData(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new SvgPathData(nativePtr);
			}
			return null;
		}

		// Token: 0x170001D9 RID: 473
		// (get) Token: 0x06000DE1 RID: 3553 RVA: 0x0002646A File Offset: 0x0002466A
		public int SegmentDataCount
		{
			get
			{
				return this.GetSegmentDataCount();
			}
		}

		// Token: 0x170001DA RID: 474
		// (get) Token: 0x06000DE2 RID: 3554 RVA: 0x00026472 File Offset: 0x00024672
		public int CommandsCount
		{
			get
			{
				return this.GetCommandsCount();
			}
		}

		// Token: 0x06000DE3 RID: 3555 RVA: 0x0002647C File Offset: 0x0002467C
		public unsafe void RemoveSegmentDataAtEnd(int dataCount)
		{
			calli(System.Int32(System.Void*,System.Int32), this._nativePointer, dataCount, *(*(IntPtr*)this._nativePointer + (IntPtr)6 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000DE4 RID: 3556 RVA: 0x000264B4 File Offset: 0x000246B4
		public unsafe void UpdateSegmentData(float[] data, int dataCount, int startIndex)
		{
			Result result;
			fixed (float[] array = data)
			{
				void* ptr;
				if (data == null || array.Length == 0)
				{
					ptr = null;
				}
				else
				{
					ptr = (void*)(&array[0]);
				}
				result = calli(System.Int32(System.Void*,System.Void*,System.Int32,System.Int32), this._nativePointer, ptr, dataCount, startIndex, *(*(IntPtr*)this._nativePointer + (IntPtr)7 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x06000DE5 RID: 3557 RVA: 0x00026508 File Offset: 0x00024708
		public unsafe void GetSegmentData(float[] data, int dataCount, int startIndex)
		{
			Result result;
			fixed (float[] array = data)
			{
				void* ptr;
				if (data == null || array.Length == 0)
				{
					ptr = null;
				}
				else
				{
					ptr = (void*)(&array[0]);
				}
				result = calli(System.Int32(System.Void*,System.Void*,System.Int32,System.Int32), this._nativePointer, ptr, dataCount, startIndex, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x06000DE6 RID: 3558 RVA: 0x0002655C File Offset: 0x0002475C
		internal unsafe int GetSegmentDataCount()
		{
			return calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)9 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000DE7 RID: 3559 RVA: 0x0002657C File Offset: 0x0002477C
		public unsafe void RemoveCommandsAtEnd(int commandsCount)
		{
			calli(System.Int32(System.Void*,System.Int32), this._nativePointer, commandsCount, *(*(IntPtr*)this._nativePointer + (IntPtr)10 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000DE8 RID: 3560 RVA: 0x000265B8 File Offset: 0x000247B8
		public unsafe void UpdateCommands(SvgPathCommand[] commands, int commandsCount, int startIndex)
		{
			Result result;
			fixed (SvgPathCommand[] array = commands)
			{
				void* ptr;
				if (commands == null || array.Length == 0)
				{
					ptr = null;
				}
				else
				{
					ptr = (void*)(&array[0]);
				}
				result = calli(System.Int32(System.Void*,System.Void*,System.Int32,System.Int32), this._nativePointer, ptr, commandsCount, startIndex, *(*(IntPtr*)this._nativePointer + (IntPtr)11 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x06000DE9 RID: 3561 RVA: 0x00026610 File Offset: 0x00024810
		public unsafe void GetCommands(SvgPathCommand[] commands, int commandsCount, int startIndex)
		{
			Result result;
			fixed (SvgPathCommand[] array = commands)
			{
				void* ptr;
				if (commands == null || array.Length == 0)
				{
					ptr = null;
				}
				else
				{
					ptr = (void*)(&array[0]);
				}
				result = calli(System.Int32(System.Void*,System.Void*,System.Int32,System.Int32), this._nativePointer, ptr, commandsCount, startIndex, *(*(IntPtr*)this._nativePointer + (IntPtr)12 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x06000DEA RID: 3562 RVA: 0x00026665 File Offset: 0x00024865
		internal unsafe int GetCommandsCount()
		{
			return calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)13 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000DEB RID: 3563 RVA: 0x00026688 File Offset: 0x00024888
		public unsafe void CreatePathGeometry(FillMode fillMode, out PathGeometry1 athGeometryRef)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Int32,System.Void*), this._nativePointer, fillMode, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)14 * (IntPtr)sizeof(void*)));
			if (zero != IntPtr.Zero)
			{
				athGeometryRef = new PathGeometry1(zero);
			}
			else
			{
				athGeometryRef = null;
			}
			result.CheckError();
		}
	}
}
