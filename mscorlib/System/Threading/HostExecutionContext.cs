using System;
using System.Security;

namespace System.Threading
{
	/// <summary>Encapsulates and propagates the host execution context across threads.</summary>
	// Token: 0x020004CE RID: 1230
	public class HostExecutionContext : IDisposable
	{
		/// <summary>Gets or sets the state of the host execution context.</summary>
		/// <returns>An object representing the host execution context state.</returns>
		// Token: 0x17000901 RID: 2305
		// (get) Token: 0x06003B1E RID: 15134 RVA: 0x000DF541 File Offset: 0x000DD741
		// (set) Token: 0x06003B1F RID: 15135 RVA: 0x000DF549 File Offset: 0x000DD749
		protected internal object State
		{
			get
			{
				return this.state;
			}
			set
			{
				this.state = value;
			}
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Threading.HostExecutionContext" /> class.</summary>
		// Token: 0x06003B20 RID: 15136 RVA: 0x000DF552 File Offset: 0x000DD752
		public HostExecutionContext()
		{
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Threading.HostExecutionContext" /> class using the specified state.</summary>
		/// <param name="state">An object representing the host execution context state.</param>
		// Token: 0x06003B21 RID: 15137 RVA: 0x000DF55A File Offset: 0x000DD75A
		public HostExecutionContext(object state)
		{
			this.state = state;
		}

		/// <summary>Creates a copy of the current host execution context.</summary>
		/// <returns>A <see cref="T:System.Threading.HostExecutionContext" /> object representing the host context for the current thread.</returns>
		// Token: 0x06003B22 RID: 15138 RVA: 0x000DF56C File Offset: 0x000DD76C
		[SecuritySafeCritical]
		public virtual HostExecutionContext CreateCopy()
		{
			object obj = this.state;
			if (this.state is IUnknownSafeHandle)
			{
				obj = ((IUnknownSafeHandle)this.state).Clone();
			}
			return new HostExecutionContext(this.state);
		}

		/// <summary>Releases all resources used by the current instance of the <see cref="T:System.Threading.HostExecutionContext" /> class.</summary>
		// Token: 0x06003B23 RID: 15139 RVA: 0x000DF5A9 File Offset: 0x000DD7A9
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		/// <summary>When overridden in a derived class, releases the unmanaged resources used by the <see cref="T:System.Threading.WaitHandle" />, and optionally releases the managed resources.</summary>
		/// <param name="disposing">
		///   <see langword="true" /> to release both managed and unmanaged resources; <see langword="false" /> to release only unmanaged resources.</param>
		// Token: 0x06003B24 RID: 15140 RVA: 0x000DF5B8 File Offset: 0x000DD7B8
		public virtual void Dispose(bool disposing)
		{
		}

		// Token: 0x040018E0 RID: 6368
		private object state;
	}
}
