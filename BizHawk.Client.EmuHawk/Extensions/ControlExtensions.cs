﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

using BizHawk.Common;
using BizHawk.Common.ReflectionExtensions;


namespace BizHawk.Client.EmuHawk.WinFormExtensions
{
	public static class ControlExtensions
	{
		public static void PopulateFromEnum<T>(this ComboBox box, object enumVal)
			where T : struct, IConvertible
		{
			if (!typeof(T).IsEnum)
			{
				throw new ArgumentException("T must be an enumerated type");
			}

			box.Items.Clear();
			box.Items.AddRange(
				typeof(T).GetEnumDescriptions()
				.ToArray());
			box.SelectedItem = enumVal.GetDescription();
		}

		// extension method to make Control.Invoke easier to use
		public static void Invoke(this Control control, Action action)
		{
			control.Invoke(action);
		}

		public static void AddColumn(this ListView listView, string columnName, bool enabled, int columnWidth)
		{
			if (enabled)
			{
				if (listView.Columns[columnName] == null)
				{
					var column = new ColumnHeader
					{
						Name = columnName,
						Text = columnName.Replace("Column", string.Empty),
						Width = columnWidth,
					};

					listView.Columns.Add(column);
				}
			}
		}

		public static Point ChildPointToScreen(this Control control, Control child)
		{
			return control.PointToScreen(new Point(child.Location.X, child.Location.Y));
		}

		#region Enumerable to Enumerable<T>

		/// <summary>
		/// Converts the outdated IEnumerable Controls property to a IEnumerable<T> like .NET should have done a long time ago
		/// </summary>
		public static IEnumerable<Control> Controls(this Control control)
		{
			return control.Controls
				.OfType<Control>();
		}

		public static IEnumerable<TabPage> TabPages(this TabControl tabControl)
		{
			return tabControl.TabPages.Cast<TabPage>();
		}

		public static IEnumerable<int> SelectedIndices(this ListView listView)
		{
			return listView.SelectedIndices.Cast<int>();
		}

		#endregion
	}

	public static class FormExtensions
	{
		/// <summary>
		/// Handles EmuHawk specific issues before showing a modal dialog
		/// </summary>
        public static DialogResult ShowHawkDialog(this IHasShowDialog form)
		{
			GlobalWin.Sound.StopSound();
			var result = form.ShowDialog();
			GlobalWin.Sound.StartSound();
			return result;
		}

		/// <summary>
		/// Handles EmuHawk specific issues before showing a modal dialog
		/// </summary>
		public static DialogResult ShowHawkDialog(this CommonDialog form)
		{
			GlobalWin.Sound.StopSound();
			var result = form.ShowDialog();
			GlobalWin.Sound.StartSound();
			return result;
		}
	}

	public static class ListViewExtensions
	{
		[StructLayout(LayoutKind.Sequential)]
		public struct HDITEM
		{
			public Mask mask;
			public int cxy;
			[MarshalAs(UnmanagedType.LPTStr)]
			public string pszText;
			public IntPtr hbm;
			public int cchTextMax;
			public Format fmt;
			public IntPtr lParam;
			// _WIN32_IE >= 0x0300 
			public int iImage;
			public int iOrder;
			// _WIN32_IE >= 0x0500
			public uint type;
			public IntPtr pvFilter;
			// _WIN32_WINNT >= 0x0600
			public uint state;

			[Flags]
			public enum Mask
			{
				Format = 0x4,       // HDI_FORMAT
			};

			[Flags]
			public enum Format
			{
				SortDown = 0x200,   // HDF_SORTDOWN
				SortUp = 0x400,     // HDF_SORTUP
			};
		};

		public const int LVM_FIRST = 0x1000;
		public const int LVM_GETHEADER = LVM_FIRST + 31;

		public const int HDM_FIRST = 0x1200;
		public const int HDM_GETITEM = HDM_FIRST + 11;
		public const int HDM_SETITEM = HDM_FIRST + 12;

		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		static extern IntPtr SendMessage(IntPtr hWnd, UInt32 msg, IntPtr wParam, IntPtr lParam);

		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		static extern IntPtr SendMessage(IntPtr hWnd, UInt32 msg, IntPtr wParam, ref HDITEM lParam);

		/// <summary>
		/// Dumps the contents of the ListView into a tab separated list of lines
		/// </summary>
		public static string CopyItemsAsText(this ListView listViewControl)
		{
			var indexes = listViewControl.SelectedIndices;
			if (indexes.Count <= 0)
			{
				return String.Empty;
			}

			var sb = new StringBuilder();

			// walk over each selected item and subitem within it to generate a string from it
			foreach (int index in indexes)
			{
				foreach (ListViewItem.ListViewSubItem item in listViewControl.Items[index].SubItems)
				{
					if (!String.IsNullOrWhiteSpace(item.Text))
					{
						sb.Append(item.Text).Append('\t');
					}
				}

				// remove the last tab
				sb.Remove(sb.Length - 1, 1);

				sb.Append("\r\n");
			}

			// remove last newline
			sb.Length -= 2;


			return sb.ToString();
		}

		public static void SetSortIcon(this ListView listViewControl, int columnIndex, SortOrder order)
		{
			IntPtr columnHeader = SendMessage(listViewControl.Handle, LVM_GETHEADER, IntPtr.Zero, IntPtr.Zero);
			for (int columnNumber = 0; columnNumber <= listViewControl.Columns.Count - 1; columnNumber++)
			{
				var columnPtr = new IntPtr(columnNumber);
				var item = new HDITEM
				{
					mask = HDITEM.Mask.Format
				};

				if (SendMessage(columnHeader, HDM_GETITEM, columnPtr, ref item) == IntPtr.Zero)
				{
					throw new Win32Exception();
				}

				if (order != SortOrder.None && columnNumber == columnIndex)
				{
					switch (order)
					{
						case SortOrder.Ascending:
							item.fmt &= ~HDITEM.Format.SortDown;
							item.fmt |= HDITEM.Format.SortUp;
							break;
						case SortOrder.Descending:
							item.fmt &= ~HDITEM.Format.SortUp;
							item.fmt |= HDITEM.Format.SortDown;
							break;
					}
				}
				else
				{
					item.fmt &= ~HDITEM.Format.SortDown & ~HDITEM.Format.SortUp;
				}

				if (SendMessage(columnHeader, HDM_SETITEM, columnPtr, ref item) == IntPtr.Zero)
				{
					throw new Win32Exception();
				}
			}
		}
	}
}
