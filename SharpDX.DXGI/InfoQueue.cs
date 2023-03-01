using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.DXGI
{
	// Token: 0x02000011 RID: 17
	[Guid("D67441C7-672A-476f-9E82-CD55B44949CE")]
	public class InfoQueue : ComObject
	{
		// Token: 0x0600006F RID: 111 RVA: 0x00003538 File Offset: 0x00001738
		public static InfoQueue TryCreate()
		{
			IntPtr nativePtr;
			if (!DebugInterface.TryCreateComPtr<InfoQueue>(out nativePtr))
			{
				return null;
			}
			return new InfoQueue(nativePtr);
		}

		// Token: 0x06000070 RID: 112 RVA: 0x0000272E File Offset: 0x0000092E
		public InfoQueue(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000071 RID: 113 RVA: 0x00003556 File Offset: 0x00001756
		public new static explicit operator InfoQueue(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new InfoQueue(nativePtr);
			}
			return null;
		}

		// Token: 0x06000072 RID: 114 RVA: 0x00003570 File Offset: 0x00001770
		public unsafe void SetMessageCountLimit(Guid producer, long messageCountLimit)
		{
			calli(System.Int32(System.Void*,System.Guid,System.Int64), this._nativePointer, producer, messageCountLimit, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000073 RID: 115 RVA: 0x000035A9 File Offset: 0x000017A9
		public unsafe void ClearStoredMessages(Guid producer)
		{
			calli(System.Void(System.Void*,System.Guid), this._nativePointer, producer, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000074 RID: 116 RVA: 0x000035CC File Offset: 0x000017CC
		public unsafe void GetMessage(Guid producer, long messageIndex, InformationQueueMessage[] messageRef, ref PointerSize messageByteLengthRef)
		{
			InformationQueueMessage.__Native[] array = (messageRef == null) ? null : new InformationQueueMessage.__Native[messageRef.Length];
			Result result;
			fixed (PointerSize* ptr = &messageByteLengthRef)
			{
				void* ptr2 = (void*)ptr;
				InformationQueueMessage.__Native[] array2;
				void* ptr3;
				if ((array2 = array) == null || array2.Length == 0)
				{
					ptr3 = null;
				}
				else
				{
					ptr3 = (void*)(&array2[0]);
				}
				result = calli(System.Int32(System.Void*,System.Guid,System.Int64,System.Void*,System.Void*), this._nativePointer, producer, messageIndex, ptr3, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*)));
				array2 = null;
			}
			if (messageRef != null)
			{
				for (int i = 0; i < messageRef.Length; i++)
				{
					if (messageRef != null)
					{
						messageRef[i].__MarshalFrom(ref array[i]);
					}
				}
			}
			result.CheckError();
		}

		// Token: 0x06000075 RID: 117 RVA: 0x0000366D File Offset: 0x0000186D
		public unsafe long GetNumStoredMessagesAllowedByRetrievalFilters(Guid producer)
		{
			return calli(System.Int64(System.Void*,System.Guid), this._nativePointer, producer, *(*(IntPtr*)this._nativePointer + (IntPtr)6 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000076 RID: 118 RVA: 0x0000368D File Offset: 0x0000188D
		public unsafe long GetNumStoredMessages(Guid producer)
		{
			return calli(System.Int64(System.Void*,System.Guid), this._nativePointer, producer, *(*(IntPtr*)this._nativePointer + (IntPtr)7 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000077 RID: 119 RVA: 0x000036AD File Offset: 0x000018AD
		public unsafe long GetNumMessagesDiscardedByMessageCountLimit(Guid producer)
		{
			return calli(System.Int64(System.Void*,System.Guid), this._nativePointer, producer, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000078 RID: 120 RVA: 0x000036CD File Offset: 0x000018CD
		public unsafe long GetMessageCountLimit(Guid producer)
		{
			return calli(System.Int64(System.Void*,System.Guid), this._nativePointer, producer, *(*(IntPtr*)this._nativePointer + (IntPtr)9 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000079 RID: 121 RVA: 0x000036EE File Offset: 0x000018EE
		public unsafe long GetNumMessagesAllowedByStorageFilter(Guid producer)
		{
			return calli(System.Int64(System.Void*,System.Guid), this._nativePointer, producer, *(*(IntPtr*)this._nativePointer + (IntPtr)10 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x0600007A RID: 122 RVA: 0x0000370F File Offset: 0x0000190F
		public unsafe long GetNumMessagesDeniedByStorageFilter(Guid producer)
		{
			return calli(System.Int64(System.Void*,System.Guid), this._nativePointer, producer, *(*(IntPtr*)this._nativePointer + (IntPtr)11 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x0600007B RID: 123 RVA: 0x00003730 File Offset: 0x00001930
		public unsafe void AddStorageFilterEntries(Guid producer, ref InfoQueueFilter filterRef)
		{
			Result result;
			fixed (InfoQueueFilter* ptr = &filterRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Guid,System.Void*), this._nativePointer, producer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)12 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x0600007C RID: 124 RVA: 0x00003774 File Offset: 0x00001974
		public unsafe void GetStorageFilter(Guid producer, InfoQueueFilter[] filterRef, ref PointerSize filterByteLengthRef)
		{
			Result result;
			fixed (PointerSize* ptr = &filterByteLengthRef)
			{
				void* ptr2 = (void*)ptr;
				fixed (InfoQueueFilter[] array = filterRef)
				{
					void* ptr3;
					if (filterRef == null || array.Length == 0)
					{
						ptr3 = null;
					}
					else
					{
						ptr3 = (void*)(&array[0]);
					}
					result = calli(System.Int32(System.Void*,System.Guid,System.Void*,System.Void*), this._nativePointer, producer, ptr3, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)13 * (IntPtr)sizeof(void*)));
				}
			}
			result.CheckError();
		}

		// Token: 0x0600007D RID: 125 RVA: 0x000037D5 File Offset: 0x000019D5
		public unsafe void ClearStorageFilter(Guid producer)
		{
			calli(System.Void(System.Void*,System.Guid), this._nativePointer, producer, *(*(IntPtr*)this._nativePointer + (IntPtr)14 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x0600007E RID: 126 RVA: 0x000037F8 File Offset: 0x000019F8
		public unsafe void PushEmptyStorageFilter(Guid producer)
		{
			calli(System.Int32(System.Void*,System.Guid), this._nativePointer, producer, *(*(IntPtr*)this._nativePointer + (IntPtr)15 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x0600007F RID: 127 RVA: 0x00003834 File Offset: 0x00001A34
		public unsafe void PushDenyAllStorageFilter(Guid producer)
		{
			calli(System.Int32(System.Void*,System.Guid), this._nativePointer, producer, *(*(IntPtr*)this._nativePointer + (IntPtr)16 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000080 RID: 128 RVA: 0x00003870 File Offset: 0x00001A70
		public unsafe void PushCopyOfStorageFilter(Guid producer)
		{
			calli(System.Int32(System.Void*,System.Guid), this._nativePointer, producer, *(*(IntPtr*)this._nativePointer + (IntPtr)17 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000081 RID: 129 RVA: 0x000038AC File Offset: 0x00001AAC
		public unsafe void PushStorageFilter(Guid producer, ref InfoQueueFilter filterRef)
		{
			Result result;
			fixed (InfoQueueFilter* ptr = &filterRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Guid,System.Void*), this._nativePointer, producer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)18 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x06000082 RID: 130 RVA: 0x000038EE File Offset: 0x00001AEE
		public unsafe void PopStorageFilter(Guid producer)
		{
			calli(System.Void(System.Void*,System.Guid), this._nativePointer, producer, *(*(IntPtr*)this._nativePointer + (IntPtr)19 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000083 RID: 131 RVA: 0x0000390F File Offset: 0x00001B0F
		public unsafe int GetStorageFilterStackSize(Guid producer)
		{
			return calli(System.Int32(System.Void*,System.Guid), this._nativePointer, producer, *(*(IntPtr*)this._nativePointer + (IntPtr)20 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000084 RID: 132 RVA: 0x00003930 File Offset: 0x00001B30
		public unsafe void AddRetrievalFilterEntries(Guid producer, ref InfoQueueFilter filterRef)
		{
			Result result;
			fixed (InfoQueueFilter* ptr = &filterRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Guid,System.Void*), this._nativePointer, producer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)21 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x06000085 RID: 133 RVA: 0x00003974 File Offset: 0x00001B74
		public unsafe void GetRetrievalFilter(Guid producer, InfoQueueFilter[] filterRef, ref PointerSize filterByteLengthRef)
		{
			Result result;
			fixed (PointerSize* ptr = &filterByteLengthRef)
			{
				void* ptr2 = (void*)ptr;
				fixed (InfoQueueFilter[] array = filterRef)
				{
					void* ptr3;
					if (filterRef == null || array.Length == 0)
					{
						ptr3 = null;
					}
					else
					{
						ptr3 = (void*)(&array[0]);
					}
					result = calli(System.Int32(System.Void*,System.Guid,System.Void*,System.Void*), this._nativePointer, producer, ptr3, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)22 * (IntPtr)sizeof(void*)));
				}
			}
			result.CheckError();
		}

		// Token: 0x06000086 RID: 134 RVA: 0x000039D5 File Offset: 0x00001BD5
		public unsafe void ClearRetrievalFilter(Guid producer)
		{
			calli(System.Void(System.Void*,System.Guid), this._nativePointer, producer, *(*(IntPtr*)this._nativePointer + (IntPtr)23 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000087 RID: 135 RVA: 0x000039F8 File Offset: 0x00001BF8
		public unsafe void PushEmptyRetrievalFilter(Guid producer)
		{
			calli(System.Int32(System.Void*,System.Guid), this._nativePointer, producer, *(*(IntPtr*)this._nativePointer + (IntPtr)24 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000088 RID: 136 RVA: 0x00003A34 File Offset: 0x00001C34
		public unsafe void PushDenyAllRetrievalFilter(Guid producer)
		{
			calli(System.Int32(System.Void*,System.Guid), this._nativePointer, producer, *(*(IntPtr*)this._nativePointer + (IntPtr)25 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000089 RID: 137 RVA: 0x00003A70 File Offset: 0x00001C70
		public unsafe void PushCopyOfRetrievalFilter(Guid producer)
		{
			calli(System.Int32(System.Void*,System.Guid), this._nativePointer, producer, *(*(IntPtr*)this._nativePointer + (IntPtr)26 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x0600008A RID: 138 RVA: 0x00003AAC File Offset: 0x00001CAC
		public unsafe void PushRetrievalFilter(Guid producer, ref InfoQueueFilter filterRef)
		{
			Result result;
			fixed (InfoQueueFilter* ptr = &filterRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Guid,System.Void*), this._nativePointer, producer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)27 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x0600008B RID: 139 RVA: 0x00003AEE File Offset: 0x00001CEE
		public unsafe void PopRetrievalFilter(Guid producer)
		{
			calli(System.Void(System.Void*,System.Guid), this._nativePointer, producer, *(*(IntPtr*)this._nativePointer + (IntPtr)28 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x0600008C RID: 140 RVA: 0x00003B0F File Offset: 0x00001D0F
		public unsafe int GetRetrievalFilterStackSize(Guid producer)
		{
			return calli(System.Int32(System.Void*,System.Guid), this._nativePointer, producer, *(*(IntPtr*)this._nativePointer + (IntPtr)29 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x0600008D RID: 141 RVA: 0x00003B30 File Offset: 0x00001D30
		public unsafe void AddMessage(Guid producer, InformationQueueMessageCategory category, InformationQueueMessageSeverity severity, int id, string descriptionRef)
		{
			IntPtr intPtr = Marshal.StringToHGlobalAnsi(descriptionRef);
			Result result = calli(System.Int32(System.Void*,System.Guid,System.Int32,System.Int32,System.Int32,System.Void*), this._nativePointer, producer, category, severity, id, (void*)intPtr, *(*(IntPtr*)this._nativePointer + (IntPtr)30 * (IntPtr)sizeof(void*)));
			Marshal.FreeHGlobal(intPtr);
			result.CheckError();
		}

		// Token: 0x0600008E RID: 142 RVA: 0x00003B84 File Offset: 0x00001D84
		public unsafe void AddApplicationMessage(InformationQueueMessageSeverity severity, string descriptionRef)
		{
			IntPtr intPtr = Marshal.StringToHGlobalAnsi(descriptionRef);
			Result result = calli(System.Int32(System.Void*,System.Int32,System.Void*), this._nativePointer, severity, (void*)intPtr, *(*(IntPtr*)this._nativePointer + (IntPtr)31 * (IntPtr)sizeof(void*)));
			Marshal.FreeHGlobal(intPtr);
			result.CheckError();
		}

		// Token: 0x0600008F RID: 143 RVA: 0x00003BD0 File Offset: 0x00001DD0
		public unsafe void SetBreakOnCategory(Guid producer, InformationQueueMessageCategory category, RawBool bEnable)
		{
			calli(System.Int32(System.Void*,System.Guid,System.Int32,SharpDX.Mathematics.Interop.RawBool), this._nativePointer, producer, category, bEnable, *(*(IntPtr*)this._nativePointer + (IntPtr)32 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000090 RID: 144 RVA: 0x00003C0C File Offset: 0x00001E0C
		public unsafe void SetBreakOnSeverity(Guid producer, InformationQueueMessageSeverity severity, RawBool bEnable)
		{
			calli(System.Int32(System.Void*,System.Guid,System.Int32,SharpDX.Mathematics.Interop.RawBool), this._nativePointer, producer, severity, bEnable, *(*(IntPtr*)this._nativePointer + (IntPtr)33 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000091 RID: 145 RVA: 0x00003C48 File Offset: 0x00001E48
		public unsafe void SetBreakOnID(Guid producer, int id, RawBool bEnable)
		{
			calli(System.Int32(System.Void*,System.Guid,System.Int32,SharpDX.Mathematics.Interop.RawBool), this._nativePointer, producer, id, bEnable, *(*(IntPtr*)this._nativePointer + (IntPtr)34 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000092 RID: 146 RVA: 0x00003C83 File Offset: 0x00001E83
		public unsafe RawBool GetBreakOnCategory(Guid producer, InformationQueueMessageCategory category)
		{
			return calli(SharpDX.Mathematics.Interop.RawBool(System.Void*,System.Guid,System.Int32), this._nativePointer, producer, category, *(*(IntPtr*)this._nativePointer + (IntPtr)35 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000093 RID: 147 RVA: 0x00003CA5 File Offset: 0x00001EA5
		public unsafe RawBool GetBreakOnSeverity(Guid producer, InformationQueueMessageSeverity severity)
		{
			return calli(SharpDX.Mathematics.Interop.RawBool(System.Void*,System.Guid,System.Int32), this._nativePointer, producer, severity, *(*(IntPtr*)this._nativePointer + (IntPtr)36 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000094 RID: 148 RVA: 0x00003CC7 File Offset: 0x00001EC7
		public unsafe RawBool GetBreakOnID(Guid producer, int id)
		{
			return calli(SharpDX.Mathematics.Interop.RawBool(System.Void*,System.Guid,System.Int32), this._nativePointer, producer, id, *(*(IntPtr*)this._nativePointer + (IntPtr)37 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000095 RID: 149 RVA: 0x00003CE9 File Offset: 0x00001EE9
		public unsafe void SetMuteDebugOutput(Guid producer, RawBool bMute)
		{
			calli(System.Void(System.Void*,System.Guid,SharpDX.Mathematics.Interop.RawBool), this._nativePointer, producer, bMute, *(*(IntPtr*)this._nativePointer + (IntPtr)38 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000096 RID: 150 RVA: 0x00003D0B File Offset: 0x00001F0B
		public unsafe RawBool GetMuteDebugOutput(Guid producer)
		{
			return calli(SharpDX.Mathematics.Interop.RawBool(System.Void*,System.Guid), this._nativePointer, producer, *(*(IntPtr*)this._nativePointer + (IntPtr)39 * (IntPtr)sizeof(void*)));
		}
	}
}
