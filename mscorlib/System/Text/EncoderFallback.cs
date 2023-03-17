using System;
using System.Threading;

namespace System.Text
{
	/// <summary>Provides a failure-handling mechanism, called a fallback, for an input character that cannot be converted to an encoded output byte sequence.</summary>
	// Token: 0x02000A42 RID: 2626
	[__DynamicallyInvokable]
	[Serializable]
	public abstract class EncoderFallback
	{
		// Token: 0x170011A6 RID: 4518
		// (get) Token: 0x060066E4 RID: 26340 RVA: 0x0015A9B8 File Offset: 0x00158BB8
		private static object InternalSyncObject
		{
			get
			{
				if (EncoderFallback.s_InternalSyncObject == null)
				{
					object value = new object();
					Interlocked.CompareExchange<object>(ref EncoderFallback.s_InternalSyncObject, value, null);
				}
				return EncoderFallback.s_InternalSyncObject;
			}
		}

		/// <summary>Gets an object that outputs a substitute string in place of an input character that cannot be encoded.</summary>
		/// <returns>A type derived from the <see cref="T:System.Text.EncoderFallback" /> class. The default value is a <see cref="T:System.Text.EncoderReplacementFallback" /> object that replaces unknown input characters with the QUESTION MARK character ("?", U+003F).</returns>
		// Token: 0x170011A7 RID: 4519
		// (get) Token: 0x060066E5 RID: 26341 RVA: 0x0015A9E4 File Offset: 0x00158BE4
		[__DynamicallyInvokable]
		public static EncoderFallback ReplacementFallback
		{
			[__DynamicallyInvokable]
			get
			{
				if (EncoderFallback.replacementFallback == null)
				{
					object internalSyncObject = EncoderFallback.InternalSyncObject;
					lock (internalSyncObject)
					{
						if (EncoderFallback.replacementFallback == null)
						{
							EncoderFallback.replacementFallback = new EncoderReplacementFallback();
						}
					}
				}
				return EncoderFallback.replacementFallback;
			}
		}

		/// <summary>Gets an object that throws an exception when an input character cannot be encoded.</summary>
		/// <returns>A type derived from the <see cref="T:System.Text.EncoderFallback" /> class. The default value is a <see cref="T:System.Text.EncoderExceptionFallback" /> object.</returns>
		// Token: 0x170011A8 RID: 4520
		// (get) Token: 0x060066E6 RID: 26342 RVA: 0x0015AA44 File Offset: 0x00158C44
		[__DynamicallyInvokable]
		public static EncoderFallback ExceptionFallback
		{
			[__DynamicallyInvokable]
			get
			{
				if (EncoderFallback.exceptionFallback == null)
				{
					object internalSyncObject = EncoderFallback.InternalSyncObject;
					lock (internalSyncObject)
					{
						if (EncoderFallback.exceptionFallback == null)
						{
							EncoderFallback.exceptionFallback = new EncoderExceptionFallback();
						}
					}
				}
				return EncoderFallback.exceptionFallback;
			}
		}

		/// <summary>When overridden in a derived class, initializes a new instance of the <see cref="T:System.Text.EncoderFallbackBuffer" /> class.</summary>
		/// <returns>An object that provides a fallback buffer for an encoder.</returns>
		// Token: 0x060066E7 RID: 26343
		[__DynamicallyInvokable]
		public abstract EncoderFallbackBuffer CreateFallbackBuffer();

		/// <summary>When overridden in a derived class, gets the maximum number of characters the current <see cref="T:System.Text.EncoderFallback" /> object can return.</summary>
		/// <returns>The maximum number of characters the current <see cref="T:System.Text.EncoderFallback" /> object can return.</returns>
		// Token: 0x170011A9 RID: 4521
		// (get) Token: 0x060066E8 RID: 26344
		[__DynamicallyInvokable]
		public abstract int MaxCharCount { [__DynamicallyInvokable] get; }

		/// <summary>Initializes a new instance of the <see cref="T:System.Text.EncoderFallback" /> class.</summary>
		// Token: 0x060066E9 RID: 26345 RVA: 0x0015AAA4 File Offset: 0x00158CA4
		[__DynamicallyInvokable]
		protected EncoderFallback()
		{
		}

		// Token: 0x04002DAB RID: 11691
		internal bool bIsMicrosoftBestFitFallback;

		// Token: 0x04002DAC RID: 11692
		private static volatile EncoderFallback replacementFallback;

		// Token: 0x04002DAD RID: 11693
		private static volatile EncoderFallback exceptionFallback;

		// Token: 0x04002DAE RID: 11694
		private static object s_InternalSyncObject;
	}
}
