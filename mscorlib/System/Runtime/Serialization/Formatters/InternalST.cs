using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Runtime.Serialization.Formatters
{
	/// <summary>Logs tracing messages when the .NET Framework serialization infrastructure is compiled.</summary>
	// Token: 0x02000736 RID: 1846
	[SecurityCritical]
	[ComVisible(true)]
	public sealed class InternalST
	{
		// Token: 0x060051EC RID: 20972 RVA: 0x0011F163 File Offset: 0x0011D363
		private InternalST()
		{
		}

		/// <summary>Prints SOAP trace messages.</summary>
		/// <param name="messages">An array of trace messages to print.</param>
		// Token: 0x060051ED RID: 20973 RVA: 0x0011F16B File Offset: 0x0011D36B
		[Conditional("_LOGGING")]
		public static void InfoSoap(params object[] messages)
		{
		}

		/// <summary>Checks if SOAP tracing is enabled.</summary>
		/// <returns>
		///   <see langword="true" />, if tracing is enabled; otherwise, <see langword="false" />.</returns>
		// Token: 0x060051EE RID: 20974 RVA: 0x0011F16D File Offset: 0x0011D36D
		public static bool SoapCheckEnabled()
		{
			return BCLDebug.CheckEnabled("Soap");
		}

		/// <summary>Processes the specified array of messages.</summary>
		/// <param name="messages">An array of messages to process.</param>
		// Token: 0x060051EF RID: 20975 RVA: 0x0011F179 File Offset: 0x0011D379
		[Conditional("SER_LOGGING")]
		public static void Soap(params object[] messages)
		{
			if (!(messages[0] is string))
			{
				messages[0] = messages[0].GetType().Name + " ";
				return;
			}
			messages[0] = messages[0] + " ";
		}

		/// <summary>Asserts the specified message.</summary>
		/// <param name="condition">A Boolean value to use when asserting.</param>
		/// <param name="message">The message to use when asserting.</param>
		// Token: 0x060051F0 RID: 20976 RVA: 0x0011F1B0 File Offset: 0x0011D3B0
		[Conditional("_DEBUG")]
		public static void SoapAssert(bool condition, string message)
		{
		}

		/// <summary>Sets the value of a field.</summary>
		/// <param name="fi">A <see cref="T:System.Reflection.FieldInfo" /> containing data about the target field.</param>
		/// <param name="target">The field to change.</param>
		/// <param name="value">The value to set.</param>
		// Token: 0x060051F1 RID: 20977 RVA: 0x0011F1B2 File Offset: 0x0011D3B2
		public static void SerializationSetValue(FieldInfo fi, object target, object value)
		{
			if (fi == null)
			{
				throw new ArgumentNullException("fi");
			}
			if (target == null)
			{
				throw new ArgumentNullException("target");
			}
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			FormatterServices.SerializationSetValue(fi, target, value);
		}

		/// <summary>Loads a specified assembly to debug.</summary>
		/// <param name="assemblyString">The name of the assembly to load.</param>
		/// <returns>The <see cref="T:System.Reflection.Assembly" /> to debug.</returns>
		// Token: 0x060051F2 RID: 20978 RVA: 0x0011F1EC File Offset: 0x0011D3EC
		public static Assembly LoadAssemblyFromString(string assemblyString)
		{
			return FormatterServices.LoadAssemblyFromString(assemblyString);
		}
	}
}
