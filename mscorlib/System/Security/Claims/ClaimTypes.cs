using System;
using System.Runtime.InteropServices;

namespace System.Security.Claims
{
	/// <summary>Defines constants for the well-known claim types that can be assigned to a subject. This class cannot be inherited.</summary>
	// Token: 0x020002F2 RID: 754
	[ComVisible(false)]
	public static class ClaimTypes
	{
		// Token: 0x04000EF3 RID: 3827
		internal const string ClaimTypeNamespace = "http://schemas.microsoft.com/ws/2008/06/identity/claims";

		/// <summary>The URI for a claim that specifies the instant at which an entity was authenticated; http://schemas.microsoft.com/ws/2008/06/identity/claims/authenticationinstant.</summary>
		// Token: 0x04000EF4 RID: 3828
		public const string AuthenticationInstant = "http://schemas.microsoft.com/ws/2008/06/identity/claims/authenticationinstant";

		/// <summary>The URI for a claim that specifies the method with which an entity was authenticated; http://schemas.microsoft.com/ws/2008/06/identity/claims/authenticationmethod.</summary>
		// Token: 0x04000EF5 RID: 3829
		public const string AuthenticationMethod = "http://schemas.microsoft.com/ws/2008/06/identity/claims/authenticationmethod";

		/// <summary>The URI for a claim that specifies the cookie path; http://schemas.microsoft.com/ws/2008/06/identity/claims/cookiepath.</summary>
		// Token: 0x04000EF6 RID: 3830
		public const string CookiePath = "http://schemas.microsoft.com/ws/2008/06/identity/claims/cookiepath";

		/// <summary>The URI for a claim that specifies the deny-only primary SID on an entity; http://schemas.microsoft.com/ws/2008/06/identity/claims/denyonlyprimarysid. A deny-only SID denies the specified entity to a securable object.</summary>
		// Token: 0x04000EF7 RID: 3831
		public const string DenyOnlyPrimarySid = "http://schemas.microsoft.com/ws/2008/06/identity/claims/denyonlyprimarysid";

		/// <summary>The URI for a claim that specifies the deny-only primary group SID on an entity; http://schemas.microsoft.com/ws/2008/06/identity/claims/denyonlyprimarygroupsid. A deny-only SID denies the specified entity to a securable object.</summary>
		// Token: 0x04000EF8 RID: 3832
		public const string DenyOnlyPrimaryGroupSid = "http://schemas.microsoft.com/ws/2008/06/identity/claims/denyonlyprimarygroupsid";

		/// <summary>http://schemas.microsoft.com/ws/2008/06/identity/claims/denyonlywindowsdevicegroup.</summary>
		// Token: 0x04000EF9 RID: 3833
		public const string DenyOnlyWindowsDeviceGroup = "http://schemas.microsoft.com/ws/2008/06/identity/claims/denyonlywindowsdevicegroup";

		/// <summary>http://schemas.microsoft.com/ws/2008/06/identity/claims/dsa.</summary>
		// Token: 0x04000EFA RID: 3834
		public const string Dsa = "http://schemas.microsoft.com/ws/2008/06/identity/claims/dsa";

		/// <summary>http://schemas.microsoft.com/ws/2008/06/identity/claims/expiration.</summary>
		// Token: 0x04000EFB RID: 3835
		public const string Expiration = "http://schemas.microsoft.com/ws/2008/06/identity/claims/expiration";

		/// <summary>http://schemas.microsoft.com/ws/2008/06/identity/claims/expired.</summary>
		// Token: 0x04000EFC RID: 3836
		public const string Expired = "http://schemas.microsoft.com/ws/2008/06/identity/claims/expired";

		/// <summary>The URI for a claim that specifies the SID for the group of an entity, http://schemas.microsoft.com/ws/2008/06/identity/claims/groupsid.</summary>
		// Token: 0x04000EFD RID: 3837
		public const string GroupSid = "http://schemas.microsoft.com/ws/2008/06/identity/claims/groupsid";

		/// <summary>http://schemas.microsoft.com/ws/2008/06/identity/claims/ispersistent.</summary>
		// Token: 0x04000EFE RID: 3838
		public const string IsPersistent = "http://schemas.microsoft.com/ws/2008/06/identity/claims/ispersistent";

		/// <summary>The URI for a claim that specifies the primary group SID of an entity, http://schemas.microsoft.com/ws/2008/06/identity/claims/primarygroupsid.</summary>
		// Token: 0x04000EFF RID: 3839
		public const string PrimaryGroupSid = "http://schemas.microsoft.com/ws/2008/06/identity/claims/primarygroupsid";

		/// <summary>The URI for a claim that specifies the primary SID of an entity, http://schemas.microsoft.com/ws/2008/06/identity/claims/primarysid.</summary>
		// Token: 0x04000F00 RID: 3840
		public const string PrimarySid = "http://schemas.microsoft.com/ws/2008/06/identity/claims/primarysid";

		/// <summary>The URI for a claim that specifies the role of an entity, http://schemas.microsoft.com/ws/2008/06/identity/claims/role.</summary>
		// Token: 0x04000F01 RID: 3841
		public const string Role = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role";

		/// <summary>The URI for a claim that specifies a serial number, http://schemas.microsoft.com/ws/2008/06/identity/claims/serialnumber.</summary>
		// Token: 0x04000F02 RID: 3842
		public const string SerialNumber = "http://schemas.microsoft.com/ws/2008/06/identity/claims/serialnumber";

		/// <summary>http://schemas.microsoft.com/ws/2008/06/identity/claims/userdata.</summary>
		// Token: 0x04000F03 RID: 3843
		public const string UserData = "http://schemas.microsoft.com/ws/2008/06/identity/claims/userdata";

		/// <summary>http://schemas.microsoft.com/ws/2008/06/identity/claims/version.</summary>
		// Token: 0x04000F04 RID: 3844
		public const string Version = "http://schemas.microsoft.com/ws/2008/06/identity/claims/version";

		/// <summary>The URI for a claim that specifies the Windows domain account name of an entity, http://schemas.microsoft.com/ws/2008/06/identity/claims/windowsaccountname.</summary>
		// Token: 0x04000F05 RID: 3845
		public const string WindowsAccountName = "http://schemas.microsoft.com/ws/2008/06/identity/claims/windowsaccountname";

		/// <summary>http://schemas.microsoft.com/ws/2008/06/identity/claims/windowsdeviceclaim.</summary>
		// Token: 0x04000F06 RID: 3846
		public const string WindowsDeviceClaim = "http://schemas.microsoft.com/ws/2008/06/identity/claims/windowsdeviceclaim";

		/// <summary>http://schemas.microsoft.com/ws/2008/06/identity/claims/windowsdevicegroup.</summary>
		// Token: 0x04000F07 RID: 3847
		public const string WindowsDeviceGroup = "http://schemas.microsoft.com/ws/2008/06/identity/claims/windowsdevicegroup";

		/// <summary>http://schemas.microsoft.com/ws/2008/06/identity/claims/windowsuserclaim.</summary>
		// Token: 0x04000F08 RID: 3848
		public const string WindowsUserClaim = "http://schemas.microsoft.com/ws/2008/06/identity/claims/windowsuserclaim";

		/// <summary>http://schemas.microsoft.com/ws/2008/06/identity/claims/windowsfqbnversion.</summary>
		// Token: 0x04000F09 RID: 3849
		public const string WindowsFqbnVersion = "http://schemas.microsoft.com/ws/2008/06/identity/claims/windowsfqbnversion";

		/// <summary>http://schemas.microsoft.com/ws/2008/06/identity/claims/windowssubauthority.</summary>
		// Token: 0x04000F0A RID: 3850
		public const string WindowsSubAuthority = "http://schemas.microsoft.com/ws/2008/06/identity/claims/windowssubauthority";

		// Token: 0x04000F0B RID: 3851
		internal const string ClaimType2005Namespace = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims";

		/// <summary>The URI for a claim that specifies the anonymous user; http://schemas.xmlsoap.org/ws/2005/05/identity/claims/anonymous.</summary>
		// Token: 0x04000F0C RID: 3852
		public const string Anonymous = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/anonymous";

		/// <summary>The URI for a claim that specifies details about whether an identity is authenticated, http://schemas.xmlsoap.org/ws/2005/05/identity/claims/authenticated.</summary>
		// Token: 0x04000F0D RID: 3853
		public const string Authentication = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/authentication";

		/// <summary>The URI for a claim that specifies an authorization decision on an entity; http://schemas.xmlsoap.org/ws/2005/05/identity/claims/authorizationdecision.</summary>
		// Token: 0x04000F0E RID: 3854
		public const string AuthorizationDecision = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/authorizationdecision";

		/// <summary>The URI for a claim that specifies the country/region in which an entity resides, http://schemas.xmlsoap.org/ws/2005/05/identity/claims/country.</summary>
		// Token: 0x04000F0F RID: 3855
		public const string Country = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/country";

		/// <summary>The URI for a claim that specifies the date of birth of an entity, http://schemas.xmlsoap.org/ws/2005/05/identity/claims/dateofbirth.</summary>
		// Token: 0x04000F10 RID: 3856
		public const string DateOfBirth = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/dateofbirth";

		/// <summary>The URI for a claim that specifies the DNS name associated with the computer name or with the alternative name of either the subject or issuer of an X.509 certificate, http://schemas.xmlsoap.org/ws/2005/05/identity/claims/dns.</summary>
		// Token: 0x04000F11 RID: 3857
		public const string Dns = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/dns";

		/// <summary>The URI for a claim that specifies a deny-only security identifier (SID) for an entity, http://schemas.xmlsoap.org/ws/2005/05/identity/claims/denyonlysid. A deny-only SID denies the specified entity to a securable object.</summary>
		// Token: 0x04000F12 RID: 3858
		public const string DenyOnlySid = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/denyonlysid";

		/// <summary>The URI for a claim that specifies the email address of an entity, http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress.</summary>
		// Token: 0x04000F13 RID: 3859
		public const string Email = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress";

		/// <summary>The URI for a claim that specifies the gender of an entity, http://schemas.xmlsoap.org/ws/2005/05/identity/claims/gender.</summary>
		// Token: 0x04000F14 RID: 3860
		public const string Gender = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/gender";

		/// <summary>The URI for a claim that specifies the given name of an entity, http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname.</summary>
		// Token: 0x04000F15 RID: 3861
		public const string GivenName = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname";

		/// <summary>The URI for a claim that specifies a hash value, http://schemas.xmlsoap.org/ws/2005/05/identity/claims/hash.</summary>
		// Token: 0x04000F16 RID: 3862
		public const string Hash = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/hash";

		/// <summary>The URI for a claim that specifies the home phone number of an entity, http://schemas.xmlsoap.org/ws/2005/05/identity/claims/homephone.</summary>
		// Token: 0x04000F17 RID: 3863
		public const string HomePhone = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/homephone";

		/// <summary>The URI for a claim that specifies the locale in which an entity resides, http://schemas.xmlsoap.org/ws/2005/05/identity/claims/locality.</summary>
		// Token: 0x04000F18 RID: 3864
		public const string Locality = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/locality";

		/// <summary>The URI for a claim that specifies the mobile phone number of an entity, http://schemas.xmlsoap.org/ws/2005/05/identity/claims/mobilephone.</summary>
		// Token: 0x04000F19 RID: 3865
		public const string MobilePhone = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/mobilephone";

		/// <summary>The URI for a claim that specifies the name of an entity, http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name.</summary>
		// Token: 0x04000F1A RID: 3866
		public const string Name = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name";

		/// <summary>The URI for a claim that specifies the name of an entity, http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier.</summary>
		// Token: 0x04000F1B RID: 3867
		public const string NameIdentifier = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier";

		/// <summary>The URI for a claim that specifies the alternative phone number of an entity, http://schemas.xmlsoap.org/ws/2005/05/identity/claims/otherphone.</summary>
		// Token: 0x04000F1C RID: 3868
		public const string OtherPhone = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/otherphone";

		/// <summary>The URI for a claim that specifies the postal code of an entity, http://schemas.xmlsoap.org/ws/2005/05/identity/claims/postalcode.</summary>
		// Token: 0x04000F1D RID: 3869
		public const string PostalCode = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/postalcode";

		/// <summary>The URI for a claim that specifies an RSA key, http://schemas.xmlsoap.org/ws/2005/05/identity/claims/rsa.</summary>
		// Token: 0x04000F1E RID: 3870
		public const string Rsa = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/rsa";

		/// <summary>The URI for a claim that specifies a security identifier (SID), http://schemas.xmlsoap.org/ws/2005/05/identity/claims/sid.</summary>
		// Token: 0x04000F1F RID: 3871
		public const string Sid = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/sid";

		/// <summary>The URI for a claim that specifies a service principal name (SPN) claim, http://schemas.xmlsoap.org/ws/2005/05/identity/claims/spn.</summary>
		// Token: 0x04000F20 RID: 3872
		public const string Spn = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/spn";

		/// <summary>The URI for a claim that specifies the state or province in which an entity resides, http://schemas.xmlsoap.org/ws/2005/05/identity/claims/stateorprovince.</summary>
		// Token: 0x04000F21 RID: 3873
		public const string StateOrProvince = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/stateorprovince";

		/// <summary>The URI for a claim that specifies the street address of an entity, http://schemas.xmlsoap.org/ws/2005/05/identity/claims/streetaddress.</summary>
		// Token: 0x04000F22 RID: 3874
		public const string StreetAddress = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/streetaddress";

		/// <summary>The URI for a claim that specifies the surname of an entity, http://schemas.xmlsoap.org/ws/2005/05/identity/claims/surname.</summary>
		// Token: 0x04000F23 RID: 3875
		public const string Surname = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/surname";

		/// <summary>The URI for a claim that identifies the system entity, http://schemas.xmlsoap.org/ws/2005/05/identity/claims/system.</summary>
		// Token: 0x04000F24 RID: 3876
		public const string System = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/system";

		/// <summary>The URI for a claim that specifies a thumbprint, http://schemas.xmlsoap.org/ws/2005/05/identity/claims/thumbprint. A thumbprint is a globally unique SHA-1 hash of an X.509 certificate.</summary>
		// Token: 0x04000F25 RID: 3877
		public const string Thumbprint = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/thumbprint";

		/// <summary>The URI for a claim that specifies a user principal name (UPN), http://schemas.xmlsoap.org/ws/2005/05/identity/claims/upn.</summary>
		// Token: 0x04000F26 RID: 3878
		public const string Upn = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/upn";

		/// <summary>The URI for a claim that specifies a URI, http://schemas.xmlsoap.org/ws/2005/05/identity/claims/uri.</summary>
		// Token: 0x04000F27 RID: 3879
		public const string Uri = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/uri";

		/// <summary>The URI for a claim that specifies the webpage of an entity, http://schemas.xmlsoap.org/ws/2005/05/identity/claims/webpage.</summary>
		// Token: 0x04000F28 RID: 3880
		public const string Webpage = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/webpage";

		/// <summary>The URI for a distinguished name claim of an X.509 certificate, http://schemas.xmlsoap.org/ws/2005/05/identity/claims/x500distinguishedname. The X.500 standard defines the methodology for defining distinguished names that are used by X.509 certificates.</summary>
		// Token: 0x04000F29 RID: 3881
		public const string X500DistinguishedName = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/x500distinguishedname";

		// Token: 0x04000F2A RID: 3882
		internal const string ClaimType2009Namespace = "http://schemas.xmlsoap.org/ws/2009/09/identity/claims";

		/// <summary>http://schemas.xmlsoap.org/ws/2009/09/identity/claims/actor.</summary>
		// Token: 0x04000F2B RID: 3883
		public const string Actor = "http://schemas.xmlsoap.org/ws/2009/09/identity/claims/actor";
	}
}
