﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Net4.WinForms.Controls;

namespace OKHOSTING.UI.Net4.WinForms
{
	public class Activator : UI.Activator
	{
		public override IControl Create<T>()
		{
			if (typeof(T) == typeof(IButton))
			{
				return new Button();
			}

			if (typeof(T) == typeof(ILabel))
			{
				return new Label();
			}

			if (typeof(T) == typeof(ITextBox))
			{
				return new TextBox();
			}

			throw new NotSupportedException();
		}
	}
}