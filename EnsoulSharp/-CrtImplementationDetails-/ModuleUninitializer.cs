using System;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Security;
using System.Threading;

namespace <CrtImplementationDetails>
{
	// Token: 0x02000175 RID: 373
	internal class ModuleUninitializer : Stack
	{
		// Token: 0x060006C1 RID: 1729 RVA: 0x00010A4C File Offset: 0x0000FE4C
		[SecuritySafeCritical]
		internal void AddHandler(EventHandler handler)
		{
			bool flag = false;
			RuntimeHelpers.PrepareConstrainedRegions();
			try
			{
				RuntimeHelpers.PrepareConstrainedRegions();
				Monitor.Enter(ModuleUninitializer.@lock, ref flag);
				RuntimeHelpers.PrepareDelegate(handler);
				this.Push(handler);
			}
			finally
			{
				if (flag)
				{
					Monitor.Exit(ModuleUninitializer.@lock);
				}
			}
		}

		// Token: 0x060006C3 RID: 1731 RVA: 0x00011040 File Offset: 0x00010440
		[SecuritySafeCritical]
		private ModuleUninitializer()
		{
			EventHandler value = new EventHandler(this.SingletonDomainUnload);
			AppDomain.CurrentDomain.DomainUnload += value;
			AppDomain.CurrentDomain.ProcessExit += value;
		}

		// Token: 0x060006C4 RID: 1732 RVA: 0x00010AAC File Offset: 0x0000FEAC
		[PrePrepareMethod]
		[SecurityCritical]
		private void SingletonDomainUnload(object source, EventArgs arguments)
		{
			bool flag = false;
			RuntimeHelpers.PrepareConstrainedRegions();
			try
			{
				RuntimeHelpers.PrepareConstrainedRegions();
				Monitor.Enter(ModuleUninitializer.@lock, ref flag);
				using (IEnumerator enumerator = this.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						((EventHandler)enumerator.Current)(source, arguments);
					}
				}
			}
			finally
			{
				if (flag)
				{
					Monitor.Exit(ModuleUninitializer.@lock);
				}
			}
		}

		// Token: 0x04000412 RID: 1042
		private static object @lock = new object();

		// Token: 0x04000413 RID: 1043
		internal static ModuleUninitializer _ModuleUninitializer = new ModuleUninitializer();
	}
}
