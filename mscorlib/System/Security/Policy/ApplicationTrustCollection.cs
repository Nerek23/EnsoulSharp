using System;
using System.Collections;
using System.Deployment.Internal.Isolation;
using System.Deployment.Internal.Isolation.Manifest;
using System.Runtime.InteropServices;
using System.Threading;

namespace System.Security.Policy
{
	/// <summary>Represents a collection of <see cref="T:System.Security.Policy.ApplicationTrust" /> objects. This class cannot be inherited.</summary>
	// Token: 0x0200031A RID: 794
	[SecurityCritical]
	[ComVisible(true)]
	public sealed class ApplicationTrustCollection : ICollection, IEnumerable
	{
		// Token: 0x1700055E RID: 1374
		// (get) Token: 0x06002886 RID: 10374 RVA: 0x00095403 File Offset: 0x00093603
		private static StoreApplicationReference InstallReference
		{
			get
			{
				if (ApplicationTrustCollection.s_installReference == null)
				{
					Interlocked.CompareExchange(ref ApplicationTrustCollection.s_installReference, new StoreApplicationReference(IsolationInterop.GUID_SXS_INSTALL_REFERENCE_SCHEME_OPAQUESTRING, "{60051b8f-4f12-400a-8e50-dd05ebd438d1}", null), null);
				}
				return (StoreApplicationReference)ApplicationTrustCollection.s_installReference;
			}
		}

		// Token: 0x1700055F RID: 1375
		// (get) Token: 0x06002887 RID: 10375 RVA: 0x00095438 File Offset: 0x00093638
		private ArrayList AppTrusts
		{
			[SecurityCritical]
			get
			{
				if (this.m_appTrusts == null)
				{
					ArrayList arrayList = new ArrayList();
					if (this.m_storeBounded)
					{
						this.RefreshStorePointer();
						StoreDeploymentMetadataEnumeration storeDeploymentMetadataEnumeration = this.m_pStore.EnumInstallerDeployments(IsolationInterop.GUID_SXS_INSTALL_REFERENCE_SCHEME_OPAQUESTRING, "{60051b8f-4f12-400a-8e50-dd05ebd438d1}", "ApplicationTrust", null);
						foreach (object obj in storeDeploymentMetadataEnumeration)
						{
							IDefinitionAppId deployment = (IDefinitionAppId)obj;
							StoreDeploymentMetadataPropertyEnumeration storeDeploymentMetadataPropertyEnumeration = this.m_pStore.EnumInstallerDeploymentProperties(IsolationInterop.GUID_SXS_INSTALL_REFERENCE_SCHEME_OPAQUESTRING, "{60051b8f-4f12-400a-8e50-dd05ebd438d1}", "ApplicationTrust", deployment);
							foreach (object obj2 in storeDeploymentMetadataPropertyEnumeration)
							{
								StoreOperationMetadataProperty storeOperationMetadataProperty = (StoreOperationMetadataProperty)obj2;
								string value = storeOperationMetadataProperty.Value;
								if (value != null && value.Length > 0)
								{
									SecurityElement element = SecurityElement.FromString(value);
									ApplicationTrust applicationTrust = new ApplicationTrust();
									applicationTrust.FromXml(element);
									arrayList.Add(applicationTrust);
								}
							}
						}
					}
					Interlocked.CompareExchange(ref this.m_appTrusts, arrayList, null);
				}
				return this.m_appTrusts as ArrayList;
			}
		}

		// Token: 0x06002888 RID: 10376 RVA: 0x00095580 File Offset: 0x00093780
		[SecurityCritical]
		internal ApplicationTrustCollection() : this(false)
		{
		}

		// Token: 0x06002889 RID: 10377 RVA: 0x00095589 File Offset: 0x00093789
		internal ApplicationTrustCollection(bool storeBounded)
		{
			this.m_storeBounded = storeBounded;
		}

		// Token: 0x0600288A RID: 10378 RVA: 0x00095598 File Offset: 0x00093798
		[SecurityCritical]
		private void RefreshStorePointer()
		{
			if (this.m_pStore != null)
			{
				Marshal.ReleaseComObject(this.m_pStore.InternalStore);
			}
			this.m_pStore = IsolationInterop.GetUserStore();
		}

		/// <summary>Gets the number of items contained in the collection.</summary>
		/// <returns>The number of items contained in the collection.</returns>
		// Token: 0x17000560 RID: 1376
		// (get) Token: 0x0600288B RID: 10379 RVA: 0x000955BE File Offset: 0x000937BE
		public int Count
		{
			[SecuritySafeCritical]
			get
			{
				return this.AppTrusts.Count;
			}
		}

		/// <summary>Gets the <see cref="T:System.Security.Policy.ApplicationTrust" /> object located at the specified index in the collection.</summary>
		/// <param name="index">The zero-based index of the object within the collection.</param>
		/// <returns>The <see cref="T:System.Security.Policy.ApplicationTrust" /> object at the specified index in the collection.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="index" /> is greater than or equal to the count of objects in the collection.</exception>
		/// <exception cref="T:System.InvalidOperationException">
		///   <paramref name="index" /> is negative.</exception>
		// Token: 0x17000561 RID: 1377
		public ApplicationTrust this[int index]
		{
			[SecurityCritical]
			get
			{
				return this.AppTrusts[index] as ApplicationTrust;
			}
		}

		/// <summary>Gets the <see cref="T:System.Security.Policy.ApplicationTrust" /> object for the specified application.</summary>
		/// <param name="appFullName">The full name of the application.</param>
		/// <returns>The <see cref="T:System.Security.Policy.ApplicationTrust" /> object for the specified application, or <see langword="null" /> if the object cannot be found.</returns>
		// Token: 0x17000562 RID: 1378
		public ApplicationTrust this[string appFullName]
		{
			[SecurityCritical]
			get
			{
				ApplicationIdentity applicationIdentity = new ApplicationIdentity(appFullName);
				ApplicationTrustCollection applicationTrustCollection = this.Find(applicationIdentity, ApplicationVersionMatch.MatchExactVersion);
				if (applicationTrustCollection.Count > 0)
				{
					return applicationTrustCollection[0];
				}
				return null;
			}
		}

		// Token: 0x0600288E RID: 10382 RVA: 0x00095610 File Offset: 0x00093810
		[SecurityCritical]
		private void CommitApplicationTrust(ApplicationIdentity applicationIdentity, string trustXml)
		{
			StoreOperationMetadataProperty[] setProperties = new StoreOperationMetadataProperty[]
			{
				new StoreOperationMetadataProperty(ApplicationTrustCollection.ClrPropertySet, "ApplicationTrust", trustXml)
			};
			IEnumDefinitionIdentity enumDefinitionIdentity = applicationIdentity.Identity.EnumAppPath();
			IDefinitionIdentity[] array = new IDefinitionIdentity[1];
			IDefinitionIdentity definitionIdentity = null;
			if (enumDefinitionIdentity.Next(1U, array) == 1U)
			{
				definitionIdentity = array[0];
			}
			IDefinitionAppId definitionAppId = IsolationInterop.AppIdAuthority.CreateDefinition();
			definitionAppId.SetAppPath(1U, new IDefinitionIdentity[]
			{
				definitionIdentity
			});
			definitionAppId.put_Codebase(applicationIdentity.CodeBase);
			using (StoreTransaction storeTransaction = new StoreTransaction())
			{
				storeTransaction.Add(new StoreOperationSetDeploymentMetadata(definitionAppId, ApplicationTrustCollection.InstallReference, setProperties));
				this.RefreshStorePointer();
				this.m_pStore.Transact(storeTransaction.Operations);
			}
			this.m_appTrusts = null;
		}

		/// <summary>Adds an element to the collection.</summary>
		/// <param name="trust">The <see cref="T:System.Security.Policy.ApplicationTrust" /> object to add.</param>
		/// <returns>The index at which the new element was inserted.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="trust" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">The <see cref="P:System.Security.Policy.ApplicationTrust.ApplicationIdentity" /> property of the <see cref="T:System.Security.Policy.ApplicationTrust" /> specified in <paramref name="trust" /> is <see langword="null" />.</exception>
		// Token: 0x0600288F RID: 10383 RVA: 0x000956E4 File Offset: 0x000938E4
		[SecurityCritical]
		public int Add(ApplicationTrust trust)
		{
			if (trust == null)
			{
				throw new ArgumentNullException("trust");
			}
			if (trust.ApplicationIdentity == null)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_ApplicationTrustShouldHaveIdentity"));
			}
			if (this.m_storeBounded)
			{
				this.CommitApplicationTrust(trust.ApplicationIdentity, trust.ToXml().ToString());
				return -1;
			}
			return this.AppTrusts.Add(trust);
		}

		/// <summary>Copies the elements of the specified <see cref="T:System.Security.Policy.ApplicationTrust" /> array to the end of the collection.</summary>
		/// <param name="trusts">An array of type <see cref="T:System.Security.Policy.ApplicationTrust" /> containing the objects to add to the collection.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="trusts" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">The <see cref="P:System.Security.Policy.ApplicationTrust.ApplicationIdentity" /> property of an <see cref="T:System.Security.Policy.ApplicationTrust" /> specified in <paramref name="trust" /> is <see langword="null" />.</exception>
		// Token: 0x06002890 RID: 10384 RVA: 0x00095744 File Offset: 0x00093944
		[SecurityCritical]
		public void AddRange(ApplicationTrust[] trusts)
		{
			if (trusts == null)
			{
				throw new ArgumentNullException("trusts");
			}
			int i = 0;
			try
			{
				while (i < trusts.Length)
				{
					this.Add(trusts[i]);
					i++;
				}
			}
			catch
			{
				for (int j = 0; j < i; j++)
				{
					this.Remove(trusts[j]);
				}
				throw;
			}
		}

		/// <summary>Copies the elements of the specified <see cref="T:System.Security.Policy.ApplicationTrustCollection" /> to the end of the collection.</summary>
		/// <param name="trusts">A <see cref="T:System.Security.Policy.ApplicationTrustCollection" /> containing the objects to add to the collection.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="trusts" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">The <see cref="P:System.Security.Policy.ApplicationTrust.ApplicationIdentity" /> property of an <see cref="T:System.Security.Policy.ApplicationTrust" /> specified in <paramref name="trust" /> is <see langword="null" />.</exception>
		// Token: 0x06002891 RID: 10385 RVA: 0x000957A4 File Offset: 0x000939A4
		[SecurityCritical]
		public void AddRange(ApplicationTrustCollection trusts)
		{
			if (trusts == null)
			{
				throw new ArgumentNullException("trusts");
			}
			int num = 0;
			try
			{
				foreach (ApplicationTrust trust in trusts)
				{
					this.Add(trust);
					num++;
				}
			}
			catch
			{
				for (int i = 0; i < num; i++)
				{
					this.Remove(trusts[i]);
				}
				throw;
			}
		}

		/// <summary>Gets the application trusts in the collection that match the specified application identity.</summary>
		/// <param name="applicationIdentity">An <see cref="T:System.ApplicationIdentity" /> object describing the application to find.</param>
		/// <param name="versionMatch">One of the <see cref="T:System.Security.Policy.ApplicationVersionMatch" /> values.</param>
		/// <returns>An <see cref="T:System.Security.Policy.ApplicationTrustCollection" /> containing all matching <see cref="T:System.Security.Policy.ApplicationTrust" /> objects.</returns>
		// Token: 0x06002892 RID: 10386 RVA: 0x00095814 File Offset: 0x00093A14
		[SecurityCritical]
		public ApplicationTrustCollection Find(ApplicationIdentity applicationIdentity, ApplicationVersionMatch versionMatch)
		{
			ApplicationTrustCollection applicationTrustCollection = new ApplicationTrustCollection(false);
			foreach (ApplicationTrust applicationTrust in this)
			{
				if (CmsUtils.CompareIdentities(applicationTrust.ApplicationIdentity, applicationIdentity, versionMatch))
				{
					applicationTrustCollection.Add(applicationTrust);
				}
			}
			return applicationTrustCollection;
		}

		/// <summary>Removes all application trust objects that match the specified criteria from the collection.</summary>
		/// <param name="applicationIdentity">The <see cref="T:System.ApplicationIdentity" /> of the <see cref="T:System.Security.Policy.ApplicationTrust" /> object to be removed.</param>
		/// <param name="versionMatch">One of the <see cref="T:System.Security.Policy.ApplicationVersionMatch" /> values.</param>
		// Token: 0x06002893 RID: 10387 RVA: 0x00095858 File Offset: 0x00093A58
		[SecurityCritical]
		public void Remove(ApplicationIdentity applicationIdentity, ApplicationVersionMatch versionMatch)
		{
			ApplicationTrustCollection trusts = this.Find(applicationIdentity, versionMatch);
			this.RemoveRange(trusts);
		}

		/// <summary>Removes the specified application trust from the collection.</summary>
		/// <param name="trust">The <see cref="T:System.Security.Policy.ApplicationTrust" /> object to remove.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="trust" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">The <see cref="P:System.Security.Policy.ApplicationTrust.ApplicationIdentity" /> property of the <see cref="T:System.Security.Policy.ApplicationTrust" /> object specified by <paramref name="trust" /> is <see langword="null" />.</exception>
		// Token: 0x06002894 RID: 10388 RVA: 0x00095878 File Offset: 0x00093A78
		[SecurityCritical]
		public void Remove(ApplicationTrust trust)
		{
			if (trust == null)
			{
				throw new ArgumentNullException("trust");
			}
			if (trust.ApplicationIdentity == null)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_ApplicationTrustShouldHaveIdentity"));
			}
			if (this.m_storeBounded)
			{
				this.CommitApplicationTrust(trust.ApplicationIdentity, null);
				return;
			}
			this.AppTrusts.Remove(trust);
		}

		/// <summary>Removes the application trust objects in the specified array from the collection.</summary>
		/// <param name="trusts">A one-dimensional array of type <see cref="T:System.Security.Policy.ApplicationTrust" /> that contains items to be removed from the current collection.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="trusts" /> is <see langword="null" />.</exception>
		// Token: 0x06002895 RID: 10389 RVA: 0x000958D0 File Offset: 0x00093AD0
		[SecurityCritical]
		public void RemoveRange(ApplicationTrust[] trusts)
		{
			if (trusts == null)
			{
				throw new ArgumentNullException("trusts");
			}
			int i = 0;
			try
			{
				while (i < trusts.Length)
				{
					this.Remove(trusts[i]);
					i++;
				}
			}
			catch
			{
				for (int j = 0; j < i; j++)
				{
					this.Add(trusts[j]);
				}
				throw;
			}
		}

		/// <summary>Removes the application trust objects in the specified collection from the collection.</summary>
		/// <param name="trusts">An <see cref="T:System.Security.Policy.ApplicationTrustCollection" /> that contains items to be removed from the currentcollection.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="trusts" /> is <see langword="null" />.</exception>
		// Token: 0x06002896 RID: 10390 RVA: 0x00095930 File Offset: 0x00093B30
		[SecurityCritical]
		public void RemoveRange(ApplicationTrustCollection trusts)
		{
			if (trusts == null)
			{
				throw new ArgumentNullException("trusts");
			}
			int num = 0;
			try
			{
				foreach (ApplicationTrust trust in trusts)
				{
					this.Remove(trust);
					num++;
				}
			}
			catch
			{
				for (int i = 0; i < num; i++)
				{
					this.Add(trusts[i]);
				}
				throw;
			}
		}

		/// <summary>Removes all the application trusts from the collection.</summary>
		/// <exception cref="T:System.ArgumentException">The <see cref="P:System.Security.Policy.ApplicationTrust.ApplicationIdentity" /> property of an item in the collection is <see langword="null" />.</exception>
		// Token: 0x06002897 RID: 10391 RVA: 0x000959A0 File Offset: 0x00093BA0
		[SecurityCritical]
		public void Clear()
		{
			ArrayList appTrusts = this.AppTrusts;
			if (this.m_storeBounded)
			{
				foreach (object obj in appTrusts)
				{
					ApplicationTrust applicationTrust = (ApplicationTrust)obj;
					if (applicationTrust.ApplicationIdentity == null)
					{
						throw new ArgumentException(Environment.GetResourceString("Argument_ApplicationTrustShouldHaveIdentity"));
					}
					this.CommitApplicationTrust(applicationTrust.ApplicationIdentity, null);
				}
			}
			appTrusts.Clear();
		}

		/// <summary>Returns an object that can be used to iterate over the collection.</summary>
		/// <returns>An <see cref="T:System.Security.Policy.ApplicationTrustEnumerator" /> that can be used to iterate over the collection.</returns>
		// Token: 0x06002898 RID: 10392 RVA: 0x00095A28 File Offset: 0x00093C28
		public ApplicationTrustEnumerator GetEnumerator()
		{
			return new ApplicationTrustEnumerator(this);
		}

		/// <summary>Returns an enumerator that iterates through the collection.</summary>
		/// <returns>An <see cref="T:System.Collections.IEnumerator" /> that can be used to iterate through the collection.</returns>
		// Token: 0x06002899 RID: 10393 RVA: 0x00095A30 File Offset: 0x00093C30
		[SecuritySafeCritical]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return new ApplicationTrustEnumerator(this);
		}

		/// <summary>Copies the elements of the <see cref="T:System.Collections.ICollection" /> to the specified <see cref="T:System.Array" />, starting at the specified <see cref="T:System.Array" /> index.</summary>
		/// <param name="array">The one-dimensional <see cref="T:System.Array" /> that is the destination of the elements copied from the <see cref="T:System.Collections.ICollection" />. The <see cref="T:System.Array" /> must have zero-based indexing.</param>
		/// <param name="index">The zero-based index in <paramref name="array" /> at which copying begins.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="array" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="index" /> is less than zero.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="array" /> is multidimensional.  
		/// -or-  
		/// The number of elements in the source <see cref="T:System.Collections.ICollection" /> is greater than the available space from <paramref name="index" /> to the end of the destination <paramref name="array" />.</exception>
		// Token: 0x0600289A RID: 10394 RVA: 0x00095A38 File Offset: 0x00093C38
		[SecuritySafeCritical]
		void ICollection.CopyTo(Array array, int index)
		{
			if (array == null)
			{
				throw new ArgumentNullException("array");
			}
			if (array.Rank != 1)
			{
				throw new ArgumentException(Environment.GetResourceString("Arg_RankMultiDimNotSupported"));
			}
			if (index < 0 || index >= array.Length)
			{
				throw new ArgumentOutOfRangeException("index", Environment.GetResourceString("ArgumentOutOfRange_Index"));
			}
			if (array.Length - index < this.Count)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_InvalidOffLen"));
			}
			for (int i = 0; i < this.Count; i++)
			{
				array.SetValue(this[i], index++);
			}
		}

		/// <summary>Copies the entire collection to a compatible one-dimensional array, starting at the specified index of the target array.</summary>
		/// <param name="array">The one-dimensional array of type <see cref="T:System.Security.Policy.ApplicationTrust" /> that is the destination of the elements copied from the current collection.</param>
		/// <param name="index">The zero-based index in <paramref name="array" /> at which copying begins.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="array" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="index" /> is less than the lower bound of <paramref name="array" />.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="array" /> is multidimensional.  
		/// -or-  
		/// The number of elements in the <see cref="T:System.Security.Policy.ApplicationTrustCollection" /> is greater than the available space from <paramref name="index" /> to the end of the destination <paramref name="array" />.</exception>
		// Token: 0x0600289B RID: 10395 RVA: 0x00095AD2 File Offset: 0x00093CD2
		public void CopyTo(ApplicationTrust[] array, int index)
		{
			((ICollection)this).CopyTo(array, index);
		}

		/// <summary>Gets a value indicating whether access to the collection is synchronized (thread safe).</summary>
		/// <returns>
		///   <see langword="false" /> in all cases.</returns>
		// Token: 0x17000563 RID: 1379
		// (get) Token: 0x0600289C RID: 10396 RVA: 0x00095ADC File Offset: 0x00093CDC
		public bool IsSynchronized
		{
			[SecuritySafeCritical]
			get
			{
				return false;
			}
		}

		/// <summary>Gets an object that can be used to synchronize access to the collection.</summary>
		/// <returns>The object to use to synchronize access to the collection.</returns>
		// Token: 0x17000564 RID: 1380
		// (get) Token: 0x0600289D RID: 10397 RVA: 0x00095ADF File Offset: 0x00093CDF
		public object SyncRoot
		{
			[SecuritySafeCritical]
			get
			{
				return this;
			}
		}

		// Token: 0x04001061 RID: 4193
		private const string ApplicationTrustProperty = "ApplicationTrust";

		// Token: 0x04001062 RID: 4194
		private const string InstallerIdentifier = "{60051b8f-4f12-400a-8e50-dd05ebd438d1}";

		// Token: 0x04001063 RID: 4195
		private static Guid ClrPropertySet = new Guid("c989bb7a-8385-4715-98cf-a741a8edb823");

		// Token: 0x04001064 RID: 4196
		private static object s_installReference = null;

		// Token: 0x04001065 RID: 4197
		private object m_appTrusts;

		// Token: 0x04001066 RID: 4198
		private bool m_storeBounded;

		// Token: 0x04001067 RID: 4199
		private Store m_pStore;
	}
}
