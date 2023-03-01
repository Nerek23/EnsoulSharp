using System;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using EnsoulSharp.Native;
using EnsoulSharp.Native.Enums;
using SharpDX;

namespace EnsoulSharp
{
	/// <summary>
	/// 	This class contains everthing we can offer related to basic game.
	/// </summary>
	// Token: 0x020000E2 RID: 226
	public class Game
	{
		// Token: 0x0600051B RID: 1307 RVA: 0x0000AF00 File Offset: 0x0000A300
		static Game()
		{
			AppDomain.CurrentDomain.DomainUnload += Game.DomainUnloadEventHandler;
			Game.m_NotifyNativeDelegate = new Game.OnNotifyNativeDelegate(Game.OnNotifyNative);
			Game.m_NotifyNative = Marshal.GetFunctionPointerForDelegate<Game.OnNotifyNativeDelegate>(Game.m_NotifyNativeDelegate);
			<Module>.EnsoulSharp.Native.EventHandler<void\u0020(__cdecl*)(enum\u0020EnsoulSharp::Native::Enums::EventsNames,EnsoulSharp::Native::BaseParams\u0020*)>.Add(<Module>.EnsoulSharp.Native.EventAdapter.GetGameNotifyHandler(<Module>.EnsoulSharp.Native.EventAdapter.GetInstance()), Game.m_NotifyNative.ToPointer());
			Game.m_ProcessPacketNativeDelegate = new Game.OnProcessPacketNativeDelegate(Game.OnProcessPacketNative);
			Game.m_ProcessPacketNative = Marshal.GetFunctionPointerForDelegate<Game.OnProcessPacketNativeDelegate>(Game.m_ProcessPacketNativeDelegate);
			<Module>.EnsoulSharp.Native.EventHandler<void\u0020(__cdecl*)(EnsoulSharp::Native::DefaultPacket\u0020*,bool\u0020*)>.Add(<Module>.EnsoulSharp.Native.EventAdapter.GetGameProcessPacketHandler(<Module>.EnsoulSharp.Native.EventAdapter.GetInstance()), Game.m_ProcessPacketNative.ToPointer());
			Game.m_DisplayChatNativeDelegate = new Game.OnDisplayChatNativeDelegate(Game.OnDisplayChatNative);
			Game.m_DisplayChatNative = Marshal.GetFunctionPointerForDelegate<Game.OnDisplayChatNativeDelegate>(Game.m_DisplayChatNativeDelegate);
			<Module>.EnsoulSharp.Native.EventHandler<void\u0020(__cdecl*)(char\u0020const\u0020*,unsigned\u0020int,bool\u0020*)>.Add(<Module>.EnsoulSharp.Native.EventAdapter.GetGameDisplayChatHandler(<Module>.EnsoulSharp.Native.EventAdapter.GetInstance()), Game.m_DisplayChatNative.ToPointer());
			Game.m_SendChatNativeDelegate = new Game.OnSendChatNativeDelegate(Game.OnSendChatNative);
			Game.m_SendChatNative = Marshal.GetFunctionPointerForDelegate<Game.OnSendChatNativeDelegate>(Game.m_SendChatNativeDelegate);
			<Module>.EnsoulSharp.Native.EventHandler<void\u0020(__cdecl*)(char\u0020const\u0020*,bool,bool\u0020*)>.Add(<Module>.EnsoulSharp.Native.EventAdapter.GetGameSendChatHandler(<Module>.EnsoulSharp.Native.EventAdapter.GetInstance()), Game.m_SendChatNative.ToPointer());
			Game.m_WndProcNativeDelegate = new Game.OnWndProcNativeDelegate(Game.OnWndProcNative);
			Game.m_WndProcNative = Marshal.GetFunctionPointerForDelegate<Game.OnWndProcNativeDelegate>(Game.m_WndProcNativeDelegate);
			<Module>.EnsoulSharp.Native.EventHandler<void\u0020(__cdecl*)(HWND__\u0020*,unsigned\u0020int,unsigned\u0020int,long,bool\u0020*)>.Add(<Module>.EnsoulSharp.Native.EventAdapter.GetGameWndProcHandler(<Module>.EnsoulSharp.Native.EventAdapter.GetInstance()), Game.m_WndProcNative.ToPointer());
			Game.m_UpdateNativeDelegate = new Game.OnUpdateNativeDelegate(Game.OnUpdateNative);
			Game.m_UpdateNative = Marshal.GetFunctionPointerForDelegate<Game.OnUpdateNativeDelegate>(Game.m_UpdateNativeDelegate);
			<Module>.EnsoulSharp.Native.EventHandler<void\u0020(__cdecl*)(void)>.Add(<Module>.EnsoulSharp.Native.EventAdapter.GetGameUpdateHandler(<Module>.EnsoulSharp.Native.EventAdapter.GetInstance()), Game.m_UpdateNative.ToPointer());
		}

		// Token: 0x0600051C RID: 1308 RVA: 0x00009660 File Offset: 0x00008A60
		internal static void DomainUnloadEventHandler(object sender, EventArgs args)
		{
			<Module>.EnsoulSharp.Native.EventHandler<void\u0020(__cdecl*)(enum\u0020EnsoulSharp::Native::Enums::EventsNames,EnsoulSharp::Native::BaseParams\u0020*)>.Remove(<Module>.EnsoulSharp.Native.EventAdapter.GetGameNotifyHandler(<Module>.EnsoulSharp.Native.EventAdapter.GetInstance()), Game.m_NotifyNative.ToPointer());
			<Module>.EnsoulSharp.Native.EventHandler<void\u0020(__cdecl*)(EnsoulSharp::Native::DefaultPacket\u0020*,bool\u0020*)>.Remove(<Module>.EnsoulSharp.Native.EventAdapter.GetGameProcessPacketHandler(<Module>.EnsoulSharp.Native.EventAdapter.GetInstance()), Game.m_ProcessPacketNative.ToPointer());
			<Module>.EnsoulSharp.Native.EventHandler<void\u0020(__cdecl*)(char\u0020const\u0020*,unsigned\u0020int,bool\u0020*)>.Remove(<Module>.EnsoulSharp.Native.EventAdapter.GetGameDisplayChatHandler(<Module>.EnsoulSharp.Native.EventAdapter.GetInstance()), Game.m_DisplayChatNative.ToPointer());
			<Module>.EnsoulSharp.Native.EventHandler<void\u0020(__cdecl*)(char\u0020const\u0020*,bool,bool\u0020*)>.Remove(<Module>.EnsoulSharp.Native.EventAdapter.GetGameSendChatHandler(<Module>.EnsoulSharp.Native.EventAdapter.GetInstance()), Game.m_SendChatNative.ToPointer());
			<Module>.EnsoulSharp.Native.EventHandler<void\u0020(__cdecl*)(HWND__\u0020*,unsigned\u0020int,unsigned\u0020int,long,bool\u0020*)>.Remove(<Module>.EnsoulSharp.Native.EventAdapter.GetGameWndProcHandler(<Module>.EnsoulSharp.Native.EventAdapter.GetInstance()), Game.m_WndProcNative.ToPointer());
			<Module>.EnsoulSharp.Native.EventHandler<void\u0020(__cdecl*)(void)>.Remove(<Module>.EnsoulSharp.Native.EventAdapter.GetGameUpdateHandler(<Module>.EnsoulSharp.Native.EventAdapter.GetInstance()), Game.m_UpdateNative.ToPointer());
		}

		// Token: 0x0600051D RID: 1309 RVA: 0x00009704 File Offset: 0x00008B04
		[SecurityCritical]
		[HandleProcessCorruptedStateExceptions]
		internal unsafe static void OnNotifyNative(EventsNames type, BaseParams* @params)
		{
			GameNotify[] array = null;
			try
			{
				int num = 256;
				byte[] array2 = new byte[256];
				for (int i = 0; i < num; i++)
				{
					try
					{
						byte[] array3 = array2;
						int num2 = i;
						array3[num2] = *(byte*)(num2 / sizeof(BaseParams) + @params);
					}
					catch (Exception)
					{
						break;
					}
				}
				uint* ptr = <Module>.EnsoulSharp.Native.BaseParams.GetOtherNetworkID(@params);
				GameNotifyEventArgs args = new GameNotifyEventArgs((GameEventId)type, (int)(*ptr), array2);
				foreach (GameNotify gameNotify in Game.NotifyHandlers.ToArray())
				{
					try
					{
						gameNotify(args);
					}
					catch (Exception ex)
					{
						Console.WriteLine();
						Console.WriteLine("========================================");
						Console.WriteLine("Exception detected in EnsoulSharp .NET Wrapper");
						Console.WriteLine();
						Console.WriteLine("Type: {0}", ex.GetType().FullName);
						Console.WriteLine("Message: {0}", ex.Message);
						Console.WriteLine();
						Console.WriteLine("Stracktrace:");
						Console.WriteLine(ex.StackTrace);
						Exception innerException = ex.InnerException;
						if (innerException != null)
						{
							Console.WriteLine();
							Console.WriteLine("InnerException(s):");
							do
							{
								Console.WriteLine("----------------------------------------");
								Console.WriteLine("Type: {0}", innerException.GetType().FullName);
								Console.WriteLine("Message: {0}", innerException.Message);
								Console.WriteLine();
								Console.WriteLine("Stracktrace:");
								Console.WriteLine(innerException.StackTrace);
								innerException = innerException.InnerException;
							}
							while (innerException != null);
							Console.WriteLine("----------------------------------------");
						}
						Console.WriteLine("========================================");
						Console.WriteLine();
						string newValue = "";
						Log.Error(ex.ToString().Replace("\r", newValue).Replace("\n", newValue));
					}
				}
			}
			catch (Exception ex2)
			{
				Console.WriteLine();
				Console.WriteLine("========================================");
				Console.WriteLine("Exception detected in EnsoulSharp .NET Wrapper");
				Console.WriteLine();
				Console.WriteLine("Type: {0}", ex2.GetType().FullName);
				Console.WriteLine("Message: {0}", ex2.Message);
				Console.WriteLine();
				Console.WriteLine("Stracktrace:");
				Console.WriteLine(ex2.StackTrace);
				Exception innerException2 = ex2.InnerException;
				if (innerException2 != null)
				{
					Console.WriteLine();
					Console.WriteLine("InnerException(s):");
					do
					{
						Console.WriteLine("----------------------------------------");
						Console.WriteLine("Type: {0}", innerException2.GetType().FullName);
						Console.WriteLine("Message: {0}", innerException2.Message);
						Console.WriteLine();
						Console.WriteLine("Stracktrace:");
						Console.WriteLine(innerException2.StackTrace);
						innerException2 = innerException2.InnerException;
					}
					while (innerException2 != null);
					Console.WriteLine("----------------------------------------");
				}
				Console.WriteLine("========================================");
				Console.WriteLine();
				string newValue = "";
				Log.Error(ex2.ToString().Replace("\r", newValue).Replace("\n", newValue));
			}
		}

		// Token: 0x0600051E RID: 1310 RVA: 0x00009A0C File Offset: 0x00008E0C
		[HandleProcessCorruptedStateExceptions]
		[SecurityCritical]
		internal unsafe static void OnProcessPacketNative(DefaultPacket* packet, bool* process)
		{
			GameProcessPacket[] array = null;
			try
			{
				uint num = <Module>.EnsoulSharp.Native.SerializableVtbl.GetEstimatedSize(<Module>.EnsoulSharp.Native.Serializable.GetVftable(<Module>.EnsoulSharp.Native.DefaultPacket.GetSerialize(packet)));
				byte[] array2 = new byte[num];
				IntPtr source = new IntPtr((void*)packet);
				Marshal.Copy(source, array2, 0, (int)num);
				int networkId = *<Module>.EnsoulSharp.Native.DefaultPacketHeader.GetFromID(<Module>.EnsoulSharp.Native.DefaultPacket.GetHeader(packet));
				ushort* ptr = <Module>.EnsoulSharp.Native.DefaultPacketHeader.GetEventID(<Module>.EnsoulSharp.Native.DefaultPacket.GetHeader(packet));
				GamePacketEventArgs gamePacketEventArgs = new GamePacketEventArgs(*process, (int)(*ptr), networkId, array2);
				foreach (GameProcessPacket gameProcessPacket in Game.ProcessPacketHandlers.ToArray())
				{
					try
					{
						gameProcessPacket(gamePacketEventArgs);
					}
					catch (Exception ex)
					{
						Console.WriteLine();
						Console.WriteLine("========================================");
						Console.WriteLine("Exception detected in EnsoulSharp .NET Wrapper");
						Console.WriteLine();
						Console.WriteLine("Type: {0}", ex.GetType().FullName);
						Console.WriteLine("Message: {0}", ex.Message);
						Console.WriteLine();
						Console.WriteLine("Stracktrace:");
						Console.WriteLine(ex.StackTrace);
						Exception innerException = ex.InnerException;
						if (innerException != null)
						{
							Console.WriteLine();
							Console.WriteLine("InnerException(s):");
							do
							{
								Console.WriteLine("----------------------------------------");
								Console.WriteLine("Type: {0}", innerException.GetType().FullName);
								Console.WriteLine("Message: {0}", innerException.Message);
								Console.WriteLine();
								Console.WriteLine("Stracktrace:");
								Console.WriteLine(innerException.StackTrace);
								innerException = innerException.InnerException;
							}
							while (innerException != null);
							Console.WriteLine("----------------------------------------");
						}
						Console.WriteLine("========================================");
						Console.WriteLine();
						string newValue = "";
						Log.Error(ex.ToString().Replace("\r", newValue).Replace("\n", newValue));
					}
				}
				*process = gamePacketEventArgs.Process;
			}
			catch (Exception ex2)
			{
				Console.WriteLine();
				Console.WriteLine("========================================");
				Console.WriteLine("Exception detected in EnsoulSharp .NET Wrapper");
				Console.WriteLine();
				Console.WriteLine("Type: {0}", ex2.GetType().FullName);
				Console.WriteLine("Message: {0}", ex2.Message);
				Console.WriteLine();
				Console.WriteLine("Stracktrace:");
				Console.WriteLine(ex2.StackTrace);
				Exception innerException2 = ex2.InnerException;
				if (innerException2 != null)
				{
					Console.WriteLine();
					Console.WriteLine("InnerException(s):");
					do
					{
						Console.WriteLine("----------------------------------------");
						Console.WriteLine("Type: {0}", innerException2.GetType().FullName);
						Console.WriteLine("Message: {0}", innerException2.Message);
						Console.WriteLine();
						Console.WriteLine("Stracktrace:");
						Console.WriteLine(innerException2.StackTrace);
						innerException2 = innerException2.InnerException;
					}
					while (innerException2 != null);
					Console.WriteLine("----------------------------------------");
				}
				Console.WriteLine("========================================");
				Console.WriteLine();
				string newValue = "";
				Log.Error(ex2.ToString().Replace("\r", newValue).Replace("\n", newValue));
			}
		}

		// Token: 0x0600051F RID: 1311 RVA: 0x00009D1C File Offset: 0x0000911C
		[SecurityCritical]
		[HandleProcessCorruptedStateExceptions]
		internal unsafe static void OnDisplayChatNative(sbyte* msg, uint flags, bool* process)
		{
			GameDisplayChat[] array = null;
			try
			{
				sbyte* ptr = msg;
				while (*(sbyte*)ptr != 0)
				{
					ptr += 1 / sizeof(sbyte);
				}
				int length = (int)(ptr - msg);
				GameDisplayChatEventArgs gameDisplayChatEventArgs = new GameDisplayChatEventArgs(*process, new string((sbyte*)msg, 0, length, Encoding.UTF8), (int)flags);
				foreach (GameDisplayChat gameDisplayChat in Game.DisplayChatHandlers.ToArray())
				{
					try
					{
						gameDisplayChat(gameDisplayChatEventArgs);
					}
					catch (Exception ex)
					{
						Console.WriteLine();
						Console.WriteLine("========================================");
						Console.WriteLine("Exception detected in EnsoulSharp .NET Wrapper");
						Console.WriteLine();
						Console.WriteLine("Type: {0}", ex.GetType().FullName);
						Console.WriteLine("Message: {0}", ex.Message);
						Console.WriteLine();
						Console.WriteLine("Stracktrace:");
						Console.WriteLine(ex.StackTrace);
						Exception innerException = ex.InnerException;
						if (innerException != null)
						{
							Console.WriteLine();
							Console.WriteLine("InnerException(s):");
							do
							{
								Console.WriteLine("----------------------------------------");
								Console.WriteLine("Type: {0}", innerException.GetType().FullName);
								Console.WriteLine("Message: {0}", innerException.Message);
								Console.WriteLine();
								Console.WriteLine("Stracktrace:");
								Console.WriteLine(innerException.StackTrace);
								innerException = innerException.InnerException;
							}
							while (innerException != null);
							Console.WriteLine("----------------------------------------");
						}
						Console.WriteLine("========================================");
						Console.WriteLine();
						string newValue = "";
						Log.Error(ex.ToString().Replace("\r", newValue).Replace("\n", newValue));
					}
				}
				*process = gameDisplayChatEventArgs.Process;
			}
			catch (Exception ex2)
			{
				Console.WriteLine();
				Console.WriteLine("========================================");
				Console.WriteLine("Exception detected in EnsoulSharp .NET Wrapper");
				Console.WriteLine();
				Console.WriteLine("Type: {0}", ex2.GetType().FullName);
				Console.WriteLine("Message: {0}", ex2.Message);
				Console.WriteLine();
				Console.WriteLine("Stracktrace:");
				Console.WriteLine(ex2.StackTrace);
				Exception innerException2 = ex2.InnerException;
				if (innerException2 != null)
				{
					Console.WriteLine();
					Console.WriteLine("InnerException(s):");
					do
					{
						Console.WriteLine("----------------------------------------");
						Console.WriteLine("Type: {0}", innerException2.GetType().FullName);
						Console.WriteLine("Message: {0}", innerException2.Message);
						Console.WriteLine();
						Console.WriteLine("Stracktrace:");
						Console.WriteLine(innerException2.StackTrace);
						innerException2 = innerException2.InnerException;
					}
					while (innerException2 != null);
					Console.WriteLine("----------------------------------------");
				}
				Console.WriteLine("========================================");
				Console.WriteLine();
				string newValue = "";
				Log.Error(ex2.ToString().Replace("\r", newValue).Replace("\n", newValue));
			}
		}

		// Token: 0x06000520 RID: 1312 RVA: 0x00009FFC File Offset: 0x000093FC
		[SecurityCritical]
		[HandleProcessCorruptedStateExceptions]
		internal unsafe static void OnSendChatNative(sbyte* msg, [MarshalAs(UnmanagedType.U1)] bool sendToAll, bool* process)
		{
			GameSendChat[] array = null;
			try
			{
				sbyte* ptr = msg;
				while (*(sbyte*)ptr != 0)
				{
					ptr += 1 / sizeof(sbyte);
				}
				int length = (int)(ptr - msg);
				GameSendChatEventArgs gameSendChatEventArgs = new GameSendChatEventArgs(*process, new string((sbyte*)msg, 0, length, Encoding.UTF8), sendToAll);
				foreach (GameSendChat gameSendChat in Game.SendChatHandlers.ToArray())
				{
					try
					{
						gameSendChat(gameSendChatEventArgs);
					}
					catch (Exception ex)
					{
						Console.WriteLine();
						Console.WriteLine("========================================");
						Console.WriteLine("Exception detected in EnsoulSharp .NET Wrapper");
						Console.WriteLine();
						Console.WriteLine("Type: {0}", ex.GetType().FullName);
						Console.WriteLine("Message: {0}", ex.Message);
						Console.WriteLine();
						Console.WriteLine("Stracktrace:");
						Console.WriteLine(ex.StackTrace);
						Exception innerException = ex.InnerException;
						if (innerException != null)
						{
							Console.WriteLine();
							Console.WriteLine("InnerException(s):");
							do
							{
								Console.WriteLine("----------------------------------------");
								Console.WriteLine("Type: {0}", innerException.GetType().FullName);
								Console.WriteLine("Message: {0}", innerException.Message);
								Console.WriteLine();
								Console.WriteLine("Stracktrace:");
								Console.WriteLine(innerException.StackTrace);
								innerException = innerException.InnerException;
							}
							while (innerException != null);
							Console.WriteLine("----------------------------------------");
						}
						Console.WriteLine("========================================");
						Console.WriteLine();
						string newValue = "";
						Log.Error(ex.ToString().Replace("\r", newValue).Replace("\n", newValue));
					}
				}
				*process = gameSendChatEventArgs.Process;
			}
			catch (Exception ex2)
			{
				Console.WriteLine();
				Console.WriteLine("========================================");
				Console.WriteLine("Exception detected in EnsoulSharp .NET Wrapper");
				Console.WriteLine();
				Console.WriteLine("Type: {0}", ex2.GetType().FullName);
				Console.WriteLine("Message: {0}", ex2.Message);
				Console.WriteLine();
				Console.WriteLine("Stracktrace:");
				Console.WriteLine(ex2.StackTrace);
				Exception innerException2 = ex2.InnerException;
				if (innerException2 != null)
				{
					Console.WriteLine();
					Console.WriteLine("InnerException(s):");
					do
					{
						Console.WriteLine("----------------------------------------");
						Console.WriteLine("Type: {0}", innerException2.GetType().FullName);
						Console.WriteLine("Message: {0}", innerException2.Message);
						Console.WriteLine();
						Console.WriteLine("Stracktrace:");
						Console.WriteLine(innerException2.StackTrace);
						innerException2 = innerException2.InnerException;
					}
					while (innerException2 != null);
					Console.WriteLine("----------------------------------------");
				}
				Console.WriteLine("========================================");
				Console.WriteLine();
				string newValue = "";
				Log.Error(ex2.ToString().Replace("\r", newValue).Replace("\n", newValue));
			}
		}

		// Token: 0x06000521 RID: 1313 RVA: 0x0000A2DC File Offset: 0x000096DC
		[SecurityCritical]
		[HandleProcessCorruptedStateExceptions]
		internal unsafe static void OnWndProcNative(HWND__* hWnd, uint uMsg, uint wParam, int lParam, bool* process)
		{
			GameWndProc[] array = null;
			try
			{
				IntPtr hWnd2 = new IntPtr((void*)hWnd);
				GameWndEventArgs gameWndEventArgs = new GameWndEventArgs(*process, hWnd2, uMsg, wParam, lParam);
				foreach (GameWndProc gameWndProc in Game.WndProcHandlers.ToArray())
				{
					try
					{
						gameWndProc(gameWndEventArgs);
					}
					catch (Exception ex)
					{
						Console.WriteLine();
						Console.WriteLine("========================================");
						Console.WriteLine("Exception detected in EnsoulSharp .NET Wrapper");
						Console.WriteLine();
						Console.WriteLine("Type: {0}", ex.GetType().FullName);
						Console.WriteLine("Message: {0}", ex.Message);
						Console.WriteLine();
						Console.WriteLine("Stracktrace:");
						Console.WriteLine(ex.StackTrace);
						Exception innerException = ex.InnerException;
						if (innerException != null)
						{
							Console.WriteLine();
							Console.WriteLine("InnerException(s):");
							do
							{
								Console.WriteLine("----------------------------------------");
								Console.WriteLine("Type: {0}", innerException.GetType().FullName);
								Console.WriteLine("Message: {0}", innerException.Message);
								Console.WriteLine();
								Console.WriteLine("Stracktrace:");
								Console.WriteLine(innerException.StackTrace);
								innerException = innerException.InnerException;
							}
							while (innerException != null);
							Console.WriteLine("----------------------------------------");
						}
						Console.WriteLine("========================================");
						Console.WriteLine();
						string newValue = "";
						Log.Error(ex.ToString().Replace("\r", newValue).Replace("\n", newValue));
					}
				}
				*process = gameWndEventArgs.Process;
			}
			catch (Exception ex2)
			{
				Console.WriteLine();
				Console.WriteLine("========================================");
				Console.WriteLine("Exception detected in EnsoulSharp .NET Wrapper");
				Console.WriteLine();
				Console.WriteLine("Type: {0}", ex2.GetType().FullName);
				Console.WriteLine("Message: {0}", ex2.Message);
				Console.WriteLine();
				Console.WriteLine("Stracktrace:");
				Console.WriteLine(ex2.StackTrace);
				Exception innerException2 = ex2.InnerException;
				if (innerException2 != null)
				{
					Console.WriteLine();
					Console.WriteLine("InnerException(s):");
					do
					{
						Console.WriteLine("----------------------------------------");
						Console.WriteLine("Type: {0}", innerException2.GetType().FullName);
						Console.WriteLine("Message: {0}", innerException2.Message);
						Console.WriteLine();
						Console.WriteLine("Stracktrace:");
						Console.WriteLine(innerException2.StackTrace);
						innerException2 = innerException2.InnerException;
					}
					while (innerException2 != null);
					Console.WriteLine("----------------------------------------");
				}
				Console.WriteLine("========================================");
				Console.WriteLine();
				string newValue = "";
				Log.Error(ex2.ToString().Replace("\r", newValue).Replace("\n", newValue));
			}
		}

		// Token: 0x06000522 RID: 1314 RVA: 0x0000A5A8 File Offset: 0x000099A8
		[SecurityCritical]
		[HandleProcessCorruptedStateExceptions]
		internal static void OnUpdateNative()
		{
			GameUpdate[] array = null;
			try
			{
				foreach (GameUpdate gameUpdate in Game.UpdateHandlers.ToArray())
				{
					try
					{
						gameUpdate(EventArgs.Empty);
					}
					catch (Exception ex)
					{
						Console.WriteLine();
						Console.WriteLine("========================================");
						Console.WriteLine("Exception detected in EnsoulSharp .NET Wrapper");
						Console.WriteLine();
						Console.WriteLine("Type: {0}", ex.GetType().FullName);
						Console.WriteLine("Message: {0}", ex.Message);
						Console.WriteLine();
						Console.WriteLine("Stracktrace:");
						Console.WriteLine(ex.StackTrace);
						Exception innerException = ex.InnerException;
						if (innerException != null)
						{
							Console.WriteLine();
							Console.WriteLine("InnerException(s):");
							do
							{
								Console.WriteLine("----------------------------------------");
								Console.WriteLine("Type: {0}", innerException.GetType().FullName);
								Console.WriteLine("Message: {0}", innerException.Message);
								Console.WriteLine();
								Console.WriteLine("Stracktrace:");
								Console.WriteLine(innerException.StackTrace);
								innerException = innerException.InnerException;
							}
							while (innerException != null);
							Console.WriteLine("----------------------------------------");
						}
						Console.WriteLine("========================================");
						Console.WriteLine();
						string newValue = "";
						Log.Error(ex.ToString().Replace("\r", newValue).Replace("\n", newValue));
					}
				}
			}
			catch (Exception ex2)
			{
				Console.WriteLine();
				Console.WriteLine("========================================");
				Console.WriteLine("Exception detected in EnsoulSharp .NET Wrapper");
				Console.WriteLine();
				Console.WriteLine("Type: {0}", ex2.GetType().FullName);
				Console.WriteLine("Message: {0}", ex2.Message);
				Console.WriteLine();
				Console.WriteLine("Stracktrace:");
				Console.WriteLine(ex2.StackTrace);
				Exception innerException2 = ex2.InnerException;
				if (innerException2 != null)
				{
					Console.WriteLine();
					Console.WriteLine("InnerException(s):");
					do
					{
						Console.WriteLine("----------------------------------------");
						Console.WriteLine("Type: {0}", innerException2.GetType().FullName);
						Console.WriteLine("Message: {0}", innerException2.Message);
						Console.WriteLine();
						Console.WriteLine("Stracktrace:");
						Console.WriteLine(innerException2.StackTrace);
						innerException2 = innerException2.InnerException;
					}
					while (innerException2 != null);
					Console.WriteLine("----------------------------------------");
				}
				Console.WriteLine("========================================");
				Console.WriteLine();
				string newValue = "";
				Log.Error(ex2.ToString().Replace("\r", newValue).Replace("\n", newValue));
			}
		}

		/// <summary>
		/// 	This event is fired every a notify is received and about to be processed.
		/// </summary>
		// Token: 0x14000019 RID: 25
		// (add) Token: 0x06000523 RID: 1315 RVA: 0x0000A854 File Offset: 0x00009C54
		// (remove) Token: 0x06000524 RID: 1316 RVA: 0x0000A86C File Offset: 0x00009C6C
		public static event GameNotify OnNotify
		{
			add
			{
				Game.NotifyHandlers.Add(value);
			}
			remove
			{
				Game.NotifyHandlers.Remove(value);
			}
		}

		/// <summary>
		/// 	This event is fired every a packet is received and about to be processed.
		/// </summary>
		// Token: 0x14000018 RID: 24
		// (add) Token: 0x06000525 RID: 1317 RVA: 0x0000A888 File Offset: 0x00009C88
		// (remove) Token: 0x06000526 RID: 1318 RVA: 0x0000A8A0 File Offset: 0x00009CA0
		public static event GameProcessPacket OnProcessPacket
		{
			add
			{
				Game.ProcessPacketHandlers.Add(value);
			}
			remove
			{
				Game.ProcessPacketHandlers.Remove(value);
			}
		}

		/// <summary>
		/// 	This event is fired before displaying chat.
		/// </summary>
		// Token: 0x14000017 RID: 23
		// (add) Token: 0x06000527 RID: 1319 RVA: 0x0000A8BC File Offset: 0x00009CBC
		// (remove) Token: 0x06000528 RID: 1320 RVA: 0x0000A8D4 File Offset: 0x00009CD4
		public static event GameDisplayChat OnDisplayChat
		{
			add
			{
				Game.DisplayChatHandlers.Add(value);
			}
			remove
			{
				Game.DisplayChatHandlers.Remove(value);
			}
		}

		/// <summary>
		/// 	This event is fired before sending chat.
		/// </summary>
		// Token: 0x14000016 RID: 22
		// (add) Token: 0x06000529 RID: 1321 RVA: 0x0000A8F0 File Offset: 0x00009CF0
		// (remove) Token: 0x0600052A RID: 1322 RVA: 0x0000A908 File Offset: 0x00009D08
		public static event GameSendChat OnSendChat
		{
			add
			{
				Game.SendChatHandlers.Add(value);
			}
			remove
			{
				Game.SendChatHandlers.Remove(value);
			}
		}

		/// <summary>
		/// 	This event is fired every a window event is received and about to be processed.
		/// </summary>
		// Token: 0x14000015 RID: 21
		// (add) Token: 0x0600052B RID: 1323 RVA: 0x0000A924 File Offset: 0x00009D24
		// (remove) Token: 0x0600052C RID: 1324 RVA: 0x0000A93C File Offset: 0x00009D3C
		public static event GameWndProc OnWndProc
		{
			add
			{
				Game.WndProcHandlers.Add(value);
			}
			remove
			{
				Game.WndProcHandlers.Remove(value);
			}
		}

		/// <summary>
		/// 	This event is fired every time the game updates.
		/// </summary>
		// Token: 0x14000014 RID: 20
		// (add) Token: 0x0600052D RID: 1325 RVA: 0x0000A958 File Offset: 0x00009D58
		// (remove) Token: 0x0600052E RID: 1326 RVA: 0x0000A970 File Offset: 0x00009D70
		public static event GameUpdate OnUpdate
		{
			add
			{
				Game.UpdateHandlers.Add(value);
			}
			remove
			{
				Game.UpdateHandlers.Remove(value);
			}
		}

		/// <summary>
		/// 	Gets or sets the desired zoom of the game.
		/// </summary>
		// Token: 0x17000135 RID: 309
		// (get) Token: 0x0600052F RID: 1327 RVA: 0x0000A98C File Offset: 0x00009D8C
		// (set) Token: 0x06000530 RID: 1328 RVA: 0x0000A9B0 File Offset: 0x00009DB0
		public unsafe static float ZoomDesired
		{
			get
			{
				Zoom* ptr = <Module>.EnsoulSharp.Native.Zoom.GetInstance();
				if (ptr != null)
				{
					return *<Module>.EnsoulSharp.Native.Zoom.GetDesired(ptr);
				}
				return 0f;
			}
			set
			{
				Zoom* ptr = <Module>.EnsoulSharp.Native.Zoom.GetInstance();
				if (ptr != null)
				{
					*<Module>.EnsoulSharp.Native.Zoom.GetDesired(ptr) = value;
				}
			}
		}

		/// <summary>
		/// 	Gets or sets the minimum zoom of the game.
		/// </summary>
		// Token: 0x17000134 RID: 308
		// (get) Token: 0x06000531 RID: 1329 RVA: 0x0000A9D0 File Offset: 0x00009DD0
		// (set) Token: 0x06000532 RID: 1330 RVA: 0x0000A9F4 File Offset: 0x00009DF4
		public unsafe static float ZoomMin
		{
			get
			{
				CameraConfig* ptr = <Module>.EnsoulSharp.Native.CameraConfig.GetInstance();
				if (ptr != null)
				{
					return *<Module>.EnsoulSharp.Native.CameraConfig.GetZoomMinDistance(ptr);
				}
				return 0f;
			}
			set
			{
				CameraConfig* ptr = <Module>.EnsoulSharp.Native.CameraConfig.GetInstance();
				if (ptr != null)
				{
					*<Module>.EnsoulSharp.Native.CameraConfig.GetZoomMinDistance(ptr) = value;
				}
			}
		}

		/// <summary>
		/// 	Gets or sets the maximum zoomof the game.
		/// </summary>
		// Token: 0x17000133 RID: 307
		// (get) Token: 0x06000533 RID: 1331 RVA: 0x0000AA14 File Offset: 0x00009E14
		// (set) Token: 0x06000534 RID: 1332 RVA: 0x0000AA38 File Offset: 0x00009E38
		public unsafe static float ZoomMax
		{
			get
			{
				CameraConfig* ptr = <Module>.EnsoulSharp.Native.CameraConfig.GetInstance();
				if (ptr != null)
				{
					return *<Module>.EnsoulSharp.Native.CameraConfig.GetZoomMaxDistance(ptr);
				}
				return 0f;
			}
			set
			{
				CameraConfig* ptr = <Module>.EnsoulSharp.Native.CameraConfig.GetInstance();
				if (ptr != null)
				{
					*<Module>.EnsoulSharp.Native.CameraConfig.GetZoomMaxDistance(ptr) = value;
				}
			}
		}

		/// <summary>
		/// 	Gets the fps of the game.
		/// </summary>
		// Token: 0x17000132 RID: 306
		// (get) Token: 0x06000535 RID: 1333 RVA: 0x0000AA58 File Offset: 0x00009E58
		public unsafe static int FPS
		{
			get
			{
				FramerateInformation* ptr = <Module>.EnsoulSharp.Native.FramerateInformation.GetInstance();
				if (ptr != null)
				{
					return <Module>.EnsoulSharp.Native.FramerateInformation.GetMovingAverageFps(ptr) + 0.5;
				}
				return 0;
			}
		}

		/// <summary>
		/// 	Gets the ping of the game.
		/// </summary>
		// Token: 0x17000131 RID: 305
		// (get) Token: 0x06000536 RID: 1334 RVA: 0x0000AA84 File Offset: 0x00009E84
		public unsafe static int Ping
		{
			get
			{
				MultiplayerClient* ptr = <Module>.EnsoulSharp.Native.MultiplayerClient.GetInstance();
				if (ptr != null)
				{
					return <Module>.EnsoulSharp.Native.MultiplayerClient.CurrentRoundTripTimeMS(ptr);
				}
				return 0;
			}
		}

		/// <summary>
		/// 	Gets the time of the game.
		/// </summary>
		// Token: 0x17000130 RID: 304
		// (get) Token: 0x06000537 RID: 1335 RVA: 0x0000AAA4 File Offset: 0x00009EA4
		public unsafe static float Time
		{
			get
			{
				FrameClockFacade* ptr = <Module>.EnsoulSharp.Native.FrameClockFacade.GetInstance();
				if (ptr != null)
				{
					return <Module>.EnsoulSharp.Native.FrameClockFacade.GetFrameStartTimeSecs(ptr);
				}
				return 0f;
			}
		}

		/// <summary>
		/// 	Gets the window of the game.
		/// </summary>
		// Token: 0x1700012F RID: 303
		// (get) Token: 0x06000538 RID: 1336 RVA: 0x0000AAC8 File Offset: 0x00009EC8
		public static IntPtr Window
		{
			get
			{
				IntPtr result = new IntPtr(<Module>.EnsoulSharp.Native.System.GetMainWndHandle());
				return result;
			}
		}

		/// <summary>
		/// 	Gets the map id of the game.
		/// </summary>
		// Token: 0x1700012E RID: 302
		// (get) Token: 0x06000539 RID: 1337 RVA: 0x0000AAE4 File Offset: 0x00009EE4
		public unsafe static GameMapId MapId
		{
			get
			{
				GameSessionInfo* ptr = <Module>.EnsoulSharp.Native.GameSessionInfo.GetInstance();
				if (ptr != null)
				{
					return (GameMapId)(*<Module>.EnsoulSharp.Native.GameSessionInfo.GetMapID(ptr));
				}
				return GameMapId.Unknown;
			}
		}

		/// <summary>
		/// 	Gets the state of the game.
		/// </summary>
		// Token: 0x1700012D RID: 301
		// (get) Token: 0x0600053A RID: 1338 RVA: 0x0000AB04 File Offset: 0x00009F04
		public unsafe static GameState State
		{
			get
			{
				GameClient* ptr = <Module>.EnsoulSharp.Native.GameClient.GetInstance();
				if (ptr != null)
				{
					return (GameState)(*<Module>.EnsoulSharp.Native.GameClient.GetCurrentGameState(ptr));
				}
				return GameState.Loading;
			}
		}

		/// <summary>
		/// 	Gets the 3D cursor world position of the game.
		/// </summary>
		// Token: 0x1700012C RID: 300
		// (get) Token: 0x0600053B RID: 1339 RVA: 0x0000AB24 File Offset: 0x00009F24
		public unsafe static Vector3 CursorPos
		{
			get
			{
				HudCursorTargetLogic* ptr = <Module>.EnsoulSharp.Native.HudCursorTargetLogic.GetInstance();
				if (ptr != null)
				{
					Vector3f* ptr2 = <Module>.EnsoulSharp.Native.HudCursorTargetLogic.GetCursorTargetPosRaw(ptr);
					Vector3 result = new Vector3(<Module>.EnsoulSharp.Native.Vector3f.GetX(ptr2), <Module>.EnsoulSharp.Native.Vector3f.GetZ(ptr2), <Module>.EnsoulSharp.Native.Vector3f.GetY(ptr2));
					return result;
				}
				return Vector3.Zero;
			}
		}

		/// <summary>
		/// 	Gets the version of the game.
		/// </summary>
		// Token: 0x1700012B RID: 299
		// (get) Token: 0x0600053C RID: 1340 RVA: 0x0000AB64 File Offset: 0x00009F64
		public static string Version
		{
			get
			{
				return new string(<Module>.EnsoulSharp.Native.VersionInfo.GetBuildVersion());
			}
		}

		/// <summary>
		/// 	Prints text into game chat with format and params.
		/// </summary>
		/// <param name="format">The format.</param>
		/// <param name="triggerEvent">A value indicating whether trigger event.</param>
		/// <param name="params">The params.</param>
		// Token: 0x0600053D RID: 1341 RVA: 0x0000ABD4 File Offset: 0x00009FD4
		public static void Print(string format, [MarshalAs(UnmanagedType.U1)] bool triggerEvent, params object[] @params)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendFormat(format, @params);
			Game.Print(stringBuilder.ToString(), triggerEvent);
		}

		/// <summary>
		/// 	Prints text into game chat with format and params.
		/// </summary>
		/// <param name="format">The format.</param>
		/// <param name="params">The params.</param>
		// Token: 0x0600053E RID: 1342 RVA: 0x0000B108 File Offset: 0x0000A508
		public static void Print(string format, params object[] @params)
		{
			Game.Print(format, true, @params);
		}

		/// <summary>
		/// 	Prints text into game chat.
		/// </summary>
		/// <param name="text">The text.</param>
		/// <param name="triggerEvent">A value indicating whether trigger event.</param>
		// Token: 0x0600053F RID: 1343 RVA: 0x0000AB7C File Offset: 0x00009F7C
		public unsafe static void Print(string text, [MarshalAs(UnmanagedType.U1)] bool triggerEvent)
		{
			ChatViewController* ptr = <Module>.EnsoulSharp.Native.ChatViewController.GetInstance();
			if (ptr != null)
			{
				byte[] bytes = Encoding.UTF8.GetBytes(text);
				int num = bytes.Length;
				IntPtr intPtr = Marshal.AllocHGlobal(num + 1);
				IntPtr intPtr2 = intPtr;
				Marshal.Copy(bytes, 0, intPtr, num);
				Marshal.WriteByte(intPtr2, num, 0);
				<Module>.EnsoulSharp.Native.ChatViewController.DisplayChat(ptr, (sbyte*)intPtr2.ToPointer(), triggerEvent);
				Marshal.FreeHGlobal(intPtr2);
			}
		}

		/// <summary>
		/// 	Prints text into game chat.
		/// </summary>
		/// <param name="text">The text.</param>
		// Token: 0x06000540 RID: 1344 RVA: 0x0000B0F4 File Offset: 0x0000A4F4
		public static void Print(string text)
		{
			Game.Print(text, true);
		}

		/// <summary>
		/// 	Says something to team channel or all channel with format and params.
		/// </summary>
		/// <param name="format">The format.</param>
		/// <param name="sendToAll">A value indicating whether send to all channel.</param>
		/// <param name="triggerEvent">A value indicating whether trigger event.</param>
		/// <param name="params">The params.</param>
		// Token: 0x06000541 RID: 1345 RVA: 0x0000AC58 File Offset: 0x0000A058
		public static void Say(string format, [MarshalAs(UnmanagedType.U1)] bool sendToAll, [MarshalAs(UnmanagedType.U1)] bool triggerEvent, params object[] @params)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendFormat(format, @params);
			Game.Say(stringBuilder.ToString(), sendToAll, triggerEvent);
		}

		/// <summary>
		/// 	Says something to team channel or all channel with format and params.
		/// </summary>
		/// <param name="format">The format.</param>
		/// <param name="sendToAll">A value indicating whether send to all channel.</param>
		/// <param name="params">The params.</param>
		// Token: 0x06000542 RID: 1346 RVA: 0x0000B138 File Offset: 0x0000A538
		public static void Say(string format, [MarshalAs(UnmanagedType.U1)] bool sendToAll, params object[] @params)
		{
			Game.Say(format, sendToAll, true, @params);
		}

		/// <summary>
		/// 	Says something to team channel or all channel.
		/// </summary>
		/// <param name="text">The text.</param>
		/// <param name="sendToAll">A value indicating whether send to all channel.</param>
		/// <param name="triggerEvent">A value indicating whether trigger event.</param>
		// Token: 0x06000543 RID: 1347 RVA: 0x0000ABFC File Offset: 0x00009FFC
		public unsafe static void Say(string text, [MarshalAs(UnmanagedType.U1)] bool sendToAll, [MarshalAs(UnmanagedType.U1)] bool triggerEvent)
		{
			MultiplayerClient* ptr = <Module>.EnsoulSharp.Native.MultiplayerClient.GetInstance();
			if (ptr != null)
			{
				byte[] bytes = Encoding.UTF8.GetBytes(text);
				int num = bytes.Length;
				IntPtr intPtr = Marshal.AllocHGlobal(num + 1);
				IntPtr intPtr2 = intPtr;
				Marshal.Copy(bytes, 0, intPtr, num);
				Marshal.WriteByte(intPtr2, num, 0);
				<Module>.EnsoulSharp.Native.MultiplayerClient.SendChat(ptr, (sbyte*)intPtr2.ToPointer(), sendToAll, triggerEvent);
				Marshal.FreeHGlobal(intPtr2);
			}
		}

		/// <summary>
		/// 	Says something to team channel or all channel.
		/// </summary>
		/// <param name="text">The text.</param>
		/// <param name="sendToAll">A value indicating whether send to all channel.</param>
		// Token: 0x06000544 RID: 1348 RVA: 0x0000B120 File Offset: 0x0000A520
		public static void Say(string text, [MarshalAs(UnmanagedType.U1)] bool sendToAll)
		{
			Game.Say(text, sendToAll, true);
		}

		/// <summary>
		/// 	Shows specified ping on the given position at local.
		/// </summary>
		/// <param name="pingType">The ping.</param>
		/// <param name="position">The world position.</param>
		/// <param name="playAudio">A value indicating whether play audio.</param>
		/// <param name="showChat">A value indicating whether show chat.</param>
		// Token: 0x06000545 RID: 1349 RVA: 0x0000AD78 File Offset: 0x0000A178
		public unsafe static void ShowPing(PingCategory pingType, Vector3 position, [MarshalAs(UnmanagedType.U1)] bool playAudio, [MarshalAs(UnmanagedType.U1)] bool showChat)
		{
			if (<Module>.EnsoulSharp.Native.ObjectManager.GetInstance() != null)
			{
				AIHeroClient* ptr = <Module>.EnsoulSharp.Native.ObjectManager.GetPlayer();
				if (ptr != null)
				{
					MenuGUI* ptr2 = <Module>.EnsoulSharp.Native.MenuGUI.GetInstance();
					if (ptr2 != null)
					{
						uint* ptr3 = <Module>.EnsoulSharp.Native.GameObject.GetID(ptr);
						Vector2f vector2f;
						<Module>.EnsoulSharp.Native.MenuGUI.PingMiniMap(ptr2, <Module>.EnsoulSharp.Native.Vector2f.{ctor}(ref vector2f, position.X, position.Y), 0U, *ptr3, (PingCategory)pingType, playAudio, showChat);
					}
				}
			}
		}

		/// <summary>
		/// 	Shows specified ping on the given position at local.
		/// </summary>
		/// <param name="pingType">The ping.</param>
		/// <param name="position">The world position.</param>
		/// <param name="playAudio">A value indicating whether play audio.</param>
		// Token: 0x06000546 RID: 1350 RVA: 0x0000B198 File Offset: 0x0000A598
		public static void ShowPing(PingCategory pingType, Vector3 position, [MarshalAs(UnmanagedType.U1)] bool playAudio)
		{
			Game.ShowPing(pingType, position, playAudio, true);
		}

		/// <summary>
		/// 	Shows specified ping on the given position at local.
		/// </summary>
		/// <param name="pingType">The ping.</param>
		/// <param name="position">The world position.</param>
		// Token: 0x06000547 RID: 1351 RVA: 0x0000B1F8 File Offset: 0x0000A5F8
		public static void ShowPing(PingCategory pingType, Vector3 position)
		{
			Game.ShowPing(pingType, position, true);
		}

		/// <summary>
		/// 	Shows specified ping on the given position at local.
		/// </summary>
		/// <param name="pingType">The ping.</param>
		/// <param name="position">The world position.</param>
		/// <param name="playAudio">A value indicating whether play audio.</param>
		/// <param name="showChat">A value indicating whether show chat.</param>
		// Token: 0x06000548 RID: 1352 RVA: 0x0000AD28 File Offset: 0x0000A128
		public unsafe static void ShowPing(PingCategory pingType, Vector2 position, [MarshalAs(UnmanagedType.U1)] bool playAudio, [MarshalAs(UnmanagedType.U1)] bool showChat)
		{
			if (<Module>.EnsoulSharp.Native.ObjectManager.GetInstance() != null)
			{
				AIHeroClient* ptr = <Module>.EnsoulSharp.Native.ObjectManager.GetPlayer();
				if (ptr != null)
				{
					MenuGUI* ptr2 = <Module>.EnsoulSharp.Native.MenuGUI.GetInstance();
					if (ptr2 != null)
					{
						uint* ptr3 = <Module>.EnsoulSharp.Native.GameObject.GetID(ptr);
						Vector2f vector2f;
						<Module>.EnsoulSharp.Native.MenuGUI.PingMiniMap(ptr2, <Module>.EnsoulSharp.Native.Vector2f.{ctor}(ref vector2f, position.X, position.Y), 0U, *ptr3, (PingCategory)pingType, playAudio, showChat);
					}
				}
			}
		}

		/// <summary>
		/// 	Shows specified ping on the given position at local.
		/// </summary>
		/// <param name="pingType">The ping.</param>
		/// <param name="position">The world position.</param>
		/// <param name="playAudio">A value indicating whether play audio.</param>
		// Token: 0x06000549 RID: 1353 RVA: 0x0000B180 File Offset: 0x0000A580
		public static void ShowPing(PingCategory pingType, Vector2 position, [MarshalAs(UnmanagedType.U1)] bool playAudio)
		{
			Game.ShowPing(pingType, position, playAudio, true);
		}

		/// <summary>
		/// 	Shows specified ping on the given position at local.
		/// </summary>
		/// <param name="pingType">The ping.</param>
		/// <param name="position">The world position.</param>
		// Token: 0x0600054A RID: 1354 RVA: 0x0000B1E0 File Offset: 0x0000A5E0
		public static void ShowPing(PingCategory pingType, Vector2 position)
		{
			Game.ShowPing(pingType, position, true);
		}

		/// <summary>
		/// 	Shows specified ping from given unit on the given unit at local.
		/// </summary>
		/// <param name="pingType">The ping.</param>
		/// <param name="source">The source</param>
		/// <param name="target">The target.</param>
		/// <param name="playAudio">A value indicating whether play audio.</param>
		/// <param name="showChat">A value indicating whether show chat.</param>
		// Token: 0x0600054B RID: 1355 RVA: 0x0000ACE0 File Offset: 0x0000A0E0
		public unsafe static void ShowPing(PingCategory pingType, GameObject source, GameObject target, [MarshalAs(UnmanagedType.U1)] bool playAudio, [MarshalAs(UnmanagedType.U1)] bool showChat)
		{
			MenuGUI* ptr = <Module>.EnsoulSharp.Native.MenuGUI.GetInstance();
			if (ptr != null)
			{
				Vector3 position = target.Position;
				Vector2f vector2f;
				<Module>.EnsoulSharp.Native.MenuGUI.PingMiniMap(ptr, <Module>.EnsoulSharp.Native.Vector2f.{ctor}(ref vector2f, position.X, position.Y), (uint)target.Index, (uint)source.Index, (PingCategory)pingType, playAudio, showChat);
			}
		}

		/// <summary>
		/// 	Shows specified ping from given unit on the given unit at local.
		/// </summary>
		/// <param name="pingType">The ping.</param>
		/// <param name="source">The source.</param>
		/// <param name="target">The target.</param>
		/// <param name="playAudio">A value indicating whether play audio.</param>
		// Token: 0x0600054C RID: 1356 RVA: 0x0000B168 File Offset: 0x0000A568
		public static void ShowPing(PingCategory pingType, GameObject source, GameObject target, [MarshalAs(UnmanagedType.U1)] bool playAudio)
		{
			Game.ShowPing(pingType, source, target, playAudio, true);
		}

		/// <summary>
		/// 	Shows specified ping from given unit on the given unit at local.
		/// </summary>
		/// <param name="pingType">The ping.</param>
		/// <param name="source">The source.</param>
		/// <param name="target">The target.</param>
		// Token: 0x0600054D RID: 1357 RVA: 0x0000B1C8 File Offset: 0x0000A5C8
		public static void ShowPing(PingCategory pingType, GameObject source, GameObject target)
		{
			Game.ShowPing(pingType, source, target, true);
		}

		/// <summary>
		/// 	Shows specified ping on the given unit at local.
		/// </summary>
		/// <param name="pingType">The ping.</param>
		/// <param name="target">The target.</param>
		/// <param name="playAudio">A value indicating whether play audio.</param>
		/// <param name="showChat">A value indicating whether show chat.</param>
		// Token: 0x0600054E RID: 1358 RVA: 0x0000AC84 File Offset: 0x0000A084
		public unsafe static void ShowPing(PingCategory pingType, GameObject target, [MarshalAs(UnmanagedType.U1)] bool playAudio, [MarshalAs(UnmanagedType.U1)] bool showChat)
		{
			if (<Module>.EnsoulSharp.Native.ObjectManager.GetInstance() != null)
			{
				AIHeroClient* ptr = <Module>.EnsoulSharp.Native.ObjectManager.GetPlayer();
				if (ptr != null)
				{
					MenuGUI* ptr2 = <Module>.EnsoulSharp.Native.MenuGUI.GetInstance();
					if (ptr2 != null)
					{
						Vector3 position = target.Position;
						uint* ptr3 = <Module>.EnsoulSharp.Native.GameObject.GetID(ptr);
						Vector2f vector2f;
						<Module>.EnsoulSharp.Native.MenuGUI.PingMiniMap(ptr2, <Module>.EnsoulSharp.Native.Vector2f.{ctor}(ref vector2f, position.X, position.Y), (uint)target.Index, *ptr3, (PingCategory)pingType, playAudio, showChat);
					}
				}
			}
		}

		/// <summary>
		/// 	Shows specified ping on the given unit at local.
		/// </summary>
		/// <param name="pingType">The ping.</param>
		/// <param name="target">The target.</param>
		/// <param name="playAudio">A value indicating whether play audio.</param>
		// Token: 0x0600054F RID: 1359 RVA: 0x0000B150 File Offset: 0x0000A550
		public static void ShowPing(PingCategory pingType, GameObject target, [MarshalAs(UnmanagedType.U1)] bool playAudio)
		{
			Game.ShowPing(pingType, target, playAudio, true);
		}

		/// <summary>
		/// 	Shows specified ping on the given unit at local.
		/// </summary>
		/// <param name="pingType">The ping.</param>
		/// <param name="target">The target.</param>
		// Token: 0x06000550 RID: 1360 RVA: 0x0000B1B0 File Offset: 0x0000A5B0
		public static void ShowPing(PingCategory pingType, GameObject target)
		{
			Game.ShowPing(pingType, target, true);
		}

		/// <summary>
		/// 	Sends specified ping at the given position to network.
		/// </summary>
		/// <param name="pingType">The ping.</param>
		/// <param name="position">The world position.</param>
		// Token: 0x06000551 RID: 1361 RVA: 0x0000AE3C File Offset: 0x0000A23C
		public unsafe static void SendPing(PingCategory pingType, Vector3 position)
		{
			SmartPingClientManager* ptr = <Module>.EnsoulSharp.Native.SmartPingClientManager.GetInstance();
			if (ptr != null)
			{
				Vector2f vector2f;
				<Module>.EnsoulSharp.Native.SmartPingClientManager.CallCurrentPing(ptr, <Module>.EnsoulSharp.Native.Vector2f.{ctor}(ref vector2f, position.X, position.Y), 0U, (PingCategory)pingType);
			}
		}

		/// <summary>
		/// 	Sends specified ping at the given position to network.
		/// </summary>
		/// <param name="pingType">The ping.</param>
		/// <param name="position">The world position.</param>
		// Token: 0x06000552 RID: 1362 RVA: 0x0000AE08 File Offset: 0x0000A208
		public unsafe static void SendPing(PingCategory pingType, Vector2 position)
		{
			SmartPingClientManager* ptr = <Module>.EnsoulSharp.Native.SmartPingClientManager.GetInstance();
			if (ptr != null)
			{
				Vector2f vector2f;
				<Module>.EnsoulSharp.Native.SmartPingClientManager.CallCurrentPing(ptr, <Module>.EnsoulSharp.Native.Vector2f.{ctor}(ref vector2f, position.X, position.Y), 0U, (PingCategory)pingType);
			}
		}

		/// <summary>
		/// 	Sends specified ping on the given unit to network.
		/// </summary>
		/// <param name="pingType">The ping.</param>
		/// <param name="target">The unit.</param>
		// Token: 0x06000553 RID: 1363 RVA: 0x0000ADC8 File Offset: 0x0000A1C8
		public unsafe static void SendPing(PingCategory pingType, GameObject target)
		{
			SmartPingClientManager* ptr = <Module>.EnsoulSharp.Native.SmartPingClientManager.GetInstance();
			if (ptr != null)
			{
				Vector3 position = target.Position;
				Vector2f vector2f;
				<Module>.EnsoulSharp.Native.SmartPingClientManager.CallCurrentPing(ptr, <Module>.EnsoulSharp.Native.Vector2f.{ctor}(ref vector2f, position.X, position.Y), (uint)target.NetworkId, (PingCategory)pingType);
			}
		}

		/// <summary>
		/// 	Sends your champion mastery badge.
		/// </summary>
		/// <returns>A value indicating whether successfully sent.</returns>
		// Token: 0x06000554 RID: 1364 RVA: 0x0000AE70 File Offset: 0x0000A270
		[return: MarshalAs(UnmanagedType.U1)]
		public unsafe static bool SendMasteryBadge()
		{
			MenuGUI* ptr = <Module>.EnsoulSharp.Native.MenuGUI.GetInstance();
			return ptr != null && <Module>.EnsoulSharp.Native.MenuGUI.DoDisplayChampMasteryBadge(ptr) != null;
		}

		/// <summary>
		/// 	Sends your emote.
		/// </summary>
		/// <param name="emoteId">The emote id.</param>
		/// <returns>A vlaue indicating whether successfully sent.</returns>
		// Token: 0x06000555 RID: 1365 RVA: 0x0000AE90 File Offset: 0x0000A290
		[return: MarshalAs(UnmanagedType.U1)]
		public unsafe static bool SendEmote(EmoteId emoteId)
		{
			MenuGUI* ptr = <Module>.EnsoulSharp.Native.MenuGUI.GetInstance();
			return ptr != null && <Module>.EnsoulSharp.Native.MenuGUI.DoEmote(ptr, (EmoteId)emoteId) != null;
		}

		/// <summary>
		/// 	Sends your summoner emote.
		/// </summary>
		/// <param name="emoteSlot">The emote slot.</param>
		/// <returns>A value indicating whether successfully sent.</returns>
		// Token: 0x06000556 RID: 1366 RVA: 0x0000AEB0 File Offset: 0x0000A2B0
		[return: MarshalAs(UnmanagedType.U1)]
		public unsafe static bool SendSummonerEmote(SummonerEmoteSlot emoteSlot)
		{
			EmoteRadialViewController* ptr = <Module>.EnsoulSharp.Native.EmoteRadialViewController.GetInstance();
			if (ptr != null)
			{
				<Module>.EnsoulSharp.Native.EmoteRadialViewController.FireEventForSlot(ptr, (SummonerEmoteSlot)emoteSlot);
				return true;
			}
			return false;
		}

		/// <summary>
		/// 	Gets whether the position is in fow.
		/// </summary>
		/// <param name="position">The position.</param>
		/// <returns>A value indicating whether the position is in fow.</returns>
		// Token: 0x06000557 RID: 1367 RVA: 0x0000AED0 File Offset: 0x0000A2D0
		[return: MarshalAs(UnmanagedType.U1)]
		public static bool IsInFogOfWar(Vector3 position)
		{
			Vector3f vector3f;
			return <Module>.EnsoulSharp.Native.FogOfWar.IsInFoW(<Module>.EnsoulSharp.Native.Vector3f.{ctor}(ref vector3f, position.X, position.Z, position.Y)) != null;
		}

		// Token: 0x040003CF RID: 975
		internal static Game.OnNotifyNativeDelegate m_NotifyNativeDelegate;

		// Token: 0x040003D0 RID: 976
		internal static Game.OnProcessPacketNativeDelegate m_ProcessPacketNativeDelegate;

		// Token: 0x040003D1 RID: 977
		internal static Game.OnDisplayChatNativeDelegate m_DisplayChatNativeDelegate;

		// Token: 0x040003D2 RID: 978
		internal static Game.OnSendChatNativeDelegate m_SendChatNativeDelegate;

		// Token: 0x040003D3 RID: 979
		internal static Game.OnWndProcNativeDelegate m_WndProcNativeDelegate;

		// Token: 0x040003D4 RID: 980
		internal static Game.OnUpdateNativeDelegate m_UpdateNativeDelegate;

		// Token: 0x040003D5 RID: 981
		internal static IntPtr m_NotifyNative = IntPtr.Zero;

		// Token: 0x040003D6 RID: 982
		internal static IntPtr m_ProcessPacketNative = IntPtr.Zero;

		// Token: 0x040003D7 RID: 983
		internal static IntPtr m_DisplayChatNative = IntPtr.Zero;

		// Token: 0x040003D8 RID: 984
		internal static IntPtr m_SendChatNative = IntPtr.Zero;

		// Token: 0x040003D9 RID: 985
		internal static IntPtr m_WndProcNative = IntPtr.Zero;

		// Token: 0x040003DA RID: 986
		internal static IntPtr m_UpdateNative = IntPtr.Zero;

		// Token: 0x040003DB RID: 987
		internal static List<GameNotify> NotifyHandlers = new List<GameNotify>();

		// Token: 0x040003DC RID: 988
		internal static List<GameProcessPacket> ProcessPacketHandlers = new List<GameProcessPacket>();

		// Token: 0x040003DD RID: 989
		internal static List<GameDisplayChat> DisplayChatHandlers = new List<GameDisplayChat>();

		// Token: 0x040003DE RID: 990
		internal static List<GameSendChat> SendChatHandlers = new List<GameSendChat>();

		// Token: 0x040003DF RID: 991
		internal static List<GameWndProc> WndProcHandlers = new List<GameWndProc>();

		// Token: 0x040003E0 RID: 992
		internal static List<GameUpdate> UpdateHandlers = new List<GameUpdate>();

		// Token: 0x020000E3 RID: 227
		// (Invoke) Token: 0x0600055A RID: 1370
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal unsafe delegate void OnNotifyNativeDelegate(EventsNames type, BaseParams* @params);

		// Token: 0x020000E4 RID: 228
		// (Invoke) Token: 0x0600055E RID: 1374
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal unsafe delegate void OnProcessPacketNativeDelegate(DefaultPacket* packet, bool* process);

		// Token: 0x020000E5 RID: 229
		// (Invoke) Token: 0x06000562 RID: 1378
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal unsafe delegate void OnDisplayChatNativeDelegate(sbyte* msg, uint flags, bool* process);

		// Token: 0x020000E6 RID: 230
		// (Invoke) Token: 0x06000566 RID: 1382
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal unsafe delegate void OnSendChatNativeDelegate(sbyte* msg, [MarshalAs(UnmanagedType.U1)] bool sendToAll, bool* process);

		// Token: 0x020000E7 RID: 231
		// (Invoke) Token: 0x0600056A RID: 1386
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal unsafe delegate void OnWndProcNativeDelegate(HWND__* hWnd, uint uMsg, uint wParam, int lParam, bool* process);

		// Token: 0x020000E8 RID: 232
		// (Invoke) Token: 0x0600056E RID: 1390
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void OnUpdateNativeDelegate();
	}
}
