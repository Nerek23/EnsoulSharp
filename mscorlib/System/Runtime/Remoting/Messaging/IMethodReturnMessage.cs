using System;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Runtime.Remoting.Messaging
{
	/// <summary>Defines the method call return message interface.</summary>
	// Token: 0x0200082F RID: 2095
	[ComVisible(true)]
	public interface IMethodReturnMessage : IMethodMessage, IMessage
	{
		/// <summary>Gets the number of arguments in the method call marked as <see langword="ref" /> or <see langword="out" /> parameters.</summary>
		/// <returns>The number of arguments in the method call marked as <see langword="ref" /> or <see langword="out" /> parameters.</returns>
		/// <exception cref="T:System.Security.SecurityException">The immediate caller makes the call through a reference to the interface and does not have infrastructure permission.</exception>
		// Token: 0x17000F1A RID: 3866
		// (get) Token: 0x06005973 RID: 22899
		int OutArgCount { [SecurityCritical] get; }

		/// <summary>Returns the name of the specified argument marked as a <see langword="ref" /> or an <see langword="out" /> parameter.</summary>
		/// <param name="index">The number of the requested argument name.</param>
		/// <returns>The argument name, or <see langword="null" /> if the current method is not implemented.</returns>
		/// <exception cref="T:System.Security.SecurityException">The immediate caller makes the call through a reference to the interface and does not have infrastructure permission.</exception>
		// Token: 0x06005974 RID: 22900
		[SecurityCritical]
		string GetOutArgName(int index);

		/// <summary>Returns the specified argument marked as a <see langword="ref" /> or an <see langword="out" /> parameter.</summary>
		/// <param name="argNum">The number of the requested argument.</param>
		/// <returns>The specified argument marked as a <see langword="ref" /> or an <see langword="out" /> parameter.</returns>
		/// <exception cref="T:System.Security.SecurityException">The immediate caller makes the call through a reference to the interface and does not have infrastructure permission.</exception>
		// Token: 0x06005975 RID: 22901
		[SecurityCritical]
		object GetOutArg(int argNum);

		/// <summary>Returns the specified argument marked as a <see langword="ref" /> or an <see langword="out" /> parameter.</summary>
		/// <returns>The specified argument marked as a <see langword="ref" /> or an <see langword="out" /> parameter.</returns>
		/// <exception cref="T:System.Security.SecurityException">The immediate caller makes the call through a reference to the interface and does not have infrastructure permission.</exception>
		// Token: 0x17000F1B RID: 3867
		// (get) Token: 0x06005976 RID: 22902
		object[] OutArgs { [SecurityCritical] get; }

		/// <summary>Gets the exception thrown during the method call.</summary>
		/// <returns>The exception object for the method call, or <see langword="null" /> if the method did not throw an exception.</returns>
		/// <exception cref="T:System.Security.SecurityException">The immediate caller makes the call through a reference to the interface and does not have infrastructure permission.</exception>
		// Token: 0x17000F1C RID: 3868
		// (get) Token: 0x06005977 RID: 22903
		Exception Exception { [SecurityCritical] get; }

		/// <summary>Gets the return value of the method call.</summary>
		/// <returns>The return value of the method call.</returns>
		/// <exception cref="T:System.Security.SecurityException">The immediate caller makes the call through a reference to the interface and does not have infrastructure permission.</exception>
		// Token: 0x17000F1D RID: 3869
		// (get) Token: 0x06005978 RID: 22904
		object ReturnValue { [SecurityCritical] get; }
	}
}
