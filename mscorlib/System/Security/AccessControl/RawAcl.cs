using System;
using System.Collections;

namespace System.Security.AccessControl
{
	/// <summary>Represents an Access Control List (ACL).</summary>
	// Token: 0x0200020C RID: 524
	public sealed class RawAcl : GenericAcl
	{
		// Token: 0x06001E99 RID: 7833 RVA: 0x0006AD84 File Offset: 0x00068F84
		private static void VerifyHeader(byte[] binaryForm, int offset, out byte revision, out int count, out int length)
		{
			if (binaryForm == null)
			{
				throw new ArgumentNullException("binaryForm");
			}
			if (offset < 0)
			{
				throw new ArgumentOutOfRangeException("offset", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
			}
			if (binaryForm.Length - offset >= 8)
			{
				revision = binaryForm[offset];
				length = (int)binaryForm[offset + 2] + ((int)binaryForm[offset + 3] << 8);
				count = (int)binaryForm[offset + 4] + ((int)binaryForm[offset + 5] << 8);
				if (length <= binaryForm.Length - offset)
				{
					return;
				}
			}
			throw new ArgumentOutOfRangeException("binaryForm", Environment.GetResourceString("ArgumentOutOfRange_ArrayTooSmall"));
		}

		// Token: 0x06001E9A RID: 7834 RVA: 0x0006AE04 File Offset: 0x00069004
		private void MarshalHeader(byte[] binaryForm, int offset)
		{
			if (binaryForm == null)
			{
				throw new ArgumentNullException("binaryForm");
			}
			if (offset < 0)
			{
				throw new ArgumentOutOfRangeException("offset", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
			}
			if (this.BinaryLength > GenericAcl.MaxBinaryLength)
			{
				throw new InvalidOperationException(Environment.GetResourceString("AccessControl_AclTooLong"));
			}
			if (binaryForm.Length - offset < this.BinaryLength)
			{
				throw new ArgumentOutOfRangeException("binaryForm", Environment.GetResourceString("ArgumentOutOfRange_ArrayTooSmall"));
			}
			binaryForm[offset] = this.Revision;
			binaryForm[offset + 1] = 0;
			binaryForm[offset + 2] = (byte)this.BinaryLength;
			binaryForm[offset + 3] = (byte)(this.BinaryLength >> 8);
			binaryForm[offset + 4] = (byte)this.Count;
			binaryForm[offset + 5] = (byte)(this.Count >> 8);
			binaryForm[offset + 6] = 0;
			binaryForm[offset + 7] = 0;
		}

		// Token: 0x06001E9B RID: 7835 RVA: 0x0006AEC8 File Offset: 0x000690C8
		internal void SetBinaryForm(byte[] binaryForm, int offset)
		{
			int num;
			int num2;
			RawAcl.VerifyHeader(binaryForm, offset, out this._revision, out num, out num2);
			num2 += offset;
			offset += 8;
			this._aces = new ArrayList(num);
			int num3 = 8;
			for (int i = 0; i < num; i++)
			{
				GenericAce genericAce = GenericAce.CreateFromBinaryForm(binaryForm, offset);
				int binaryLength = genericAce.BinaryLength;
				if (num3 + binaryLength > GenericAcl.MaxBinaryLength)
				{
					throw new ArgumentException(Environment.GetResourceString("ArgumentException_InvalidAclBinaryForm"), "binaryForm");
				}
				this._aces.Add(genericAce);
				if (binaryLength % 4 != 0)
				{
					throw new SystemException();
				}
				num3 += binaryLength;
				if (this._revision == GenericAcl.AclRevisionDS)
				{
					offset += (int)binaryForm[offset + 2] + ((int)binaryForm[offset + 3] << 8);
				}
				else
				{
					offset += binaryLength;
				}
				if (offset > num2)
				{
					throw new ArgumentException(Environment.GetResourceString("ArgumentException_InvalidAclBinaryForm"), "binaryForm");
				}
			}
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Security.AccessControl.RawAcl" /> class with the specified revision level.</summary>
		/// <param name="revision">The revision level of the new Access Control List (ACL).</param>
		/// <param name="capacity">The number of Access Control Entries (ACEs) this <see cref="T:System.Security.AccessControl.RawAcl" /> object can contain. This number is to be used only as a hint.</param>
		// Token: 0x06001E9C RID: 7836 RVA: 0x0006AF9C File Offset: 0x0006919C
		public RawAcl(byte revision, int capacity)
		{
			this._revision = revision;
			this._aces = new ArrayList(capacity);
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Security.AccessControl.RawAcl" /> class from the specified binary form.</summary>
		/// <param name="binaryForm">An array of byte values that represent an Access Control List (ACL).</param>
		/// <param name="offset">The offset in the <paramref name="binaryForm" /> parameter at which to begin unmarshaling data.</param>
		// Token: 0x06001E9D RID: 7837 RVA: 0x0006AFB7 File Offset: 0x000691B7
		public RawAcl(byte[] binaryForm, int offset)
		{
			this.SetBinaryForm(binaryForm, offset);
		}

		/// <summary>Gets the revision level of the <see cref="T:System.Security.AccessControl.RawAcl" />.</summary>
		/// <returns>A byte value that specifies the revision level of the <see cref="T:System.Security.AccessControl.RawAcl" />.</returns>
		// Token: 0x17000382 RID: 898
		// (get) Token: 0x06001E9E RID: 7838 RVA: 0x0006AFC7 File Offset: 0x000691C7
		public override byte Revision
		{
			get
			{
				return this._revision;
			}
		}

		/// <summary>Gets the number of access control entries (ACEs) in the current <see cref="T:System.Security.AccessControl.RawAcl" /> object.</summary>
		/// <returns>The number of ACEs in the current <see cref="T:System.Security.AccessControl.RawAcl" /> object.</returns>
		// Token: 0x17000383 RID: 899
		// (get) Token: 0x06001E9F RID: 7839 RVA: 0x0006AFCF File Offset: 0x000691CF
		public override int Count
		{
			get
			{
				return this._aces.Count;
			}
		}

		/// <summary>Gets the length, in bytes, of the binary representation of the current <see cref="T:System.Security.AccessControl.RawAcl" /> object. This length should be used before marshaling the ACL into a binary array with the <see cref="M:System.Security.AccessControl.RawAcl.GetBinaryForm(System.Byte[],System.Int32)" /> method.</summary>
		/// <returns>The length, in bytes, of the binary representation of the current <see cref="T:System.Security.AccessControl.RawAcl" /> object.</returns>
		// Token: 0x17000384 RID: 900
		// (get) Token: 0x06001EA0 RID: 7840 RVA: 0x0006AFDC File Offset: 0x000691DC
		public override int BinaryLength
		{
			get
			{
				int num = 8;
				for (int i = 0; i < this.Count; i++)
				{
					GenericAce genericAce = this._aces[i] as GenericAce;
					num += genericAce.BinaryLength;
				}
				return num;
			}
		}

		/// <summary>Marshals the contents of the <see cref="T:System.Security.AccessControl.RawAcl" /> object into the specified byte array beginning at the specified offset.</summary>
		/// <param name="binaryForm">The byte array into which the contents of the <see cref="T:System.Security.AccessControl.RawAcl" /> is marshaled.</param>
		/// <param name="offset">The offset at which to start marshaling.</param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="offset" /> is negative or too high to allow the entire <see cref="T:System.Security.AccessControl.RawAcl" /> to be copied into <paramref name="array" />.</exception>
		// Token: 0x06001EA1 RID: 7841 RVA: 0x0006B018 File Offset: 0x00069218
		public override void GetBinaryForm(byte[] binaryForm, int offset)
		{
			this.MarshalHeader(binaryForm, offset);
			offset += 8;
			for (int i = 0; i < this.Count; i++)
			{
				GenericAce genericAce = this._aces[i] as GenericAce;
				genericAce.GetBinaryForm(binaryForm, offset);
				int binaryLength = genericAce.BinaryLength;
				if (binaryLength % 4 != 0)
				{
					throw new SystemException();
				}
				offset += binaryLength;
			}
		}

		/// <summary>Gets or sets the Access Control Entry (ACE) at the specified index.</summary>
		/// <param name="index">The zero-based index of the ACE to get or set.</param>
		/// <returns>The ACE at the specified index.</returns>
		// Token: 0x17000385 RID: 901
		public override GenericAce this[int index]
		{
			get
			{
				return this._aces[index] as GenericAce;
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				if (value.BinaryLength % 4 != 0)
				{
					throw new SystemException();
				}
				int num = this.BinaryLength - ((index < this._aces.Count) ? (this._aces[index] as GenericAce).BinaryLength : 0) + value.BinaryLength;
				if (num > GenericAcl.MaxBinaryLength)
				{
					throw new OverflowException(Environment.GetResourceString("AccessControl_AclTooLong"));
				}
				this._aces[index] = value;
			}
		}

		/// <summary>Inserts the specified Access Control Entry (ACE) at the specified index.</summary>
		/// <param name="index">The position at which to add the new ACE. Specify the value of the <see cref="P:System.Security.AccessControl.RawAcl.Count" /> property to insert an ACE at the end of the <see cref="T:System.Security.AccessControl.RawAcl" /> object.</param>
		/// <param name="ace">The ACE to insert.</param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="offset" /> is negative or too high to allow the entire <see cref="T:System.Security.AccessControl.GenericAcl" /> to be copied into <paramref name="array" />.</exception>
		// Token: 0x06001EA4 RID: 7844 RVA: 0x0006B114 File Offset: 0x00069314
		public void InsertAce(int index, GenericAce ace)
		{
			if (ace == null)
			{
				throw new ArgumentNullException("ace");
			}
			if (this.BinaryLength + ace.BinaryLength > GenericAcl.MaxBinaryLength)
			{
				throw new OverflowException(Environment.GetResourceString("AccessControl_AclTooLong"));
			}
			this._aces.Insert(index, ace);
		}

		/// <summary>Removes the Access Control Entry (ACE) at the specified location.</summary>
		/// <param name="index">The zero-based index of the ACE to remove.</param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The value of the <paramref name="index" /> parameter is higher than the value of the <see cref="P:System.Security.AccessControl.RawAcl.Count" /> property minus one or is negative.</exception>
		// Token: 0x06001EA5 RID: 7845 RVA: 0x0006B168 File Offset: 0x00069368
		public void RemoveAce(int index)
		{
			GenericAce genericAce = this._aces[index] as GenericAce;
			this._aces.RemoveAt(index);
		}

		// Token: 0x04000B09 RID: 2825
		private byte _revision;

		// Token: 0x04000B0A RID: 2826
		private ArrayList _aces;
	}
}
