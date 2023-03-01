using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct2D1
{
	// Token: 0x02000233 RID: 563
	[Guid("ac7b67a6-183e-49c1-a823-0ebe40b0db29")]
	public class SvgElement : Resource
	{
		// Token: 0x170001B5 RID: 437
		// (get) Token: 0x06000CD1 RID: 3281 RVA: 0x00023948 File Offset: 0x00021B48
		public SvgElement[] Children
		{
			get
			{
				if (!this.HasChildren())
				{
					return new SvgElement[0];
				}
				SvgElement svgElement = this.FirstChild;
				int num = 0;
				SvgElement svgElement2;
				do
				{
					this.GetNextChild(svgElement, out svgElement2);
					svgElement = svgElement2;
					num++;
				}
				while (svgElement2 != null);
				SvgElement[] array = new SvgElement[num];
				svgElement = this.FirstChild;
				for (int i = 0; i < num; i++)
				{
					array[i] = svgElement;
					this.GetNextChild(svgElement, out svgElement);
				}
				return array;
			}
		}

		// Token: 0x170001B6 RID: 438
		// (get) Token: 0x06000CD2 RID: 3282 RVA: 0x000239B4 File Offset: 0x00021BB4
		public unsafe string TagName
		{
			get
			{
				int tagNameLength = this.GetTagNameLength();
				sbyte* value = stackalloc sbyte[(UIntPtr)tagNameLength];
				this.GetTagName(new IntPtr((void*)value), tagNameLength + 1);
				return Marshal.PtrToStringUni((IntPtr)((void*)value), tagNameLength);
			}
		}

		// Token: 0x06000CD3 RID: 3283 RVA: 0x000239E8 File Offset: 0x00021BE8
		public unsafe void SetAttributeValue(string name, float value)
		{
			this.SetAttributeValue(name, SvgAttributePodType.Float, new IntPtr((void*)(&value)), 4);
		}

		// Token: 0x06000CD4 RID: 3284 RVA: 0x000239FC File Offset: 0x00021BFC
		public unsafe void GetAttributeValue(string name, out float value)
		{
			fixed (float* ptr = &value)
			{
				float* value2 = ptr;
				this.GetAttributeValue(name, SvgAttributePodType.Float, new IntPtr((void*)value2), 4);
			}
		}

		// Token: 0x06000CD5 RID: 3285 RVA: 0x00023A20 File Offset: 0x00021C20
		public unsafe void SetAttributeValue(string name, RawColor4 color)
		{
			this.SetAttributeValue(name, SvgAttributePodType.Color, new IntPtr((void*)(&color)), sizeof(RawColor4));
		}

		// Token: 0x06000CD6 RID: 3286 RVA: 0x00023A38 File Offset: 0x00021C38
		public unsafe void GetAttributeValue(string name, out RawColor4 color)
		{
			fixed (RawColor4* ptr = &color)
			{
				RawColor4* value = ptr;
				this.GetAttributeValue(name, SvgAttributePodType.Color, new IntPtr((void*)value), sizeof(RawColor4));
			}
		}

		// Token: 0x06000CD7 RID: 3287 RVA: 0x00023A61 File Offset: 0x00021C61
		public unsafe void SetAttributeValue(string name, FillMode fillMode)
		{
			this.SetAttributeValue(name, SvgAttributePodType.FillMode, new IntPtr((void*)(&fillMode)), 4);
		}

		// Token: 0x06000CD8 RID: 3288 RVA: 0x00023A74 File Offset: 0x00021C74
		public unsafe void GetAttributeValue(string name, out FillMode fillMode)
		{
			fixed (FillMode* ptr = &fillMode)
			{
				FillMode* value = ptr;
				this.GetAttributeValue(name, SvgAttributePodType.FillMode, new IntPtr((void*)value), 4);
			}
		}

		// Token: 0x06000CD9 RID: 3289 RVA: 0x00023A98 File Offset: 0x00021C98
		public unsafe void SetAttributeValue(string name, SvgDisplay display)
		{
			this.SetAttributeValue(name, SvgAttributePodType.Display, new IntPtr((void*)(&display)), 4);
		}

		// Token: 0x06000CDA RID: 3290 RVA: 0x00023AAC File Offset: 0x00021CAC
		public unsafe void GetAttributeValue(string name, out SvgDisplay display)
		{
			fixed (SvgDisplay* ptr = &display)
			{
				SvgDisplay* value = ptr;
				this.GetAttributeValue(name, SvgAttributePodType.Display, new IntPtr((void*)value), 4);
			}
		}

		// Token: 0x06000CDB RID: 3291 RVA: 0x00023AD0 File Offset: 0x00021CD0
		public unsafe void SetAttributeValue(string name, SvgOverflow overflow)
		{
			this.SetAttributeValue(name, SvgAttributePodType.Overflow, new IntPtr((void*)(&overflow)), 4);
		}

		// Token: 0x06000CDC RID: 3292 RVA: 0x00023AE4 File Offset: 0x00021CE4
		public unsafe void GetAttributeValue(string name, out SvgOverflow overflow)
		{
			fixed (SvgOverflow* ptr = &overflow)
			{
				SvgOverflow* value = ptr;
				this.GetAttributeValue(name, SvgAttributePodType.Overflow, new IntPtr((void*)value), 4);
			}
		}

		// Token: 0x06000CDD RID: 3293 RVA: 0x00023B08 File Offset: 0x00021D08
		public unsafe void SetAttributeValue(string name, SvgLineJoin lineJoin)
		{
			this.SetAttributeValue(name, SvgAttributePodType.LineJoin, new IntPtr((void*)(&lineJoin)), 4);
		}

		// Token: 0x06000CDE RID: 3294 RVA: 0x00023B1C File Offset: 0x00021D1C
		public unsafe void GetAttributeValue(string name, out SvgLineJoin lineJoin)
		{
			fixed (SvgLineJoin* ptr = &lineJoin)
			{
				SvgLineJoin* value = ptr;
				this.GetAttributeValue(name, SvgAttributePodType.LineJoin, new IntPtr((void*)value), 4);
			}
		}

		// Token: 0x06000CDF RID: 3295 RVA: 0x00023B40 File Offset: 0x00021D40
		public unsafe void SetAttributeValue(string name, SvgLineCap lineCap)
		{
			this.SetAttributeValue(name, SvgAttributePodType.LineCap, new IntPtr((void*)(&lineCap)), 4);
		}

		// Token: 0x06000CE0 RID: 3296 RVA: 0x00023B54 File Offset: 0x00021D54
		public unsafe void GetAttributeValue(string name, out SvgLineCap lineCap)
		{
			fixed (SvgLineCap* ptr = &lineCap)
			{
				SvgLineCap* value = ptr;
				this.GetAttributeValue(name, SvgAttributePodType.LineCap, new IntPtr((void*)value), 4);
			}
		}

		// Token: 0x06000CE1 RID: 3297 RVA: 0x00023B78 File Offset: 0x00021D78
		public unsafe void SetAttributeValue(string name, SvgVisibility visibility)
		{
			this.SetAttributeValue(name, SvgAttributePodType.Visibility, new IntPtr((void*)(&visibility)), 4);
		}

		// Token: 0x06000CE2 RID: 3298 RVA: 0x00023B8C File Offset: 0x00021D8C
		public unsafe void GetAttributeValue(string name, out SvgVisibility visibility)
		{
			fixed (SvgVisibility* ptr = &visibility)
			{
				SvgVisibility* value = ptr;
				this.GetAttributeValue(name, SvgAttributePodType.Visibility, new IntPtr((void*)value), 4);
			}
		}

		// Token: 0x06000CE3 RID: 3299 RVA: 0x00023BB0 File Offset: 0x00021DB0
		public unsafe void SetAttributeValue(string name, RawMatrix3x2 matrix)
		{
			this.SetAttributeValue(name, SvgAttributePodType.Matrix, new IntPtr((void*)(&matrix)), sizeof(RawMatrix3x2));
		}

		// Token: 0x06000CE4 RID: 3300 RVA: 0x00023BC8 File Offset: 0x00021DC8
		public unsafe void GetAttributeValue(string name, out RawMatrix3x2 matrix)
		{
			fixed (RawMatrix3x2* ptr = &matrix)
			{
				RawMatrix3x2* value = ptr;
				this.GetAttributeValue(name, SvgAttributePodType.Matrix, new IntPtr((void*)value), sizeof(RawMatrix3x2));
			}
		}

		// Token: 0x06000CE5 RID: 3301 RVA: 0x00023BF1 File Offset: 0x00021DF1
		public unsafe void SetAttributeValue(string name, SvgUnitType unitType)
		{
			this.SetAttributeValue(name, SvgAttributePodType.UnitType, new IntPtr((void*)(&unitType)), 4);
		}

		// Token: 0x06000CE6 RID: 3302 RVA: 0x00023C08 File Offset: 0x00021E08
		public unsafe void GetAttributeValue(string name, out SvgUnitType unitType)
		{
			fixed (SvgUnitType* ptr = &unitType)
			{
				SvgUnitType* value = ptr;
				this.GetAttributeValue(name, SvgAttributePodType.UnitType, new IntPtr((void*)value), 4);
			}
		}

		// Token: 0x06000CE7 RID: 3303 RVA: 0x00023C2D File Offset: 0x00021E2D
		public unsafe void SetAttributeValue(string name, ExtendMode extendMode)
		{
			this.SetAttributeValue(name, SvgAttributePodType.ExtendMode, new IntPtr((void*)(&extendMode)), 4);
		}

		// Token: 0x06000CE8 RID: 3304 RVA: 0x00023C44 File Offset: 0x00021E44
		public unsafe void GetAttributeValue(string name, out ExtendMode extendMode)
		{
			fixed (ExtendMode* ptr = &extendMode)
			{
				ExtendMode* value = ptr;
				this.GetAttributeValue(name, SvgAttributePodType.ExtendMode, new IntPtr((void*)value), 4);
			}
		}

		// Token: 0x06000CE9 RID: 3305 RVA: 0x00023C69 File Offset: 0x00021E69
		public unsafe void SetAttributeValue(string name, SvgPreserveAspectRatio preserveAspectRatio)
		{
			this.SetAttributeValue(name, SvgAttributePodType.PreserveAspectRatio, new IntPtr((void*)(&preserveAspectRatio)), sizeof(SvgPreserveAspectRatio));
		}

		// Token: 0x06000CEA RID: 3306 RVA: 0x00023C84 File Offset: 0x00021E84
		public unsafe void GetAttributeValue(string name, out SvgPreserveAspectRatio preserveAspectRatio)
		{
			fixed (SvgPreserveAspectRatio* ptr = &preserveAspectRatio)
			{
				SvgPreserveAspectRatio* value = ptr;
				this.GetAttributeValue(name, SvgAttributePodType.PreserveAspectRatio, new IntPtr((void*)value), sizeof(SvgPreserveAspectRatio));
			}
		}

		// Token: 0x06000CEB RID: 3307 RVA: 0x00023CAE File Offset: 0x00021EAE
		public unsafe void SetAttributeValue(string name, SvgLength length)
		{
			this.SetAttributeValue(name, SvgAttributePodType.Length, new IntPtr((void*)(&length)), sizeof(SvgLength));
		}

		// Token: 0x06000CEC RID: 3308 RVA: 0x00023CC8 File Offset: 0x00021EC8
		public unsafe void GetAttributeValue(string name, out SvgLength length)
		{
			fixed (SvgLength* ptr = &length)
			{
				SvgLength* value = ptr;
				this.GetAttributeValue(name, SvgAttributePodType.Length, new IntPtr((void*)value), sizeof(SvgLength));
			}
		}

		// Token: 0x06000CED RID: 3309 RVA: 0x00023CF4 File Offset: 0x00021EF4
		public T GetAttributeValue<T>(string name) where T : SvgAttribute
		{
			IntPtr comObjectPtr;
			this.GetAttributeValue(name, Utilities.GetGuidFromType(typeof(T)), out comObjectPtr);
			return CppObject.FromPointer<T>(comObjectPtr);
		}

		// Token: 0x06000CEE RID: 3310 RVA: 0x00016258 File Offset: 0x00014458
		public SvgElement(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000CEF RID: 3311 RVA: 0x00023D1F File Offset: 0x00021F1F
		public new static explicit operator SvgElement(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new SvgElement(nativePtr);
			}
			return null;
		}

		// Token: 0x170001B7 RID: 439
		// (get) Token: 0x06000CF0 RID: 3312 RVA: 0x00023D38 File Offset: 0x00021F38
		public SvgDocument Document
		{
			get
			{
				SvgDocument result;
				this.GetDocument(out result);
				return result;
			}
		}

		// Token: 0x170001B8 RID: 440
		// (get) Token: 0x06000CF1 RID: 3313 RVA: 0x00023D4E File Offset: 0x00021F4E
		public int TagNameLength
		{
			get
			{
				return this.GetTagNameLength();
			}
		}

		// Token: 0x170001B9 RID: 441
		// (get) Token: 0x06000CF2 RID: 3314 RVA: 0x00023D56 File Offset: 0x00021F56
		public RawBool IsTextContent
		{
			get
			{
				return this.IsTextContent_();
			}
		}

		// Token: 0x170001BA RID: 442
		// (get) Token: 0x06000CF3 RID: 3315 RVA: 0x00023D60 File Offset: 0x00021F60
		public SvgElement Parent
		{
			get
			{
				SvgElement result;
				this.GetParent(out result);
				return result;
			}
		}

		// Token: 0x170001BB RID: 443
		// (get) Token: 0x06000CF4 RID: 3316 RVA: 0x00023D78 File Offset: 0x00021F78
		public SvgElement FirstChild
		{
			get
			{
				SvgElement result;
				this.GetFirstChild(out result);
				return result;
			}
		}

		// Token: 0x170001BC RID: 444
		// (get) Token: 0x06000CF5 RID: 3317 RVA: 0x00023D90 File Offset: 0x00021F90
		public SvgElement LastChild
		{
			get
			{
				SvgElement result;
				this.GetLastChild(out result);
				return result;
			}
		}

		// Token: 0x170001BD RID: 445
		// (get) Token: 0x06000CF6 RID: 3318 RVA: 0x00023DA6 File Offset: 0x00021FA6
		public int SpecifiedAttributeCount
		{
			get
			{
				return this.GetSpecifiedAttributeCount();
			}
		}

		// Token: 0x170001BE RID: 446
		// (get) Token: 0x06000CF7 RID: 3319 RVA: 0x00023DAE File Offset: 0x00021FAE
		public int TextValueLength
		{
			get
			{
				return this.GetTextValueLength();
			}
		}

		// Token: 0x06000CF8 RID: 3320 RVA: 0x00023DB8 File Offset: 0x00021FB8
		internal unsafe void GetDocument(out SvgDocument document)
		{
			IntPtr zero = IntPtr.Zero;
			calli(System.Void(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*)));
			if (zero != IntPtr.Zero)
			{
				document = new SvgDocument(zero);
				return;
			}
			document = null;
		}

		// Token: 0x06000CF9 RID: 3321 RVA: 0x00023E04 File Offset: 0x00022004
		public unsafe void GetTagName(IntPtr name, int nameCount)
		{
			calli(System.Int32(System.Void*,System.Void*,System.Int32), this._nativePointer, (void*)name, nameCount, *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000CFA RID: 3322 RVA: 0x00011F85 File Offset: 0x00010185
		internal unsafe int GetTagNameLength()
		{
			return calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)6 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000CFB RID: 3323 RVA: 0x0000B6BA File Offset: 0x000098BA
		internal unsafe RawBool IsTextContent_()
		{
			return calli(SharpDX.Mathematics.Interop.RawBool(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)7 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000CFC RID: 3324 RVA: 0x00023E44 File Offset: 0x00022044
		internal unsafe void GetParent(out SvgElement arentRef)
		{
			IntPtr zero = IntPtr.Zero;
			calli(System.Void(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*)));
			if (zero != IntPtr.Zero)
			{
				arentRef = new SvgElement(zero);
				return;
			}
			arentRef = null;
		}

		// Token: 0x06000CFD RID: 3325 RVA: 0x00023E90 File Offset: 0x00022090
		public unsafe RawBool HasChildren()
		{
			return calli(SharpDX.Mathematics.Interop.RawBool(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)9 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000CFE RID: 3326 RVA: 0x00023EB0 File Offset: 0x000220B0
		internal unsafe void GetFirstChild(out SvgElement child)
		{
			IntPtr zero = IntPtr.Zero;
			calli(System.Void(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)10 * (IntPtr)sizeof(void*)));
			if (zero != IntPtr.Zero)
			{
				child = new SvgElement(zero);
				return;
			}
			child = null;
		}

		// Token: 0x06000CFF RID: 3327 RVA: 0x00023F00 File Offset: 0x00022100
		internal unsafe void GetLastChild(out SvgElement child)
		{
			IntPtr zero = IntPtr.Zero;
			calli(System.Void(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)11 * (IntPtr)sizeof(void*)));
			if (zero != IntPtr.Zero)
			{
				child = new SvgElement(zero);
				return;
			}
			child = null;
		}

		// Token: 0x06000D00 RID: 3328 RVA: 0x00023F50 File Offset: 0x00022150
		public unsafe void GetPreviousChild(SvgElement referenceChild, out SvgElement reviousChildRef)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr zero = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<SvgElement>(referenceChild);
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)value, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)12 * (IntPtr)sizeof(void*)));
			if (zero != IntPtr.Zero)
			{
				reviousChildRef = new SvgElement(zero);
			}
			else
			{
				reviousChildRef = null;
			}
			result.CheckError();
		}

		// Token: 0x06000D01 RID: 3329 RVA: 0x00023FC0 File Offset: 0x000221C0
		public unsafe void GetNextChild(SvgElement referenceChild, out SvgElement nextChild)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr zero = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<SvgElement>(referenceChild);
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)value, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)13 * (IntPtr)sizeof(void*)));
			if (zero != IntPtr.Zero)
			{
				nextChild = new SvgElement(zero);
			}
			else
			{
				nextChild = null;
			}
			result.CheckError();
		}

		// Token: 0x06000D02 RID: 3330 RVA: 0x00024030 File Offset: 0x00022230
		public unsafe void InsertChildBefore(SvgElement newChild, SvgElement referenceChild)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr value2 = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<SvgElement>(newChild);
			value2 = CppObject.ToCallbackPtr<SvgElement>(referenceChild);
			calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)value, (void*)value2, *(*(IntPtr*)this._nativePointer + (IntPtr)14 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000D03 RID: 3331 RVA: 0x00024090 File Offset: 0x00022290
		public unsafe void AppendChild(SvgElement newChild)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<SvgElement>(newChild);
			calli(System.Int32(System.Void*,System.Void*), this._nativePointer, (void*)value, *(*(IntPtr*)this._nativePointer + (IntPtr)15 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000D04 RID: 3332 RVA: 0x000240DC File Offset: 0x000222DC
		public unsafe void ReplaceChild(SvgElement newChild, SvgElement oldChild)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr value2 = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<SvgElement>(newChild);
			value2 = CppObject.ToCallbackPtr<SvgElement>(oldChild);
			calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)value, (void*)value2, *(*(IntPtr*)this._nativePointer + (IntPtr)16 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000D05 RID: 3333 RVA: 0x0002413C File Offset: 0x0002233C
		public unsafe void RemoveChild(SvgElement oldChild)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<SvgElement>(oldChild);
			calli(System.Int32(System.Void*,System.Void*), this._nativePointer, (void*)value, *(*(IntPtr*)this._nativePointer + (IntPtr)17 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000D06 RID: 3334 RVA: 0x00024188 File Offset: 0x00022388
		public unsafe void CreateChild(string tagName, out SvgElement newChild)
		{
			IntPtr zero = IntPtr.Zero;
			Result result;
			fixed (string text = tagName)
			{
				char* ptr = text;
				if (ptr != null)
				{
					ptr += RuntimeHelpers.OffsetToStringData / 2;
				}
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, ptr, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)18 * (IntPtr)sizeof(void*)));
			}
			if (zero != IntPtr.Zero)
			{
				newChild = new SvgElement(zero);
			}
			else
			{
				newChild = null;
			}
			result.CheckError();
		}

		// Token: 0x06000D07 RID: 3335 RVA: 0x000241F8 File Offset: 0x000223F8
		public unsafe RawBool IsAttributeSpecified(string name, out RawBool inherited)
		{
			inherited = default(RawBool);
			RawBool result;
			fixed (RawBool* ptr = &inherited)
			{
				void* ptr2 = (void*)ptr;
				fixed (string text = name)
				{
					char* ptr3 = text;
					if (ptr3 != null)
					{
						ptr3 += RuntimeHelpers.OffsetToStringData / 2;
					}
					result = calli(SharpDX.Mathematics.Interop.RawBool(System.Void*,System.Void*,System.Void*), this._nativePointer, ptr3, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)19 * (IntPtr)sizeof(void*)));
				}
			}
			return result;
		}

		// Token: 0x06000D08 RID: 3336 RVA: 0x0000EC4F File Offset: 0x0000CE4F
		internal unsafe int GetSpecifiedAttributeCount()
		{
			return calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)20 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000D09 RID: 3337 RVA: 0x00024248 File Offset: 0x00022448
		public unsafe void GetSpecifiedAttributeName(int index, IntPtr name, int nameCount, out RawBool inherited)
		{
			inherited = default(RawBool);
			Result result;
			fixed (RawBool* ptr = &inherited)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Int32,System.Void*), this._nativePointer, index, (void*)name, nameCount, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)21 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x06000D0A RID: 3338 RVA: 0x0002429C File Offset: 0x0002249C
		public unsafe void GetSpecifiedAttributeNameLength(int index, out int nameLength, out RawBool inherited)
		{
			inherited = default(RawBool);
			Result result;
			fixed (RawBool* ptr = &inherited)
			{
				void* ptr2 = (void*)ptr;
				fixed (int* ptr3 = &nameLength)
				{
					void* ptr4 = (void*)ptr3;
					result = calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Void*), this._nativePointer, index, ptr4, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)22 * (IntPtr)sizeof(void*)));
				}
			}
			result.CheckError();
		}

		// Token: 0x06000D0B RID: 3339 RVA: 0x000242F4 File Offset: 0x000224F4
		public unsafe void RemoveAttribute(string name)
		{
			Result result;
			fixed (string text = name)
			{
				char* ptr = text;
				if (ptr != null)
				{
					ptr += RuntimeHelpers.OffsetToStringData / 2;
				}
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr, *(*(IntPtr*)this._nativePointer + (IntPtr)23 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x06000D0C RID: 3340 RVA: 0x00024340 File Offset: 0x00022540
		public unsafe void SetTextValue(string name, int nameCount)
		{
			Result result;
			fixed (string text = name)
			{
				char* ptr = text;
				if (ptr != null)
				{
					ptr += RuntimeHelpers.OffsetToStringData / 2;
				}
				result = calli(System.Int32(System.Void*,System.Void*,System.Int32), this._nativePointer, ptr, nameCount, *(*(IntPtr*)this._nativePointer + (IntPtr)24 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x06000D0D RID: 3341 RVA: 0x0002438C File Offset: 0x0002258C
		public unsafe void GetTextValue(IntPtr name, int nameCount)
		{
			calli(System.Int32(System.Void*,System.Void*,System.Int32), this._nativePointer, (void*)name, nameCount, *(*(IntPtr*)this._nativePointer + (IntPtr)25 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000D0E RID: 3342 RVA: 0x0000ED2F File Offset: 0x0000CF2F
		internal unsafe int GetTextValueLength()
		{
			return calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)26 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000D0F RID: 3343 RVA: 0x000243CC File Offset: 0x000225CC
		public unsafe void SetAttributeValue(string name, SvgAttribute value)
		{
			IntPtr value2 = IntPtr.Zero;
			value2 = CppObject.ToCallbackPtr<SvgAttribute>(value);
			Result result;
			fixed (string text = name)
			{
				char* ptr = text;
				if (ptr != null)
				{
					ptr += RuntimeHelpers.OffsetToStringData / 2;
				}
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, ptr, (void*)value2, *(*(IntPtr*)this._nativePointer + (IntPtr)27 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x06000D10 RID: 3344 RVA: 0x0002442C File Offset: 0x0002262C
		public unsafe void SetAttributeValue(string name, SvgAttributePodType type, IntPtr value, int valueSizeInBytes)
		{
			Result result;
			fixed (string text = name)
			{
				char* ptr = text;
				if (ptr != null)
				{
					ptr += RuntimeHelpers.OffsetToStringData / 2;
				}
				result = calli(System.Int32(System.Void*,System.Void*,System.Int32,System.Void*,System.Int32), this._nativePointer, ptr, type, (void*)value, valueSizeInBytes, *(*(IntPtr*)this._nativePointer + (IntPtr)28 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x06000D11 RID: 3345 RVA: 0x00024480 File Offset: 0x00022680
		public unsafe void SetAttributeValue(string name, SvgAttributeStringType type, string value)
		{
			Result result;
			fixed (string text = value)
			{
				char* ptr = text;
				if (ptr != null)
				{
					ptr += RuntimeHelpers.OffsetToStringData / 2;
				}
				fixed (string text2 = name)
				{
					char* ptr2 = text2;
					if (ptr2 != null)
					{
						ptr2 += RuntimeHelpers.OffsetToStringData / 2;
					}
					result = calli(System.Int32(System.Void*,System.Void*,System.Int32,System.Void*), this._nativePointer, ptr2, type, ptr, *(*(IntPtr*)this._nativePointer + (IntPtr)29 * (IntPtr)sizeof(void*)));
				}
			}
			result.CheckError();
		}

		// Token: 0x06000D12 RID: 3346 RVA: 0x000244E4 File Offset: 0x000226E4
		public unsafe void GetAttributeValue(string name, Guid riid, out IntPtr value)
		{
			Result result;
			fixed (IntPtr* ptr = &value)
			{
				void* ptr2 = (void*)ptr;
				fixed (string text = name)
				{
					char* ptr3 = text;
					if (ptr3 != null)
					{
						ptr3 += RuntimeHelpers.OffsetToStringData / 2;
					}
					result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, ptr3, &riid, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)30 * (IntPtr)sizeof(void*)));
				}
			}
			result.CheckError();
		}

		// Token: 0x06000D13 RID: 3347 RVA: 0x00024540 File Offset: 0x00022740
		public unsafe void GetAttributeValue(string name, SvgAttributePodType type, IntPtr value, int valueSizeInBytes)
		{
			Result result;
			fixed (string text = name)
			{
				char* ptr = text;
				if (ptr != null)
				{
					ptr += RuntimeHelpers.OffsetToStringData / 2;
				}
				result = calli(System.Int32(System.Void*,System.Void*,System.Int32,System.Void*,System.Int32), this._nativePointer, ptr, type, (void*)value, valueSizeInBytes, *(*(IntPtr*)this._nativePointer + (IntPtr)31 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x06000D14 RID: 3348 RVA: 0x00024594 File Offset: 0x00022794
		public unsafe void GetAttributeValue(string name, SvgAttributeStringType type, IntPtr value, int valueCount)
		{
			Result result;
			fixed (string text = name)
			{
				char* ptr = text;
				if (ptr != null)
				{
					ptr += RuntimeHelpers.OffsetToStringData / 2;
				}
				result = calli(System.Int32(System.Void*,System.Void*,System.Int32,System.Void*,System.Int32), this._nativePointer, ptr, type, (void*)value, valueCount, *(*(IntPtr*)this._nativePointer + (IntPtr)32 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x06000D15 RID: 3349 RVA: 0x000245E8 File Offset: 0x000227E8
		public unsafe void GetAttributeValueLength(string name, SvgAttributeStringType type, out int valueLength)
		{
			Result result;
			fixed (int* ptr = &valueLength)
			{
				void* ptr2 = (void*)ptr;
				fixed (string text = name)
				{
					char* ptr3 = text;
					if (ptr3 != null)
					{
						ptr3 += RuntimeHelpers.OffsetToStringData / 2;
					}
					result = calli(System.Int32(System.Void*,System.Void*,System.Int32,System.Void*), this._nativePointer, ptr3, type, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)33 * (IntPtr)sizeof(void*)));
				}
			}
			result.CheckError();
		}
	}
}
