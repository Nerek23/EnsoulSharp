using System;
using System.Security;

namespace System.Threading
{
	/// <summary>Represents ambient data that is local to a given asynchronous control flow, such as an asynchronous method.</summary>
	/// <typeparam name="T">The type of the ambient data.</typeparam>
	// Token: 0x020004B8 RID: 1208
	[__DynamicallyInvokable]
	public sealed class AsyncLocal<T> : IAsyncLocal
	{
		/// <summary>Instantiates an <see cref="T:System.Threading.AsyncLocal`1" /> instance that does not receive change notifications.</summary>
		// Token: 0x06003A58 RID: 14936 RVA: 0x000DDA03 File Offset: 0x000DBC03
		[__DynamicallyInvokable]
		public AsyncLocal()
		{
		}

		/// <summary>Instantiates an <see cref="T:System.Threading.AsyncLocal`1" /> local instance that receives change notifications.</summary>
		/// <param name="valueChangedHandler">The delegate that is called whenever the current value changes on any thread.</param>
		// Token: 0x06003A59 RID: 14937 RVA: 0x000DDA0B File Offset: 0x000DBC0B
		[SecurityCritical]
		[__DynamicallyInvokable]
		public AsyncLocal(Action<AsyncLocalValueChangedArgs<T>> valueChangedHandler)
		{
			this.m_valueChangedHandler = valueChangedHandler;
		}

		/// <summary>Gets or sets the value of the ambient data.</summary>
		/// <returns>The value of the ambient data. If no value has been set, the returned value is default(T).</returns>
		// Token: 0x170008EA RID: 2282
		// (get) Token: 0x06003A5A RID: 14938 RVA: 0x000DDA1C File Offset: 0x000DBC1C
		// (set) Token: 0x06003A5B RID: 14939 RVA: 0x000DDA43 File Offset: 0x000DBC43
		[__DynamicallyInvokable]
		public T Value
		{
			[SecuritySafeCritical]
			[__DynamicallyInvokable]
			get
			{
				object localValue = ExecutionContext.GetLocalValue(this);
				if (localValue != null)
				{
					return (T)((object)localValue);
				}
				return default(T);
			}
			[SecuritySafeCritical]
			[__DynamicallyInvokable]
			set
			{
				ExecutionContext.SetLocalValue(this, value, this.m_valueChangedHandler != null);
			}
		}

		// Token: 0x06003A5C RID: 14940 RVA: 0x000DDA5C File Offset: 0x000DBC5C
		[SecurityCritical]
		void IAsyncLocal.OnValueChanged(object previousValueObj, object currentValueObj, bool contextChanged)
		{
			T previousValue = (previousValueObj == null) ? default(T) : ((T)((object)previousValueObj));
			T currentValue = (currentValueObj == null) ? default(T) : ((T)((object)currentValueObj));
			this.m_valueChangedHandler(new AsyncLocalValueChangedArgs<T>(previousValue, currentValue, contextChanged));
		}

		// Token: 0x040018AB RID: 6315
		[SecurityCritical]
		private readonly Action<AsyncLocalValueChangedArgs<T>> m_valueChangedHandler;
	}
}
