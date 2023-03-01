using System;

namespace SharpDX
{
	// Token: 0x0200002C RID: 44
	public class ServiceEventArgs : EventArgs
	{
		// Token: 0x0600015B RID: 347 RVA: 0x000049D5 File Offset: 0x00002BD5
		public ServiceEventArgs(Type serviceType, object serviceInstance)
		{
			this.ServiceType = serviceType;
			this.Instance = serviceInstance;
		}

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x0600015C RID: 348 RVA: 0x000049EB File Offset: 0x00002BEB
		// (set) Token: 0x0600015D RID: 349 RVA: 0x000049F3 File Offset: 0x00002BF3
		public Type ServiceType { get; private set; }

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x0600015E RID: 350 RVA: 0x000049FC File Offset: 0x00002BFC
		// (set) Token: 0x0600015F RID: 351 RVA: 0x00004A04 File Offset: 0x00002C04
		public object Instance { get; private set; }
	}
}
