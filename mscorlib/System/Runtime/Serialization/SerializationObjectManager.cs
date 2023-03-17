using System;
using System.Collections;
using System.Security;

namespace System.Runtime.Serialization
{
	/// <summary>Manages serialization processes at run time. This class cannot be inherited.</summary>
	// Token: 0x02000729 RID: 1833
	public sealed class SerializationObjectManager
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.Serialization.SerializationObjectManager" /> class.</summary>
		/// <param name="context">An instance of the <see cref="T:System.Runtime.Serialization.StreamingContext" /> class that contains information about the current serialization operation.</param>
		// Token: 0x060051BC RID: 20924 RVA: 0x0011E88E File Offset: 0x0011CA8E
		public SerializationObjectManager(StreamingContext context)
		{
			this.m_context = context;
			this.m_objectSeenTable = new Hashtable();
		}

		/// <summary>Registers the object upon which events will be raised.</summary>
		/// <param name="obj">The object to register.</param>
		// Token: 0x060051BD RID: 20925 RVA: 0x0011E8B4 File Offset: 0x0011CAB4
		[SecurityCritical]
		public void RegisterObject(object obj)
		{
			SerializationEvents serializationEventsForType = SerializationEventsCache.GetSerializationEventsForType(obj.GetType());
			if (serializationEventsForType.HasOnSerializingEvents && this.m_objectSeenTable[obj] == null)
			{
				this.m_objectSeenTable[obj] = true;
				serializationEventsForType.InvokeOnSerializing(obj, this.m_context);
				this.AddOnSerialized(obj);
			}
		}

		/// <summary>Invokes the OnSerializing callback event if the type of the object has one; and registers the object for raising the OnSerialized event if the type of the object has one.</summary>
		// Token: 0x060051BE RID: 20926 RVA: 0x0011E909 File Offset: 0x0011CB09
		public void RaiseOnSerializedEvent()
		{
			if (this.m_onSerializedHandler != null)
			{
				this.m_onSerializedHandler(this.m_context);
			}
		}

		// Token: 0x060051BF RID: 20927 RVA: 0x0011E924 File Offset: 0x0011CB24
		[SecuritySafeCritical]
		private void AddOnSerialized(object obj)
		{
			SerializationEvents serializationEventsForType = SerializationEventsCache.GetSerializationEventsForType(obj.GetType());
			this.m_onSerializedHandler = serializationEventsForType.AddOnSerialized(obj, this.m_onSerializedHandler);
		}

		// Token: 0x04002402 RID: 9218
		private Hashtable m_objectSeenTable = new Hashtable();

		// Token: 0x04002403 RID: 9219
		private SerializationEventHandler m_onSerializedHandler;

		// Token: 0x04002404 RID: 9220
		private StreamingContext m_context;
	}
}
