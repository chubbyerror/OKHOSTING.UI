﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Net4.WPF.Controls
{
	public class Label : System.Windows.Controls.Label, UI.Controls.ILabel
	{
		public IPage Page
		{
			get
			{
				return (Page)System.Windows.Window.GetWindow(this);
			}
		}

		public string Text
		{
			get
			{
				return (string) base.Content;
			}

			set
			{
				base.Content = value;
			}
		}

		public bool Visible
		{
			get
			{
				return base.Visibility == System.Windows.Visibility.Visible;
			}
			set
			{
				if (value)
				{
					base.Visibility = System.Windows.Visibility.Visible;
				}
				else
				{
					base.Visibility = System.Windows.Visibility.Collapsed;
				}
			}
		}
	}
}