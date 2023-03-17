using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security;

namespace System.Reflection
{
	/// <summary>Represents a missing <see cref="T:System.Object" />. This class cannot be inherited.</summary>
	// Token: 0x020005DD RID: 1501
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public sealed class Missing : ISerializable
	{
		// Token: 0x06004668 RID: 18024 RVA: 0x0010004F File Offset: 0x000FE24F
		private Missing()
		{
		}

		/// <summary>Sets a <see cref="T:System.Runtime.Serialization.SerializationInfo" /> object with the logical context information needed to recreate the sole instance of the <see cref="T:System.Reflection.Missing" /> object.</summary>
		/// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> object to be populated with serialization information.</param>
		/// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext" /> object representing the destination context of the serialization.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="info" /> is <see langword="null" />.</exception>
		// Token: 0x06004669 RID: 18025 RVA: 0x00100057 File Offset: 0x000FE257
		[SecurityCritical]
		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
		{
			if (info == null)
			{
				throw new ArgumentNullException("info");
			}
			UnitySerializationHolder.GetUnitySerializationInfo(info, this);
		}

		/// <summary>Represents the sole instance of the <see cref="T:System.Reflection.Missing" /> class.</summary>
		// Token: 0x04001CF2 RID: 7410
		[__DynamicallyInvokable]
		public static readonly Missing Value = new Missing();
	}
}
