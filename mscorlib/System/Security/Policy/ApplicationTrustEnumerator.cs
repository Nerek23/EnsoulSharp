using System;
using System.Collections;
using System.Runtime.InteropServices;

namespace System.Security.Policy
{
	/// <summary>Represents the enumerator for <see cref="T:System.Security.Policy.ApplicationTrust" /> objects in the <see cref="T:System.Security.Policy.ApplicationTrustCollection" /> collection.</summary>
	// Token: 0x0200031B RID: 795
	[ComVisible(true)]
	public sealed class ApplicationTrustEnumerator : IEnumerator
	{
		// Token: 0x0600289F RID: 10399 RVA: 0x00095AF9 File Offset: 0x00093CF9
		private ApplicationTrustEnumerator()
		{
		}

		// Token: 0x060028A0 RID: 10400 RVA: 0x00095B01 File Offset: 0x00093D01
		[SecurityCritical]
		internal ApplicationTrustEnumerator(ApplicationTrustCollection trusts)
		{
			this.m_trusts = trusts;
			this.m_current = -1;
		}

		/// <summary>Gets the current <see cref="T:System.Security.Policy.ApplicationTrust" /> object in the <see cref="T:System.Security.Policy.ApplicationTrustCollection" /> collection.</summary>
		/// <returns>The current <see cref="T:System.Security.Policy.ApplicationTrust" /> in the <see cref="T:System.Security.Policy.ApplicationTrustCollection" />.</returns>
		// Token: 0x17000565 RID: 1381
		// (get) Token: 0x060028A1 RID: 10401 RVA: 0x00095B17 File Offset: 0x00093D17
		public ApplicationTrust Current
		{
			[SecuritySafeCritical]
			get
			{
				return this.m_trusts[this.m_current];
			}
		}

		/// <summary>Gets the current <see cref="T:System.Object" /> in the <see cref="T:System.Security.Policy.ApplicationTrustCollection" /> collection.</summary>
		/// <returns>The current <see cref="T:System.Object" /> in the <see cref="T:System.Security.Policy.ApplicationTrustCollection" />.</returns>
		// Token: 0x17000566 RID: 1382
		// (get) Token: 0x060028A2 RID: 10402 RVA: 0x00095B2A File Offset: 0x00093D2A
		object IEnumerator.Current
		{
			[SecuritySafeCritical]
			get
			{
				return this.m_trusts[this.m_current];
			}
		}

		/// <summary>Moves to the next element in the <see cref="T:System.Security.Policy.ApplicationTrustCollection" /> collection.</summary>
		/// <returns>
		///   <see langword="true" /> if the enumerator was successfully advanced to the next element; <see langword="false" /> if the enumerator has passed the end of the collection.</returns>
		// Token: 0x060028A3 RID: 10403 RVA: 0x00095B3D File Offset: 0x00093D3D
		[SecuritySafeCritical]
		public bool MoveNext()
		{
			if (this.m_current == this.m_trusts.Count - 1)
			{
				return false;
			}
			this.m_current++;
			return true;
		}

		/// <summary>Resets the enumerator to the beginning of the <see cref="T:System.Security.Policy.ApplicationTrustCollection" /> collection.</summary>
		// Token: 0x060028A4 RID: 10404 RVA: 0x00095B65 File Offset: 0x00093D65
		public void Reset()
		{
			this.m_current = -1;
		}

		// Token: 0x04001068 RID: 4200
		[SecurityCritical]
		private ApplicationTrustCollection m_trusts;

		// Token: 0x04001069 RID: 4201
		private int m_current;
	}
}
