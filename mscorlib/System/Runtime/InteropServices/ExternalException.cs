using System;
using System.Globalization;
using System.Runtime.Serialization;

namespace System.Runtime.InteropServices
{
	/// <summary>The base exception type for all COM interop exceptions and structured exception handling (SEH) exceptions.</summary>
	// Token: 0x02000919 RID: 2329
	[ComVisible(true)]
	[Serializable]
	public class ExternalException : SystemException
	{
		/// <summary>Initializes a new instance of the <see langword="ExternalException" /> class with default properties.</summary>
		// Token: 0x06005F5C RID: 24412 RVA: 0x001476AC File Offset: 0x001458AC
		public ExternalException() : base(Environment.GetResourceString("Arg_ExternalException"))
		{
			base.SetErrorCode(-2147467259);
		}

		/// <summary>Initializes a new instance of the <see langword="ExternalException" /> class with a specified error message.</summary>
		/// <param name="message">The error message that specifies the reason for the exception.</param>
		// Token: 0x06005F5D RID: 24413 RVA: 0x001476C9 File Offset: 0x001458C9
		public ExternalException(string message) : base(message)
		{
			base.SetErrorCode(-2147467259);
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.InteropServices.ExternalException" /> class with a specified error message and a reference to the inner exception that is the cause of this exception.</summary>
		/// <param name="message">The error message that explains the reason for the exception.</param>
		/// <param name="inner">The exception that is the cause of the current exception. If the <paramref name="inner" /> parameter is not <see langword="null" />, the current exception is raised in a <see langword="catch" /> block that handles the inner exception.</param>
		// Token: 0x06005F5E RID: 24414 RVA: 0x001476DD File Offset: 0x001458DD
		public ExternalException(string message, Exception inner) : base(message, inner)
		{
			base.SetErrorCode(-2147467259);
		}

		/// <summary>Initializes a new instance of the <see langword="ExternalException" /> class with a specified error message and the HRESULT of the error.</summary>
		/// <param name="message">The error message that specifies the reason for the exception.</param>
		/// <param name="errorCode">The HRESULT of the error.</param>
		// Token: 0x06005F5F RID: 24415 RVA: 0x001476F2 File Offset: 0x001458F2
		public ExternalException(string message, int errorCode) : base(message)
		{
			base.SetErrorCode(errorCode);
		}

		/// <summary>Initializes a new instance of the <see langword="ExternalException" /> class from serialization data.</summary>
		/// <param name="info">The object that holds the serialized object data.</param>
		/// <param name="context">The contextual information about the source or destination.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="info" /> is <see langword="null" />.</exception>
		// Token: 0x06005F60 RID: 24416 RVA: 0x00147702 File Offset: 0x00145902
		protected ExternalException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}

		/// <summary>Gets the <see langword="HRESULT" /> of the error.</summary>
		/// <returns>The <see langword="HRESULT" /> of the error.</returns>
		// Token: 0x170010E1 RID: 4321
		// (get) Token: 0x06005F61 RID: 24417 RVA: 0x0014770C File Offset: 0x0014590C
		public virtual int ErrorCode
		{
			get
			{
				return base.HResult;
			}
		}

		/// <summary>Returns a string that contains the HRESULT of the error.</summary>
		/// <returns>A string that represents the HRESULT.</returns>
		// Token: 0x06005F62 RID: 24418 RVA: 0x00147714 File Offset: 0x00145914
		public override string ToString()
		{
			string message = this.Message;
			string str = base.GetType().ToString();
			string text = str + " (0x" + base.HResult.ToString("X8", CultureInfo.InvariantCulture) + ")";
			if (!string.IsNullOrEmpty(message))
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
