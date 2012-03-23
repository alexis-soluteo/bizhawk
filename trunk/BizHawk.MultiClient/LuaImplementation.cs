﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using LuaInterface;
using System.Windows.Forms;
using BizHawk.MultiClient.tools;
using System.Threading;


namespace BizHawk.MultiClient
{
	public class LuaImplementation
	{
		Lua lua = new Lua();
		LuaConsole Caller;
		public string LuaLibraryList = "";
		public EventWaitHandle LuaWait;
		public bool isRunning;
		private int CurrentMemoryDomain = 0; //Main memory by default
		public bool FrameAdvanceRequested;
		Lua currThread;

		public LuaImplementation(LuaConsole passed)
		{
			LuaWait = new AutoResetEvent(false);
			LuaLibraryList = "";
			Caller = passed.get();
			LuaRegister(lua);
		}

		public void Close()
		{
			lua = new Lua();
		}

		public void LuaRegister(Lua lua)
		{
			lua.RegisterFunction("print", this, this.GetType().GetMethod("print"));

			//Register libraries
			lua.NewTable("console");
			for (int i = 0; i < ConsoleFunctions.Length; i++)
			{
				lua.RegisterFunction("console." + ConsoleFunctions[i], this, this.GetType().GetMethod("console_" + ConsoleFunctions[i]));
				LuaLibraryList += "console." + ConsoleFunctions[i] + "\n";
			}

			lua.NewTable("gui");
			for (int i = 0; i < GuiFunctions.Length; i++)
			{
				lua.RegisterFunction("gui." + GuiFunctions[i], this, this.GetType().GetMethod("gui_" + GuiFunctions[i]));
				LuaLibraryList += "gui." + GuiFunctions[i] + "\n";
			}

			lua.NewTable("emu");
			for (int i = 0; i < EmuFunctions.Length; i++)
			{
				lua.RegisterFunction("emu." + EmuFunctions[i], this, this.GetType().GetMethod("emu_" + EmuFunctions[i]));
				LuaLibraryList += "emu." + EmuFunctions[i] + "\n";
			}

			lua.NewTable("memory");
			for (int i = 0; i < MemoryFunctions.Length; i++)
			{
				lua.RegisterFunction("memory." + MemoryFunctions[i], this, this.GetType().GetMethod("memory_" + MemoryFunctions[i]));
				LuaLibraryList += "memory." + MemoryFunctions[i] + "\n";
			}

			lua.NewTable("mainmemory");
			for (int i = 0; i < MainMemoryFunctions.Length; i++)
			{
				lua.RegisterFunction("mainmemory." + MainMemoryFunctions[i], this, this.GetType().GetMethod("mainmemory_" + MainMemoryFunctions[i]));
				LuaLibraryList += "mainmemory." + MainMemoryFunctions[i] + "\n";
			}

			lua.NewTable("savestate");
			for (int i = 0; i < SaveStateFunctions.Length; i++)
			{
				lua.RegisterFunction("savestate." + SaveStateFunctions[i], this, this.GetType().GetMethod("savestate_" + SaveStateFunctions[i]));
				LuaLibraryList += "savestate." + SaveStateFunctions[i] + "\n";
			}

			lua.NewTable("movie");
			for (int i = 0; i < MovieFunctions.Length; i++)
			{
				lua.RegisterFunction("movie." + MovieFunctions[i], this, this.GetType().GetMethod("movie_" + MovieFunctions[i]));
				LuaLibraryList += "movie." + MovieFunctions[i] + "\n";
			}

			lua.NewTable("joypad");
			for (int i = 0; i < JoypadFunctions.Length; i++)
			{
				lua.RegisterFunction("joypad." + JoypadFunctions[i], this, this.GetType().GetMethod("joypad_" + JoypadFunctions[i]));
				LuaLibraryList += "joypad." + JoypadFunctions[i] + "\n";
			}

			lua.NewTable("client");
			for (int i = 0; i < MultiClientFunctions.Length; i++)
			{
				lua.RegisterFunction("client." + MultiClientFunctions[i], this, this.GetType().GetMethod("client_" + MultiClientFunctions[i]));
				LuaLibraryList += "client." + MultiClientFunctions[i] + "\n";
			}
		}
		
		public Lua SpawnCoroutine(string File)
		{
			var t = lua.NewThread();
			LuaRegister(t);
			var main = t.LoadFile(File);
			t.Push(main); //push main function on to stack for subsequent resuming
			return t;
		}

		private int LuaInt(object lua_arg)
		{
			return Convert.ToInt32((double)lua_arg);
		}

		private uint LuaUInt(object lua_arg)
		{
			return Convert.ToUInt32((double)lua_arg);
		}

		/**
		 * LuaInterface requires the exact match of parameter count,
		 * except optional parameters. So, if you want to support
		 * variable arguments, declare them as optional and pass
		 * them to this method.
		 */
		private object[] LuaVarArgs(params object[] lua_args)
		{
			int n = lua_args.Length;
			int trim = 0;
			for (int i = n-1; i >= 0; --i)
				if (lua_args[i] == null) ++trim;
			object[] lua_result = new object[n-trim];
			Array.Copy(lua_args, lua_result, n-trim);
			return lua_result;
		}

		public class ResumeResult
		{
			public bool WaitForFrame;
		}

		public ResumeResult ResumeScript(Lua script)
		{
			currThread = script;
			script.Resume(0);
			currThread = null;
			var result = new ResumeResult();
			result.WaitForFrame = FrameAdvanceRequested;
			FrameAdvanceRequested = false;
			return result;
		}

		public void print(string s)
		{
			Caller.AddText(s);
			Caller.AddText("\n");
		}

		/****************************************************/
		/*************library definitions********************/
		/****************************************************/
		public static string[] ConsoleFunctions = new string[]
		{
			"output",
			"clear",
			"getluafunctionslist",
		};

		public static string[] GuiFunctions = new string[]
		{
			"text",
			"alert",
		};

		public static string[] EmuFunctions = new string[]
		{
			"frameadvance",
			"yield",
			"pause",
			"unpause",
			"togglepause",
			//"speedmode",
			"framecount",
			"lagcount",
			"islagged",
			"getsystemid",
			//"registerbefore",
			//"registerafter",
			//"register",
			"setrenderplanes",
		};
		
		public static string[] MemoryFunctions = new string[]
		{
			"usememorydomain",
			"getmemorydomainlist",
			"getcurrentmemorydomain",
			"read_s8",
			"read_u8",
			"read_s16_le",
			"read_s24_le",
			"read_s32_le",
			"read_u16_le",
			"read_u24_le",
			"read_u32_le",
			"read_s16_be",
			"read_s24_be",
			"read_s32_be",
			"read_u16_be",
			"read_u24_be",
			"read_u32_be",
			"write_s8",
			"write_u8",
			"write_s16_le",
			"write_s24_le",
			"write_s32_le",
			"write_u16_le",
			"write_u24_le",
			"write_u32_le",
			"write_s16_be",
			"write_s24_be",
			"write_s32_be",
			"write_u16_be",
			"write_u24_be",
			"write_u32_be",
			"readbyte",
			"writebyte",
			//"registerwrite",
			//"registerread",
		};

		public static string[] MainMemoryFunctions = new string[]
		{
			"read_s8",
			"read_u8",
			"read_s16_le",
			"read_s24_le",
			"read_s32_le",
			"read_u16_le",
			"read_u24_le",
			"read_u32_le",
			"read_s16_be",
			"read_s24_be",
			"read_s32_be",
			"read_u16_be",
			"read_u24_be",
			"read_u32_be",
			"write_s8",
			"write_u8",
			"write_s16_le",
			"write_s24_le",
			"write_s32_le",
			"write_u16_le",
			"write_u24_le",
			"write_u32_le",
			"write_s16_be",
			"write_s24_be",
			"write_s32_be",
			"write_u16_be",
			"write_u24_be",
			"write_u32_be",
			"readbyte",
			"writebyte",
			//"registerwrite",
			//"registerread",
		};

		public static string[] SaveStateFunctions = new string[] {
			"saveslot",
			"loadslot",
			"save",
			"load",
		};

		public static string[] MovieFunctions = new string[] {
			"mode",
			"isloaded",
			"rerecordcount",
			"length",
			"stop",
			"filename",
			"getreadonly",
			"setreadonly",
			//"rerecordcounting",
		};

		public static string[] JoypadFunctions = new string[] {
			"set",
			"get",
			"getimmediate"
		};

		public static string[] MultiClientFunctions = new string[] {
			"openrom",
			"closerom",
			"opentoolbox",
			"openramwatch",
			"openramsearch",
			"openrampoke",
			"openhexeditor",
			"opentasstudio",
			"opencheats",
		};

		/****************************************************/
		/*************function definitions********************/
		/****************************************************/

		//----------------------------------------------------
		//Console library
		//----------------------------------------------------

		public void console_output(object lua_input)
		{
			Global.MainForm.LuaConsole1.WriteToOutputWindow(lua_input.ToString());
		}

		public void console_clear()
		{
			Global.MainForm.LuaConsole1.ClearOutputWindow();
		}

		public string console_getluafunctionslist()
		{
			return LuaLibraryList;
		}

		//----------------------------------------------------
		//Gui library
		//----------------------------------------------------
		public void gui_text(object luaX, object luaY, object luaStr)
		{
			Global.RenderPanel.AddGUIText(luaStr.ToString(), LuaInt(luaX), LuaInt(luaY), false);
		}

		public void gui_alert(object luaX, object luaY, object luaStr)
		{
			Global.RenderPanel.AddGUIText(luaStr.ToString(), LuaInt(luaX), LuaInt(luaY), true);
		}

		//----------------------------------------------------
		//Emu library
		//----------------------------------------------------
		public void emu_frameadvance()
		{
			FrameAdvanceRequested = true;
			currThread.Yield(0);
		}

		public void emu_yield()
		{
			currThread.Yield(0);
		}

		public void emu_pause()
		{
			Global.MainForm.PauseEmulator();
		}

		public void emu_unpause()
		{
			Global.MainForm.UnpauseEmulator();
		}

		public void emu_togglepause()
		{
			Global.MainForm.TogglePause();
		}

		public int emu_framecount()
		{
			return Global.Emulator.Frame;
		}

		public int emu_lagcount()
		{
			return Global.Emulator.LagCount;
		}

		public bool emu_islagged()
		{
			return Global.Emulator.IsLagFrame;
		}

		public string emu_getsystemid()
		{
			return Global.Emulator.SystemId;
		}

		// For now, it accepts arguments up to 5.
		public void emu_setrenderplanes(
			object lua_p0, object lua_p1 = null, object lua_p2 = null,
			object lua_p3 = null, object lua_p4 = null)
		{
			emu_setrenderplanes_do(LuaVarArgs(lua_p0, lua_p1, lua_p2, lua_p3, lua_p4));
		}

		// TODO: error handling for argument count mismatch
		private void emu_setrenderplanes_do(object[] lua_p)
		{
			if (Global.Emulator is BizHawk.Emulation.Consoles.Nintendo.NES)
			{
				Global.CoreInputComm.NES_ShowOBJ = Global.Config.NESDispSprites = (bool)lua_p[0];
				Global.CoreInputComm.NES_ShowBG = Global.Config.NESDispBackground = (bool)lua_p[1];
			}
			else if (Global.Emulator is BizHawk.Emulation.Consoles.TurboGrafx.PCEngine)
			{
				Global.CoreInputComm.PCE_ShowOBJ1 = Global.Config.PCEDispOBJ1 = (bool)lua_p[0];
				Global.CoreInputComm.PCE_ShowBG1 = Global.Config.PCEDispBG1 = (bool)lua_p[1];
				if (lua_p.Length > 2)
				{
					Global.CoreInputComm.PCE_ShowOBJ2 = Global.Config.PCEDispOBJ2 = (bool)lua_p[2];
					Global.CoreInputComm.PCE_ShowBG2 = Global.Config.PCEDispBG2 = (bool)lua_p[3];
				}
			}
			else if (Global.Emulator is BizHawk.Emulation.Consoles.Sega.SMS)
			{
				Global.CoreInputComm.SMS_ShowOBJ = Global.Config.SMSDispOBJ = (bool)lua_p[0];
				Global.CoreInputComm.SMS_ShowBG = Global.Config.SMSDispBG = (bool)lua_p[1];
			}
		}

		//----------------------------------------------------
		//Memory library
		//----------------------------------------------------

		public bool memory_usememorydomain(object lua_input)
		{
			if (lua_input.GetType() != typeof(string))
				return false;

			for (int x = 0; x < Global.Emulator.MemoryDomains.Count; x++)
			{
				if (Global.Emulator.MemoryDomains[x].Name == lua_input.ToString())
				{
					CurrentMemoryDomain = x;
					return true;
				}
			}

			return false;
		}
		
		public string memory_getmemorydomainlist()
		{
			string list = "";
			for (int x = 0; x < Global.Emulator.MemoryDomains.Count; x++)
			{
				list += Global.Emulator.MemoryDomains[x].Name + '\n';
			}
			return list;
		}

		public string memory_getcurrentmemorydomain()
		{
			return Global.Emulator.MemoryDomains[CurrentMemoryDomain].Name;
		}

		public uint memory_readbyte(object lua_addr)
		{
			int addr = LuaInt(lua_addr);
			return M_R_U8(addr);
		}

		public void memory_writebyte(object lua_addr, object lua_v)
		{
			int addr = LuaInt(lua_addr);
			uint v = LuaUInt(lua_v);
			M_W_U8(addr, v);
		}

		public int memory_read_s8(object lua_addr)
		{
			int addr = LuaInt(lua_addr);
			return (sbyte)M_R_U8(addr);
		}

		public uint memory_read_u8(object lua_addr)
		{
			int addr = LuaInt(lua_addr);
			return M_R_U8(addr);
		}

		public int memory_read_s16_le(object lua_addr)
		{
			int addr = LuaInt(lua_addr);
			return M_R_S_LE(addr, 2);
		}

		public int memory_read_s24_le(object lua_addr)
		{
			int addr = LuaInt(lua_addr);
			return M_R_S_LE(addr, 3);
		}

		public int memory_read_s32_le(object lua_addr)
		{
			int addr = LuaInt(lua_addr);
			return M_R_S_LE(addr, 4);
		}

		public uint memory_read_u16_le(object lua_addr)
		{
			int addr = LuaInt(lua_addr);
			return M_R_U_LE(addr, 2);
		}

		public uint memory_read_u24_le(object lua_addr)
		{
			int addr = LuaInt(lua_addr);
			return M_R_U_LE(addr, 3);
		}

		public uint memory_read_u32_le(object lua_addr)
		{
			int addr = LuaInt(lua_addr);
			return M_R_U_LE(addr, 4);
		}

		public int memory_read_s16_be(object lua_addr)
		{
			int addr = LuaInt(lua_addr);
			return M_R_S_BE(addr, 2);
		}

		public int memory_read_s24_be(object lua_addr)
		{
			int addr = LuaInt(lua_addr);
			return M_R_S_BE(addr, 3);
		}

		public int memory_read_s32_be(object lua_addr)
		{
			int addr = LuaInt(lua_addr);
			return M_R_S_BE(addr, 4);
		}

		public uint memory_read_u16_be(object lua_addr)
		{
			int addr = LuaInt(lua_addr);
			return M_R_U_BE(addr, 2);
		}

		public uint memory_read_u24_be(object lua_addr)
		{
			int addr = LuaInt(lua_addr);
			return M_R_U_BE(addr, 3);
		}

		public uint memory_read_u32_be(object lua_addr)
		{
			int addr = LuaInt(lua_addr);
			return M_R_U_BE(addr, 4);
		}

		public void memory_write_s8(object lua_addr, object lua_v)
		{
			int addr = LuaInt(lua_addr);
			int v = LuaInt(lua_v);
			M_W_U8(addr, (uint)v);
		}

		public void memory_write_u8(object lua_addr, object lua_v)
		{
			int addr = LuaInt(lua_addr);
			uint v = LuaUInt(lua_v);
			M_W_U8(addr, v);
		}

		public void memory_write_s16_le(object lua_addr, object lua_v)
		{
			int addr = LuaInt(lua_addr);
			int v = LuaInt(lua_v);
			M_W_S_LE(addr, v, 2);
		}

		public void memory_write_s24_le(object lua_addr, object lua_v)
		{
			int addr = LuaInt(lua_addr);
			int v = LuaInt(lua_v);
			M_W_S_LE(addr, v, 3);
		}

		public void memory_write_s32_le(object lua_addr, object lua_v)
		{
			int addr = LuaInt(lua_addr);
			int v = LuaInt(lua_v);
			M_W_S_LE(addr, v, 4);
		}

		public void memory_write_u16_le(object lua_addr, object lua_v)
		{
			int addr = LuaInt(lua_addr);
			uint v = LuaUInt(lua_v);
			M_W_U_LE(addr, v, 2);
		}

		public void memory_write_u24_le(object lua_addr, object lua_v)
		{
			int addr = LuaInt(lua_addr);
			uint v = LuaUInt(lua_v);
			M_W_U_LE(addr, v, 3);
		}

		public void memory_write_u32_le(object lua_addr, object lua_v)
		{
			int addr = LuaInt(lua_addr);
			uint v = LuaUInt(lua_v);
			M_W_U_LE(addr, v, 4);
		}

		public void memory_write_s16_be(object lua_addr, object lua_v)
		{
			int addr = LuaInt(lua_addr);
			int v = LuaInt(lua_v);
			M_W_S_BE(addr, v, 2);
		}

		public void memory_write_s24_be(object lua_addr, object lua_v)
		{
			int addr = LuaInt(lua_addr);
			int v = LuaInt(lua_v);
			M_W_S_BE(addr, v, 3);
		}

		public void memory_write_s32_be(object lua_addr, object lua_v)
		{
			int addr = LuaInt(lua_addr);
			int v = LuaInt(lua_v);
			M_W_S_BE(addr, v, 4);
		}

		public void memory_write_u16_be(object lua_addr, object lua_v)
		{
			int addr = LuaInt(lua_addr);
			uint v = LuaUInt(lua_v);
			M_W_U_BE(addr, v, 2);
		}

		public void memory_write_u24_be(object lua_addr, object lua_v)
		{
			int addr = LuaInt(lua_addr);
			uint v = LuaUInt(lua_v);
			M_W_U_BE(addr, v, 3);
		}

		public void memory_write_u32_be(object lua_addr, object lua_v)
		{
			int addr = LuaInt(lua_addr);
			uint v = LuaUInt(lua_v);
			M_W_U_BE(addr, v, 4);
		}

		private int M_R_S_LE(int addr, int size)
		{
			return U2S(M_R_U_LE(addr, size), size);
		}

		private uint M_R_U_LE(int addr, int size)
		{
			uint v = 0;
			for(int i = 0; i < size; ++i)
				v |= M_R_U8(addr+i) << 8*i;
			return v;
		}

		private int M_R_S_BE(int addr, int size)
		{
			return U2S(M_R_U_BE(addr, size), size);
		}

		private uint M_R_U_BE(int addr, int size)
		{
			uint v = 0;
			for(int i = 0; i < size; ++i)
				v |= M_R_U8(addr+i) << 8*(size-1-i);
			return v;
		}

		private void M_W_S_LE(int addr, int v, int size)
		{
			M_W_U_LE(addr, (uint)v, size);
		}

		private void M_W_U_LE(int addr, uint v, int size)
		{
			for(int i = 0; i < size; ++i)
				M_W_U8(addr+i, (v>>(8*i)) & 0xFF);
		}

		private void M_W_S_BE(int addr, int v, int size)
		{
			M_W_U_BE(addr, (uint)v, size);
		}

		private void M_W_U_BE(int addr, uint v, int size)
		{
			for(int i = 0; i < size; ++i)
				M_W_U8(addr+i, (v>>(8*(size-1-i))) & 0xFF);
		}

		private uint M_R_U8(int addr)
		{
			return Global.Emulator.MemoryDomains[CurrentMemoryDomain].PeekByte(addr);
		}

		private void M_W_U8(int addr, uint v)
		{
			Global.Emulator.MemoryDomains[CurrentMemoryDomain].PokeByte(addr, (byte)v);
		}

		//----------------------------------------------------
		//Main Memory library
		//----------------------------------------------------

		public uint mainmemory_readbyte(object lua_addr)
		{
			int addr = LuaInt(lua_addr);
			return MM_R_U8(addr);
		}

		public void mainmemory_writebyte(object lua_addr, object lua_v)
		{
			int addr = LuaInt(lua_addr);
			uint v = LuaUInt(lua_v);
			MM_W_U8(addr, v);
		}

		public int mainmemory_read_s8(object lua_addr)
		{
			int addr = LuaInt(lua_addr);
			return (sbyte)MM_R_U8(addr);
		}

		public uint mainmemory_read_u8(object lua_addr)
		{
			int addr = LuaInt(lua_addr);
			return MM_R_U8(addr);
		}

		public int mainmemory_read_s16_le(object lua_addr)
		{
			int addr = LuaInt(lua_addr);
			return MM_R_S_LE(addr, 2);
		}

		public int mainmemory_read_s24_le(object lua_addr)
		{
			int addr = LuaInt(lua_addr);
			return MM_R_S_LE(addr, 3);
		}

		public int mainmemory_read_s32_le(object lua_addr)
		{
			int addr = LuaInt(lua_addr);
			return MM_R_S_LE(addr, 4);
		}

		public uint mainmemory_read_u16_le(object lua_addr)
		{
			int addr = LuaInt(lua_addr);
			return MM_R_U_LE(addr, 2);
		}

		public uint mainmemory_read_u24_le(object lua_addr)
		{
			int addr = LuaInt(lua_addr);
			return MM_R_U_LE(addr, 3);
		}

		public uint mainmemory_read_u32_le(object lua_addr)
		{
			int addr = LuaInt(lua_addr);
			return MM_R_U_LE(addr, 4);
		}

		public int mainmemory_read_s16_be(object lua_addr)
		{
			int addr = LuaInt(lua_addr);
			return MM_R_S_BE(addr, 2);
		}

		public int mainmemory_read_s24_be(object lua_addr)
		{
			int addr = LuaInt(lua_addr);
			return MM_R_S_BE(addr, 3);
		}

		public int mainmemory_read_s32_be(object lua_addr)
		{
			int addr = LuaInt(lua_addr);
			return MM_R_S_BE(addr, 4);
		}

		public uint mainmemory_read_u16_be(object lua_addr)
		{
			int addr = LuaInt(lua_addr);
			return MM_R_U_BE(addr, 2);
		}

		public uint mainmemory_read_u24_be(object lua_addr)
		{
			int addr = LuaInt(lua_addr);
			return MM_R_U_BE(addr, 3);
		}

		public uint mainmemory_read_u32_be(object lua_addr)
		{
			int addr = LuaInt(lua_addr);
			return MM_R_U_BE(addr, 4);
		}

		public void mainmemory_write_s8(object lua_addr, object lua_v)
		{
			int addr = LuaInt(lua_addr);
			int v = LuaInt(lua_v);
			MM_W_U8(addr, (uint)v);
		}

		public void mainmemory_write_u8(object lua_addr, object lua_v)
		{
			int addr = LuaInt(lua_addr);
			uint v = LuaUInt(lua_v);
			MM_W_U8(addr, v);
		}

		public void mainmemory_write_s16_le(object lua_addr, object lua_v)
		{
			int addr = LuaInt(lua_addr);
			int v = LuaInt(lua_v);
			MM_W_S_LE(addr, v, 2);
		}

		public void mainmemory_write_s24_le(object lua_addr, object lua_v)
		{
			int addr = LuaInt(lua_addr);
			int v = LuaInt(lua_v);
			MM_W_S_LE(addr, v, 3);
		}

		public void mainmemory_write_s32_le(object lua_addr, object lua_v)
		{
			int addr = LuaInt(lua_addr);
			int v = LuaInt(lua_v);
			MM_W_S_LE(addr, v, 4);
		}

		public void mainmemory_write_u16_le(object lua_addr, object lua_v)
		{
			int addr = LuaInt(lua_addr);
			uint v = LuaUInt(lua_v);
			MM_W_U_LE(addr, v, 2);
		}

		public void mainmemory_write_u24_le(object lua_addr, object lua_v)
		{
			int addr = LuaInt(lua_addr);
			uint v = LuaUInt(lua_v);
			MM_W_U_LE(addr, v, 3);
		}

		public void mainmemory_write_u32_le(object lua_addr, object lua_v)
		{
			int addr = LuaInt(lua_addr);
			uint v = LuaUInt(lua_v);
			MM_W_U_LE(addr, v, 4);
		}

		public void mainmemory_write_s16_be(object lua_addr, object lua_v)
		{
			int addr = LuaInt(lua_addr);
			int v = LuaInt(lua_v);
			MM_W_S_BE(addr, v, 2);
		}

		public void mainmemory_write_s24_be(object lua_addr, object lua_v)
		{
			int addr = LuaInt(lua_addr);
			int v = LuaInt(lua_v);
			MM_W_S_BE(addr, v, 3);
		}

		public void mainmemory_write_s32_be(object lua_addr, object lua_v)
		{
			int addr = LuaInt(lua_addr);
			int v = LuaInt(lua_v);
			MM_W_S_BE(addr, v, 4);
		}

		public void mainmemory_write_u16_be(object lua_addr, object lua_v)
		{
			int addr = LuaInt(lua_addr);
			uint v = LuaUInt(lua_v);
			MM_W_U_BE(addr, v, 2);
		}

		public void mainmemory_write_u24_be(object lua_addr, object lua_v)
		{
			int addr = LuaInt(lua_addr);
			uint v = LuaUInt(lua_v);
			MM_W_U_BE(addr, v, 3);
		}

		public void mainmemory_write_u32_be(object lua_addr, object lua_v)
		{
			int addr = LuaInt(lua_addr);
			uint v = LuaUInt(lua_v);
			MM_W_U_BE(addr, v, 4);
		}

		private int MM_R_S_LE(int addr, int size)
		{
			return U2S(MM_R_U_LE(addr, size), size);
		}

		private uint MM_R_U_LE(int addr, int size)
		{
			uint v = 0;
			for(int i = 0; i < size; ++i)
				v |= MM_R_U8(addr+i) << 8*i;
			return v;
		}

		private int MM_R_S_BE(int addr, int size)
		{
			return U2S(MM_R_U_BE(addr, size), size);
		}

		private uint MM_R_U_BE(int addr, int size)
		{
			uint v = 0;
			for(int i = 0; i < size; ++i)
				v |= MM_R_U8(addr+i) << 8*(size-1-i);
			return v;
		}

		private void MM_W_S_LE(int addr, int v, int size)
		{
			MM_W_U_LE(addr, (uint)v, size);
		}

		private void MM_W_U_LE(int addr, uint v, int size)
		{
			for(int i = 0; i < size; ++i)
				MM_W_U8(addr+i, (v>>(8*i)) & 0xFF);
		}

		private void MM_W_S_BE(int addr, int v, int size)
		{
			MM_W_U_BE(addr, (uint)v, size);
		}

		private void MM_W_U_BE(int addr, uint v, int size)
		{
			for(int i = 0; i < size; ++i)
				MM_W_U8(addr+i, (v>>(8*(size-1-i))) & 0xFF);
		}

		private uint MM_R_U8(int addr)
		{
			return Global.Emulator.MainMemory.PeekByte(addr);
		}

		private void MM_W_U8(int addr, uint v)
		{
			Global.Emulator.MainMemory.PokeByte(addr, (byte)v);
		}

		private int U2S(uint u, int size)
		{
			int s = (int)u;
			s <<= 8*(4-size);
			s >>= 8*(4-size);
			return s;
		}

		//----------------------------------------------------
		//Savestate library
		//----------------------------------------------------
		public void savestate_saveslot(object lua_input)
		{
			int x = 0;

			try //adelikat:  This crap might not be necessary, need to test for a more elegant solution
			{
				x = int.Parse(lua_input.ToString());
			}
			catch
			{
				return;
			}

			if (x < 0 || x > 9)
				return;

			Global.MainForm.SaveState("QuickSave" + x.ToString()); 
		}

		public void savestate_loadslot(object lua_input)
		{
			int x = 0;

			try //adelikat:  This crap might not be necessary, need to test for a more elegant solution
			{
				x = int.Parse(lua_input.ToString());
			}
			catch
			{
				return;
			}

			if (x < 0 || x > 9)
				return;

			Global.MainForm.LoadState("QuickLoad" + x.ToString());
		}

		public void savestate_save(object lua_input)
		{
			if (lua_input.GetType() == typeof(string))
			{
				string path = lua_input.ToString();
				var writer = new StreamWriter(path);
				Global.MainForm.SaveStateFile(writer, path, true);
			}
		}

		public void savestate_load(object lua_input)
		{
			if (lua_input.GetType() == typeof(string))
			{
				Global.MainForm.LoadStateFile(lua_input.ToString(), Path.GetFileName(lua_input.ToString()));
			}
		}

		//----------------------------------------------------
		//Movie library
		//----------------------------------------------------
		public string movie_mode()
		{
			return Global.MovieSession.Movie.Mode.ToString();
		}

		public string movie_rerecordcount()
		{
			return Global.MovieSession.Movie.Rerecords.ToString();
		}
		
		public void movie_stop()
		{
			Global.MovieSession.Movie.StopMovie();
		}

		public bool movie_isloaded()
		{
			if (Global.MovieSession.Movie.Mode == MOVIEMODE.INACTIVE)
				return false;
			else
				return true;
		}

		public int movie_length()
		{
			return Global.MovieSession.Movie.Length();
		}

		public string movie_filename()
		{
			return Global.MovieSession.Movie.Filename;
		}

		public bool movie_getreadonly()
		{
			return Global.MainForm.ReadOnly;
		}

		public void movie_setreadonly(object lua_input)
		{
			int x = 0;
			x++;
			int y = x;

			if (lua_input.ToString().ToUpper() == "TRUE" || lua_input.ToString() == "1")
				Global.MainForm.SetReadOnly(true);
			else
				Global.MainForm.SetReadOnly(false);
		}

		//----------------------------------------------------
		//Joypad library
		//----------------------------------------------------

		//Currently sends all controllers, needs to control which ones it sends
		public LuaTable joypad_get()
		{
			LuaTable buttons = new LuaTable(1, lua);
			foreach (string button in Global.ControllerOutput.Source.Type.BoolButtons)
				buttons[button] = Global.ControllerOutput[button];
			
			//zero 23-mar-2012 - wtf is this??????
			buttons["clear"] = null;
			buttons["getluafunctionslist"] = null;
			buttons["output"] = null;
			
			return buttons;
		}

		public LuaTable joypad_getimmediate()
		{
			LuaTable buttons = new LuaTable(1, lua);
			foreach (string button in Global.ActiveController.Type.BoolButtons)
				buttons[button] = Global.ActiveController[button];
			return buttons;
		}

		public void joypad_set(object button, object value)
		{
			if (button.GetType() != typeof(string) || value.GetType() != typeof(bool))
			{
				MessageBox.Show(
					"Invalid parameter types " + button.GetType().ToString() + ", " + button.GetType().ToString() + "."
				);
				return;
			}
			Global.ClickyVirtualPadController.Click(button.ToString());
		}

		//----------------------------------------------------
		//Client library
		//----------------------------------------------------
		public void client_openrom(object lua_input)
		{
			Global.MainForm.LoadRom(lua_input.ToString());
		}

		public void client_closerom()
		{
			Global.MainForm.CloseROM();
		}

		public void client_opentoolbox()
		{
			Global.MainForm.LoadToolBox();
		}

		public void client_openramwatch()
		{
			Global.MainForm.LoadRamWatch();
		}

		public void client_openramsearch()
		{
			Global.MainForm.LoadRamSearch();
		}

		public void client_openrampoke()
		{
			Global.MainForm.LoadRamPoke();
		}

		public void client_openhexeditor()
		{
			Global.MainForm.LoadHexEditor();
		}

		public void client_opentasstudio()
		{
			Global.MainForm.LoadTAStudio();
		}

		public void client_opencheats()
		{
			Global.MainForm.LoadCheatsWindow();
		}
	}
}
