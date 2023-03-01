using System;
using System.Collections;
using System.Reflection;
using log4net.Util;

namespace log4net.Core
{
	// Token: 0x020000BC RID: 188
	[Serializable]
	public class MethodItem
	{
		// Token: 0x06000563 RID: 1379 RVA: 0x0001168F File Offset: 0x0001068F
		public MethodItem()
		{
			this.m_name = "?";
			this.m_parameters = new string[0];
		}

		// Token: 0x06000564 RID: 1380 RVA: 0x000116AE File Offset: 0x000106AE
		public MethodItem(string name) : this()
		{
			this.m_name = name;
		}

		// Token: 0x06000565 RID: 1381 RVA: 0x000116BD File Offset: 0x000106BD
		public MethodItem(string name, string[] parameters) : this(name)
		{
			this.m_parameters = parameters;
		}

		// Token: 0x06000566 RID: 1382 RVA: 0x000116CD File Offset: 0x000106CD
		public MethodItem(MethodBase methodBase) : this(methodBase.Name, MethodItem.GetMethodParameterNames(methodBase))
		{
		}

		// Token: 0x06000567 RID: 1383 RVA: 0x000116E4 File Offset: 0x000106E4
		private static string[] GetMethodParameterNames(MethodBase methodBase)
		{
			ArrayList arrayList = new ArrayList();
			try
			{
				ParameterInfo[] parameters = methodBase.GetParameters();
				int upperBound = parameters.GetUpperBound(0);
				for (int i = 0; i <= upperBound; i++)
				{
					ArrayList arrayList2 = arrayList;
					Type parameterType = parameters[i].ParameterType;
					arrayList2.Add(((parameterType != null) ? parameterType.ToString() : null) + " " + parameters[i].Name);
				}
			}
			catch (Exception exception)
			{
				LogLog.Error(MethodItem.declaringType, "An exception ocurred while retreiving method parameters.", exception);
			}
			return (string[])arrayList.ToArray(typeof(string));
		}

		// Token: 0x17000101 RID: 257
		// (get) Token: 0x06000568 RID: 1384 RVA: 0x0001177C File Offset: 0x0001077C
		public string Name
		{
			get
			{
				return this.m_name;
			}
		}

		// Token: 0x17000102 RID: 258
		// (get) Token: 0x06000569 RID: 1385 RVA: 0x00011784 File Offset: 0x00010784
		public string[] Parameters
		{
			get
			{
				return this.m_parameters;
			}
		}

		// Token: 0x0400018D RID: 397
		private readonly string m_name;

		// Token: 0x0400018E RID: 398
		private readonly string[] m_parameters;

		// Token: 0x0400018F RID: 399
		private static readonly Type declaringType = typeof(MethodItem);

		// Token: 0x04000190 RID: 400
		private const string NA = "?";
	}
}
