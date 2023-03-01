using System;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;

namespace EnsoulSharp.SDK
{
	// Token: 0x02000005 RID: 5
	[Serializable]
	public class BootstrapConfig
	{
		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000013 RID: 19 RVA: 0x000023F8 File Offset: 0x000005F8
		// (set) Token: 0x06000014 RID: 20 RVA: 0x00002400 File Offset: 0x00000600
		public string ConfigDirectory { get; set; }

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000015 RID: 21 RVA: 0x00002409 File Offset: 0x00000609
		// (set) Token: 0x06000016 RID: 22 RVA: 0x00002411 File Offset: 0x00000611
		public string LogDirectory { get; set; }

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000017 RID: 23 RVA: 0x0000241A File Offset: 0x0000061A
		// (set) Token: 0x06000018 RID: 24 RVA: 0x00002422 File Offset: 0x00000622
		public string Language { get; set; }

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000019 RID: 25 RVA: 0x0000242B File Offset: 0x0000062B
		// (set) Token: 0x0600001A RID: 26 RVA: 0x00002433 File Offset: 0x00000633
		public int ShowMenuPressKey { get; set; }

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x0600001B RID: 27 RVA: 0x0000243C File Offset: 0x0000063C
		// (set) Token: 0x0600001C RID: 28 RVA: 0x00002444 File Offset: 0x00000644
		public int ShowMenuToggleKey { get; set; }

		// Token: 0x0600001D RID: 29 RVA: 0x00002450 File Offset: 0x00000650
		public BootstrapConfig Deserialize(byte[] data)
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				memoryStream.Write(data, 0, data.Length);
				memoryStream.Seek(0L, SeekOrigin.Begin);
				object obj = new BinaryFormatter().Deserialize(memoryStream);
				Type type = obj.GetType();
				Type typeFromHandle = typeof(BootstrapConfig);
				foreach (PropertyInfo propertyInfo in type.GetProperties(BindingFlags.Instance | BindingFlags.Public))
				{
					PropertyInfo property = typeFromHandle.GetProperty(propertyInfo.Name, BindingFlags.Instance | BindingFlags.Public);
					if (property != null)
					{
						property.SetValue(this, propertyInfo.GetValue(obj));
					}
				}
			}
			return this;
		}
	}
}
