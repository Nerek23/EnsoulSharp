using System;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Deployment.Internal
{
	/// <summary>Provides access to data from an <see cref="T:System.ActivationContext" /> object.</summary>
	// Token: 0x02000640 RID: 1600
	[ComVisible(false)]
	public static class InternalActivationContextHelper
	{
		/// <summary>Gets the contents of the application manifest from an <see cref="T:System.ActivationContext" /> object.</summary>
		/// <param name="appInfo">The object containing the manifest.</param>
		/// <returns>The application manifest that is contained by the <see cref="T:System.ActivationContext" /> object.</returns>
		// Token: 0x06004DF6 RID: 19958 RVA: 0x001178D8 File Offset: 0x00115AD8
		[SecuritySafeCritical]
		public static object GetActivationContextData(ActivationContext appInfo)
		{
			return appInfo.ActivationContextData;
		}

		/// <summary>Gets the manifest of the last deployment component in an <see cref="T:System.ActivationContext" /> object.</summary>
		/// <param name="appInfo">The object containing the manifest.</param>
		/// <returns>The manifest of the last deployment component in the <see cref="T:System.ActivationContext" /> object.</returns>
		// Token: 0x06004DF7 RID: 19959 RVA: 0x001178E0 File Offset: 0x00115AE0
		[SecuritySafeCritical]
		public static object GetApplicationComponentManifest(ActivationContext appInfo)
		{
			return appInfo.ApplicationComponentManifest;
		}

		/// <summary>Gets the manifest of the first deployment component in an <see cref="T:System.ActivationContext" /> object.</summary>
		/// <param name="appInfo">The object containing the manifest.</param>
		/// <returns>The manifest of the first deployment component in the <see cref="T:System.ActivationContext" /> object.</returns>
		// Token: 0x06004DF8 RID: 19960 RVA: 0x001178E8 File Offset: 0x00115AE8
		[SecuritySafeCritical]
		public static object GetDeploymentComponentManifest(ActivationContext appInfo)
		{
			return appInfo.DeploymentComponentManifest;
		}

		/// <summary>Informs an <see cref="T:System.ActivationContext" /> to get ready to be run.</summary>
		/// <param name="appInfo">The object to inform.</param>
		// Token: 0x06004DF9 RID: 19961 RVA: 0x001178F0 File Offset: 0x00115AF0
		public static void PrepareForExecution(ActivationContext appInfo)
		{
			appInfo.PrepareForExecution();
		}

		/// <summary>Gets a value indicating whether this is the first time this <see cref="T:System.ActivationContext" /> object has been run.</summary>
		/// <param name="appInfo">The object to examine.</param>
		/// <returns>
		///   <see langword="true" /> if the <see cref="T:System.ActivationContext" /> indicates it is running for the first time; otherwise, <see langword="false" />.</returns>
		// Token: 0x06004DFA RID: 19962 RVA: 0x001178F8 File Offset: 0x00115AF8
		public static bool IsFirstRun(ActivationContext appInfo)
		{
			return appInfo.LastApplicationStateResult == ActivationContext.ApplicationStateDisposition.RunningFirstTime;
		}

		/// <summary>Gets a byte array containing the raw content of the application manifest.</summary>
		/// <param name="appInfo">The object to get bytes from.</param>
		/// <returns>An array containing the application manifest as raw data.</returns>
		// Token: 0x06004DFB RID: 19963 RVA: 0x00117907 File Offset: 0x00115B07
		public static byte[] GetApplicationManifestBytes(ActivationContext appInfo)
		{
			if (appInfo == null)
			{
				throw new ArgumentNullException("appInfo");
			}
			return appInfo.GetApplicationManifestBytes();
		}

		/// <summary>Gets a byte array containing the raw content of the deployment manifest.</summary>
		/// <param name="appInfo">The object to get bytes from.</param>
		/// <returns>An array containing the deployment manifest as raw data.</returns>
		// Token: 0x06004DFC RID: 19964 RVA: 0x0011791D File Offset: 0x00115B1D
		public static byte[] GetDeploymentManifestBytes(ActivationContext appInfo)
		{
			if (appInfo == null)
			{
				throw new ArgumentNullException("appInfo");
			}
			return appInfo.GetDeploymentManifestBytes();
		}
	}
}
