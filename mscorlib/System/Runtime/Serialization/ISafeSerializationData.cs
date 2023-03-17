using System;

namespace System.Runtime.Serialization
{
	/// <summary>Enables serialization of custom exception data in security-transparent code.</summary>
	// Token: 0x02000727 RID: 1831
	public interface ISafeSerializationData
	{
		/// <summary>This method is called when the instance is deserialized.</summary>
		/// <param name="deserialized">An object that contains the state of the instance.</param>
		// Token: 0x060051B1 RID: 20913
		void CompleteDeserialization(object deserialized);
	}
}
