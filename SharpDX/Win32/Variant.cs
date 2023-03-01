using System;
using System.Globalization;
using System.Reflection;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Win32
{
	// Token: 0x02000058 RID: 88
	public struct Variant
	{
		// Token: 0x1700003F RID: 63
		// (get) Token: 0x06000265 RID: 613 RVA: 0x00006CEB File Offset: 0x00004EEB
		// (set) Token: 0x06000266 RID: 614 RVA: 0x00006CFA File Offset: 0x00004EFA
		public VariantElementType ElementType
		{
			get
			{
				return (VariantElementType)(this.vt & 4095);
			}
			set
			{
				this.vt = ((this.vt & 61440) | (ushort)value);
			}
		}

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x06000267 RID: 615 RVA: 0x00006D11 File Offset: 0x00004F11
		// (set) Token: 0x06000268 RID: 616 RVA: 0x00006D20 File Offset: 0x00004F20
		public VariantType Type
		{
			get
			{
				return (VariantType)(this.vt & 61440);
			}
			set
			{
				this.vt = ((this.vt & 4095) | (ushort)value);
			}
		}

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x06000269 RID: 617 RVA: 0x00006D38 File Offset: 0x00004F38
		// (set) Token: 0x0600026A RID: 618 RVA: 0x00007318 File Offset: 0x00005518
		public unsafe object Value
		{
			get
			{
				VariantType type = this.Type;
				VariantElementType elementType;
				if (type == VariantType.Default)
				{
					elementType = this.ElementType;
					switch (elementType)
					{
					case VariantElementType.Empty:
					case VariantElementType.Null:
						return null;
					case VariantElementType.Short:
						return this.variantValue.shortValue;
					case VariantElementType.Int:
					case VariantElementType.Int1:
						return this.variantValue.intValue;
					case VariantElementType.Float:
						return this.variantValue.floatValue;
					case VariantElementType.Double:
						return this.variantValue.doubleValue;
					case VariantElementType.Currency:
					case VariantElementType.Date:
					case VariantElementType.Error:
					case VariantElementType.Variant:
					case VariantElementType.Decimal:
					case (VariantElementType)15:
					case VariantElementType.Void:
					case VariantElementType.Result:
					case VariantElementType.SafeArray:
					case VariantElementType.ConstantArray:
					case VariantElementType.UserDefined:
					case (VariantElementType)32:
					case (VariantElementType)33:
					case (VariantElementType)34:
					case (VariantElementType)35:
					case VariantElementType.Recor:
						break;
					case VariantElementType.BinaryString:
						throw new NotSupportedException();
					case VariantElementType.Dispatch:
					case VariantElementType.ComUnknown:
						return new ComObject(this.variantValue.pointerValue);
					case VariantElementType.Bool:
						return this.variantValue.intValue != 0;
					case VariantElementType.Byte:
						return this.variantValue.signedByteValue;
					case VariantElementType.UByte:
						return this.variantValue.byteValue;
					case VariantElementType.UShort:
						return this.variantValue.ushortValue;
					case VariantElementType.UInt:
					case VariantElementType.UInt1:
						return this.variantValue.uintValue;
					case VariantElementType.Long:
						return this.variantValue.longValue;
					case VariantElementType.ULong:
						return this.variantValue.ulongValue;
					case VariantElementType.Pointer:
					case VariantElementType.IntPointer:
						return this.variantValue.pointerValue;
					case VariantElementType.StringPointer:
						return Marshal.PtrToStringAnsi(this.variantValue.pointerValue);
					case VariantElementType.WStringPointer:
						return Marshal.PtrToStringUni(this.variantValue.pointerValue);
					default:
						if (elementType == VariantElementType.FileTime)
						{
							return DateTime.FromFileTime(this.variantValue.longValue);
						}
						if (elementType == VariantElementType.Blob)
						{
							byte[] array = new byte[(int)this.variantValue.recordValue.RecordInfo];
							if (array.Length != 0)
							{
								Utilities.Read<byte>(this.variantValue.recordValue.RecordPointer, array, 0, array.Length);
							}
							return array;
						}
						break;
					}
					return null;
				}
				if (type != VariantType.Vector)
				{
					return null;
				}
				int num = (int)this.variantValue.recordValue.RecordInfo;
				elementType = this.ElementType;
				switch (elementType)
				{
				case VariantElementType.Short:
				{
					short[] array2 = new short[num];
					Utilities.Read<short>(this.variantValue.recordValue.RecordPointer, array2, 0, num);
					return array2;
				}
				case VariantElementType.Int:
				case VariantElementType.Int1:
				{
					int[] array3 = new int[num];
					Utilities.Read<int>(this.variantValue.recordValue.RecordPointer, array3, 0, num);
					return array3;
				}
				case VariantElementType.Float:
				{
					float[] array4 = new float[num];
					Utilities.Read<float>(this.variantValue.recordValue.RecordPointer, array4, 0, num);
					return array4;
				}
				case VariantElementType.Double:
				{
					double[] array5 = new double[num];
					Utilities.Read<double>(this.variantValue.recordValue.RecordPointer, array5, 0, num);
					return array5;
				}
				case VariantElementType.Currency:
				case VariantElementType.Date:
				case VariantElementType.Error:
				case VariantElementType.Variant:
				case VariantElementType.Decimal:
				case (VariantElementType)15:
				case VariantElementType.Void:
				case VariantElementType.Result:
				case VariantElementType.SafeArray:
				case VariantElementType.ConstantArray:
				case VariantElementType.UserDefined:
				case (VariantElementType)32:
				case (VariantElementType)33:
				case (VariantElementType)34:
				case (VariantElementType)35:
				case VariantElementType.Recor:
					break;
				case VariantElementType.BinaryString:
					throw new NotSupportedException();
				case VariantElementType.Dispatch:
				case VariantElementType.ComUnknown:
				{
					ComObject[] array6 = new ComObject[num];
					for (int i = 0; i < num; i++)
					{
						array6[i] = new ComObject(*(IntPtr*)((byte*)((void*)this.variantValue.recordValue.RecordPointer) + (IntPtr)i * (IntPtr)sizeof(IntPtr)));
					}
					return array6;
				}
				case VariantElementType.Bool:
				{
					RawBool[] array7 = new RawBool[num];
					Utilities.Read<RawBool>(this.variantValue.recordValue.RecordPointer, array7, 0, num);
					return Utilities.ConvertToBoolArray(array7);
				}
				case VariantElementType.Byte:
				{
					sbyte[] array8 = new sbyte[num];
					Utilities.Read<sbyte>(this.variantValue.recordValue.RecordPointer, array8, 0, num);
					return array8;
				}
				case VariantElementType.UByte:
				{
					byte[] array9 = new byte[num];
					Utilities.Read<byte>(this.variantValue.recordValue.RecordPointer, array9, 0, num);
					return array9;
				}
				case VariantElementType.UShort:
				{
					ushort[] array10 = new ushort[num];
					Utilities.Read<ushort>(this.variantValue.recordValue.RecordPointer, array10, 0, num);
					return array10;
				}
				case VariantElementType.UInt:
				case VariantElementType.UInt1:
				{
					uint[] array11 = new uint[num];
					Utilities.Read<uint>(this.variantValue.recordValue.RecordPointer, array11, 0, num);
					return array11;
				}
				case VariantElementType.Long:
				{
					long[] array12 = new long[num];
					Utilities.Read<long>(this.variantValue.recordValue.RecordPointer, array12, 0, num);
					return array12;
				}
				case VariantElementType.ULong:
				{
					ulong[] array13 = new ulong[num];
					Utilities.Read<ulong>(this.variantValue.recordValue.RecordPointer, array13, 0, num);
					return array13;
				}
				case VariantElementType.Pointer:
				case VariantElementType.IntPointer:
				{
					IntPtr[] array14 = new IntPtr[num];
					Utilities.Read<IntPtr>(this.variantValue.recordValue.RecordPointer, array14, 0, num);
					return array14;
				}
				case VariantElementType.StringPointer:
				{
					string[] array15 = new string[num];
					for (int j = 0; j < num; j++)
					{
						array15[j] = Marshal.PtrToStringAnsi(*(IntPtr*)((byte*)((void*)this.variantValue.recordValue.RecordPointer) + (IntPtr)j * (IntPtr)sizeof(IntPtr)));
					}
					return array15;
				}
				case VariantElementType.WStringPointer:
				{
					string[] array16 = new string[num];
					for (int k = 0; k < num; k++)
					{
						array16[k] = Marshal.PtrToStringUni(*(IntPtr*)((byte*)((void*)this.variantValue.recordValue.RecordPointer) + (IntPtr)k * (IntPtr)sizeof(IntPtr)));
					}
					return array16;
				}
				default:
					if (elementType == VariantElementType.FileTime)
					{
						DateTime[] array17 = new DateTime[num];
						for (int l = 0; l < num; l++)
						{
							array17[l] = DateTime.FromFileTime(*(long*)((byte*)((void*)this.variantValue.recordValue.RecordPointer) + (IntPtr)l * 8));
						}
						return array17;
					}
					break;
				}
				return null;
			}
			set
			{
				if (value == null)
				{
					this.Type = VariantType.Default;
					this.ElementType = VariantElementType.Null;
					return;
				}
				Type type = value.GetType();
				this.Type = VariantType.Default;
				if (type.GetTypeInfo().IsPrimitive)
				{
					if (type == typeof(byte))
					{
						this.ElementType = VariantElementType.UByte;
						this.variantValue.byteValue = (byte)value;
						return;
					}
					if (type == typeof(sbyte))
					{
						this.ElementType = VariantElementType.Byte;
						this.variantValue.signedByteValue = (sbyte)value;
						return;
					}
					if (type == typeof(int))
					{
						this.ElementType = VariantElementType.Int;
						this.variantValue.intValue = (int)value;
						return;
					}
					if (type == typeof(uint))
					{
						this.ElementType = VariantElementType.UInt;
						this.variantValue.uintValue = (uint)value;
						return;
					}
					if (type == typeof(long))
					{
						this.ElementType = VariantElementType.Long;
						this.variantValue.longValue = (long)value;
						return;
					}
					if (type == typeof(ulong))
					{
						this.ElementType = VariantElementType.ULong;
						this.variantValue.ulongValue = (ulong)value;
						return;
					}
					if (type == typeof(short))
					{
						this.ElementType = VariantElementType.Short;
						this.variantValue.shortValue = (short)value;
						return;
					}
					if (type == typeof(ushort))
					{
						this.ElementType = VariantElementType.UShort;
						this.variantValue.ushortValue = (ushort)value;
						return;
					}
					if (type == typeof(float))
					{
						this.ElementType = VariantElementType.Float;
						this.variantValue.floatValue = (float)value;
						return;
					}
					if (type == typeof(double))
					{
						this.ElementType = VariantElementType.Double;
						this.variantValue.doubleValue = (double)value;
						return;
					}
				}
				else
				{
					if (value is ComObject)
					{
						this.ElementType = VariantElementType.ComUnknown;
						this.variantValue.pointerValue = ((ComObject)value).NativePointer;
						return;
					}
					if (value is DateTime)
					{
						this.ElementType = VariantElementType.FileTime;
						this.variantValue.longValue = ((DateTime)value).ToFileTime();
						return;
					}
					if (value is string)
					{
						this.ElementType = VariantElementType.WStringPointer;
						this.variantValue.pointerValue = Marshal.StringToCoTaskMemUni((string)value);
						return;
					}
				}
				throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "Type [{0}] is not handled", new object[]
				{
					type.Name
				}));
			}
		}

		// Token: 0x040000B6 RID: 182
		private ushort vt;

		// Token: 0x040000B7 RID: 183
		private ushort reserved1;

		// Token: 0x040000B8 RID: 184
		private ushort reserved2;

		// Token: 0x040000B9 RID: 185
		private ushort reserved3;

		// Token: 0x040000BA RID: 186
		private Variant.VariantValue variantValue;

		// Token: 0x02000059 RID: 89
		[StructLayout(LayoutKind.Explicit)]
		private struct VariantValue
		{
			// Token: 0x040000BB RID: 187
			[FieldOffset(0)]
			public byte byteValue;

			// Token: 0x040000BC RID: 188
			[FieldOffset(0)]
			public sbyte signedByteValue;

			// Token: 0x040000BD RID: 189
			[FieldOffset(0)]
			public ushort ushortValue;

			// Token: 0x040000BE RID: 190
			[FieldOffset(0)]
			public short shortValue;

			// Token: 0x040000BF RID: 191
			[FieldOffset(0)]
			public uint uintValue;

			// Token: 0x040000C0 RID: 192
			[FieldOffset(0)]
			public int intValue;

			// Token: 0x040000C1 RID: 193
			[FieldOffset(0)]
			public ulong ulongValue;

			// Token: 0x040000C2 RID: 194
			[FieldOffset(0)]
			public long longValue;

			// Token: 0x040000C3 RID: 195
			[FieldOffset(0)]
			public float floatValue;

			// Token: 0x040000C4 RID: 196
			[FieldOffset(0)]
			public double doubleValue;

			// Token: 0x040000C5 RID: 197
			[FieldOffset(0)]
			public IntPtr pointerValue;

			// Token: 0x040000C6 RID: 198
			[FieldOffset(0)]
			public Variant.VariantValue.CurrencyValue currencyValue;

			// Token: 0x040000C7 RID: 199
			[FieldOffset(0)]
			public Variant.VariantValue.RecordValue recordValue;

			// Token: 0x0200005A RID: 90
			public struct CurrencyLowHigh
			{
				// Token: 0x040000C8 RID: 200
				public uint LowValue;

				// Token: 0x040000C9 RID: 201
				public int HighValue;
			}

			// Token: 0x0200005B RID: 91
			[StructLayout(LayoutKind.Explicit)]
			public struct CurrencyValue
			{
				// Token: 0x040000CA RID: 202
				[FieldOffset(0)]
				public Variant.VariantValue.CurrencyLowHigh LowHigh;

				// Token: 0x040000CB RID: 203
				[FieldOffset(0)]
				public long longValue;
			}

			// Token: 0x0200005C RID: 92
			public struct RecordValue
			{
				// Token: 0x040000CC RID: 204
				public IntPtr RecordInfo;

				// Token: 0x040000CD RID: 205
				public IntPtr RecordPointer;
			}
		}
	}
}
