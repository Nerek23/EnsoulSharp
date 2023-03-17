using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Security;

namespace System.Runtime.Serialization.Formatters.Binary
{
	/// <summary>Serializes and deserializes an object, or an entire graph of connected objects, in binary format.</summary>
	// Token: 0x0200074C RID: 1868
	[ComVisible(true)]
	public sealed class BinaryFormatter : IRemotingFormatter, IFormatter
	{
		/// <summary>Gets or sets the format in which type descriptions are laid out in the serialized stream.</summary>
		/// <returns>The style of type layouts to use.</returns>
		// Token: 0x17000DB7 RID: 3511
		// (get) Token: 0x06005217 RID: 21015 RVA: 0x0011F4C0 File Offset: 0x0011D6C0
		// (set) Token: 0x06005218 RID: 21016 RVA: 0x0011F4C8 File Offset: 0x0011D6C8
		public FormatterTypeStyle TypeFormat
		{
			get
			{
				return this.m_typeFormat;
			}
			set
			{
				this.m_typeFormat = value;
			}
		}

		/// <summary>Gets or sets the behavior of the deserializer with regards to finding and loading assemblies.</summary>
		/// <returns>One of the <see cref="T:System.Runtime.Serialization.Formatters.FormatterAssemblyStyle" /> values that specifies the deserializer behavior.</returns>
		// Token: 0x17000DB8 RID: 3512
		// (get) Token: 0x06005219 RID: 21017 RVA: 0x0011F4D1 File Offset: 0x0011D6D1
		// (set) Token: 0x0600521A RID: 21018 RVA: 0x0011F4D9 File Offset: 0x0011D6D9
		public FormatterAssemblyStyle AssemblyFormat
		{
			get
			{
				return this.m_assemblyFormat;
			}
			set
			{
				this.m_assemblyFormat = value;
			}
		}

		/// <summary>Gets or sets the <see cref="T:System.Runtime.Serialization.Formatters.TypeFilterLevel" /> of automatic deserialization the <see cref="T:System.Runtime.Serialization.Formatters.Binary.BinaryFormatter" /> performs.</summary>
		/// <returns>The <see cref="T:System.Runtime.Serialization.Formatters.TypeFilterLevel" /> that represents the current automatic deserialization level.</returns>
		// Token: 0x17000DB9 RID: 3513
		// (get) Token: 0x0600521B RID: 21019 RVA: 0x0011F4E2 File Offset: 0x0011D6E2
		// (set) Token: 0x0600521C RID: 21020 RVA: 0x0011F4EA File Offset: 0x0011D6EA
		public TypeFilterLevel FilterLevel
		{
			get
			{
				return this.m_securityLevel;
			}
			set
			{
				this.m_securityLevel = value;
			}
		}

		/// <summary>Gets or sets a <see cref="T:System.Runtime.Serialization.ISurrogateSelector" /> that controls type substitution during serialization and deserialization.</summary>
		/// <returns>The surrogate selector to use with this formatter.</returns>
		// Token: 0x17000DBA RID: 3514
		// (get) Token: 0x0600521D RID: 21021 RVA: 0x0011F4F3 File Offset: 0x0011D6F3
		// (set) Token: 0x0600521E RID: 21022 RVA: 0x0011F4FB File Offset: 0x0011D6FB
		public ISurrogateSelector SurrogateSelector
		{
			get
			{
				return this.m_surrogates;
			}
			set
			{
				this.m_surrogates = value;
			}
		}

		/// <summary>Gets or sets an object of type <see cref="T:System.Runtime.Serialization.SerializationBinder" /> that controls the binding of a serialized object to a type.</summary>
		/// <returns>The serialization binder to use with this formatter.</returns>
		// Token: 0x17000DBB RID: 3515
		// (get) Token: 0x0600521F RID: 21023 RVA: 0x0011F504 File Offset: 0x0011D704
		// (set) Token: 0x06005220 RID: 21024 RVA: 0x0011F50C File Offset: 0x0011D70C
		public SerializationBinder Binder
		{
			get
			{
				return this.m_binder;
			}
			set
			{
				this.m_binder = value;
			}
		}

		/// <summary>Gets or sets the <see cref="T:System.Runtime.Serialization.StreamingContext" /> for this formatter.</summary>
		/// <returns>The streaming context to use with this formatter.</returns>
		// Token: 0x17000DBC RID: 3516
		// (get) Token: 0x06005221 RID: 21025 RVA: 0x0011F515 File Offset: 0x0011D715
		// (set) Token: 0x06005222 RID: 21026 RVA: 0x0011F51D File Offset: 0x0011D71D
		public StreamingContext Context
		{
			get
			{
				return this.m_context;
			}
			set
			{
				this.m_context = value;
			}
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.Serialization.Formatters.Binary.BinaryFormatter" /> class with default values.</summary>
		// Token: 0x06005223 RID: 21027 RVA: 0x0011F526 File Offset: 0x0011D726
		public BinaryFormatter()
		{
			this.m_surrogates = null;
			this.m_context = new StreamingContext(StreamingContextStates.All);
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.Serialization.Formatters.Binary.BinaryFormatter" /> class with a given surrogate selector and streaming context.</summary>
		/// <param name="selector">The <see cref="T:System.Runtime.Serialization.ISurrogateSelector" /> to use. Can be <see langword="null" />.</param>
		/// <param name="context">The source and destination for the serialized data.</param>
		// Token: 0x06005224 RID: 21028 RVA: 0x0011F553 File Offset: 0x0011D753
		public BinaryFormatter(ISurrogateSelector selector, StreamingContext context)
		{
			this.m_surrogates = selector;
			this.m_context = context;
		}

		/// <summary>Deserializes the specified stream into an object graph.</summary>
		/// <param name="serializationStream">The stream from which to deserialize the object graph.</param>
		/// <returns>The top (root) of the object graph.</returns>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="serializationStream" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.Runtime.Serialization.SerializationException">The <paramref name="serializationStream" /> supports seeking, but its length is 0.  
		///  -or-  
		///  The target type is a <see cref="T:System.Decimal" />, but the value is out of range of the <see cref="T:System.Decimal" /> type.</exception>
		/// <exception cref="T:System.Security.SecurityException">The caller does not have the required permission.</exception>
		// Token: 0x06005225 RID: 21029 RVA: 0x0011F577 File Offset: 0x0011D777
		public object Deserialize(Stream serializationStream)
		{
			return this.Deserialize(serializationStream, null);
		}

		// Token: 0x06005226 RID: 21030 RVA: 0x0011F581 File Offset: 0x0011D781
		[SecurityCritical]
		internal object Deserialize(Stream serializationStream, HeaderHandler handler, bool fCheck)
		{
			return this.Deserialize(serializationStream, handler, fCheck, null);
		}

		/// <summary>Deserializes the specified stream into an object graph. The provided <see cref="T:System.Runtime.Remoting.Messaging.HeaderHandler" /> handles any headers in that stream.</summary>
		/// <param name="serializationStream">The stream from which to deserialize the object graph.</param>
		/// <param name="handler">The <see cref="T:System.Runtime.Remoting.Messaging.HeaderHandler" /> that handles any headers in the <paramref name="serializationStream" />. Can be <see langword="null" />.</param>
		/// <returns>The deserialized object or the top object (root) of the object graph.</returns>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="serializationStream" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.Runtime.Serialization.SerializationException">The <paramref name="serializationStream" /> supports seeking, but its length is 0.  
		///  -or-  
		///  The target type is a <see cref="T:System.Decimal" />, but the value is out of range of the <see cref="T:System.Decimal" /> type.</exception>
		/// <exception cref="T:System.Security.SecurityException">The caller does not have the required permission.</exception>
		// Token: 0x06005227 RID: 21031 RVA: 0x0011F58D File Offset: 0x0011D78D
		[SecuritySafeCritical]
		public object Deserialize(Stream serializationStream, HeaderHandler handler)
		{
			return this.Deserialize(serializationStream, handler, true);
		}

		/// <summary>Deserializes a response to a remote method call from the provided <see cref="T:System.IO.Stream" />.</summary>
		/// <param name="serializationStream">The stream from which to deserialize the object graph.</param>
		/// <param name="handler">The <see cref="T:System.Runtime.Remoting.Messaging.HeaderHandler" /> that handles any headers in the <paramref name="serializationStream" />. Can be <see langword="null" />.</param>
		/// <param name="methodCallMessage">The <see cref="T:System.Runtime.Remoting.Messaging.IMethodCallMessage" /> that contains details about where the call came from.</param>
		/// <returns>The deserialized response to the remote method call.</returns>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="serializationStream" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.Runtime.Serialization.SerializationException">The <paramref name="serializationStream" /> supports seeking, but its length is 0.</exception>
		/// <exception cref="T:System.Security.SecurityException">The caller does not have the required permission.</exception>
		// Token: 0x06005228 RID: 21032 RVA: 0x0011F598 File Offset: 0x0011D798
		[SecuritySafeCritical]
		public object DeserializeMethodResponse(Stream serializationStream, HeaderHandler handler, IMethodCallMessage methodCallMessage)
		{
			return this.Deserialize(serializationStream, handler, true, methodCallMessage);
		}

		/// <summary>Deserializes the specified stream into an object graph. The provided <see cref="T:System.Runtime.Remoting.Messaging.HeaderHandler" /> handles any headers in that stream.</summary>
		/// <param name="serializationStream">The stream from which to deserialize the object graph.</param>
		/// <param name="handler">The <see cref="T:System.Runtime.Remoting.Messaging.HeaderHandler" /> that handles any headers in the <paramref name="serializationStream" />. Can be <see langword="null" />.</param>
		/// <returns>The deserialized object or the top object (root) of the object graph.</returns>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="serializationStream" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.Runtime.Serialization.SerializationException">The <paramref name="serializationStream" /> supports seeking, but its length is 0.</exception>
		/// <exception cref="T:System.Security.SecurityException">The caller does not have the required permission.</exception>
		// Token: 0x06005229 RID: 21033 RVA: 0x0011F5A4 File Offset: 0x0011D7A4
		[SecurityCritical]
		[ComVisible(false)]
		public object UnsafeDeserialize(Stream serializationStream, HeaderHandler handler)
		{
			return this.Deserialize(serializationStream, handler, false);
		}

		/// <summary>Deserializes a response to a remote method call from the provided <see cref="T:System.IO.Stream" />.</summary>
		/// <param name="serializationStream">The stream from which to deserialize the object graph.</param>
		/// <param name="handler">The <see cref="T:System.Runtime.Remoting.Messaging.HeaderHandler" /> that handles any headers in the <paramref name="serializationStream" />. Can be <see langword="null" />.</param>
		/// <param name="methodCallMessage">The <see cref="T:System.Runtime.Remoting.Messaging.IMethodCallMessage" /> that contains details about where the call came from.</param>
		/// <returns>The deserialized response to the remote method call.</returns>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="serializationStream" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.Runtime.Serialization.SerializationException">The <paramref name="serializationStream" /> supports seeking, but its length is 0.</exception>
		/// <exception cref="T:System.Security.SecurityException">The caller does not have the required permission.</exception>
		// Token: 0x0600522A RID: 21034 RVA: 0x0011F5AF File Offset: 0x0011D7AF
		[SecurityCritical]
		[ComVisible(false)]
		public object UnsafeDeserializeMethodResponse(Stream serializationStream, HeaderHandler handler, IMethodCallMessage methodCallMessage)
		{
			return this.Deserialize(serializationStream, handler, false, methodCallMessage);
		}

		// Token: 0x0600522B RID: 21035 RVA: 0x0011F5BB File Offset: 0x0011D7BB
		[SecurityCritical]
		internal object Deserialize(Stream serializationStream, HeaderHandler handler, bool fCheck, IMethodCallMessage methodCallMessage)
		{
			return this.Deserialize(serializationStream, handler, fCheck, false, methodCallMessage);
		}

		// Token: 0x0600522C RID: 21036 RVA: 0x0011F5CC File Offset: 0x0011D7CC
		[SecurityCritical]
		internal object Deserialize(Stream serializationStream, HeaderHandler handler, bool fCheck, bool isCrossAppDomain, IMethodCallMessage methodCallMessage)
		{
			if (serializationStream == null)
			{
				throw new ArgumentNullException("serializationStream", Environment.GetResourceString("ArgumentNull_WithParamName", new object[]
				{
					serializationStream
				}));
			}
			if (serializationStream.CanSeek && serializationStream.Length == 0L)
			{
				throw new SerializationException(Environment.GetResourceString("Serialization_Stream"));
			}
			InternalFE internalFE = new InternalFE();
			internalFE.FEtypeFormat = this.m_typeFormat;
			internalFE.FEserializerTypeEnum = InternalSerializerTypeE.Binary;
			internalFE.FEassemblyFormat = this.m_assemblyFormat;
			internalFE.FEsecurityLevel = this.m_securityLevel;
			ObjectReader objectReader = new ObjectReader(serializationStream, this.m_surrogates, this.m_context, internalFE, this.m_binder);
			objectReader.crossAppDomainArray = this.m_crossAppDomainArray;
			return objectReader.Deserialize(handler, new __BinaryParser(serializationStream, objectReader), fCheck, isCrossAppDomain, methodCallMessage);
		}

		/// <summary>Serializes the object, or graph of objects with the specified top (root), to the given stream.</summary>
		/// <param name="serializationStream">The stream to which the graph is to be serialized.</param>
		/// <param name="graph">The object at the root of the graph to serialize.</param>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="serializationStream" /> is <see langword="null" />.  
		///  -or-  
		///  The <paramref name="graph" /> is null.</exception>
		/// <exception cref="T:System.Runtime.Serialization.SerializationException">An error has occurred during serialization, such as if an object in the <paramref name="graph" /> parameter is not marked as serializable.</exception>
		/// <exception cref="T:System.Security.SecurityException">The caller does not have the required permission.</exception>
		// Token: 0x0600522D RID: 21037 RVA: 0x0011F685 File Offset: 0x0011D885
		public void Serialize(Stream serializationStream, object graph)
		{
			this.Serialize(serializationStream, graph, null);
		}

		/// <summary>Serializes the object, or graph of objects with the specified top (root), to the given stream attaching the provided headers.</summary>
		/// <param name="serializationStream">The stream to which the object is to be serialized.</param>
		/// <param name="graph">The object at the root of the graph to serialize.</param>
		/// <param name="headers">Remoting headers to include in the serialization. Can be <see langword="null" />.</param>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="serializationStream" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.Runtime.Serialization.SerializationException">An error has occurred during serialization, such as if an object in the <paramref name="graph" /> parameter is not marked as serializable.</exception>
		/// <exception cref="T:System.Security.SecurityException">The caller does not have the required permission.</exception>
		// Token: 0x0600522E RID: 21038 RVA: 0x0011F690 File Offset: 0x0011D890
		[SecuritySafeCritical]
		public void Serialize(Stream serializationStream, object graph, Header[] headers)
		{
			this.Serialize(serializationStream, graph, headers, true);
		}

		// Token: 0x0600522F RID: 21039 RVA: 0x0011F69C File Offset: 0x0011D89C
		[SecurityCritical]
		internal void Serialize(Stream serializationStream, object graph, Header[] headers, bool fCheck)
		{
			if (serializationStream == null)
			{
				throw new ArgumentNullException("serializationStream", Environment.GetResourceString("ArgumentNull_WithParamName", new object[]
				{
					serializationStream
				}));
			}
			InternalFE internalFE = new InternalFE();
			internalFE.FEtypeFormat = this.m_typeFormat;
			internalFE.FEserializerTypeEnum = InternalSerializerTypeE.Binary;
			internalFE.FEassemblyFormat = this.m_assemblyFormat;
			ObjectWriter objectWriter = new ObjectWriter(this.m_surrogates, this.m_context, internalFE, this.m_binder);
			__BinaryWriter serWriter = new __BinaryWriter(serializationStream, objectWriter, this.m_typeFormat);
			objectWriter.Serialize(graph, headers, serWriter, fCheck);
			this.m_crossAppDomainArray = objectWriter.crossAppDomainArray;
		}

		// Token: 0x06005230 RID: 21040 RVA: 0x0011F730 File Offset: 0x0011D930
		internal static TypeInformation GetTypeInformation(Type type)
		{
			if (AppContextSwitches.UseConcurrentFormatterTypeCache)
			{
				return BinaryFormatter.concurrentTypeNameCache.Value.GetOrAdd(type, delegate(Type t)
				{
					bool hasTypeForwardedFrom2;
					string clrAssemblyName2 = FormatterServices.GetClrAssemblyName(t, out hasTypeForwardedFrom2);
					return new TypeInformation(FormatterServices.GetClrTypeFullName(t), clrAssemblyName2, hasTypeForwardedFrom2);
				});
			}
			Dictionary<Type, TypeInformation> obj = BinaryFormatter.typeNameCache;
			TypeInformation result;
			lock (obj)
			{
				TypeInformation typeInformation = null;
				if (!BinaryFormatter.typeNameCache.TryGetValue(type, out typeInformation))
				{
					bool hasTypeForwardedFrom;
					string clrAssemblyName = FormatterServices.GetClrAssemblyName(type, out hasTypeForwardedFrom);
					typeInformation = new TypeInformation(FormatterServices.GetClrTypeFullName(type), clrAssemblyName, hasTypeForwardedFrom);
					BinaryFormatter.typeNameCache.Add(type, typeInformation);
				}
				result = typeInformation;
			}
			return result;
		}

		// Token: 0x040024BF RID: 9407
		internal ISurrogateSelector m_surrogates;

		// Token: 0x040024C0 RID: 9408
		internal StreamingContext m_context;

		// Token: 0x040024C1 RID: 9409
		internal SerializationBinder m_binder;

		// Token: 0x040024C2 RID: 9410
		internal FormatterTypeStyle m_typeFormat = FormatterTypeStyle.TypesAlways;

		// Token: 0x040024C3 RID: 9411
		internal FormatterAssemblyStyle m_assemblyFormat;

		// Token: 0x040024C4 RID: 9412
		internal TypeFilterLevel m_securityLevel = TypeFilterLevel.Full;

		// Token: 0x040024C5 RID: 9413
		internal object[] m_crossAppDomainArray;

		// Token: 0x040024C6 RID: 9414
		private static Dictionary<Type, TypeInformation> typeNameCache = new Dictionary<Type, TypeInformation>();

		// Token: 0x040024C7 RID: 9415
		private static Lazy<ConcurrentDictionary<Type, TypeInformation>> concurrentTypeNameCache = new Lazy<ConcurrentDictionary<Type, TypeInformation>>(() => new ConcurrentDictionary<Type, TypeInformation>());
	}
}
