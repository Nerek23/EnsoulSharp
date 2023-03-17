using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Security.Permissions;

namespace System.Security.Policy
{
	/// <summary>Provides the Authenticode X.509v3 digital signature of a code assembly as evidence for policy evaluation. This class cannot be inherited.</summary>
	// Token: 0x0200034A RID: 842
	[ComVisible(true)]
	[Serializable]
	public sealed class Publisher : EvidenceBase, IIdentityPermissionFactory
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Security.Policy.Publisher" /> class with the Authenticode X.509v3 certificate containing the publisher's public key.</summary>
		/// <param name="cert">An <see cref="T:System.Security.Cryptography.X509Certificates.X509Certificate" /> that contains the software publisher's public key.</param>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="cert" /> parameter is <see langword="null" />.</exception>
		// Token: 0x06002ADE RID: 10974 RVA: 0x0009F42C File Offset: 0x0009D62C
		public Publisher(X509Certificate cert)
		{
			if (cert == null)
			{
				throw new ArgumentNullException("cert");
			}
			this.m_cert = cert;
		}

		/// <summary>Creates an identity permission that corresponds to the current instance of the <see cref="T:System.Security.Policy.Publisher" /> class.</summary>
		/// <param name="evidence">The <see cref="T:System.Security.Policy.Evidence" /> from which to construct the identity permission.</param>
		/// <returns>A <see cref="T:System.Security.Permissions.PublisherIdentityPermission" /> for the specified <see cref="T:System.Security.Policy.Publisher" />.</returns>
		// Token: 0x06002ADF RID: 10975 RVA: 0x0009F449 File Offset: 0x0009D649
		public IPermission CreateIdentityPermission(Evidence evidence)
		{
			return new PublisherIdentityPermission(this.m_cert);
		}

		/// <summary>Compares the current <see cref="T:System.Security.Policy.Publisher" /> to the specified object for equivalence.</summary>
		/// <param name="o">The <see cref="T:System.Security.Policy.Publisher" /> to test for equivalence with the current object.</param>
		/// <returns>
		///   <see langword="true" /> if the two instances of the <see cref="T:System.Security.Policy.Publisher" /> class are equal; otherwise, <see langword="false" />.</returns>
		/// <exception cref="T:System.ArgumentException">The <paramref name="o" /> parameter is not a <see cref="T:System.Security.Policy.Publisher" /> object.</exception>
		// Token: 0x06002AE0 RID: 10976 RVA: 0x0009F458 File Offset: 0x0009D658
		public override bool Equals(object o)
		{
			Publisher publisher = o as Publisher;
			return publisher != null && Publisher.PublicKeyEquals(this.m_cert, publisher.m_cert);
		}

		// Token: 0x06002AE1 RID: 10977 RVA: 0x0009F484 File Offset: 0x0009D684
		internal static bool PublicKeyEquals(X509Certificate cert1, X509Certificate cert2)
		{
			if (cert1 == null)
			{
				return cert2 == null;
			}
			if (cert2 == null)
			{
				return false;
			}
			byte[] publicKey = cert1.GetPublicKey();
			string keyAlgorithm = cert1.GetKeyAlgorithm();
			byte[] keyAlgorithmParameters = cert1.GetKeyAlgorithmParameters();
			byte[] publicKey2 = cert2.GetPublicKey();
			string keyAlgorithm2 = cert2.GetKeyAlgorithm();
			byte[] keyAlgorithmParameters2 = cert2.GetKeyAlgorithmParameters();
			int num = publicKey.Length;
			if (num != publicKey2.Length)
			{
				return false;
			}
			for (int i = 0; i < num; i++)
			{
				if (publicKey[i] != publicKey2[i])
				{
					return false;
				}
			}
			if (!keyAlgorithm.Equals(keyAlgorithm2))
			{
				return false;
			}
			num = keyAlgorithmParameters.Length;
			if (keyAlgorithmParameters2.Length != num)
			{
				return false;
			}
			for (int j = 0; j < num; j++)
			{
				if (keyAlgorithmParameters[j] != keyAlgorithmParameters2[j])
				{
					return false;
				}
			}
			return true;
		}

		/// <summary>Gets the hash code of the current <see cref="P:System.Security.Policy.Publisher.Certificate" />.</summary>
		/// <returns>The hash code of the current <see cref="P:System.Security.Policy.Publisher.Certificate" />.</returns>
		// Token: 0x06002AE2 RID: 10978 RVA: 0x0009F52F File Offset: 0x0009D72F
		public override int GetHashCode()
		{
			return this.m_cert.GetHashCode();
		}

		/// <summary>Gets the publisher's Authenticode X.509v3 certificate.</summary>
		/// <returns>The publisher's <see cref="T:System.Security.Cryptography.X509Certificates.X509Certificate" />.</returns>
		// Token: 0x170005C5 RID: 1477
		// (get) Token: 0x06002AE3 RID: 10979 RVA: 0x0009F53C File Offset: 0x0009D73C
		public X509Certificate Certificate
		{
			get
			{
				return new X509Certificate(this.m_cert);
			}
		}

		/// <summary>Creates a new object that is a copy of the current instance.</summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		// Token: 0x06002AE4 RID: 10980 RVA: 0x0009F549 File Offset: 0x0009D749
		public override EvidenceBase Clone()
		{
			return new Publisher(this.m_cert);
		}

		/// <summary>Creates an equivalent copy of the <see cref="T:System.Security.Policy.Publisher" />.</summary>
		/// <returns>A new, identical copy of the <see cref="T:System.Security.Policy.Publisher" />.</returns>
		// Token: 0x06002AE5 RID: 10981 RVA: 0x0009F556 File Offset: 0x0009D756
		public object Copy()
		{
			return this.Clone();
		}

		// Token: 0x06002AE6 RID: 10982 RVA: 0x0009F560 File Offset: 0x0009D760
		internal SecurityElement ToXml()
		{
			SecurityElement securityElement = new SecurityElement("System.Security.Policy.Publisher");
			securityElement.AddAttribute("version", "1");
			securityElement.AddChild(new SecurityElement("X509v3Certificate", (this.m_cert != null) ? this.m_cert.GetRawCertDataString() : ""));
			return securityElement;
		}

		/// <summary>Returns a string representation of the current <see cref="T:System.Security.Policy.Publisher" />.</summary>
		/// <returns>A representation of the current <see cref="T:System.Security.Policy.Publisher" />.</returns>
		// Token: 0x06002AE7 RID: 10983 RVA: 0x0009F5B3 File Offset: 0x0009D7B3
		public override string ToString()
		{
			return this.ToXml().ToString();
		}

		// Token: 0x06002AE8 RID: 10984 RVA: 0x0009F5C0 File Offset: 0x0009D7C0
		internal object Normalize()
		{
			return new MemoryStream(this.m_cert.GetRawCertData())
			{
				Position = 0L
			};
		}

		// Token: 0x040010FE RID: 4350
		private X509Certificate m_cert;
	}
}
