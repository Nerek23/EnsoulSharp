using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;
using SharpDX.Win32;

namespace SharpDX.Direct2D1
{
	// Token: 0x02000232 RID: 562
	[Guid("86b88e4d-afa4-4d7b-88e4-68a51c4a0aec")]
	public class SvgDocument : Resource
	{
		// Token: 0x06000CBF RID: 3263 RVA: 0x00023484 File Offset: 0x00021684
		public SvgElement FindElementById(string id)
		{
			SvgElement result;
			this.TryFindElementById_(id, out result).CheckError();
			return result;
		}

		// Token: 0x06000CC0 RID: 3264 RVA: 0x00016258 File Offset: 0x00014458
		public SvgDocument(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000CC1 RID: 3265 RVA: 0x000234A3 File Offset: 0x000216A3
		public new static explicit operator SvgDocument(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new SvgDocument(nativePtr);
			}
			return null;
		}

		// Token: 0x170001B3 RID: 435
		// (get) Token: 0x06000CC2 RID: 3266 RVA: 0x000234BA File Offset: 0x000216BA
		// (set) Token: 0x06000CC3 RID: 3267 RVA: 0x000234C2 File Offset: 0x000216C2
		public Size2F ViewportSize
		{
			get
			{
				return this.GetViewportSize();
			}
			set
			{
				this.SetViewportSize(value);
			}
		}

		// Token: 0x170001B4 RID: 436
		// (get) Token: 0x06000CC4 RID: 3268 RVA: 0x000234CC File Offset: 0x000216CC
		// (set) Token: 0x06000CC5 RID: 3269 RVA: 0x000234E2 File Offset: 0x000216E2
		public SvgElement Root
		{
			get
			{
				SvgElement result;
				this.GetRoot(out result);
				return result;
			}
			set
			{
				this.SetRoot(value);
			}
		}

		// Token: 0x06000CC6 RID: 3270 RVA: 0x000234EC File Offset: 0x000216EC
		internal unsafe void SetViewportSize(Size2F viewportSize)
		{
			calli(System.Int32(System.Void*,SharpDX.Size2F), this._nativePointer, viewportSize, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000CC7 RID: 3271 RVA: 0x00023524 File Offset: 0x00021724
		internal unsafe Size2F GetViewportSize()
		{
			Size2F result;
			object obj = calli(System.Void*(System.Void*,System.Void*), this._nativePointer, &result, *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*)));
			return result;
		}

		// Token: 0x06000CC8 RID: 3272 RVA: 0x00023554 File Offset: 0x00021754
		internal unsafe void SetRoot(SvgElement root)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<SvgElement>(root);
			calli(System.Int32(System.Void*,System.Void*), this._nativePointer, (void*)value, *(*(IntPtr*)this._nativePointer + (IntPtr)6 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000CC9 RID: 3273 RVA: 0x000235A0 File Offset: 0x000217A0
		internal unsafe void GetRoot(out SvgElement root)
		{
			IntPtr zero = IntPtr.Zero;
			calli(System.Void(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)7 * (IntPtr)sizeof(void*)));
			if (zero != IntPtr.Zero)
			{
				root = new SvgElement(zero);
				return;
			}
			root = null;
		}

		// Token: 0x06000CCA RID: 3274 RVA: 0x000235EC File Offset: 0x000217EC
		private unsafe Result TryFindElementById_(string id, out SvgElement svgElement)
		{
			IntPtr zero = IntPtr.Zero;
			Result result;
			fixed (string text = id)
			{
				char* ptr = text;
				if (ptr != null)
				{
					ptr += RuntimeHelpers.OffsetToStringData / 2;
				}
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, ptr, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*)));
			}
			if (zero != IntPtr.Zero)
			{
				svgElement = new SvgElement(zero);
				return result;
			}
			svgElement = null;
			return result;
		}

		// Token: 0x06000CCB RID: 3275 RVA: 0x00023650 File Offset: 0x00021850
		public unsafe void Serialize(IStream outputXmlStream, SvgElement subtree)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr value2 = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<IStream>(outputXmlStream);
			value2 = CppObject.ToCallbackPtr<SvgElement>(subtree);
			calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)value, (void*)value2, *(*(IntPtr*)this._nativePointer + (IntPtr)9 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000CCC RID: 3276 RVA: 0x000236B0 File Offset: 0x000218B0
		public unsafe void Deserialize(IStream inputXmlStream, out SvgElement subtree)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr zero = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<IStream>(inputXmlStream);
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)value, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)10 * (IntPtr)sizeof(void*)));
			if (zero != IntPtr.Zero)
			{
				subtree = new SvgElement(zero);
			}
			else
			{
				subtree = null;
			}
			result.CheckError();
		}

		// Token: 0x06000CCD RID: 3277 RVA: 0x00023720 File Offset: 0x00021920
		public unsafe void CreatePaint(SvgPaintType paintType, RawColor4? color, string id, out SvgPaint aintRef)
		{
			IntPtr zero = IntPtr.Zero;
			RawColor4 value;
			if (color != null)
			{
				value = color.Value;
			}
			Result result;
			fixed (string text = id)
			{
				char* ptr = text;
				if (ptr != null)
				{
					ptr += RuntimeHelpers.OffsetToStringData / 2;
				}
				result = calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Void*,System.Void*), this._nativePointer, paintType, (color == null) ? null : (&value), ptr, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)11 * (IntPtr)sizeof(void*)));
			}
			if (zero != IntPtr.Zero)
			{
				aintRef = new SvgPaint(zero);
			}
			else
			{
				aintRef = null;
			}
			result.CheckError();
		}

		// Token: 0x06000CCE RID: 3278 RVA: 0x000237B8 File Offset: 0x000219B8
		public unsafe void CreateStrokeDashArray(SvgLength[] dashes, int dashesCount, out SvgStrokeDashArray strokeDashArray)
		{
			IntPtr zero = IntPtr.Zero;
			Result result;
			fixed (SvgLength[] array = dashes)
			{
				void* ptr;
				if (dashes == null || array.Length == 0)
				{
					ptr = null;
				}
				else
				{
					ptr = (void*)(&array[0]);
				}
				result = calli(System.Int32(System.Void*,System.Void*,System.Int32,System.Void*), this._nativePointer, ptr, dashesCount, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)12 * (IntPtr)sizeof(void*)));
			}
			if (zero != IntPtr.Zero)
			{
				strokeDashArray = new SvgStrokeDashArray(zero);
			}
			else
			{
				strokeDashArray = null;
			}
			result.CheckError();
		}

		// Token: 0x06000CCF RID: 3279 RVA: 0x00023830 File Offset: 0x00021A30
		public unsafe void CreatePointCollection(RawVector2[] ointsRef, int pointsCount, out SvgPointCollection ointCollectionRef)
		{
			IntPtr zero = IntPtr.Zero;
			Result result;
			fixed (RawVector2[] array = ointsRef)
			{
				void* ptr;
				if (ointsRef == null || array.Length == 0)
				{
					ptr = null;
				}
				else
				{
					ptr = (void*)(&array[0]);
				}
				result = calli(System.Int32(System.Void*,System.Void*,System.Int32,System.Void*), this._nativePointer, ptr, pointsCount, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)13 * (IntPtr)sizeof(void*)));
			}
			if (zero != IntPtr.Zero)
			{
				ointCollectionRef = new SvgPointCollection(zero);
			}
			else
			{
				ointCollectionRef = null;
			}
			result.CheckError();
		}

		// Token: 0x06000CD0 RID: 3280 RVA: 0x000238A8 File Offset: 0x00021AA8
		public unsafe void CreatePathData(float[] segmentData, int segmentDataCount, SvgPathCommand[] commands, int commandsCount, out SvgPathData athDataRef)
		{
			IntPtr zero = IntPtr.Zero;
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
				fixed (float[] array2 = segmentData)
				{
					void* ptr2;
					if (segmentData == null || array2.Length == 0)
					{
						ptr2 = null;
					}
					else
					{
						ptr2 = (void*)(&array2[0]);
					}
					result = calli(System.Int32(System.Void*,System.Void*,System.Int32,System.Void*,System.Int32,System.Void*), this._nativePointer, ptr2, segmentDataCount, ptr, commandsCount, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)14 * (IntPtr)sizeof(void*)));
				}
			}
			if (zero != IntPtr.Zero)
			{
				athDataRef = new SvgPathData(zero);
			}
			else
			{
				athDataRef = null;
			}
			result.CheckError();
		}
	}
}
