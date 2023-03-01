using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct2D1
{
	// Token: 0x0200022E RID: 558
	[Guid("4dc583bf-3a10-438a-8722-e9765224f1f1")]
	public class SpriteBatch : Resource
	{
		// Token: 0x06000C95 RID: 3221 RVA: 0x00022E9C File Offset: 0x0002109C
		public SpriteBatch(DeviceContext3 context3) : this(IntPtr.Zero)
		{
			context3.CreateSpriteBatch(this);
		}

		// Token: 0x06000C96 RID: 3222 RVA: 0x00016258 File Offset: 0x00014458
		public SpriteBatch(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000C97 RID: 3223 RVA: 0x00022EB0 File Offset: 0x000210B0
		public new static explicit operator SpriteBatch(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new SpriteBatch(nativePtr);
			}
			return null;
		}

		// Token: 0x170001A8 RID: 424
		// (get) Token: 0x06000C98 RID: 3224 RVA: 0x00022EC7 File Offset: 0x000210C7
		public int SpriteCount
		{
			get
			{
				return this.GetSpriteCount();
			}
		}

		// Token: 0x06000C99 RID: 3225 RVA: 0x00022ED0 File Offset: 0x000210D0
		public unsafe void AddSprites(int spriteCount, RawRectangleF[] destinationRectangles, RawRectangle[] sourceRectangles, RawColor4[] colors, RawMatrix3x2[] transforms, int destinationRectanglesStride, int sourceRectanglesStride, int colorsStride, int transformsStride)
		{
			Result result;
			fixed (RawMatrix3x2[] array = transforms)
			{
				void* ptr;
				if (transforms == null || array.Length == 0)
				{
					ptr = null;
				}
				else
				{
					ptr = (void*)(&array[0]);
				}
				fixed (RawColor4[] array2 = colors)
				{
					void* ptr2;
					if (colors == null || array2.Length == 0)
					{
						ptr2 = null;
					}
					else
					{
						ptr2 = (void*)(&array2[0]);
					}
					fixed (RawRectangle[] array3 = sourceRectangles)
					{
						void* ptr3;
						if (sourceRectangles == null || array3.Length == 0)
						{
							ptr3 = null;
						}
						else
						{
							ptr3 = (void*)(&array3[0]);
						}
						fixed (RawRectangleF[] array4 = destinationRectangles)
						{
							void* ptr4;
							if (destinationRectangles == null || array4.Length == 0)
							{
								ptr4 = null;
							}
							else
							{
								ptr4 = (void*)(&array4[0]);
							}
							result = calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Void*,System.Void*,System.Void*,System.Int32,System.Int32,System.Int32,System.Int32), this._nativePointer, spriteCount, ptr4, ptr3, ptr2, ptr, destinationRectanglesStride, sourceRectanglesStride, colorsStride, transformsStride, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*)));
						}
					}
				}
			}
			result.CheckError();
		}

		// Token: 0x06000C9A RID: 3226 RVA: 0x00022F90 File Offset: 0x00021190
		public unsafe void SetSprites(int startIndex, int spriteCount, RawRectangleF[] destinationRectangles, RawRectangle[] sourceRectangles, RawColor4[] colors, RawMatrix3x2[] transforms, int destinationRectanglesStride, int sourceRectanglesStride, int colorsStride, int transformsStride)
		{
			Result result;
			fixed (RawMatrix3x2[] array = transforms)
			{
				void* ptr;
				if (transforms == null || array.Length == 0)
				{
					ptr = null;
				}
				else
				{
					ptr = (void*)(&array[0]);
				}
				fixed (RawColor4[] array2 = colors)
				{
					void* ptr2;
					if (colors == null || array2.Length == 0)
					{
						ptr2 = null;
					}
					else
					{
						ptr2 = (void*)(&array2[0]);
					}
					fixed (RawRectangle[] array3 = sourceRectangles)
					{
						void* ptr3;
						if (sourceRectangles == null || array3.Length == 0)
						{
							ptr3 = null;
						}
						else
						{
							ptr3 = (void*)(&array3[0]);
						}
						fixed (RawRectangleF[] array4 = destinationRectangles)
						{
							void* ptr4;
							if (destinationRectangles == null || array4.Length == 0)
							{
								ptr4 = null;
							}
							else
							{
								ptr4 = (void*)(&array4[0]);
							}
							result = calli(System.Int32(System.Void*,System.Int32,System.Int32,System.Void*,System.Void*,System.Void*,System.Void*,System.Int32,System.Int32,System.Int32,System.Int32), this._nativePointer, startIndex, spriteCount, ptr4, ptr3, ptr2, ptr, destinationRectanglesStride, sourceRectanglesStride, colorsStride, transformsStride, *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*)));
						}
					}
				}
			}
			result.CheckError();
		}

		// Token: 0x06000C9B RID: 3227 RVA: 0x00023054 File Offset: 0x00021254
		public unsafe void GetSprites(int startIndex, int spriteCount, RawRectangleF[] destinationRectangles, RawRectangle[] sourceRectangles, RawColor4[] colors, RawMatrix3x2[] transforms)
		{
			Result result;
			fixed (RawMatrix3x2[] array = transforms)
			{
				void* ptr;
				if (transforms == null || array.Length == 0)
				{
					ptr = null;
				}
				else
				{
					ptr = (void*)(&array[0]);
				}
				fixed (RawColor4[] array2 = colors)
				{
					void* ptr2;
					if (colors == null || array2.Length == 0)
					{
						ptr2 = null;
					}
					else
					{
						ptr2 = (void*)(&array2[0]);
					}
					fixed (RawRectangle[] array3 = sourceRectangles)
					{
						void* ptr3;
						if (sourceRectangles == null || array3.Length == 0)
						{
							ptr3 = null;
						}
						else
						{
							ptr3 = (void*)(&array3[0]);
						}
						fixed (RawRectangleF[] array4 = destinationRectangles)
						{
							void* ptr4;
							if (destinationRectangles == null || array4.Length == 0)
							{
								ptr4 = null;
							}
							else
							{
								ptr4 = (void*)(&array4[0]);
							}
							result = calli(System.Int32(System.Void*,System.Int32,System.Int32,System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, startIndex, spriteCount, ptr4, ptr3, ptr2, ptr, *(*(IntPtr*)this._nativePointer + (IntPtr)6 * (IntPtr)sizeof(void*)));
						}
					}
				}
			}
			result.CheckError();
		}

		// Token: 0x06000C9C RID: 3228 RVA: 0x0002310E File Offset: 0x0002130E
		internal unsafe int GetSpriteCount()
		{
			return calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)7 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000C9D RID: 3229 RVA: 0x0002312D File Offset: 0x0002132D
		public unsafe void Clear()
		{
			calli(System.Void(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*)));
		}
	}
}
