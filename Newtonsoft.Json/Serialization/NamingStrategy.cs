using System;
using System.Runtime.CompilerServices;

namespace Newtonsoft.Json.Serialization
{
	// Token: 0x0200009C RID: 156
	[NullableContext(1)]
	[Nullable(0)]
	public abstract class NamingStrategy
	{
		// Token: 0x17000161 RID: 353
		// (get) Token: 0x0600081F RID: 2079 RVA: 0x00023AE4 File Offset: 0x00021CE4
		// (set) Token: 0x06000820 RID: 2080 RVA: 0x00023AEC File Offset: 0x00021CEC
		public bool ProcessDictionaryKeys { get; set; }

		// Token: 0x17000162 RID: 354
		// (get) Token: 0x06000821 RID: 2081 RVA: 0x00023AF5 File Offset: 0x00021CF5
		// (set) Token: 0x06000822 RID: 2082 RVA: 0x00023AFD File Offset: 0x00021CFD
		public bool ProcessExtensionDataNames { get; set; }

		// Token: 0x17000163 RID: 355
		// (get) Token: 0x06000823 RID: 2083 RVA: 0x00023B06 File Offset: 0x00021D06
		// (set) Token: 0x06000824 RID: 2084 RVA: 0x00023B0E File Offset: 0x00021D0E
		public bool OverrideSpecifiedNames { get; set; }

		// Token: 0x06000825 RID: 2085 RVA: 0x00023B17 File Offset: 0x00021D17
		public virtual string GetPropertyName(string name, bool hasSpecifiedName)
		{
			if (hasSpecifiedName && !this.OverrideSpecifiedNames)
			{
				return name;
			}
			return this.ResolvePropertyName(name);
		}

		// Token: 0x06000826 RID: 2086 RVA: 0x00023B2D File Offset: 0x00021D2D
		public virtual string GetExtensionDataName(string name)
		{
			if (!this.ProcessExtensionDataNames)
			{
				return name;
			}
			return this.ResolvePropertyName(name);
		}

		// Token: 0x06000827 RID: 2087 RVA: 0x00023B40 File Offset: 0x00021D40
		public virtual string GetDictionaryKey(string key)
		{
			if (!this.ProcessDictionaryKeys)
			{
				return key;
			}
			return this.ResolvePropertyName(key);
		}

		// Token: 0x06000828 RID: 2088
		protected abstract string ResolvePropertyName(string name);

		// Token: 0x06000829 RID: 2089 RVA: 0x00023B54 File Offset: 0x00021D54
		public override int GetHashCode()
		{
			return ((base.GetType().GetHashCode() * 397 ^ this.ProcessDictionaryKeys.GetHashCode()) * 397 ^ this.ProcessExtensionDataNames.GetHashCode()) * 397 ^ this.OverrideSpecifiedNames.GetHashCode();
		}

		// Token: 0x0600082A RID: 2090 RVA: 0x00023BAB File Offset: 0x00021DAB
		public override bool Equals(object obj)
		{
			return this.Equals(obj as NamingStrategy);
		}

		// Token: 0x0600082B RID: 2091 RVA: 0x00023BBC File Offset: 0x00021DBC
		[NullableContext(2)]
		protected bool Equals(NamingStrategy other)
		{
			return other != null && (base.GetType() == other.GetType() && this.ProcessDictionaryKeys == other.ProcessDictionaryKeys && this.ProcessExtensionDataNames == other.ProcessExtensionDataNames) && this.OverrideSpecifiedNames == other.OverrideSpecifiedNames;
		}
	}
}
