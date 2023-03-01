using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using SharpDX.Win32;

namespace SharpDX.WIC
{
	// Token: 0x02000023 RID: 35
	[Guid("30989668-E1C9-4597-B395-458EEDB808DF")]
	public class MetadataQueryReader : ComObject
	{
		// Token: 0x17000042 RID: 66
		// (get) Token: 0x0600016E RID: 366 RVA: 0x00006068 File Offset: 0x00004268
		public IEnumerable<string> Enumerator
		{
			get
			{
				return new ComStringEnumerator(this.GetEnumerator());
			}
		}

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x0600016F RID: 367 RVA: 0x00006075 File Offset: 0x00004275
		public IEnumerable<string> QueryPaths
		{
			get
			{
				foreach (string name in this.Enumerator)
				{
					object obj;
					if (this.TryGetMetadataByName(name, out obj).Success)
					{
						MetadataQueryReader metadataQueryReader = obj as MetadataQueryReader;
						if (metadataQueryReader == null)
						{
							yield return name;
						}
						else
						{
							foreach (string str in metadataQueryReader.QueryPaths)
							{
								yield return name + str;
							}
							IEnumerator<string> enumerator2 = null;
						}
					}
					else
					{
						yield return name;
					}
					name = null;
				}
				IEnumerator<string> enumerator = null;
				yield break;
				yield break;
			}
		}

		// Token: 0x17000044 RID: 68
		// (get) Token: 0x06000170 RID: 368 RVA: 0x00006088 File Offset: 0x00004288
		public unsafe string Location
		{
			get
			{
				int num = 0;
				this.GetLocation(0, IntPtr.Zero, out num);
				if (num == 0)
				{
					return null;
				}
				char* value = stackalloc char[checked(unchecked((UIntPtr)num) * 2)];
				this.GetLocation(num, (IntPtr)((void*)value), out num);
				return new string(value, 0, num - 1);
			}
		}

		// Token: 0x06000171 RID: 369 RVA: 0x000060CC File Offset: 0x000042CC
		public unsafe Result TryGetMetadataByName(string name, out object value)
		{
			value = null;
			byte* ptr = stackalloc byte[(UIntPtr)512];
			Result metadataByName = this.GetMetadataByName(name, (IntPtr)((void*)ptr));
			if (metadataByName.Success)
			{
				Variant* ptr2 = (Variant*)ptr;
				value = ptr2->Value;
				ComObject comObject = value as ComObject;
				if (comObject != null)
				{
					value = comObject.QueryInterfaceOrNull<MetadataQueryReader>();
				}
			}
			return metadataByName;
		}

		// Token: 0x06000172 RID: 370 RVA: 0x0000611C File Offset: 0x0000431C
		public object TryGetMetadataByName(string name)
		{
			object result;
			Result right = this.TryGetMetadataByName(name, out result);
			if (ResultCode.Propertynotfound != right && ResultCode.Propertynotsupported != right)
			{
				right.CheckError();
			}
			return result;
		}

		// Token: 0x06000173 RID: 371 RVA: 0x00006158 File Offset: 0x00004358
		public object GetMetadataByName(string name)
		{
			object result;
			this.TryGetMetadataByName(name, out result).CheckError();
			return result;
		}

		// Token: 0x06000174 RID: 372 RVA: 0x00006178 File Offset: 0x00004378
		public void Dump(TextWriter writer, int level = 0)
		{
			foreach (string text in this.Enumerator)
			{
				object metadataByName = this.GetMetadataByName(text);
				for (int i = 0; i < level; i++)
				{
					writer.Write("    ");
				}
				string arg = (metadataByName is MetadataQueryReader) ? "..." : string.Concat((metadataByName is Array) ? Utilities.Join(",", ((Array)metadataByName).GetEnumerator()) : ((metadataByName is IntPtr) ? string.Format("0x{0:X}", metadataByName) : metadataByName));
				writer.WriteLine("{0} = {1}", text, arg);
				if (metadataByName is MetadataQueryReader)
				{
					((MetadataQueryReader)metadataByName).Dump(writer, level + 1);
				}
			}
		}

		// Token: 0x06000175 RID: 373 RVA: 0x00002A7F File Offset: 0x00000C7F
		public MetadataQueryReader(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000176 RID: 374 RVA: 0x00006258 File Offset: 0x00004458
		public new static explicit operator MetadataQueryReader(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new MetadataQueryReader(nativePtr);
			}
			return null;
		}

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x06000177 RID: 375 RVA: 0x00006270 File Offset: 0x00004470
		public Guid ContainerFormat
		{
			get
			{
				Guid result;
				this.GetContainerFormat(out result);
				return result;
			}
		}

		// Token: 0x06000178 RID: 376 RVA: 0x00006288 File Offset: 0x00004488
		internal unsafe void GetContainerFormat(out Guid guidContainerFormatRef)
		{
			guidContainerFormatRef = default(Guid);
			Result result;
			fixed (Guid* ptr = &guidContainerFormatRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x06000179 RID: 377 RVA: 0x000062D0 File Offset: 0x000044D0
		internal unsafe void GetLocation(int cchMaxLength, IntPtr @namespace, out int cchActualLengthRef)
		{
			Result result;
			fixed (int* ptr = &cchActualLengthRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Void*), this._nativePointer, cchMaxLength, (void*)@namespace, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x0600017A RID: 378 RVA: 0x00006318 File Offset: 0x00004518
		internal unsafe Result GetMetadataByName(string name, IntPtr varValueRef)
		{
			Result result;
			fixed (string text = name)
			{
				char* ptr = text;
				if (ptr != null)
				{
					ptr += RuntimeHelpers.OffsetToStringData / 2;
				}
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, ptr, (void*)varValueRef, *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*)));
			}
			return result;
		}

		// Token: 0x0600017B RID: 379 RVA: 0x00006360 File Offset: 0x00004560
		internal unsafe IntPtr GetEnumerator()
		{
			IntPtr result;
			calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &result, *(*(IntPtr*)this._nativePointer + (IntPtr)6 * (IntPtr)sizeof(void*))).CheckError();
			return result;
		}
	}
}
