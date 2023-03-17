using System;
using System.Reflection;
using System.Runtime.Serialization;
using System.Security;

namespace System.Runtime.InteropServices
{
	/// <summary>Exposes the public members of the <see cref="T:System.Exception" /> class to unmanaged code.</summary>
	// Token: 0x0200091F RID: 2335
	[Guid("b36b5c63-42ef-38bc-a07e-0b34c98f164a")]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[CLSCompliant(false)]
	[ComVisible(true)]
	public interface _Exception
	{
		/// <summary>Provides COM objects with version-independent access to the <see cref="M:System.Exception.ToString" /> method.</summary>
		/// <returns>A string that represents the current <see cref="T:System.Exception" /> object.</returns>
		// Token: 0x06005F93 RID: 24467
		string ToString();

		/// <summary>Provides COM objects with version-independent access to the <see cref="M:System.Object.Equals(System.Object)" /> method.</summary>
		/// <param name="obj">The <see cref="T:System.Object" /> to compare with the current <see cref="T:System.Object" />.</param>
		/// <returns>
		///   <see langword="true" /> if the specified <see cref="T:System.Object" /> is equal to the current <see cref="T:System.Object" />; otherwise, <see langword="false" />.</returns>
		// Token: 0x06005F94 RID: 24468
		bool Equals(object obj);

		/// <summary>Provides COM objects with version-independent access to the <see cref="M:System.Object.GetHashCode" /> method.</summary>
		/// <returns>The hash code for the current instance.</returns>
		// Token: 0x06005F95 RID: 24469
		int GetHashCode();

		/// <summary>Provides COM objects with version-independent access to the <see cref="M:System.Exception.GetType" /> method.</summary>
		/// <returns>A <see cref="T:System.Type" /> object that represents the exact runtime type of the current instance.</returns>
		// Token: 0x06005F96 RID: 24470
		Type GetType();

		/// <summary>Provides COM objects with version-independent access to the <see cref="P:System.Exception.Message" /> property.</summary>
		/// <returns>The error message that explains the reason for the exception, or an empty string("").</returns>
		// Token: 0x170010E6 RID: 4326
		// (get) Token: 0x06005F97 RID: 24471
		string Message { get; }

		/// <summary>Provides COM objects with version-independent access to the <see cref="M:System.Exception.GetBaseException" /> method.</summary>
		/// <returns>The first exception thrown in a chain of exceptions. If the <see cref="P:System.Exception.InnerException" /> property of the current exception is a null reference (<see langword="Nothing" /> in Visual Basic), this property returns the current exception.</returns>
		// Token: 0x06005F98 RID: 24472
		Exception GetBaseException();

		/// <summary>Provides COM objects with version-independent access to the <see cref="P:System.Exception.StackTrace" /> property.</summary>
		/// <returns>A string that describes the contents of the call stack, with the most recent method call appearing first.</returns>
		// Token: 0x170010E7 RID: 4327
		// (get) Token: 0x06005F99 RID: 24473
		string StackTrace { get; }

		/// <summary>Provides COM objects with version-independent access to the <see cref="P:System.Exception.HelpLink" /> property.</summary>
		/// <returns>The Uniform Resource Name (URN) or Uniform Resource Locator (URL) to a help file.</returns>
		// Token: 0x170010E8 RID: 4328
		// (get) Token: 0x06005F9A RID: 24474
		// (set) Token: 0x06005F9B RID: 24475
		string HelpLink { get; set; }

		/// <summary>Provides COM objects with version-independent access to the <see cref="P:System.Exception.Source" /> property.</summary>
		/// <returns>The name of the application or the object that causes the error.</returns>
		// Token: 0x170010E9 RID: 4329
		// (get) Token: 0x06005F9C RID: 24476
		// (set) Token: 0x06005F9D RID: 24477
		string Source { get; set; }

		/// <summary>Provides COM objects with version-independent access to the <see cref="M:System.Exception.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)" /> method</summary>
		/// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> object that holds the serialized object data about the exception being thrown.</param>
		/// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext" /> structure that contains contextual information about the source or destination.</param>
		// Token: 0x06005F9E RID: 24478
		[SecurityCritical]
		void GetObjectData(SerializationInfo info, StreamingContext context);

		/// <summary>Provides COM objects with version-independent access to the <see cref="P:System.Exception.InnerException" /> property.</summary>
		/// <returns>An instance of <see cref="T:System.Exception" /> that describes the error that caused the current exception. The <see cref="P:System.Exception.InnerException" /> property returns the same value that was passed to the constructor, or a null reference (<see langword="Nothing" /> in Visual Basic) if the inner exception value was not supplied to the constructor. This property is read-only.</returns>
		// Token: 0x170010EA RID: 4330
		// (get) Token: 0x06005F9F RID: 24479
		Exception InnerException { get; }

		/// <summary>Provides COM objects with version-independent access to the <see cref="P:System.Exception.TargetSite" /> property.</summary>
		/// <returns>The <see cref="T:System.Reflection.MethodBase" /> object that threw the current exception.</returns>
		// Token: 0x170010EB RID: 4331
		// (get) Token: 0x06005FA0 RID: 24480
		MethodBase TargetSite { get; }
	}
}
