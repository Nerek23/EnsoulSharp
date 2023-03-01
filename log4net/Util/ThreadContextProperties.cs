using System;

namespace log4net.Util
{
	// Token: 0x02000030 RID: 48
	public sealed class ThreadContextProperties : ContextPropertiesBase
	{
		// Token: 0x060001FF RID: 511 RVA: 0x000068ED File Offset: 0x000058ED
		internal ThreadContextProperties()
		{
		}

		// Token: 0x17000073 RID: 115
		public override object this[string key]
		{
			get
			{
				if (ThreadContextProperties._dictionary != null)
				{
					return ThreadContextProperties._dictionary[key];
				}
				return null;
			}
			set
			{
				this.GetProperties(true)[key] = value;
			}
		}

		// Token: 0x06000202 RID: 514 RVA: 0x0000691B File Offset: 0x0000591B
		public void Remove(string key)
		{
			if (ThreadContextProperties._dictionary != null)
			{
				ThreadContextProperties._dictionary.Remove(key);
			}
		}

		// Token: 0x06000203 RID: 515 RVA: 0x0000692F File Offset: 0x0000592F
		public string[] GetKeys()
		{
			if (ThreadContextProperties._dictionary != null)
			{
				return ThreadContextProperties._dictionary.GetKeys();
			}
			return null;
		}

		// Token: 0x06000204 RID: 516 RVA: 0x00006944 File Offset: 0x00005944
		public void Clear()
		{
			if (ThreadContextProperties._dictionary != null)
			{
				ThreadContextProperties._dictionary.Clear();
			}
		}

		// Token: 0x06000205 RID: 517 RVA: 0x00006957 File Offset: 0x00005957
		internal PropertiesDictionary GetProperties(bool create)
		{
			if (ThreadContextProperties._dictionary == null && create)
			{
				ThreadContextProperties._dictionary = new PropertiesDictionary();
			}
			return ThreadContextProperties._dictionary;
		}

		// Token: 0x0400006E RID: 110
		[ThreadStatic]
		private static PropertiesDictionary _dictionary;
	}
}
