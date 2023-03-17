using System;
using System.Globalization;
using System.Runtime.Serialization;
using System.Security;
using Microsoft.Win32;

namespace System.Runtime.InteropServices
{
	/// <summary>The exception that is thrown when an unrecognized HRESULT is returned from a COM method call.</summary>
	// Token: 0x02000917 RID: 2327
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public class COMException : ExternalException
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.InteropServices.COMException" /> class with default values.</summary>
		// Token: 0x06005F48 RID: 24392 RVA: 0x001474C5 File Offset: 0x001456C5
		[__DynamicallyInvokable]
		public COMException() : base(Environment.GetResourceString("Arg_COMException"))
		{
			base.SetErrorCode(-2147467259);
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.InteropServices.COMException" /> class with a specified message.</summary>
		/// <param name="message">The message that indicates the reason for the exception.</param>
		// Token: 0x06005F49 RID: 24393 RVA: 0x001474E2 File Offset: 0x001456E2
		[__DynamicallyInvokable]
		public COMException(string message) : base(message)
		{
			base.SetErrorCode(-2147467259);
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.InteropServices.COMException" /> class with a specified error message and a reference to the inner exception that is the cause of this exception.</summary>
		/// <param name="message">The error message that explains the reason for the exception.</param>
		/// <param name="inner">The exception that is the cause of the current exception. If the <paramref name="inner" /> parameter is not <see langword="null" />, the current exception is raised in a <see langword="catch" /> block that handles the inner exception.</param>
		// Token: 0x06005F4A RID: 24394 RVA: 0x001474F6 File Offset: 0x001456F6
		[__DynamicallyInvokable]
		public COMException(string message, Exception inner) : base(message, inner)
		{
			base.SetErrorCode(-2147467259);
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.InteropServices.COMException" /> class with a specified message and error code.</summary>
		/// <param name="message">The message that indicates the reason the exception occurred.</param>
		/// <param name="errorCode">The error code (HRESULT) value associated with this exception.</param>
		// Token: 0x06005F4B RID: 24395 RVA: 0x0014750B File Offset: 0x0014570B
		[__DynamicallyInvokable]
		public COMException(string message, int errorCode) : base(message)
		{
			base.SetErrorCode(errorCode);
		}

		// Token: 0x06005F4C RID: 24396 RVA: 0x0014751B File Offset: 0x0014571B
		[SecuritySafeCritical]
		internal COMException(int hresult) : base(Win32Native.GetMessage(hresult))
		{
			base.SetErrorCode(hresult);
		}

		// Token: 0x06005F4D RID: 24397 RVA: 0x00147530 File Offset: 0x00145730
		internal COMException(string message, int hresult, Exception inner) : base(message, inner)
		{
			base.SetErrorCode(hresult);
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.InteropServices.COMException" /> class from serialization data.</summary>
		/// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> object that holds the serialized object data.</param>
		/// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext" /> object that supplies the contextual information about the source or destination.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="info" /> is <see langword="null" />.</exception>
		// Token: 0x06005F4E RID: 24398 RVA: 0x00147541 File Offset: 0x00145741
		protected COMException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}

		/// <summary>Converts the contents of the exception to a string.</summary>
		/// <returns>A string containing the <see cref="P:System.Exception.HResult" />, <see cref="P:System.Exception.Message" />, <see cref="P:System.Exception.InnerException" />, and <see cref="P:System.Exception.StackTrace" /> properties of the exception.</returns>
		// Token: 0x06005F4F RID: 24399 RVA: 0x0014754C File Offset: 0x0014574C
		public override string ToString()
		{
			string message = this.Message;
			string str = base.GetType().ToString();
			string text = str + " (0x" + base.HResult.ToString("X8", CultureInfo.InvariantCulture) + ")";
			if (message != null && message.Length > 0)
			{
				text = text + ": " + message;
			}
			Exception innerException = base.InnerException;
			if (innerException != null)
			{
				text = text + " ---> " + innerException.ToString();
			}
			if (this.StackTrace != null)
			{
				text = text + Environment.NewLine + this.StackTrace;
			}
			return text;
		}
	}
}
