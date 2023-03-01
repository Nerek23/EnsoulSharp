using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct3D11
{
	// Token: 0x02000029 RID: 41
	[Guid("6543dbb6-1b48-42f5-ab82-e97ec74326f6")]
	public class InfoQueue : ComObject
	{
		// Token: 0x06000232 RID: 562 RVA: 0x00009E04 File Offset: 0x00008004
		public unsafe Message GetMessage(long messageIndex)
		{
			PointerSize pointerSize = 0;
			this.GetMessage(messageIndex, IntPtr.Zero, ref pointerSize);
			if (pointerSize == 0)
			{
				return default(Message);
			}
			byte* ptr = stackalloc byte[(UIntPtr)pointerSize];
			this.GetMessage(messageIndex, new IntPtr((void*)ptr), ref pointerSize);
			Message result = default(Message);
			result.__MarshalFrom(ref *(Message.__Native*)ptr);
			return result;
		}

		// Token: 0x06000233 RID: 563 RVA: 0x00009E68 File Offset: 0x00008068
		public unsafe InfoQueueFilter GetStorageFilter()
		{
			PointerSize zero = PointerSize.Zero;
			this.GetStorageFilter(IntPtr.Zero, ref zero);
			if (zero == 0)
			{
				return null;
			}
			byte* ptr = stackalloc byte[(UIntPtr)zero];
			this.GetStorageFilter((IntPtr)((void*)ptr), ref zero);
			InfoQueueFilter infoQueueFilter = new InfoQueueFilter();
			infoQueueFilter.__MarshalFrom(ref *(InfoQueueFilter.__Native*)ptr);
			return infoQueueFilter;
		}

		// Token: 0x06000234 RID: 564 RVA: 0x00009EBC File Offset: 0x000080BC
		public unsafe InfoQueueFilter GetRetrievalFilter()
		{
			PointerSize zero = PointerSize.Zero;
			this.GetRetrievalFilter(IntPtr.Zero, ref zero);
			if (zero == 0)
			{
				return null;
			}
			byte* ptr = stackalloc byte[(UIntPtr)zero];
			this.GetRetrievalFilter((IntPtr)((void*)ptr), ref zero);
			InfoQueueFilter infoQueueFilter = new InfoQueueFilter();
			infoQueueFilter.__MarshalFrom(ref *(InfoQueueFilter.__Native*)ptr);
			return infoQueueFilter;
		}

		// Token: 0x06000235 RID: 565 RVA: 0x0000383E File Offset: 0x00001A3E
		public InfoQueue(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000236 RID: 566 RVA: 0x00009F10 File Offset: 0x00008110
		public new static explicit operator InfoQueue(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new InfoQueue(nativePtr);
			}
			return null;
		}

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x06000237 RID: 567 RVA: 0x00009F27 File Offset: 0x00008127
		// (set) Token: 0x06000238 RID: 568 RVA: 0x00009F2F File Offset: 0x0000812F
		public long MessageCountLimit
		{
			get
			{
				return this.GetMessageCountLimit();
			}
			set
			{
				this.SetMessageCountLimit(value);
			}
		}

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x06000239 RID: 569 RVA: 0x00009F38 File Offset: 0x00008138
		public long NumMessagesAllowedByStorageFilter
		{
			get
			{
				return this.GetNumMessagesAllowedByStorageFilter();
			}
		}

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x0600023A RID: 570 RVA: 0x00009F40 File Offset: 0x00008140
		public long NumMessagesDeniedByStorageFilter
		{
			get
			{
				return this.GetNumMessagesDeniedByStorageFilter();
			}
		}

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x0600023B RID: 571 RVA: 0x00009F48 File Offset: 0x00008148
		public long NumStoredMessages
		{
			get
			{
				return this.GetNumStoredMessages();
			}
		}

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x0600023C RID: 572 RVA: 0x00009F50 File Offset: 0x00008150
		public long NumStoredMessagesAllowedByRetrievalFilter
		{
			get
			{
				return this.GetNumStoredMessagesAllowedByRetrievalFilter();
			}
		}

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x0600023D RID: 573 RVA: 0x00009F58 File Offset: 0x00008158
		public long NumMessagesDiscardedByMessageCountLimit
		{
			get
			{
				return this.GetNumMessagesDiscardedByMessageCountLimit();
			}
		}

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x0600023E RID: 574 RVA: 0x00009F60 File Offset: 0x00008160
		public int StorageFilterStackSize
		{
			get
			{
				return this.GetStorageFilterStackSize();
			}
		}

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x0600023F RID: 575 RVA: 0x00009F68 File Offset: 0x00008168
		public int RetrievalFilterStackSize
		{
			get
			{
				return this.GetRetrievalFilterStackSize();
			}
		}

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x06000240 RID: 576 RVA: 0x00009F70 File Offset: 0x00008170
		// (set) Token: 0x06000241 RID: 577 RVA: 0x00009F78 File Offset: 0x00008178
		public RawBool MuteDebugOutput
		{
			get
			{
				return this.GetMuteDebugOutput();
			}
			set
			{
				this.SetMuteDebugOutput(value);
			}
		}

		// Token: 0x06000242 RID: 578 RVA: 0x00009F84 File Offset: 0x00008184
		internal unsafe void SetMessageCountLimit(long messageCountLimit)
		{
			calli(System.Int32(System.Void*,System.Int64), this._nativePointer, messageCountLimit, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000243 RID: 579 RVA: 0x00009FBC File Offset: 0x000081BC
		public unsafe void ClearStoredMessages()
		{
			calli(System.Void(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000244 RID: 580 RVA: 0x00009FDC File Offset: 0x000081DC
		internal unsafe void GetMessage(long messageIndex, IntPtr messageRef, ref PointerSize messageByteLengthRef)
		{
			Result result;
			fixed (PointerSize* ptr = &messageByteLengthRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Int64,System.Void*,System.Void*), this._nativePointer, messageIndex, (void*)messageRef, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x06000245 RID: 581 RVA: 0x0000A023 File Offset: 0x00008223
		internal unsafe long GetNumMessagesAllowedByStorageFilter()
		{
			return calli(System.Int64(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)6 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000246 RID: 582 RVA: 0x0000A042 File Offset: 0x00008242
		internal unsafe long GetNumMessagesDeniedByStorageFilter()
		{
			return calli(System.Int64(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)7 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000247 RID: 583 RVA: 0x00009C67 File Offset: 0x00007E67
		internal unsafe long GetNumStoredMessages()
		{
			return calli(System.Int64(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000248 RID: 584 RVA: 0x0000A061 File Offset: 0x00008261
		internal unsafe long GetNumStoredMessagesAllowedByRetrievalFilter()
		{
			return calli(System.Int64(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)9 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000249 RID: 585 RVA: 0x0000A081 File Offset: 0x00008281
		internal unsafe long GetNumMessagesDiscardedByMessageCountLimit()
		{
			return calli(System.Int64(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)10 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x0600024A RID: 586 RVA: 0x0000A0A1 File Offset: 0x000082A1
		internal unsafe long GetMessageCountLimit()
		{
			return calli(System.Int64(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)11 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x0600024B RID: 587 RVA: 0x0000A0C4 File Offset: 0x000082C4
		public unsafe void AddStorageFilterEntries(InfoQueueFilter filterRef)
		{
			InfoQueueFilter.__Native _Native = default(InfoQueueFilter.__Native);
			filterRef.__MarshalTo(ref _Native);
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &_Native, *(*(IntPtr*)this._nativePointer + (IntPtr)12 * (IntPtr)sizeof(void*)));
			filterRef.__MarshalFree(ref _Native);
			result.CheckError();
		}

		// Token: 0x0600024C RID: 588 RVA: 0x0000A118 File Offset: 0x00008318
		internal unsafe void GetStorageFilter(IntPtr filterRef, ref PointerSize filterByteLengthRef)
		{
			Result result;
			fixed (PointerSize* ptr = &filterByteLengthRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)filterRef, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)13 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x0600024D RID: 589 RVA: 0x0000A15F File Offset: 0x0000835F
		public unsafe void ClearStorageFilter()
		{
			calli(System.Void(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)14 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x0600024E RID: 590 RVA: 0x0000A180 File Offset: 0x00008380
		public unsafe void PushEmptyStorageFilter()
		{
			calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)15 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x0600024F RID: 591 RVA: 0x0000A1B8 File Offset: 0x000083B8
		public unsafe void PushCopyOfStorageFilter()
		{
			calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)16 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000250 RID: 592 RVA: 0x0000A1F0 File Offset: 0x000083F0
		public unsafe void PushStorageFilter(InfoQueueFilter filterRef)
		{
			InfoQueueFilter.__Native _Native = default(InfoQueueFilter.__Native);
			filterRef.__MarshalTo(ref _Native);
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &_Native, *(*(IntPtr*)this._nativePointer + (IntPtr)17 * (IntPtr)sizeof(void*)));
			filterRef.__MarshalFree(ref _Native);
			result.CheckError();
		}

		// Token: 0x06000251 RID: 593 RVA: 0x0000A243 File Offset: 0x00008443
		public unsafe void PopStorageFilter()
		{
			calli(System.Void(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)18 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000252 RID: 594 RVA: 0x0000A263 File Offset: 0x00008463
		internal unsafe int GetStorageFilterStackSize()
		{
			return calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)19 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000253 RID: 595 RVA: 0x0000A284 File Offset: 0x00008484
		public unsafe void AddRetrievalFilterEntries(InfoQueueFilter filterRef)
		{
			InfoQueueFilter.__Native _Native = default(InfoQueueFilter.__Native);
			filterRef.__MarshalTo(ref _Native);
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &_Native, *(*(IntPtr*)this._nativePointer + (IntPtr)20 * (IntPtr)sizeof(void*)));
			filterRef.__MarshalFree(ref _Native);
			result.CheckError();
		}

		// Token: 0x06000254 RID: 596 RVA: 0x0000A2D8 File Offset: 0x000084D8
		internal unsafe void GetRetrievalFilter(IntPtr filterRef, ref PointerSize filterByteLengthRef)
		{
			Result result;
			fixed (PointerSize* ptr = &filterByteLengthRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)filterRef, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)21 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x06000255 RID: 597 RVA: 0x0000A31F File Offset: 0x0000851F
		public unsafe void ClearRetrievalFilter()
		{
			calli(System.Void(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)22 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000256 RID: 598 RVA: 0x0000A340 File Offset: 0x00008540
		public unsafe void PushEmptyRetrievalFilter()
		{
			calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)23 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000257 RID: 599 RVA: 0x0000A378 File Offset: 0x00008578
		public unsafe void PushCopyOfRetrievalFilter()
		{
			calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)24 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000258 RID: 600 RVA: 0x0000A3B0 File Offset: 0x000085B0
		public unsafe void PushRetrievalFilter(InfoQueueFilter filterRef)
		{
			InfoQueueFilter.__Native _Native = default(InfoQueueFilter.__Native);
			filterRef.__MarshalTo(ref _Native);
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &_Native, *(*(IntPtr*)this._nativePointer + (IntPtr)25 * (IntPtr)sizeof(void*)));
			filterRef.__MarshalFree(ref _Native);
			result.CheckError();
		}

		// Token: 0x06000259 RID: 601 RVA: 0x0000A403 File Offset: 0x00008603
		public unsafe void PopRetrievalFilter()
		{
			calli(System.Void(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)26 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x0600025A RID: 602 RVA: 0x0000A423 File Offset: 0x00008623
		internal unsafe int GetRetrievalFilterStackSize()
		{
			return calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)27 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x0600025B RID: 603 RVA: 0x0000A444 File Offset: 0x00008644
		public unsafe void AddMessage(MessageCategory category, MessageSeverity severity, MessageId id, string descriptionRef)
		{
			IntPtr intPtr = Marshal.StringToHGlobalAnsi(descriptionRef);
			Result result = calli(System.Int32(System.Void*,System.Int32,System.Int32,System.Int32,System.Void*), this._nativePointer, category, severity, id, (void*)intPtr, *(*(IntPtr*)this._nativePointer + (IntPtr)28 * (IntPtr)sizeof(void*)));
			Marshal.FreeHGlobal(intPtr);
			result.CheckError();
		}

		// Token: 0x0600025C RID: 604 RVA: 0x0000A494 File Offset: 0x00008694
		public unsafe void AddApplicationMessage(MessageSeverity severity, string descriptionRef)
		{
			IntPtr intPtr = Marshal.StringToHGlobalAnsi(descriptionRef);
			Result result = calli(System.Int32(System.Void*,System.Int32,System.Void*), this._nativePointer, severity, (void*)intPtr, *(*(IntPtr*)this._nativePointer + (IntPtr)29 * (IntPtr)sizeof(void*)));
			Marshal.FreeHGlobal(intPtr);
			result.CheckError();
		}

		// Token: 0x0600025D RID: 605 RVA: 0x0000A4E0 File Offset: 0x000086E0
		public unsafe void SetBreakOnCategory(MessageCategory category, RawBool bEnable)
		{
			calli(System.Int32(System.Void*,System.Int32,SharpDX.Mathematics.Interop.RawBool), this._nativePointer, category, bEnable, *(*(IntPtr*)this._nativePointer + (IntPtr)30 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x0600025E RID: 606 RVA: 0x0000A51C File Offset: 0x0000871C
		public unsafe void SetBreakOnSeverity(MessageSeverity severity, RawBool bEnable)
		{
			calli(System.Int32(System.Void*,System.Int32,SharpDX.Mathematics.Interop.RawBool), this._nativePointer, severity, bEnable, *(*(IntPtr*)this._nativePointer + (IntPtr)31 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x0600025F RID: 607 RVA: 0x0000A558 File Offset: 0x00008758
		public unsafe void SetBreakOnID(MessageId id, RawBool bEnable)
		{
			calli(System.Int32(System.Void*,System.Int32,SharpDX.Mathematics.Interop.RawBool), this._nativePointer, id, bEnable, *(*(IntPtr*)this._nativePointer + (IntPtr)32 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000260 RID: 608 RVA: 0x0000A592 File Offset: 0x00008792
		public unsafe RawBool GetBreakOnCategory(MessageCategory category)
		{
			return calli(SharpDX.Mathematics.Interop.RawBool(System.Void*,System.Int32), this._nativePointer, category, *(*(IntPtr*)this._nativePointer + (IntPtr)33 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000261 RID: 609 RVA: 0x0000A5B3 File Offset: 0x000087B3
		public unsafe RawBool GetBreakOnSeverity(MessageSeverity severity)
		{
			return calli(SharpDX.Mathematics.Interop.RawBool(System.Void*,System.Int32), this._nativePointer, severity, *(*(IntPtr*)this._nativePointer + (IntPtr)34 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000262 RID: 610 RVA: 0x0000A5D4 File Offset: 0x000087D4
		public unsafe RawBool GetBreakOnID(MessageId id)
		{
			return calli(SharpDX.Mathematics.Interop.RawBool(System.Void*,System.Int32), this._nativePointer, id, *(*(IntPtr*)this._nativePointer + (IntPtr)35 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000263 RID: 611 RVA: 0x0000A5F5 File Offset: 0x000087F5
		internal unsafe void SetMuteDebugOutput(RawBool bMute)
		{
			calli(System.Void(System.Void*,SharpDX.Mathematics.Interop.RawBool), this._nativePointer, bMute, *(*(IntPtr*)this._nativePointer + (IntPtr)36 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000264 RID: 612 RVA: 0x0000A616 File Offset: 0x00008816
		internal unsafe RawBool GetMuteDebugOutput()
		{
			return calli(SharpDX.Mathematics.Interop.RawBool(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)37 * (IntPtr)sizeof(void*)));
		}
	}
}
