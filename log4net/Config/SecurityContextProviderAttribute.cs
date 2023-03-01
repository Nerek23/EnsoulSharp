using System;
using System.Reflection;
using log4net.Core;
using log4net.Repository;
using log4net.Util;

namespace log4net.Config
{
	// Token: 0x020000CD RID: 205
	[AttributeUsage(AttributeTargets.Assembly)]
	[Serializable]
	public sealed class SecurityContextProviderAttribute : ConfiguratorAttribute
	{
		// Token: 0x060005B6 RID: 1462 RVA: 0x00011F3D File Offset: 0x00010F3D
		public SecurityContextProviderAttribute(Type providerType) : base(100)
		{
			this.m_providerType = providerType;
		}

		// Token: 0x17000110 RID: 272
		// (get) Token: 0x060005B7 RID: 1463 RVA: 0x00011F4E File Offset: 0x00010F4E
		// (set) Token: 0x060005B8 RID: 1464 RVA: 0x00011F56 File Offset: 0x00010F56
		public Type ProviderType
		{
			get
			{
				return this.m_providerType;
			}
			set
			{
				this.m_providerType = value;
			}
		}

		// Token: 0x060005B9 RID: 1465 RVA: 0x00011F60 File Offset: 0x00010F60
		public override void Configure(Assembly sourceAssembly, ILoggerRepository targetRepository)
		{
			if (this.m_providerType == null)
			{
				LogLog.Error(SecurityContextProviderAttribute.declaringType, "Attribute specified on assembly [" + sourceAssembly.FullName + "] with null ProviderType.");
				return;
			}
			LogLog.Debug(SecurityContextProviderAttribute.declaringType, "Creating provider of type [" + this.m_providerType.FullName + "]");
			SecurityContextProvider securityContextProvider = Activator.CreateInstance(this.m_providerType) as SecurityContextProvider;
			if (securityContextProvider == null)
			{
				LogLog.Error(SecurityContextProviderAttribute.declaringType, "Failed to create SecurityContextProvider instance of type [" + this.m_providerType.Name + "].");
				return;
			}
			SecurityContextProvider.DefaultProvider = securityContextProvider;
		}

		// Token: 0x040001A6 RID: 422
		private Type m_providerType;

		// Token: 0x040001A7 RID: 423
		private static readonly Type declaringType = typeof(SecurityContextProviderAttribute);
	}
}
