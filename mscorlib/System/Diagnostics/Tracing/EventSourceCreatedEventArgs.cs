using System;

namespace System.Diagnostics.Tracing
{
	/// <summary>Provides data for the <see cref="E:System.Diagnostics.Tracing.EventListener.EventSourceCreated" /> event.</summary>
	// Token: 0x020003F7 RID: 1015
	public class EventSourceCreatedEventArgs : EventArgs
	{
		/// <summary>Get the event source that is attaching to the listener.</summary>
		/// <returns>The event source that is attaching to the listener.</returns>
		// Token: 0x170007BB RID: 1979
		// (get) Token: 0x060033EE RID: 13294 RVA: 0x000C98B4 File Offset: 0x000C7AB4
		// (set) Token: 0x060033EF RID: 13295 RVA: 0x000C98BC File Offset: 0x000C7ABC
		public EventSource EventSource { get; internal set; }
	}
}
