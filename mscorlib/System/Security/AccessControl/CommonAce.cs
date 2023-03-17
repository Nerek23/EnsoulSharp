﻿using System;
using System.Security.Principal;

namespace System.Security.AccessControl
{
	/// <summary>Represents an access control entry (ACE).</summary>
	// Token: 0x02000207 RID: 519
	public sealed class CommonAce : QualifiedAce
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Security.AccessControl.CommonAce" /> class.</summary>
		/// <param name="flags">Flags that specify information about the inheritance, inheritance propagation, and auditing conditions for the new access control entry (ACE).</param>
		/// <param name="qualifier">The use of the new ACE.</param>
		/// <param name="accessMask">The access mask for the ACE.</param>
		/// <param name="sid">The <see cref="T:System.Security.Principal.SecurityIdentifier" /> associated with the new ACE.</param>
		/// <param name="isCallback">
		///   <see langword="true" /> to specify that the new ACE is a callback type ACE.</param>
		/// <param name="opaque">Opaque data associated with the new ACE. Opaque data is allowed only for callback ACE types. The length of this array must not be greater than the return value of the <see cref="M:System.Security.AccessControl.CommonAce.MaxOpaqueLength(System.Boolean)" /> method.</param>
		// Token: 0x06001E6F RID: 7791 RVA: 0x0006A48A File Offset: 0x0006868A
		public CommonAce(AceFlags flags, AceQualifier qualifier, int accessMask, SecurityIdentifier sid, bool isCallback, byte[] opaque) : base(CommonAce.TypeFromQualifier(isCallback, qualifier), flags, accessMask, sid, opaque)
		{
		}

		// Token: 0x06001E70 RID: 7792 RVA: 0x0006A4A0 File Offset: 0x000686A0
		private static AceType TypeFromQualifier(bool isCallback, AceQualifier qualifier)
		{
			switch (qualifier)
			{
			case AceQualifier.AccessAllowed:
				if (!isCallback)
				{
					return AceType.AccessAllowed;
				}
				return AceType.AccessAllowedCallback;
			case AceQualifier.AccessDenied:
				if (!isCallback)
				{
					return AceType.AccessDenied;
				}
				return AceType.AccessDeniedCallback;
			case AceQualifier.SystemAudit:
				if (!isCallback)
				{
					return AceType.SystemAudit;
				}
				return AceType.SystemAuditCallback;
			case AceQualifier.SystemAlarm:
				if (!isCallback)
				{
					return AceType.SystemAlarm;
				}
				return AceType.SystemAlarmCallback;
			default:
				throw new ArgumentOutOfRangeException("qualifier", Environment.GetResourceString("ArgumentOutOfRange_Enum"));
			}
		}

		// Token: 0x06001E71 RID: 7793 RVA: 0x0006A4FC File Offset: 0x000686FC
		internal static bool ParseBinaryForm(byte[] binaryForm, int offset, out AceQualifier qualifier, out int accessMask, out SecurityIdentifier sid, out bool isCallback, out byte[] opaque)
		{
			GenericAce.VerifyHeader(binaryForm, offset);
			if (binaryForm.Length - offset >= 8 + SecurityIdentifier.MinBinaryLength)
			{
				AceType aceType = (AceType)binaryForm[offset];
				if (aceType == AceType.AccessAllowed || aceType == AceType.AccessDenied || aceType == AceType.SystemAudit || aceType == AceType.SystemAlarm)
				{
					isCallback = false;
				}
				else
				{
					if (aceType != AceType.AccessAllowedCallback && aceType != AceType.AccessDeniedCallback && aceType != AceType.SystemAuditCallback && aceType != AceType.SystemAlarmCallback)
					{
						goto IL_114;
					}
					isCallback = true;
				}
				if (aceType == AceType.AccessAllowed || aceType == AceType.AccessAllowedCallback)
				{
					qualifier = AceQualifier.AccessAllowed;
				}
				else if (aceType == AceType.AccessDenied || aceType == AceType.AccessDeniedCallback)
				{
					qualifier = AceQualifier.AccessDenied;
				}
				else if (aceType == AceType.SystemAudit || aceType == AceType.SystemAuditCallback)
				{
					qualifier = AceQualifier.SystemAudit;
				}
				else
				{
					if (aceType != AceType.SystemAlarm && aceType != AceType.SystemAlarmCallback)
					{
						goto IL_114;
					}
					qualifier = AceQualifier.SystemAlarm;
				}
				int num = offset + 4;
				int num2 = 0;
				accessMask = (int)binaryForm[num] + ((int)binaryForm[num + 1] << 8) + ((int)binaryForm[num + 2] << 16) + ((int)binaryForm[num + 3] << 24);
				num2 += 4;
				sid = new SecurityIdentifier(binaryForm, num + num2);
				opaque = null;
				int num3 = ((int)binaryForm[offset + 3] << 8) + (int)binaryForm[offset + 2];
				if (num3 % 4 == 0)
				{
					int num4 = num3 - 4 - 4 - (int)((byte)sid.BinaryLength);
					if (num4 > 0)
					{
						opaque = new byte[num4];
						for (int i = 0; i < num4; i++)
						{
							opaque[i] = binaryForm[offset + num3 - num4 + i];
						}
					}
					return true;
				}
			}
			IL_114:
			qualifier = AceQualifier.AccessAllowed;
			accessMask = 0;
			sid = null;
			isCallback = false;
			opaque = null;
			return false;
		}

		/// <summary>Gets the length, in bytes, of the binary representation of the current <see cref="T:System.Security.AccessControl.CommonAce" /> object. Use this length with the <see cref="M:System.Security.AccessControl.CommonAce.GetBinaryForm(System.Byte[],System.Int32)" /> method before marshaling the ACL into a binary array.</summary>
		/// <returns>The length, in bytes, of the binary representation of the current <see cref="T:System.Security.AccessControl.CommonAce" /> object.</returns>
		// Token: 0x17000373 RID: 883
		// (get) Token: 0x06001E72 RID: 7794 RVA: 0x0006A630 File Offset: 0x00068830
		public override int BinaryLength
		{
			get
			{
				return 8 + base.SecurityIdentifier.BinaryLength + base.OpaqueLength;
			}
		}

		/// <summary>Gets the maximum allowed length of an opaque data BLOB for callback access control entries (ACEs).</summary>
		/// <param name="isCallback">
		///   <see langword="true" /> to specify that the <see cref="T:System.Security.AccessControl.CommonAce" /> object is a callback ACE type.</param>
		/// <returns>The allowed length of an opaque data BLOB.</returns>
		// Token: 0x06001E73 RID: 7795 RVA: 0x0006A646 File Offset: 0x00068846
		public static int MaxOpaqueLength(bool isCallback)
		{
			return 65527 - SecurityIdentifier.MaxBinaryLength;
		}

		// Token: 0x17000374 RID: 884
		// (get) Token: 0x06001E74 RID: 7796 RVA: 0x0006A653 File Offset: 0x00068853
		internal override int MaxOpaqueLengthInternal
		{
			get
			{
				return CommonAce.MaxOpaqueLength(base.IsCallback);
			}
		}

		/// <summary>Marshals the contents of the <see cref="T:System.Security.AccessControl.CommonAce" /> object into the specified byte array beginning at the specified offset.</summary>
		/// <param name="binaryForm">The byte array into which the contents of the <see cref="T:System.Security.AccessControl.CommonAce" /> object is marshaled.</param>
		/// <param name="offset">The offset at which to start marshaling.</param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="offset" /> is negative or too high to allow the entire <see cref="T:System.Security.AccessControl.CommonAce" /> to be copied into the <paramref name="binaryForm" /> array.</exception>
		// Token: 0x06001E75 RID: 7797 RVA: 0x0006A660 File Offset: 0x00068860
		public override void GetBinaryForm(byte[] binaryForm, int offset)
		{
			base.MarshalHeader(binaryForm, offset);
			int num = offset + 4;
			int num2 = 0;
			binaryForm[num] = (byte)base.AccessMask;
			binaryForm[num + 1] = (byte)(base.AccessMask >> 8);
			binaryForm[num + 2] = (byte)(base.AccessMask >> 16);
			binaryForm[num + 3] = (byte)(base.AccessMask >> 24);
			num2 += 4;
			base.SecurityIdentifier.GetBinaryForm(binaryForm, num + num2);
			num2 += base.SecurityIdentifier.BinaryLength;
			if (base.GetOpaque() != null)
			{
				if (base.OpaqueLength > this.MaxOpaqueLengthInternal)
				{
					throw new SystemException();
				}
				base.GetOpaque().CopyTo(binaryForm, num + num2);
			}
		}
	}
}
