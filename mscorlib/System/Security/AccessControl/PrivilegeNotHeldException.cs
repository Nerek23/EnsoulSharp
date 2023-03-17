using System;
using System.Globalization;
using System.Runtime.Serialization;

namespace System.Security.AccessControl
{
	/// <summary>The exception that is thrown when a method in the <see cref="N:System.Security.AccessControl" /> namespace attempts to enable a privilege that it does not have.</summary>
	// Token: 0x0200022B RID: 555
	[Serializable]
	public sealed class PrivilegeNotHeldException : UnauthorizedAccessException, ISerializable
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Security.AccessControl.PrivilegeNotHeldException" /> class.</summary>
		// Token: 0x06002013 RID: 8211 RVA: 0x00070E86 File Offset: 0x0006F086
		public PrivilegeNotHeldException() : base(Environment.GetResourceString("PrivilegeNotHeld_Default"))
		{
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Security.AccessControl.PrivilegeNotHeldException" /> class by using the specified privilege.</summary>
		/// <param name="privilege">The privilege that is not enabled.</param>
		// Token: 0x06002014 RID: 8212 RVA: 0x00070E98 File Offset: 0x0006F098
		public PrivilegeNotHeldException(string privilege) : base(string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("PrivilegeNotHeld_Named"), privilege))
		{
			this._privilegeName = privilege;
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Security.AccessControl.PrivilegeNotHeldException" /> class by using the specified exception.</summary>
		/// <param name="privilege">The privilege that is not enabled.</param>
		/// <param name="inner">The exception that is the cause of the current exception. If the innerException parameter is not a null reference (<see langword="Nothing" /> in Visual Basic), the current exception is raised in a <see langword="catch" /> block that handles the inner exception.</param>
		// Token: 0x06002015 RID: 8213 RVA: 0x00070EBC File Offset: 0x0006F0BC
		public PrivilegeNotHeldException(string privilege, Exception inner) : base(string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("PrivilegeNotHeld_Named"), privilege), inner)
		{
			this._privilegeName = privilege;
		}

		// Token: 0x06002016 RID: 8214 RVA: 0x00070EE1 File Offset: 0x0006F0E1
		internal PrivilegeNotHeldException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			this._privilegeName = info.GetString("PrivilegeName");
		}

		/// <summary>Gets the name of the privilege that is not enabled.</summary>
		/// <returns>The name of the privilege that the method failed to enable.</returns>
		// Token: 0x170003B7 RID: 951
		// (get) Token: 0x06002017 RID: 8215 RVA: 0x00070EFC File Offset: 0x0006F0FC
		public string PrivilegeName
		{
			get
			{
				return this._privilegeName;
			}
		}

		/// <summary>Sets the <paramref name="info" /> parameter with information about the exception.</summary>
		/// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> that holds the serialized object data about the exception being thrown.</param>
		/// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext" /> that contains contextual information about the source or destination.</param>
		// Token: 0x06002018 RID: 8216 RVA: 0x00070F04 File Offset: 0x0006F104
		[SecurityCritical]
		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			if (info == null)
			{
				throw new ArgumentNullException("info");
			}
			base.GetObjectData(info, context);
			info.AddValue("PrivilegeName", this._privilegeName, typeof(string));
		}

		// Token: 0x04000B8F RID: 2959
		private readonly string _privilegeName;
	}
}
