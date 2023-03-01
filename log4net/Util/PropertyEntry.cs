using System;

namespace log4net.Util
{
	// Token: 0x02000027 RID: 39
	public class PropertyEntry
	{
		// Token: 0x17000056 RID: 86
		// (get) Token: 0x0600019A RID: 410 RVA: 0x00005A00 File Offset: 0x00004A00
		// (set) Token: 0x0600019B RID: 411 RVA: 0x00005A08 File Offset: 0x00004A08
		public string Key
		{
			get
			{
				return this.m_key;
			}
			set
			{
				this.m_key = value;
			}
		}

		// Token: 0x17000057 RID: 87
		// (get) Token: 0x0600019C RID: 412 RVA: 0x00005A11 File Offset: 0x00004A11
		// (set) Token: 0x0600019D RID: 413 RVA: 0x00005A19 File Offset: 0x00004A19
		public object Value
		{
			get
			{
				return this.m_value;
			}
			set
			{
				this.m_value = value;
			}
		}

		// Token: 0x0600019E RID: 414 RVA: 0x00005A24 File Offset: 0x00004A24
		public override string ToString()
		{
			string[] array = new string[5];
			array[0] = "PropertyEntry(Key=";
			array[1] = this.m_key;
			array[2] = ", Value=";
			int num = 3;
			object value = this.m_value;
			array[num] = ((value != null) ? value.ToString() : null);
			array[4] = ")";
			return string.Concat(array);
		}

		// Token: 0x0400005A RID: 90
		private string m_key;

		// Token: 0x0400005B RID: 91
		private object m_value;
	}
}
