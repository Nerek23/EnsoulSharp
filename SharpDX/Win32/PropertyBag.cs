using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices;

namespace SharpDX.Win32
{
	// Token: 0x02000053 RID: 83
	public class PropertyBag : ComObject
	{
		// Token: 0x0600024F RID: 591 RVA: 0x00006A87 File Offset: 0x00004C87
		public PropertyBag(IntPtr propertyBagPointer) : base(propertyBagPointer)
		{
		}

		// Token: 0x06000250 RID: 592 RVA: 0x00006A90 File Offset: 0x00004C90
		protected override void NativePointerUpdated(IntPtr oldNativePointer)
		{
			base.NativePointerUpdated(oldNativePointer);
			if (base.NativePointer != IntPtr.Zero)
			{
				this.nativePropertyBag = (PropertyBag.IPropertyBag2)Marshal.GetObjectForIUnknown(base.NativePointer);
				return;
			}
			this.nativePropertyBag = null;
		}

		// Token: 0x06000251 RID: 593 RVA: 0x00006AC9 File Offset: 0x00004CC9
		private void CheckIfInitialized()
		{
			if (this.nativePropertyBag == null)
			{
				throw new InvalidOperationException("This instance is not bound to an unmanaged IPropertyBag2");
			}
		}

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x06000252 RID: 594 RVA: 0x00006AE0 File Offset: 0x00004CE0
		public int Count
		{
			get
			{
				this.CheckIfInitialized();
				int result;
				this.nativePropertyBag.CountProperties(out result);
				return result;
			}
		}

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x06000253 RID: 595 RVA: 0x00006B04 File Offset: 0x00004D04
		public string[] Keys
		{
			get
			{
				this.CheckIfInitialized();
				List<string> list = new List<string>();
				for (int i = 0; i < this.Count; i++)
				{
					PropertyBag.PROPBAG2 propbag;
					int num;
					this.nativePropertyBag.GetPropertyInfo(i, 1, out propbag, out num);
					list.Add(propbag.Name);
				}
				return list.ToArray();
			}
		}

		// Token: 0x06000254 RID: 596 RVA: 0x00006B54 File Offset: 0x00004D54
		public object Get(string name)
		{
			this.CheckIfInitialized();
			PropertyBag.PROPBAG2 propbag = new PropertyBag.PROPBAG2
			{
				Name = name
			};
			object result;
			Result result2;
			if (this.nativePropertyBag.Read(1, ref propbag, IntPtr.Zero, out result, out result2).Failure || result2.Failure)
			{
				throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "Property with name [{0}] is not valid for this instance", new object[]
				{
					name
				}));
			}
			propbag.Dispose();
			return result;
		}

		// Token: 0x06000255 RID: 597 RVA: 0x00006BCB File Offset: 0x00004DCB
		public T1 Get<T1, T2>(PropertyBagKey<T1, T2> propertyKey)
		{
			return (T1)((object)Convert.ChangeType(this.Get(propertyKey.Name), typeof(T1)));
		}

		// Token: 0x06000256 RID: 598 RVA: 0x00006BF0 File Offset: 0x00004DF0
		public void Set(string name, object value)
		{
			this.CheckIfInitialized();
			object obj = this.Get(name);
			value = Convert.ChangeType(value, (obj == null) ? value.GetType() : obj.GetType());
			PropertyBag.PROPBAG2 propbag = new PropertyBag.PROPBAG2
			{
				Name = name
			};
			PropertyBag.IPropertyBag2 propertyBag = this.nativePropertyBag;
			int cProperties = 1;
			object obj2 = value;
			propertyBag.Write(cProperties, ref propbag, ref obj2).CheckError();
			propbag.Dispose();
		}

		// Token: 0x06000257 RID: 599 RVA: 0x00006C58 File Offset: 0x00004E58
		public void Set<T1, T2>(PropertyBagKey<T1, T2> propertyKey, T1 value)
		{
			this.Set(propertyKey.Name, value);
		}

		// Token: 0x040000AB RID: 171
		private PropertyBag.IPropertyBag2 nativePropertyBag;

		// Token: 0x02000054 RID: 84
		[StructLayout(LayoutKind.Sequential, Pack = 1)]
		private struct PROPBAG2 : IDisposable
		{
			// Token: 0x1700003C RID: 60
			// (get) Token: 0x06000258 RID: 600 RVA: 0x00006C6C File Offset: 0x00004E6C
			// (set) Token: 0x06000259 RID: 601 RVA: 0x00006C79 File Offset: 0x00004E79
			public string Name
			{
				get
				{
					return Marshal.PtrToStringUni(this.pstrName);
				}
				set
				{
					this.pstrName = Marshal.StringToCoTaskMemUni(value);
				}
			}

			// Token: 0x0600025A RID: 602 RVA: 0x00006C87 File Offset: 0x00004E87
			public void Dispose()
			{
				if (this.pstrName != IntPtr.Zero)
				{
					Marshal.FreeCoTaskMem(this.pstrName);
					this.pstrName = IntPtr.Zero;
				}
			}

			// Token: 0x040000AC RID: 172
			internal uint type;

			// Token: 0x040000AD RID: 173
			internal ushort vt;

			// Token: 0x040000AE RID: 174
			internal ushort cfType;

			// Token: 0x040000AF RID: 175
			internal IntPtr dwHint;

			// Token: 0x040000B0 RID: 176
			internal IntPtr pstrName;

			// Token: 0x040000B1 RID: 177
			internal Guid clsid;
		}

		// Token: 0x02000055 RID: 85
		[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		[Guid("22F55882-280B-11D0-A8A9-00A0C90C2004")]
		[ComImport]
		private interface IPropertyBag2
		{
			// Token: 0x0600025B RID: 603
			[PreserveSig]
			Result Read([In] int cProperties, [In] ref PropertyBag.PROPBAG2 pPropBag, IntPtr pErrLog, out object pvarValue, out Result phrError);

			// Token: 0x0600025C RID: 604
			[PreserveSig]
			Result Write([In] int cProperties, [In] ref PropertyBag.PROPBAG2 pPropBag, ref object value);

			// Token: 0x0600025D RID: 605
			[PreserveSig]
			Result CountProperties(out int pcProperties);

			// Token: 0x0600025E RID: 606
			[PreserveSig]
			Result GetPropertyInfo([In] int iProperty, [In] int cProperties, out PropertyBag.PROPBAG2 pPropBag, out int pcProperties);

			// Token: 0x0600025F RID: 607
			[PreserveSig]
			Result LoadObject([MarshalAs(UnmanagedType.LPWStr)] [In] string pstrName, [In] uint dwHint, [MarshalAs(UnmanagedType.IUnknown)] [In] object pUnkObject, IntPtr pErrLog);
		}
	}
}
