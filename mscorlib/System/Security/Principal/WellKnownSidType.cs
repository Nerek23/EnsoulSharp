using System;
using System.Runtime.InteropServices;

namespace System.Security.Principal
{
	/// <summary>Defines a set of commonly used security identifiers (SIDs).</summary>
	// Token: 0x0200030D RID: 781
	[ComVisible(false)]
	public enum WellKnownSidType
	{
		/// <summary>Indicates a null SID.</summary>
		// Token: 0x04000FF1 RID: 4081
		NullSid,
		/// <summary>Indicates a SID that matches everyone.</summary>
		// Token: 0x04000FF2 RID: 4082
		WorldSid,
		/// <summary>Indicates a local SID.</summary>
		// Token: 0x04000FF3 RID: 4083
		LocalSid,
		/// <summary>Indicates a SID that matches the owner or creator of an object.</summary>
		// Token: 0x04000FF4 RID: 4084
		CreatorOwnerSid,
		/// <summary>Indicates a SID that matches the creator group of an object.</summary>
		// Token: 0x04000FF5 RID: 4085
		CreatorGroupSid,
		/// <summary>Indicates a creator owner server SID.</summary>
		// Token: 0x04000FF6 RID: 4086
		CreatorOwnerServerSid,
		/// <summary>Indicates a creator group server SID.</summary>
		// Token: 0x04000FF7 RID: 4087
		CreatorGroupServerSid,
		/// <summary>Indicates a SID for the Windows NT authority.</summary>
		// Token: 0x04000FF8 RID: 4088
		NTAuthoritySid,
		/// <summary>Indicates a SID for a dial-up account.</summary>
		// Token: 0x04000FF9 RID: 4089
		DialupSid,
		/// <summary>Indicates a SID for a network account. This SID is added to the process of a token when it logs on across a network.</summary>
		// Token: 0x04000FFA RID: 4090
		NetworkSid,
		/// <summary>Indicates a SID for a batch process. This SID is added to the process of a token when it logs on as a batch job.</summary>
		// Token: 0x04000FFB RID: 4091
		BatchSid,
		/// <summary>Indicates a SID for an interactive account. This SID is added to the process of a token when it logs on interactively.</summary>
		// Token: 0x04000FFC RID: 4092
		InteractiveSid,
		/// <summary>Indicates a SID for a service. This SID is added to the process of a token when it logs on as a service.</summary>
		// Token: 0x04000FFD RID: 4093
		ServiceSid,
		/// <summary>Indicates a SID for the anonymous account.</summary>
		// Token: 0x04000FFE RID: 4094
		AnonymousSid,
		/// <summary>Indicates a proxy SID.</summary>
		// Token: 0x04000FFF RID: 4095
		ProxySid,
		/// <summary>Indicates a SID for an enterprise controller.</summary>
		// Token: 0x04001000 RID: 4096
		EnterpriseControllersSid,
		/// <summary>Indicates a SID for self.</summary>
		// Token: 0x04001001 RID: 4097
		SelfSid,
		/// <summary>Indicates a SID for an authenticated user.</summary>
		// Token: 0x04001002 RID: 4098
		AuthenticatedUserSid,
		/// <summary>Indicates a SID for restricted code.</summary>
		// Token: 0x04001003 RID: 4099
		RestrictedCodeSid,
		/// <summary>Indicates a SID that matches a terminal server account.</summary>
		// Token: 0x04001004 RID: 4100
		TerminalServerSid,
		/// <summary>Indicates a SID that matches remote logons.</summary>
		// Token: 0x04001005 RID: 4101
		RemoteLogonIdSid,
		/// <summary>Indicates a SID that matches logon IDs.</summary>
		// Token: 0x04001006 RID: 4102
		LogonIdsSid,
		/// <summary>Indicates a SID that matches the local system.</summary>
		// Token: 0x04001007 RID: 4103
		LocalSystemSid,
		/// <summary>Indicates a SID that matches a local service.</summary>
		// Token: 0x04001008 RID: 4104
		LocalServiceSid,
		/// <summary>Indicates a SID that matches a network service.</summary>
		// Token: 0x04001009 RID: 4105
		NetworkServiceSid,
		/// <summary>Indicates a SID that matches the domain account.</summary>
		// Token: 0x0400100A RID: 4106
		BuiltinDomainSid,
		/// <summary>Indicates a SID that matches the administrator account.</summary>
		// Token: 0x0400100B RID: 4107
		BuiltinAdministratorsSid,
		/// <summary>Indicates a SID that matches built-in user accounts.</summary>
		// Token: 0x0400100C RID: 4108
		BuiltinUsersSid,
		/// <summary>Indicates a SID that matches the guest account.</summary>
		// Token: 0x0400100D RID: 4109
		BuiltinGuestsSid,
		/// <summary>Indicates a SID that matches the power users group.</summary>
		// Token: 0x0400100E RID: 4110
		BuiltinPowerUsersSid,
		/// <summary>Indicates a SID that matches the account operators account.</summary>
		// Token: 0x0400100F RID: 4111
		BuiltinAccountOperatorsSid,
		/// <summary>Indicates a SID that matches the system operators group.</summary>
		// Token: 0x04001010 RID: 4112
		BuiltinSystemOperatorsSid,
		/// <summary>Indicates a SID that matches the print operators group.</summary>
		// Token: 0x04001011 RID: 4113
		BuiltinPrintOperatorsSid,
		/// <summary>Indicates a SID that matches the backup operators group.</summary>
		// Token: 0x04001012 RID: 4114
		BuiltinBackupOperatorsSid,
		/// <summary>Indicates a SID that matches the replicator account.</summary>
		// Token: 0x04001013 RID: 4115
		BuiltinReplicatorSid,
		/// <summary>Indicates a SID that matches pre-Windows 2000 compatible accounts.</summary>
		// Token: 0x04001014 RID: 4116
		BuiltinPreWindows2000CompatibleAccessSid,
		/// <summary>Indicates a SID that matches remote desktop users.</summary>
		// Token: 0x04001015 RID: 4117
		BuiltinRemoteDesktopUsersSid,
		/// <summary>Indicates a SID that matches the network operators group.</summary>
		// Token: 0x04001016 RID: 4118
		BuiltinNetworkConfigurationOperatorsSid,
		/// <summary>Indicates a SID that matches the account administrators group.</summary>
		// Token: 0x04001017 RID: 4119
		AccountAdministratorSid,
		/// <summary>Indicates a SID that matches the account guest group.</summary>
		// Token: 0x04001018 RID: 4120
		AccountGuestSid,
		/// <summary>Indicates a SID that matches the account Kerberos target group.</summary>
		// Token: 0x04001019 RID: 4121
		AccountKrbtgtSid,
		/// <summary>Indicates a SID that matches the account domain administrator group.</summary>
		// Token: 0x0400101A RID: 4122
		AccountDomainAdminsSid,
		/// <summary>Indicates a SID that matches the account domain users group.</summary>
		// Token: 0x0400101B RID: 4123
		AccountDomainUsersSid,
		/// <summary>Indicates a SID that matches the account domain guests group.</summary>
		// Token: 0x0400101C RID: 4124
		AccountDomainGuestsSid,
		/// <summary>Indicates a SID that matches the account computer group.</summary>
		// Token: 0x0400101D RID: 4125
		AccountComputersSid,
		/// <summary>Indicates a SID that matches the account controller group.</summary>
		// Token: 0x0400101E RID: 4126
		AccountControllersSid,
		/// <summary>Indicates a SID that matches the certificate administrators group.</summary>
		// Token: 0x0400101F RID: 4127
		AccountCertAdminsSid,
		/// <summary>Indicates a SID that matches the schema administrators group.</summary>
		// Token: 0x04001020 RID: 4128
		AccountSchemaAdminsSid,
		/// <summary>Indicates a SID that matches the enterprise administrators group.</summary>
		// Token: 0x04001021 RID: 4129
		AccountEnterpriseAdminsSid,
		/// <summary>Indicates a SID that matches the policy administrators group.</summary>
		// Token: 0x04001022 RID: 4130
		AccountPolicyAdminsSid,
		/// <summary>Indicates a SID that matches the RAS and IAS server account.</summary>
		// Token: 0x04001023 RID: 4131
		AccountRasAndIasServersSid,
		/// <summary>Indicates a SID present when the Microsoft NTLM authentication package authenticated the client.</summary>
		// Token: 0x04001024 RID: 4132
		NtlmAuthenticationSid,
		/// <summary>Indicates a SID present when the Microsoft Digest authentication package authenticated the client.</summary>
		// Token: 0x04001025 RID: 4133
		DigestAuthenticationSid,
		/// <summary>Indicates a SID present when the Secure Channel (SSL/TLS) authentication package authenticated the client.</summary>
		// Token: 0x04001026 RID: 4134
		SChannelAuthenticationSid,
		/// <summary>Indicates a SID present when the user authenticated from within the forest or across a trust that does not have the selective authentication option enabled. If this SID is present, then <see cref="F:System.Security.Principal.WellKnownSidType.OtherOrganizationSid" /> cannot be present.</summary>
		// Token: 0x04001027 RID: 4135
		ThisOrganizationSid,
		/// <summary>Indicates a SID present when the user authenticated across a forest with the selective authentication option enabled. If this SID is present, then <see cref="F:System.Security.Principal.WellKnownSidType.ThisOrganizationSid" /> cannot be present.</summary>
		// Token: 0x04001028 RID: 4136
		OtherOrganizationSid,
		/// <summary>Indicates a SID that allows a user to create incoming forest trusts. It is added to the token of users who are a member of the Incoming Forest Trust Builders built-in group in the root domain of the forest.</summary>
		// Token: 0x04001029 RID: 4137
		BuiltinIncomingForestTrustBuildersSid,
		/// <summary>Indicates a SID that matches the group of users that have remote access to schedule logging of performance counters on this computer.</summary>
		// Token: 0x0400102A RID: 4138
		BuiltinPerformanceMonitoringUsersSid,
		/// <summary>Indicates a SID that matches the group of users that have remote access to monitor the computer.</summary>
		// Token: 0x0400102B RID: 4139
		BuiltinPerformanceLoggingUsersSid,
		/// <summary>Indicates a SID that matches the Windows Authorization Access group.</summary>
		// Token: 0x0400102C RID: 4140
		BuiltinAuthorizationAccessSid,
		/// <summary>Indicates a SID is present in a server that can issue Terminal Server licenses.</summary>
		// Token: 0x0400102D RID: 4141
		WinBuiltinTerminalServerLicenseServersSid,
		/// <summary>Indicates the maximum defined SID in the <see cref="T:System.Security.Principal.WellKnownSidType" /> enumeration.</summary>
		// Token: 0x0400102E RID: 4142
		MaxDefined = 60
	}
}
