using System;
using System.IO;
using System.Runtime.InteropServices;

namespace System.Runtime.Serialization
{
	/// <summary>Provides functionality for formatting serialized objects.</summary>
	// Token: 0x02000705 RID: 1797
	[ComVisible(true)]
	public interface IFormatter
	{
		/// <summary>Deserializes the data on the provided stream and reconstitutes the graph of objects.</summary>
		/// <param name="serializationStream">The stream that contains the data to deserialize.</param>
		/// <returns>The top object of the deserialized graph.</returns>
		// Token: 0x06005087 RID: 20615
		object Deserialize(Stream serializationStream);

		/// <summary>Serializes an object, or graph of objects with the given root to the provided stream.</summary>
		/// <param name="serializationStream">The stream where the formatter puts the serialized data. This stream can reference a variety of backing stores (such as files, network, memory, and so on).</param>
		/// <param name="graph">The object, or root of the object graph, to serialize. All child objects of this root object are automatically serialized.</param>
		// Token: 0x06005088 RID: 20616
		void Serialize(Stream serializationStream, object graph);

		/// <summary>Gets or sets the <see cref="T:System.Runtime.Serialization.SurrogateSelector" /> used by the current formatter.</summary>
		/// <returns>The <see cref="T:System.Runtime.Serialization.SurrogateSelector" /> used by this formatter.</returns>
		// Token: 0x17000D5A RID: 3418
		// (get) Token: 0x06005089 RID: 20617
		// (set) Token: 0x0600508A RID: 20618
		ISurrogateSelector SurrogateSelector { get; set; }

		/// <summary>Gets or sets the <see cref="T:System.Runtime.Serialization.SerializationBinder" /> that performs type lookups during deserialization.</summary>
		/// <returns>The <see cref="T:System.Runtime.Serialization.SerializationBinder" /> that performs type lookups during deserialization.</returns>
		// Token: 0x17000D5B RID: 3419
		// (get) Token: 0x0600508B RID: 20619
		// (set) Token: 0x0600508C RID: 20620
		SerializationBinder Binder { get; set; }

		/// <summary>Gets or sets the <see cref="T:System.Runtime.Serialization.StreamingContext" /> used for serialization and deserialization.</summary>
		/// <returns>The <see cref="T:System.Runtime.Serialization.StreamingContext" /> used for serialization and deserialization.</returns>
		// Token: 0x17000D5C RID: 3420
		// (get) Token: 0x0600508D RID: 20621
		// (set) Token: 0x0600508E RID: 20622
		StreamingContext Context { get; set; }
	}
}
