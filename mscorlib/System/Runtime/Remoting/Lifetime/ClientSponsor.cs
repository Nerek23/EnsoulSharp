using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;

namespace System.Runtime.Remoting.Lifetime
{
	/// <summary>Provides a default implementation for a lifetime sponsor class.</summary>
	// Token: 0x020007F0 RID: 2032
	[SecurityCritical]
	[ComVisible(true)]
	[SecurityPermission(SecurityAction.InheritanceDemand, Flags = SecurityPermissionFlag.Infrastructure)]
	public class ClientSponsor : MarshalByRefObject, ISponsor
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.Remoting.Lifetime.ClientSponsor" /> class with default values.</summary>
		// Token: 0x060057F4 RID: 22516 RVA: 0x00135162 File Offset: 0x00133362
		public ClientSponsor()
		{
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.Remoting.Lifetime.ClientSponsor" /> class with the renewal time of the sponsored object.</summary>
		/// <param name="renewalTime">The <see cref="T:System.TimeSpan" /> by which to increase the lifetime of the sponsored objects when renewal is requested.</param>
		// Token: 0x060057F5 RID: 22517 RVA: 0x0013518B File Offset: 0x0013338B
		public ClientSponsor(TimeSpan renewalTime)
		{
			this.m_renewalTime = renewalTime;
		}

		/// <summary>Gets or sets the <see cref="T:System.TimeSpan" /> by which to increase the lifetime of the sponsored objects when renewal is requested.</summary>
		/// <returns>The <see cref="T:System.TimeSpan" /> by which to increase the lifetime of the sponsored objects when renewal is requested.</returns>
		// Token: 0x17000EAD RID: 3757
		// (get) Token: 0x060057F6 RID: 22518 RVA: 0x001351BB File Offset: 0x001333BB
		// (set) Token: 0x060057F7 RID: 22519 RVA: 0x001351C3 File Offset: 0x001333C3
		public TimeSpan RenewalTime
		{
			get
			{
				return this.m_renewalTime;
			}
			set
			{
				this.m_renewalTime = value;
			}
		}

		/// <summary>Registers the specified <see cref="T:System.MarshalByRefObject" /> for sponsorship.</summary>
		/// <param name="obj">The object to register for sponsorship with the <see cref="T:System.Runtime.Remoting.Lifetime.ClientSponsor" />.</param>
		/// <returns>
		///   <see langword="true" /> if registration succeeded; otherwise, <see langword="false" />.</returns>
		// Token: 0x060057F8 RID: 22520 RVA: 0x001351CC File Offset: 0x001333CC
		[SecurityCritical]
		public bool Register(MarshalByRefObject obj)
		{
			ILease lease = (ILease)obj.GetLifetimeService();
			if (lease == null)
			{
				return false;
			}
			lease.Register(this);
			Hashtable obj2 = this.sponsorTable;
			lock (obj2)
			{
				this.sponsorTable[obj] = lease;
			}
			return true;
		}

		/// <summary>Unregisters the specified <see cref="T:System.MarshalByRefObject" /> from the list of objects sponsored by the current <see cref="T:System.Runtime.Remoting.Lifetime.ClientSponsor" />.</summary>
		/// <param name="obj">The object to unregister.</param>
		// Token: 0x060057F9 RID: 22521 RVA: 0x0013522C File Offset: 0x0013342C
		[SecurityCritical]
		public void Unregister(MarshalByRefObject obj)
		{
			ILease lease = null;
			Hashtable obj2 = this.sponsorTable;
			lock (obj2)
			{
				lease = (ILease)this.sponsorTable[obj];
			}
			if (lease != null)
			{
				lease.Unregister(this);
			}
		}

		/// <summary>Requests a sponsoring client to renew the lease for the specified object.</summary>
		/// <param name="lease">The lifetime lease of the object that requires lease renewal.</param>
		/// <returns>The additional lease time for the specified object.</returns>
		// Token: 0x060057FA RID: 22522 RVA: 0x00135284 File Offset: 0x00133484
		[SecurityCritical]
		public TimeSpan Renewal(ILease lease)
		{
			return this.m_renewalTime;
		}

		/// <summary>Empties the list objects registered with the current <see cref="T:System.Runtime.Remoting.Lifetime.ClientSponsor" />.</summary>
		// Token: 0x060057FB RID: 22523 RVA: 0x0013528C File Offset: 0x0013348C
		[SecurityCritical]
		public void Close()
		{
			Hashtable obj = this.sponsorTable;
			lock (obj)
			{
				IDictionaryEnumerator enumerator = this.sponsorTable.GetEnumerator();
				while (enumerator.MoveNext())
				{
					((ILease)enumerator.Value).Unregister(this);
				}
				this.sponsorTable.Clear();
			}
		}

		/// <summary>Initializes a new instance of <see cref="T:System.Runtime.Remoting.Lifetime.ClientSponsor" />, providing a lease for the current object.</summary>
		/// <returns>An <see cref="T:System.Runtime.Remoting.Lifetime.ILease" /> for the current object.</returns>
		// Token: 0x060057FC RID: 22524 RVA: 0x001352F8 File Offset: 0x001334F8
		[SecurityCritical]
		public override object InitializeLifetimeService()
		{
			return null;
		}

		/// <summary>Frees the resources of the current <see cref="T:System.Runtime.Remoting.Lifetime.ClientSponsor" /> before the garbage collector reclaims them.</summary>
		// Token: 0x060057FD RID: 22525 RVA: 0x001352FC File Offset: 0x001334FC
		[SecuritySafeCritical]
		~ClientSponsor()
		{
		}

		// Token: 0x040027DF RID: 10207
		private Hashtable sponsorTable = new Hashtable(10);

		// Token: 0x040027E0 RID: 10208
		private TimeSpan m_renewalTime = TimeSpan.FromMinutes(2.0);
	}
}
