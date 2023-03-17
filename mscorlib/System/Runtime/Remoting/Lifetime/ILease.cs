using System;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Runtime.Remoting.Lifetime
{
	/// <summary>Defines a lifetime lease object that is used by the remoting lifetime service.</summary>
	// Token: 0x020007F1 RID: 2033
	[ComVisible(true)]
	public interface ILease
	{
		/// <summary>Registers a sponsor for the lease, and renews it by the specified <see cref="T:System.TimeSpan" />.</summary>
		/// <param name="obj">The callback object of the sponsor.</param>
		/// <param name="renewalTime">The length of time to renew the lease by.</param>
		/// <exception cref="T:System.Security.SecurityException">The immediate caller makes the call through a reference to the interface and does not have infrastructure permission.</exception>
		// Token: 0x060057FE RID: 22526
		[SecurityCritical]
		void Register(ISponsor obj, TimeSpan renewalTime);

		/// <summary>Registers a sponsor for the lease without renewing the lease.</summary>
		/// <param name="obj">The callback object of the sponsor.</param>
		/// <exception cref="T:System.Security.SecurityException">The immediate caller makes the call through a reference to the interface and does not have infrastructure permission.</exception>
		// Token: 0x060057FF RID: 22527
		[SecurityCritical]
		void Register(ISponsor obj);

		/// <summary>Removes a sponsor from the sponsor list.</summary>
		/// <param name="obj">The lease sponsor to unregister.</param>
		/// <exception cref="T:System.Security.SecurityException">The immediate caller makes the call through a reference to the interface and does not have infrastructure permission.</exception>
		// Token: 0x06005800 RID: 22528
		[SecurityCritical]
		void Unregister(ISponsor obj);

		/// <summary>Renews a lease for the specified time.</summary>
		/// <param name="renewalTime">The length of time to renew the lease by.</param>
		/// <returns>The new expiration time of the lease.</returns>
		/// <exception cref="T:System.Security.SecurityException">The immediate caller makes the call through a reference to the interface and does not have infrastructure permission.</exception>
		// Token: 0x06005801 RID: 22529
		[SecurityCritical]
		TimeSpan Renew(TimeSpan renewalTime);

		/// <summary>Gets or sets the amount of time by which a call to the remote object renews the <see cref="P:System.Runtime.Remoting.Lifetime.ILease.CurrentLeaseTime" />.</summary>
		/// <returns>The amount of time by which a call to the remote object renews the <see cref="P:System.Runtime.Remoting.Lifetime.ILease.CurrentLeaseTime" />.</returns>
		/// <exception cref="T:System.Security.SecurityException">The immediate caller makes the call through a reference to the interface and does not have infrastructure permission.</exception>
		// Token: 0x17000EAE RID: 3758
		// (get) Token: 0x06005802 RID: 22530
		// (set) Token: 0x06005803 RID: 22531
		TimeSpan RenewOnCallTime { [SecurityCritical] get; [SecurityCritical] set; }

		/// <summary>Gets or sets the amount of time to wait for a sponsor to return with a lease renewal time.</summary>
		/// <returns>The amount of time to wait for a sponsor to return with a lease renewal time.</returns>
		/// <exception cref="T:System.Security.SecurityException">The immediate caller makes the call through a reference to the interface and does not have infrastructure permission.</exception>
		// Token: 0x17000EAF RID: 3759
		// (get) Token: 0x06005804 RID: 22532
		// (set) Token: 0x06005805 RID: 22533
		TimeSpan SponsorshipTimeout { [SecurityCritical] get; [SecurityCritical] set; }

		/// <summary>Gets or sets the initial time for the lease.</summary>
		/// <returns>The initial time for the lease.</returns>
		/// <exception cref="T:System.Security.SecurityException">The immediate caller makes the call through a reference to the interface and does not have infrastructure permission.</exception>
		// Token: 0x17000EB0 RID: 3760
		// (get) Token: 0x06005806 RID: 22534
		// (set) Token: 0x06005807 RID: 22535
		TimeSpan InitialLeaseTime { [SecurityCritical] get; [SecurityCritical] set; }

		/// <summary>Gets the amount of time remaining on the lease.</summary>
		/// <returns>The amount of time remaining on the lease.</returns>
		/// <exception cref="T:System.Security.SecurityException">The immediate caller makes the call through a reference to the interface and does not have infrastructure permission.</exception>
		// Token: 0x17000EB1 RID: 3761
		// (get) Token: 0x06005808 RID: 22536
		TimeSpan CurrentLeaseTime { [SecurityCritical] get; }

		/// <summary>Gets the current <see cref="T:System.Runtime.Remoting.Lifetime.LeaseState" /> of the lease.</summary>
		/// <returns>The current <see cref="T:System.Runtime.Remoting.Lifetime.LeaseState" /> of the lease.</returns>
		/// <exception cref="T:System.Security.SecurityException">The immediate caller makes the call through a reference to the interface and does not have infrastructure permission.</exception>
		// Token: 0x17000EB2 RID: 3762
		// (get) Token: 0x06005809 RID: 22537
		LeaseState CurrentState { [SecurityCritical] get; }
	}
}
