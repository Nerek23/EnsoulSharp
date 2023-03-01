using System;
using System.Reflection;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct2D1
{
	// Token: 0x0200020C RID: 524
	internal class PropertyBinding
	{
		// Token: 0x06000B7B RID: 2939 RVA: 0x000067AA File Offset: 0x000049AA
		protected PropertyBinding()
		{
		}

		// Token: 0x17000184 RID: 388
		// (get) Token: 0x06000B7C RID: 2940 RVA: 0x000208BB File Offset: 0x0001EABB
		public string TypeName
		{
			get
			{
				return PropertyTypeHelper.ConvertToString(this.Attribute.Type);
			}
		}

		// Token: 0x17000185 RID: 389
		// (get) Token: 0x06000B7D RID: 2941 RVA: 0x000208CD File Offset: 0x0001EACD
		// (set) Token: 0x06000B7E RID: 2942 RVA: 0x000208D5 File Offset: 0x0001EAD5
		public PropertyBindingAttribute Attribute { get; private set; }

		// Token: 0x06000B7F RID: 2943 RVA: 0x000208E0 File Offset: 0x0001EAE0
		public static PropertyBinding Get(Type customEffectType, PropertyInfo propertyInfo)
		{
			PropertyBindingAttribute customAttribute = Utilities.GetCustomAttribute<PropertyBindingAttribute>(propertyInfo, true);
			if (customAttribute == null)
			{
				return null;
			}
			PropertyBinding propertyBinding = new PropertyBinding
			{
				Attribute = customAttribute
			};
			Type propertyType = propertyInfo.PropertyType;
			PropertyType propertyType2 = customAttribute.BindingType;
			if (propertyType2 == PropertyType.Unknown)
			{
				string name = propertyType.Name;
				if (propertyType == typeof(int))
				{
					propertyBinding.nativeGetSet = new PropertyBinding.NativeGetSetValue<int>(customEffectType, propertyInfo);
					propertyType2 = PropertyType.Int32;
				}
				else if (propertyType == typeof(float))
				{
					propertyBinding.nativeGetSet = new PropertyBinding.NativeGetSetValue<float>(customEffectType, propertyInfo);
					propertyType2 = PropertyType.Float;
				}
				else if (propertyType == typeof(uint))
				{
					propertyBinding.nativeGetSet = new PropertyBinding.NativeGetSetValue<uint>(customEffectType, propertyInfo);
					propertyType2 = PropertyType.UInt32;
				}
				else if (propertyType == typeof(bool))
				{
					propertyBinding.nativeGetSet = new PropertyBinding.NativeGetSetValue<int>(customEffectType, propertyInfo);
					propertyType2 = PropertyType.Bool;
				}
				else if (name.Contains("Vector2"))
				{
					propertyBinding.nativeGetSet = new PropertyBinding.NativeGetSetValue<RawVector2>(customEffectType, propertyInfo);
					propertyType2 = PropertyType.Vector2;
				}
				else if (name.Contains("Vector3"))
				{
					propertyBinding.nativeGetSet = new PropertyBinding.NativeGetSetValue<RawVector3>(customEffectType, propertyInfo);
					propertyType2 = PropertyType.Vector3;
				}
				else if (name.Contains("RectangleF"))
				{
					propertyBinding.nativeGetSet = new PropertyBinding.NativeGetSetValue<RawRectangleF>(customEffectType, propertyInfo);
					propertyType2 = PropertyType.Vector4;
				}
				else if (name.Contains("Vector4"))
				{
					propertyBinding.nativeGetSet = new PropertyBinding.NativeGetSetValue<RawVector4>(customEffectType, propertyInfo);
					propertyType2 = PropertyType.Vector4;
				}
				else if (name.Contains("Color3"))
				{
					propertyBinding.nativeGetSet = new PropertyBinding.NativeGetSetValue<RawColor3>(customEffectType, propertyInfo);
					propertyType2 = PropertyType.Vector3;
				}
				else if (name.Contains("Color4"))
				{
					propertyBinding.nativeGetSet = new PropertyBinding.NativeGetSetValue<RawColor4>(customEffectType, propertyInfo);
					propertyType2 = PropertyType.Vector4;
				}
				else if (name.Contains("Matrix3x2"))
				{
					propertyBinding.nativeGetSet = new PropertyBinding.NativeGetSetValue<RawMatrix3x2>(customEffectType, propertyInfo);
					propertyType2 = PropertyType.Matrix3x2;
				}
				else if (name.Contains("Matrix5x4"))
				{
					propertyBinding.nativeGetSet = new PropertyBinding.NativeGetSetValue<RawMatrix5x4>(customEffectType, propertyInfo);
					propertyType2 = PropertyType.Matrix5x4;
				}
				else if (name.Contains("Matrix"))
				{
					propertyBinding.nativeGetSet = new PropertyBinding.NativeGetSetValue<RawMatrix>(customEffectType, propertyInfo);
					propertyType2 = PropertyType.Matrix4x4;
				}
				else if (Utilities.IsEnum(propertyType))
				{
					propertyBinding.nativeGetSet = new PropertyBinding.NativeGetSetValue<int>(customEffectType, propertyInfo);
					propertyType2 = PropertyType.Enum;
				}
				else
				{
					if (!Utilities.IsAssignableFrom(typeof(ComObject), propertyType))
					{
						throw new SharpDXException(string.Format("Unsupported property type [{0}] with binding [{1}] for custom effect [{2}]", propertyType, propertyType2, customEffectType), new object[0]);
					}
					propertyBinding.nativeGetSet = new PropertyBinding.NativeGetSetValue<IntPtr>(customEffectType, propertyInfo);
					propertyType2 = PropertyType.IUnknown;
				}
			}
			customAttribute.Type = propertyType2;
			propertyBinding.PropertyName = (customAttribute.DisplayName ?? propertyInfo.Name);
			propertyBinding.GetFunction = propertyBinding.nativeGetSet.GetFunctionPtr;
			propertyBinding.SetFunction = propertyBinding.nativeGetSet.SetFunctionPtr;
			return propertyBinding;
		}

		// Token: 0x06000B80 RID: 2944 RVA: 0x00020B86 File Offset: 0x0001ED86
		internal void __MarshalFree(ref PropertyBinding.__Native @ref)
		{
			Marshal.FreeHGlobal(@ref.PropertyName);
		}

		// Token: 0x06000B81 RID: 2945 RVA: 0x00020B93 File Offset: 0x0001ED93
		internal void __MarshalFrom(ref PropertyBinding.__Native @ref)
		{
			this.PropertyName = Marshal.PtrToStringUni(@ref.PropertyName);
			this.SetFunction = @ref.SetFunction;
			this.GetFunction = @ref.GetFunction;
		}

		// Token: 0x06000B82 RID: 2946 RVA: 0x00020BBE File Offset: 0x0001EDBE
		internal void __MarshalTo(ref PropertyBinding.__Native @ref)
		{
			@ref.PropertyName = Marshal.StringToHGlobalUni(this.PropertyName);
			@ref.SetFunction = this.SetFunction;
			@ref.GetFunction = this.GetFunction;
		}

		// Token: 0x04000694 RID: 1684
		private PropertyBinding.NativeGetSet nativeGetSet;

		// Token: 0x04000696 RID: 1686
		public string PropertyName;

		// Token: 0x04000697 RID: 1687
		internal IntPtr SetFunction;

		// Token: 0x04000698 RID: 1688
		internal IntPtr GetFunction;

		// Token: 0x0200020D RID: 525
		public abstract class NativeGetSet
		{
			// Token: 0x06000B83 RID: 2947 RVA: 0x00020BE9 File Offset: 0x0001EDE9
			public NativeGetSet(Type customEffectType, PropertyInfo propertyInfo)
			{
				this.customEffectType = customEffectType;
				this.propertyInfo = propertyInfo;
			}

			// Token: 0x17000186 RID: 390
			// (get) Token: 0x06000B84 RID: 2948 RVA: 0x00020BFF File Offset: 0x0001EDFF
			// (set) Token: 0x06000B85 RID: 2949 RVA: 0x00020C07 File Offset: 0x0001EE07
			public IntPtr GetFunctionPtr { get; protected set; }

			// Token: 0x17000187 RID: 391
			// (get) Token: 0x06000B86 RID: 2950 RVA: 0x00020C10 File Offset: 0x0001EE10
			// (set) Token: 0x06000B87 RID: 2951 RVA: 0x00020C18 File Offset: 0x0001EE18
			public IntPtr SetFunctionPtr { get; protected set; }

			// Token: 0x04000699 RID: 1689
			protected PropertyBinding.NativeGetSet.NativeGetFunctionDelegate getterNative;

			// Token: 0x0400069A RID: 1690
			protected PropertyBinding.NativeGetSet.NativeSetFunctionDelegate setterNative;

			// Token: 0x0400069B RID: 1691
			protected Type customEffectType;

			// Token: 0x0400069C RID: 1692
			protected PropertyInfo propertyInfo;

			// Token: 0x0200020E RID: 526
			// (Invoke) Token: 0x06000B89 RID: 2953
			[UnmanagedFunctionPointer(CallingConvention.StdCall)]
			protected delegate int NativeSetFunctionDelegate(IntPtr thisPtr, IntPtr dataPtr, int dataSize);

			// Token: 0x0200020F RID: 527
			// (Invoke) Token: 0x06000B8D RID: 2957
			[UnmanagedFunctionPointer(CallingConvention.StdCall)]
			protected delegate int NativeGetFunctionDelegate(IntPtr thisPtr, IntPtr dataPtr, int dataSize, out int actualSize);
		}

		// Token: 0x02000210 RID: 528
		public class NativeGetSetValue<T> : PropertyBinding.NativeGetSet where T : struct
		{
			// Token: 0x06000B91 RID: 2961 RVA: 0x00020C30 File Offset: 0x0001EE30
			public NativeGetSetValue(Type customEffectType, PropertyInfo propertyInfo) : base(customEffectType, propertyInfo)
			{
				if (propertyInfo.CanRead)
				{
					this.getter = Utilities.BuildPropertyGetter<T>(customEffectType, propertyInfo);
					this.getterNative = new PropertyBinding.NativeGetSet.NativeGetFunctionDelegate(this.NativeGetInt);
					base.GetFunctionPtr = Marshal.GetFunctionPointerForDelegate(this.getterNative);
				}
				if (propertyInfo.CanWrite)
				{
					this.setter = Utilities.BuildPropertySetter<T>(customEffectType, propertyInfo);
					this.setterNative = new PropertyBinding.NativeGetSet.NativeSetFunctionDelegate(this.NativeSetInt);
					base.SetFunctionPtr = Marshal.GetFunctionPointerForDelegate(this.setterNative);
				}
			}

			// Token: 0x06000B92 RID: 2962 RVA: 0x00020CB5 File Offset: 0x0001EEB5
			protected void SetValue(IntPtr sourceValue, out T destValue)
			{
				Utilities.ReadOut<T>(sourceValue, out destValue);
			}

			// Token: 0x06000B93 RID: 2963 RVA: 0x00020CBE File Offset: 0x0001EEBE
			protected void GetValue(IntPtr destValue, ref T sourceValue)
			{
				Utilities.Write<T>(destValue, ref sourceValue);
			}

			// Token: 0x06000B94 RID: 2964 RVA: 0x00020CC8 File Offset: 0x0001EEC8
			private int NativeSetInt(IntPtr thisPtr, IntPtr dataPtr, int dataSize)
			{
				try
				{
					if (dataPtr == IntPtr.Zero)
					{
						return Result.Ok.Code;
					}
					if (dataSize != PropertyBinding.NativeGetSetValue<T>.ValueSize)
					{
						return Result.InvalidArg.Code;
					}
					CustomEffect obj = (CustomEffect)CppObjectShadow.ToShadow<CustomEffectShadow>(thisPtr).Callback;
					T t;
					this.SetValue(dataPtr, out t);
					this.setter(obj, ref t);
				}
				catch (Exception ex)
				{
					return (int)Result.GetResultFromException(ex);
				}
				return Result.Ok.Code;
			}

			// Token: 0x06000B95 RID: 2965 RVA: 0x00020D60 File Offset: 0x0001EF60
			private int NativeGetInt(IntPtr thisPtr, IntPtr dataPtr, int dataSize, out int actualSize)
			{
				actualSize = PropertyBinding.NativeGetSetValue<T>.ValueSize;
				try
				{
					if (dataPtr == IntPtr.Zero)
					{
						return Result.Ok.Code;
					}
					CustomEffect obj = (CustomEffect)CppObjectShadow.ToShadow<CustomEffectShadow>(thisPtr).Callback;
					actualSize = PropertyBinding.NativeGetSetValue<T>.ValueSize;
					T t;
					this.getter(obj, out t);
					this.GetValue(dataPtr, ref t);
				}
				catch (Exception ex)
				{
					return (int)Result.GetResultFromException(ex);
				}
				return Result.Ok.Code;
			}

			// Token: 0x0400069F RID: 1695
			private readonly GetValueFastDelegate<T> getter;

			// Token: 0x040006A0 RID: 1696
			private readonly SetValueFastDelegate<T> setter;

			// Token: 0x040006A1 RID: 1697
			private static readonly int ValueSize = Utilities.SizeOf<T>();
		}

		// Token: 0x02000211 RID: 529
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		internal struct __Native
		{
			// Token: 0x040006A2 RID: 1698
			public IntPtr PropertyName;

			// Token: 0x040006A3 RID: 1699
			public IntPtr SetFunction;

			// Token: 0x040006A4 RID: 1700
			public IntPtr GetFunction;
		}
	}
}
