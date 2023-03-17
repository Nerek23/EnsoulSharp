using System;
using System.Threading;

namespace System.Text
{
	/// <summary>Provides a failure-handling mechanism, called a fallback, for an encoded input byte sequence that cannot be converted to an output character.</summary>
	// Token: 0x02000A37 RID: 2615
	[__DynamicallyInvokable]
	[Serializable]
	public abstract class DecoderFallback
	{
		// Token: 0x1700118E RID: 4494
		// (get) Token: 0x06006684 RID: 26244 RVA: 0x001595C8 File Offset: 0x001577C8
		private static object InternalSyncObject
		{
			get
			{
				if (DecoderFallback.s_InternalSyncObject == null)
				{
					object value = new object();
					Interlocked.CompareExchange<object>(ref DecoderFallback.s_InternalSyncObject, value, null);
				}
				return DecoderFallback.s_InternalSyncObject;
			}
		}

		/// <summary>Gets an object that outputs a substitute string in place of an input byte sequence that cannot be decoded.</summary>
		/// <returns>A type derived from the <see cref="T:System.Text.DecoderFallback" /> class. The default value is a <see cref="T:System.Text.DecoderReplacementFallback" /> object that emits the QUESTION MARK character ("?", U+003F) in place of unknown byte sequences.</returns>
		// Token: 0x1700118F RID: 4495
		// (get) Token: 0x06006685 RID: 26245 RVA: 0x001595F4 File Offset: 0x001577F4
		[__DynamicallyInvokable]
		public static DecoderFallback ReplacementFallback
		{
			[__DynamicallyInvokable]
			get
			{
				if (DecoderFallback.replacementFallback == null)
				{
					object internalSyncObject = DecoderFallback.InternalSyncObject;
					lock (internalSyncObject)
					{
						if (DecoderFallback.replacementFallback == null)
						{
							DecoderFallback.replacementFallback = new DecoderReplacementFallback();
						}
					}
				}
				return DecoderFallback.replacementFallback;
			}
		}

		/// <summary>Gets an object that throws an exception when an input byte sequence cannot be decoded.</summary>
		/// <returns>A type derived from the <see cref="T:System.Text.DecoderFallback" /> class. The default value is a <see cref="T:System.Text.DecoderExceptionFallback" /> object.</returns>
		// Token: 0x17001190 RID: 4496
		// (get) Token: 0x06006686 RID: 26246 RVA: 0x00159654 File Offset: 0x00157854
		[__DynamicallyInvokable]
		public static DecoderFallback ExceptionFallback
		{
			[__DynamicallyInvokable]
			get
			{
				if (DecoderFallback.exceptionFallback == null)
				{
					object internalSyncObject = DecoderFallback.InternalSyncObject;
					lock (internalSyncObject)
					{
						if (DecoderFallback.exceptionFallback == null)
						{
							DecoderFallback.exceptionFallback = new DecoderExceptionFallback();
						}
					}
				}
				return DecoderFallback.exceptionFallback;
			}
		}

		/// <summary>When overridden in a derived class, initializes a new instance of the <see cref="T:System.Text.DecoderFallbackBuffer" /> class.</summary>
		/// <returns>An object that provides a fallback buffer for a decoder.</returns>
		// Token: 0x06006687 RID: 26247
		[__DynamicallyInvokable]
		public abstract DecoderFallbackBuffer CreateFallbackBuffer();

		/// <summary>When overridden in a derived class, gets the maximum number of characters the current <see cref="T:System.Text.DecoderFallback" /> object can return.</summary>
		/// <returns>The maximum number of characters the current <see cref="T:System.Text.DecoderFallback" /> object can return.</returns>
		// Token: 0x17001191 RID: 4497
		// (get) Token: 0x06006688 RID: 26248
		[__DynamicallyInvokable]
		public abstract int MaxCharCount { [__DynamicallyInvokable] get; }

		// Token: 0x17001192 RID: 4498
		// (get) Token: 0x06006689 RID: 26249 RVA: 0x001596B4 File Offset: 0x001578B4
		internal bool IsMicrosoftBestFitFallback
		{
			get
			{
				return this.bIsMicrosoftBestFitFallback;
			}
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Text.DecoderFallback" /> class.</summary>
		// Token: 0x0600668A RID: 26250 RVA: 0x001596BC File Offset: 0x001578BC
		[__DynamicallyInvokable]
		protected DecoderFallback()
		{
		}

		// Token: 0x04002D8F RID: 11663
		internal bool bIsMicrosoftBestFitFallback;

		// Token: 0x04002D90 RID: 11664
		private static volatile DecoderFallback replacementFallback;

		// Token: 0x04002D91 RID: 11665
		private static volatile DecoderFallback exceptionFallback;

		// Token: 0x04002D92 RID: 11666
		private static object s_InternalSyncObject;
	}
}
