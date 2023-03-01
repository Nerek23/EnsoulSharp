using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using SharpDX.DirectWrite;
using SharpDX.DXGI;
using SharpDX.Win32;

namespace SharpDX.Direct2D1
{
	// Token: 0x020001E0 RID: 480
	[Guid("bb12d362-daee-4b9a-aa1d-14ba401cfa1f")]
	public class Factory1 : SharpDX.Direct2D1.Factory
	{
		// Token: 0x060009E1 RID: 2529 RVA: 0x0001CE22 File Offset: 0x0001B022
		public Factory1() : this(FactoryType.SingleThreaded)
		{
		}

		// Token: 0x060009E2 RID: 2530 RVA: 0x0001CE2B File Offset: 0x0001B02B
		public Factory1(FactoryType factoryType) : this(factoryType, DebugLevel.None)
		{
		}

		// Token: 0x060009E3 RID: 2531 RVA: 0x0001CE35 File Offset: 0x0001B035
		public Factory1(FactoryType factoryType, DebugLevel debugLevel)
		{
			this.registeredEffects = new Dictionary<Guid, CustomEffectFactory>();
			base..ctor(factoryType, debugLevel);
		}

		// Token: 0x17000162 RID: 354
		// (get) Token: 0x060009E4 RID: 2532 RVA: 0x0001CE4C File Offset: 0x0001B04C
		public Guid[] RegisteredEffects
		{
			get
			{
				int num;
				int num2;
				this.GetRegisteredEffects(null, 0, out num, out num2);
				Guid[] array = new Guid[num2];
				this.GetRegisteredEffects(array, array.Length, out num, out num2);
				return array;
			}
		}

		// Token: 0x060009E5 RID: 2533 RVA: 0x0001CE7C File Offset: 0x0001B07C
		public void RegisterEffect<T>(Func<T> effectFactory) where T : CustomEffect
		{
			Guid guidFromType = Utilities.GetGuidFromType(typeof(T));
			this.RegisterEffect<T>(effectFactory, guidFromType);
		}

		// Token: 0x060009E6 RID: 2534 RVA: 0x0001CEA4 File Offset: 0x0001B0A4
		public void RegisterEffect<T>(Func<T> effectFactory, Guid effectId) where T : CustomEffect
		{
			Dictionary<Guid, CustomEffectFactory> obj = this.registeredEffects;
			CustomEffectFactory customEffectFactory;
			lock (obj)
			{
				if (this.registeredEffects.ContainsKey(effectId))
				{
					throw new ArgumentException("An effect is already registered with this GUID", "effectFactory");
				}
				customEffectFactory = new CustomEffectFactory(() => effectFactory(), typeof(T), effectId);
				this.registeredEffects.Add(effectId, customEffectFactory);
			}
			this.RegisterEffectFromString(effectId, customEffectFactory.ToXml(), customEffectFactory.Bindings, customEffectFactory.Bindings.Length, customEffectFactory.NativePointer);
		}

		// Token: 0x060009E7 RID: 2535 RVA: 0x0001CF5C File Offset: 0x0001B15C
		public void RegisterEffect<T>() where T : CustomEffect, new()
		{
			this.RegisterEffect<T>(Utilities.GetGuidFromType(typeof(T)));
		}

		// Token: 0x060009E8 RID: 2536 RVA: 0x0001CF74 File Offset: 0x0001B174
		public void RegisterEffect<T>(Guid effectId) where T : CustomEffect, new()
		{
			Dictionary<Guid, CustomEffectFactory> obj = this.registeredEffects;
			CustomEffectFactory customEffectFactory;
			lock (obj)
			{
				if (this.registeredEffects.ContainsKey(effectId))
				{
					throw new ArgumentException("An effect is already registered with this GUID", "effectFactory");
				}
				customEffectFactory = new CustomEffectFactory(() => Activator.CreateInstance<T>(), typeof(T), effectId);
				this.registeredEffects.Add(effectId, customEffectFactory);
			}
			this.RegisterEffectFromString(effectId, customEffectFactory.ToXml(), customEffectFactory.Bindings, customEffectFactory.Bindings.Length, customEffectFactory.NativePointer);
		}

		// Token: 0x060009E9 RID: 2537 RVA: 0x0001D030 File Offset: 0x0001B230
		public void UnRegisterEffect<T>() where T : CustomEffect
		{
			Guid guidFromType = Utilities.GetGuidFromType(typeof(T));
			Dictionary<Guid, CustomEffectFactory> obj = this.registeredEffects;
			lock (obj)
			{
				CustomEffectFactory customEffectFactory;
				if (this.registeredEffects.TryGetValue(guidFromType, out customEffectFactory))
				{
					this.registeredEffects.Remove(guidFromType);
				}
			}
			this.UnregisterEffect(guidFromType);
		}

		// Token: 0x060009EA RID: 2538 RVA: 0x0001D0A0 File Offset: 0x0001B2A0
		public Factory1(IntPtr nativePtr)
		{
			this.registeredEffects = new Dictionary<Guid, CustomEffectFactory>();
			base..ctor(nativePtr);
		}

		// Token: 0x060009EB RID: 2539 RVA: 0x0001D0B4 File Offset: 0x0001B2B4
		public new static explicit operator SharpDX.Direct2D1.Factory1(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new SharpDX.Direct2D1.Factory1(nativePtr);
			}
			return null;
		}

		// Token: 0x060009EC RID: 2540 RVA: 0x0001D0CC File Offset: 0x0001B2CC
		internal unsafe void CreateDevice(Device dxgiDevice, Device d2dDevice)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr zero = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<Device>(dxgiDevice);
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)value, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)17 * (IntPtr)sizeof(void*)));
			d2dDevice.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x060009ED RID: 2541 RVA: 0x0001D128 File Offset: 0x0001B328
		internal unsafe void CreateStrokeStyle(ref StrokeStyleProperties1 strokeStyleProperties, float[] dashes, int dashesCount, StrokeStyle1 strokeStyle)
		{
			IntPtr zero = IntPtr.Zero;
			Result result;
			fixed (float[] array = dashes)
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
				fixed (StrokeStyleProperties1* ptr2 = &strokeStyleProperties)
				{
					void* ptr3 = (void*)ptr2;
					result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Int32,System.Void*), this._nativePointer, ptr3, ptr, dashesCount, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)18 * (IntPtr)sizeof(void*)));
				}
			}
			strokeStyle.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x060009EE RID: 2542 RVA: 0x0001D19C File Offset: 0x0001B39C
		internal unsafe void CreatePathGeometry(PathGeometry1 athGeometryRef)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)19 * (IntPtr)sizeof(void*)));
			athGeometryRef.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x060009EF RID: 2543 RVA: 0x0001D1E4 File Offset: 0x0001B3E4
		internal unsafe void CreateDrawingStateBlock(DrawingStateDescription1? drawingStateDescription, RenderingParams textRenderingParams, DrawingStateBlock1 drawingStateBlock)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr zero = IntPtr.Zero;
			DrawingStateDescription1 value2;
			if (drawingStateDescription != null)
			{
				value2 = drawingStateDescription.Value;
			}
			value = CppObject.ToCallbackPtr<RenderingParams>(textRenderingParams);
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, (drawingStateDescription == null) ? null : (&value2), (void*)value, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)20 * (IntPtr)sizeof(void*)));
			drawingStateBlock.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x060009F0 RID: 2544 RVA: 0x0001D260 File Offset: 0x0001B460
		internal unsafe void CreateGdiMetafile(IStream metafileStream, out GdiMetafile metafile)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr zero = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<IStream>(metafileStream);
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)value, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)21 * (IntPtr)sizeof(void*)));
			if (zero != IntPtr.Zero)
			{
				metafile = new GdiMetafile(zero);
			}
			else
			{
				metafile = null;
			}
			result.CheckError();
		}

		// Token: 0x060009F1 RID: 2545 RVA: 0x0001D2D0 File Offset: 0x0001B4D0
		internal unsafe void RegisterEffectFromStream(Guid classId, IStream ropertyXmlRef, PropertyBinding[] bindings, int bindingsCount, FunctionCallback effectFactory)
		{
			IntPtr value = IntPtr.Zero;
			PropertyBinding.__Native[] array = (bindings == null) ? null : new PropertyBinding.__Native[bindings.Length];
			value = CppObject.ToCallbackPtr<IStream>(ropertyXmlRef);
			if (bindings != null)
			{
				for (int i = 0; i < bindings.Length; i++)
				{
					if (bindings != null)
					{
						bindings[i].__MarshalTo(ref array[i]);
					}
				}
			}
			PropertyBinding.__Native[] array2;
			void* ptr;
			if ((array2 = array) == null || array2.Length == 0)
			{
				ptr = null;
			}
			else
			{
				ptr = (void*)(&array2[0]);
			}
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*,System.Int32,System.Void*), this._nativePointer, &classId, (void*)value, ptr, bindingsCount, effectFactory, *(*(IntPtr*)this._nativePointer + (IntPtr)22 * (IntPtr)sizeof(void*)));
			array2 = null;
			if (bindings != null)
			{
				for (int j = 0; j < bindings.Length; j++)
				{
					if (bindings != null)
					{
						bindings[j].__MarshalFree(ref array[j]);
					}
				}
			}
			result.CheckError();
		}

		// Token: 0x060009F2 RID: 2546 RVA: 0x0001D3A4 File Offset: 0x0001B5A4
		internal unsafe void RegisterEffectFromString(Guid classId, string ropertyXmlRef, PropertyBinding[] bindings, int bindingsCount, FunctionCallback effectFactory)
		{
			PropertyBinding.__Native[] array = (bindings == null) ? null : new PropertyBinding.__Native[bindings.Length];
			if (bindings != null)
			{
				for (int i = 0; i < bindings.Length; i++)
				{
					if (bindings != null)
					{
						bindings[i].__MarshalTo(ref array[i]);
					}
				}
			}
			PropertyBinding.__Native[] array2;
			void* ptr;
			if ((array2 = array) == null || array2.Length == 0)
			{
				ptr = null;
			}
			else
			{
				ptr = (void*)(&array2[0]);
			}
			Result result;
			fixed (string text = ropertyXmlRef)
			{
				char* ptr2 = text;
				if (ptr2 != null)
				{
					ptr2 += RuntimeHelpers.OffsetToStringData / 2;
				}
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*,System.Int32,System.Void*), this._nativePointer, &classId, ptr2, ptr, bindingsCount, effectFactory, *(*(IntPtr*)this._nativePointer + (IntPtr)23 * (IntPtr)sizeof(void*)));
			}
			array2 = null;
			if (bindings != null)
			{
				for (int j = 0; j < bindings.Length; j++)
				{
					if (bindings != null)
					{
						bindings[j].__MarshalFree(ref array[j]);
					}
				}
			}
			result.CheckError();
		}

		// Token: 0x060009F3 RID: 2547 RVA: 0x0001D480 File Offset: 0x0001B680
		internal unsafe void UnregisterEffect(Guid classId)
		{
			calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &classId, *(*(IntPtr*)this._nativePointer + (IntPtr)24 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060009F4 RID: 2548 RVA: 0x0001D4BC File Offset: 0x0001B6BC
		internal unsafe void GetRegisteredEffects(Guid[] effects, int effectsCount, out int effectsReturned, out int effectsRegistered)
		{
			Result result;
			fixed (int* ptr = &effectsRegistered)
			{
				void* ptr2 = (void*)ptr;
				fixed (int* ptr3 = &effectsReturned)
				{
					void* ptr4 = (void*)ptr3;
					fixed (Guid[] array = effects)
					{
						void* ptr5;
						if (effects == null || array.Length == 0)
						{
							ptr5 = null;
						}
						else
						{
							ptr5 = (void*)(&array[0]);
						}
						result = calli(System.Int32(System.Void*,System.Void*,System.Int32,System.Void*,System.Void*), this._nativePointer, ptr5, effectsCount, ptr4, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)25 * (IntPtr)sizeof(void*)));
					}
				}
			}
			result.CheckError();
		}

		// Token: 0x060009F5 RID: 2549 RVA: 0x0001D530 File Offset: 0x0001B730
		public unsafe Properties GetEffectProperties(Guid effectId)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, &effectId, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)26 * (IntPtr)sizeof(void*)));
			Properties result2;
			if (zero != IntPtr.Zero)
			{
				result2 = new Properties(zero);
			}
			else
			{
				result2 = null;
			}
			result.CheckError();
			return result2;
		}

		// Token: 0x04000663 RID: 1635
		private Dictionary<Guid, CustomEffectFactory> registeredEffects;
	}
}
