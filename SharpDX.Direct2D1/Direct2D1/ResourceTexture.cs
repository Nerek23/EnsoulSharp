using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct2D1
{
	// Token: 0x02000218 RID: 536
	[Guid("688d15c3-02b0-438d-b13a-d1b44c32c39a")]
	public class ResourceTexture : ComObject
	{
		// Token: 0x06000C21 RID: 3105 RVA: 0x00022589 File Offset: 0x00020789
		public ResourceTexture(EffectContext context, Guid resourceId, ResourceTextureProperties resourceTextureProperties) : base(IntPtr.Zero)
		{
			ResourceTexture.CreateResourceTexture(context, resourceId, resourceTextureProperties, null, null, this);
		}

		// Token: 0x06000C22 RID: 3106 RVA: 0x000225A1 File Offset: 0x000207A1
		public ResourceTexture(EffectContext context, Guid resourceId, ResourceTextureProperties resourceTextureProperties, byte[] data, int[] strides) : base(IntPtr.Zero)
		{
			ResourceTexture.CreateResourceTexture(context, resourceId, resourceTextureProperties, data, strides, this);
		}

		// Token: 0x06000C23 RID: 3107 RVA: 0x000225BC File Offset: 0x000207BC
		private unsafe static void CreateResourceTexture(EffectContext context, Guid resourceId, ResourceTextureProperties resourceTextureProperties, byte[] data, int[] strides, ResourceTexture outTexture)
		{
			ResourceTextureProperties.__Native _Native = default(ResourceTextureProperties.__Native);
			resourceTextureProperties.__MarshalTo(ref _Native);
			if (resourceTextureProperties.Extents == null || resourceTextureProperties.Extents.Length != resourceTextureProperties.Dimensions)
			{
				throw new ArgumentException("Extents array must be same size than dimensions", "resourceTextureProperties");
			}
			if (resourceTextureProperties.ExtendModes == null || resourceTextureProperties.ExtendModes.Length != resourceTextureProperties.Dimensions)
			{
				throw new ArgumentException("ExtendModes array must be same size than dimensions", "resourceTextureProperties");
			}
			int[] array;
			void* value;
			if ((array = resourceTextureProperties.Extents) == null || array.Length == 0)
			{
				value = null;
			}
			else
			{
				value = (void*)(&array[0]);
			}
			ExtendMode[] array2;
			void* value2;
			if ((array2 = resourceTextureProperties.ExtendModes) == null || array2.Length == 0)
			{
				value2 = null;
			}
			else
			{
				value2 = (void*)(&array2[0]);
			}
			_Native.ExtentsPointer = (IntPtr)value;
			_Native.ExtendModesPointer = (IntPtr)value2;
			context.CreateResourceTexture(new Guid?(resourceId), new IntPtr((void*)(&_Native)), data, strides, (data == null) ? 0 : data.Length, outTexture);
			array2 = null;
			array = null;
		}

		// Token: 0x06000C24 RID: 3108 RVA: 0x00002A7F File Offset: 0x00000C7F
		public ResourceTexture(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000C25 RID: 3109 RVA: 0x000226A7 File Offset: 0x000208A7
		public new static explicit operator ResourceTexture(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new ResourceTexture(nativePtr);
			}
			return null;
		}

		// Token: 0x06000C26 RID: 3110 RVA: 0x000226C0 File Offset: 0x000208C0
		public unsafe void Update(int[] minimumExtents, int[] maximimumExtents, int[] strides, int dimensions, byte[] data, int dataCount)
		{
			Result result;
			fixed (byte[] array = data)
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
				fixed (int[] array2 = strides)
				{
					void* ptr2;
					if (strides == null || array2.Length == 0)
					{
						ptr2 = null;
					}
					else
					{
						ptr2 = (void*)(&array2[0]);
					}
					fixed (int[] array3 = maximimumExtents)
					{
						void* ptr3;
						if (maximimumExtents == null || array3.Length == 0)
						{
							ptr3 = null;
						}
						else
						{
							ptr3 = (void*)(&array3[0]);
						}
						fixed (int[] array4 = minimumExtents)
						{
							void* ptr4;
							if (minimumExtents == null || array4.Length == 0)
							{
								ptr4 = null;
							}
							else
							{
								ptr4 = (void*)(&array4[0]);
							}
							result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*,System.Int32,System.Void*,System.Int32), this._nativePointer, ptr4, ptr3, ptr2, dimensions, ptr, dataCount, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*)));
						}
					}
				}
			}
			result.CheckError();
		}
	}
}
