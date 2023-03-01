using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace SharpDX.Direct2D1
{
	// Token: 0x020001B3 RID: 435
	internal class CustomEffectFactory
	{
		// Token: 0x0600085B RID: 2139 RVA: 0x000182A2 File Offset: 0x000164A2
		public CustomEffectFactory(CustomEffectFactoryDelegate factory, Type customEffectType) : this(factory, customEffectType, Utilities.GetGuidFromType(customEffectType))
		{
		}

		// Token: 0x0600085C RID: 2140 RVA: 0x000182B4 File Offset: 0x000164B4
		public CustomEffectFactory(CustomEffectFactoryDelegate factory, Type customEffectType, Guid effectId)
		{
			this.customEffectType = customEffectType;
			this.Guid = effectId;
			this.Factory = factory;
			this.callback = new CustomEffectFactory.CreateCustomEffectDelegate(this.CreateCustomEffectImpl);
			this.NativePointer = Marshal.GetFunctionPointerForDelegate(this.callback);
			this.InitializeBindings();
			this.InitializeXml();
		}

		// Token: 0x17000141 RID: 321
		// (get) Token: 0x0600085D RID: 2141 RVA: 0x0001830B File Offset: 0x0001650B
		// (set) Token: 0x0600085E RID: 2142 RVA: 0x00018313 File Offset: 0x00016513
		public Guid Guid { get; private set; }

		// Token: 0x17000142 RID: 322
		// (get) Token: 0x0600085F RID: 2143 RVA: 0x0001831C File Offset: 0x0001651C
		// (set) Token: 0x06000860 RID: 2144 RVA: 0x00018324 File Offset: 0x00016524
		public CustomEffectFactoryDelegate Factory { get; private set; }

		// Token: 0x17000143 RID: 323
		// (get) Token: 0x06000861 RID: 2145 RVA: 0x0001832D File Offset: 0x0001652D
		// (set) Token: 0x06000862 RID: 2146 RVA: 0x00018335 File Offset: 0x00016535
		public IntPtr NativePointer { get; private set; }

		// Token: 0x17000144 RID: 324
		// (get) Token: 0x06000863 RID: 2147 RVA: 0x0001833E File Offset: 0x0001653E
		// (set) Token: 0x06000864 RID: 2148 RVA: 0x00018346 File Offset: 0x00016546
		public PropertyBinding[] Bindings { get; private set; }

		// Token: 0x06000865 RID: 2149 RVA: 0x0001834F File Offset: 0x0001654F
		public string ToXml()
		{
			return string.Format("<?xml version='1.0'?>\r\n{0}", this.xml.ToString(CustomEffectFactory.SaveOptions.None));
		}

		// Token: 0x06000866 RID: 2150 RVA: 0x00018368 File Offset: 0x00016568
		private void InitializeBindings()
		{
			List<PropertyBinding> list = new List<PropertyBinding>();
			foreach (PropertyInfo propertyInfo in this.customEffectType.GetTypeInfo().DeclaredProperties)
			{
				PropertyBinding propertyBinding = PropertyBinding.Get(this.customEffectType, propertyInfo);
				if (propertyBinding != null)
				{
					list.Add(propertyBinding);
				}
			}
			list.Sort((PropertyBinding left, PropertyBinding right) => left.Attribute.Order.CompareTo(right.Attribute.Order));
			this.Bindings = list.ToArray();
		}

		// Token: 0x06000867 RID: 2151 RVA: 0x00018408 File Offset: 0x00016608
		private static CustomEffectFactory.XElement CreateXmlProperty(string name, string type, string value = null)
		{
			CustomEffectFactory.XElement xelement = new CustomEffectFactory.XElement("Property");
			xelement.SetAttributeValue("name", name);
			xelement.SetAttributeValue("type", type);
			if (value != null)
			{
				xelement.SetAttributeValue("value", value);
			}
			return xelement;
		}

		// Token: 0x06000868 RID: 2152 RVA: 0x00018448 File Offset: 0x00016648
		private void InitializeXml()
		{
			this.xml = new CustomEffectFactory.XDocument();
			CustomEffectFactory.XElement xelement = new CustomEffectFactory.XElement("Effect");
			this.xml.Add(xelement);
			TypeInfo typeInfo = this.customEffectType.GetTypeInfo();
			CustomEffectAttribute customAttribute = Utilities.GetCustomAttribute<CustomEffectAttribute>(typeInfo, true);
			xelement.Add(CustomEffectFactory.CreateXmlProperty("DisplayName", "string", (customAttribute != null) ? customAttribute.DisplayName : typeInfo.Name));
			xelement.Add(CustomEffectFactory.CreateXmlProperty("Author", "string", (customAttribute != null) ? customAttribute.Author : string.Empty));
			xelement.Add(CustomEffectFactory.CreateXmlProperty("Category", "string", (customAttribute != null) ? customAttribute.Category : string.Empty));
			xelement.Add(CustomEffectFactory.CreateXmlProperty("Description", "string", (customAttribute != null) ? customAttribute.Description : string.Empty));
			CustomEffectFactory.XElement xelement2 = new CustomEffectFactory.XElement("Inputs");
			foreach (CustomEffectInputAttribute customEffectInputAttribute in Utilities.GetCustomAttributes<CustomEffectInputAttribute>(typeInfo, true))
			{
				CustomEffectFactory.XElement xelement3 = new CustomEffectFactory.XElement("Input");
				xelement3.SetAttributeValue("name", customEffectInputAttribute.Input);
				xelement2.Add(xelement3);
			}
			xelement.Add(xelement2);
			foreach (PropertyBinding propertyBinding in this.Bindings)
			{
				CustomEffectFactory.XElement xelement4 = CustomEffectFactory.CreateXmlProperty(propertyBinding.PropertyName, propertyBinding.TypeName, null);
				xelement4.Add(CustomEffectFactory.CreateXmlProperty("DisplayName", "string", propertyBinding.PropertyName));
				xelement4.Add(CustomEffectFactory.CreateXmlProperty("Min", propertyBinding.TypeName, (propertyBinding.Attribute.Min != null) ? propertyBinding.Attribute.Min.ToString() : string.Empty));
				xelement4.Add(CustomEffectFactory.CreateXmlProperty("Max", propertyBinding.TypeName, (propertyBinding.Attribute.Max != null) ? propertyBinding.Attribute.Max.ToString() : string.Empty));
				xelement4.Add(CustomEffectFactory.CreateXmlProperty("Default", propertyBinding.TypeName, (propertyBinding.Attribute.Default != null) ? propertyBinding.Attribute.Default.ToString() : string.Empty));
				xelement.Add(xelement4);
			}
		}

		// Token: 0x06000869 RID: 2153 RVA: 0x000186B8 File Offset: 0x000168B8
		private int CreateCustomEffectImpl(out IntPtr nativeCustomEffectPtr)
		{
			nativeCustomEffectPtr = IntPtr.Zero;
			try
			{
				CustomEffect customEffect = this.Factory();
				nativeCustomEffectPtr = CustomEffectShadow.ToIntPtr(customEffect);
			}
			catch (SharpDXException ex)
			{
				return ex.ResultCode.Code;
			}
			catch (Exception)
			{
				return Result.Fail.Code;
			}
			return Result.Ok.Code;
		}

		// Token: 0x04000600 RID: 1536
		private Type customEffectType;

		// Token: 0x04000601 RID: 1537
		private CustomEffectFactory.CreateCustomEffectDelegate callback;

		// Token: 0x04000602 RID: 1538
		private CustomEffectFactory.XDocument xml;

		// Token: 0x020001B4 RID: 436
		// (Invoke) Token: 0x0600086B RID: 2155
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate int CreateCustomEffectDelegate(out IntPtr nativeCustomEffectPtr);

		// Token: 0x020001B5 RID: 437
		private enum SaveOptions
		{
			// Token: 0x04000608 RID: 1544
			None
		}

		// Token: 0x020001B6 RID: 438
		private class XNode
		{
			// Token: 0x17000145 RID: 325
			// (get) Token: 0x0600086E RID: 2158 RVA: 0x0001872C File Offset: 0x0001692C
			public bool HasChildren
			{
				get
				{
					return this.nodes.Count > 0;
				}
			}

			// Token: 0x17000146 RID: 326
			// (get) Token: 0x0600086F RID: 2159 RVA: 0x0001873C File Offset: 0x0001693C
			public IEnumerable<CustomEffectFactory.XNode> Children
			{
				get
				{
					return this.nodes;
				}
			}

			// Token: 0x06000870 RID: 2160 RVA: 0x00018744 File Offset: 0x00016944
			public void Add(CustomEffectFactory.XNode node)
			{
				this.nodes.Add(node);
			}

			// Token: 0x06000871 RID: 2161 RVA: 0x00018752 File Offset: 0x00016952
			public override string ToString()
			{
				return this.ToString(CustomEffectFactory.SaveOptions.None);
			}

			// Token: 0x06000872 RID: 2162 RVA: 0x0001875C File Offset: 0x0001695C
			public string ToString(CustomEffectFactory.SaveOptions options)
			{
				StringBuilder stringBuilder = new StringBuilder();
				this.ToString(stringBuilder);
				return stringBuilder.ToString();
			}

			// Token: 0x06000873 RID: 2163 RVA: 0x0001877C File Offset: 0x0001697C
			protected virtual void ToString(StringBuilder builder)
			{
				foreach (CustomEffectFactory.XNode xnode in this.Children)
				{
					xnode.ToString(builder);
				}
			}

			// Token: 0x04000609 RID: 1545
			private List<CustomEffectFactory.XNode> nodes = new List<CustomEffectFactory.XNode>();
		}

		// Token: 0x020001B7 RID: 439
		private class XDocument : CustomEffectFactory.XNode
		{
		}

		// Token: 0x020001B8 RID: 440
		private class XElement : CustomEffectFactory.XNode
		{
			// Token: 0x06000876 RID: 2166 RVA: 0x000187E3 File Offset: 0x000169E3
			public XElement()
			{
			}

			// Token: 0x06000877 RID: 2167 RVA: 0x000187F6 File Offset: 0x000169F6
			public XElement(string name)
			{
				this.Name = name;
			}

			// Token: 0x17000147 RID: 327
			// (get) Token: 0x06000878 RID: 2168 RVA: 0x00018810 File Offset: 0x00016A10
			// (set) Token: 0x06000879 RID: 2169 RVA: 0x00018818 File Offset: 0x00016A18
			public string Name { get; set; }

			// Token: 0x0600087A RID: 2170 RVA: 0x00018821 File Offset: 0x00016A21
			public void SetAttributeValue(string name, object value)
			{
				this.attributes.Add(new CustomEffectFactory.XElementAttribute(name, value));
			}

			// Token: 0x0600087B RID: 2171 RVA: 0x00018838 File Offset: 0x00016A38
			protected override void ToString(StringBuilder builder)
			{
				builder.AppendFormat("<{0}", this.Name);
				if (this.attributes.Count > 0)
				{
					foreach (CustomEffectFactory.XElementAttribute xelementAttribute in this.attributes)
					{
						builder.Append(" ");
						xelementAttribute.ToString(builder);
					}
				}
				if (base.HasChildren)
				{
					builder.AppendLine(">");
					base.ToString(builder);
					builder.AppendFormat("</{0}>", this.Name);
					builder.AppendLine();
					return;
				}
				builder.AppendLine("/>");
			}

			// Token: 0x0400060A RID: 1546
			private List<CustomEffectFactory.XElementAttribute> attributes = new List<CustomEffectFactory.XElementAttribute>();
		}

		// Token: 0x020001B9 RID: 441
		private class XElementAttribute
		{
			// Token: 0x0600087C RID: 2172 RVA: 0x000067AA File Offset: 0x000049AA
			public XElementAttribute()
			{
			}

			// Token: 0x0600087D RID: 2173 RVA: 0x000188F8 File Offset: 0x00016AF8
			public XElementAttribute(string name, object value)
			{
				this.Name = name;
				this.Value = value;
			}

			// Token: 0x17000148 RID: 328
			// (get) Token: 0x0600087E RID: 2174 RVA: 0x0001890E File Offset: 0x00016B0E
			// (set) Token: 0x0600087F RID: 2175 RVA: 0x00018916 File Offset: 0x00016B16
			public string Name { get; set; }

			// Token: 0x17000149 RID: 329
			// (get) Token: 0x06000880 RID: 2176 RVA: 0x0001891F File Offset: 0x00016B1F
			// (set) Token: 0x06000881 RID: 2177 RVA: 0x00018927 File Offset: 0x00016B27
			public object Value { get; set; }

			// Token: 0x06000882 RID: 2178 RVA: 0x00018930 File Offset: 0x00016B30
			public void ToString(StringBuilder builder)
			{
				builder.AppendFormat("{0}='{1}'", this.Name, this.Value);
			}
		}
	}
}
