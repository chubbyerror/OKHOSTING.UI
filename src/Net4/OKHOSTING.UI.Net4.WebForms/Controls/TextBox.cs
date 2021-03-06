﻿using System;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Net4.WebForms.Controls
{
	/// <summary>
	/// It represents a text box control.
	/// <para xml:lang="es">Representa un control de cuadro de texto.</para>
	/// </summary>
	public class TextBox : TextBoxBase, ITextBox
	{
		#region IInputControl

		/// <summary>
		/// Gets or sets the user imput value.
		/// <para xml:lang="es">Obtiene o establece el valor de entrada del usuario</para>
		/// </summary>
		/// <value>The input value.
		/// <para xml:lang="es">El valor de entrada.</para>
		/// </value>
		string IInputControl<string>.Value
		{
			get
			{
				return base.Text;
			}
			set
			{
				base.Text = value;
			}
		}

		/// <summary>
		/// On the text changed.
		/// <para xml:lang="es">Es el evento enviado al cambiar el texto.</para>
		/// </summary>
		/// <returns>The text changed.
		/// <para xml:lang="es">El texto cambiado.</para>
		/// </returns>
		protected override void OnTextChanged(EventArgs e)
		{
			base.OnTextChanged(e);
		}

		/// <summary>
		/// Occurs when value changed.
		/// <para xml:lang="es">Ocurre cuando el valor fue cambiado.</para>
		/// </summary>
		public event EventHandler<string> ValueChanged;

		/// <summary>
		/// Raises the value changed.
		/// <para xml:lang="es">Cambia el valor.</para>
		/// </summary>
		/// <returns>The value changed.
		/// <para xml:lang="es">El valor cambiado.</para>
		/// </returns>
		protected internal void RaiseValueChanged()
		{
			ValueChanged?.Invoke(this, ((IInputControl<string>)this).Value);
		}

		#endregion

		/// <summary>
		/// Gets or sets the type of the user input textbox.
		/// <para xml:lang="es">Obtiene o establece el tipo de entrada del usuario al textbox.</para>
		/// </summary>
		/// <value>The type of the user input.</value>
		ITextBoxInputType ITextBox.InputType
		{
			get
			{
				//if not InputType is provided, the InputType back to the text.
				if (base.Attributes["type"] == null)
				{
					return ITextBoxInputType.Text;
				}

				//InputTypes
				switch (base.Attributes["type"])
				{
					case "date":
						return ITextBoxInputType.Date;

					case "datetime":
						return ITextBoxInputType.DateTime;

					case "email":
						return ITextBoxInputType.Email;

					case "number":
						return ITextBoxInputType.Number;

					case "tel":
						return ITextBoxInputType.Telephone;

					case "text":
						return ITextBoxInputType.Text;

					case "time":
						return ITextBoxInputType.Time;

					case "url":
						return ITextBoxInputType.Url;

					default:
						return ITextBoxInputType.Text;
				}
			}
			set
			{
				switch (value)
				{
					case ITextBoxInputType.Date:
					case ITextBoxInputType.DateTime:
						base.Attributes["type"] = "date";
						break;

					case ITextBoxInputType.Email:
						base.Attributes["type"] = "email";
						break;

					case ITextBoxInputType.Number:
						base.Attributes["type"] = "number";
						break;

					case ITextBoxInputType.Telephone:
						base.Attributes["type"] = "tel";
						break;

					case ITextBoxInputType.Text:
						base.Attributes["type"] = "text";
						break;

					case ITextBoxInputType.Time:
						base.Attributes["type"] = "time";
						break;

					case ITextBoxInputType.Url:
						base.Attributes["type"] = "url";
						break;

					default:
						base.Attributes["type"] = "text";
						break;
				}
			}
		}

		/// <summary>
		/// The text that appears when the TextBox is empty (in a lighter color), use it as an alternative to a using a separate label to indicate this TextBox expected input
		/// </summary>
		string ITextBox.Placeholder
		{
			get
			{
				return InnerWatermarkExtender.WatermarkText;
			}
			set
			{
				InnerWatermarkExtender.WatermarkText = value;
			}
		}

		/// <summary>
		/// The font color of the Placeholder text
		/// </summary>
		Color ITextBox.PlaceholderColor
		{
			get;
			set;
		}

		/// <summary>
		/// The inner watermark extender.
		/// <para xml:lang="es">El texto con marca de agua del control.</para>
		/// </summary>
		protected readonly AjaxControlToolkit.TextBoxWatermarkExtender InnerWatermarkExtender;

		/// <summary>
		/// Ons the pre render.
		/// <para xml:lang="es">Ocurre antes de cambiar el valor</para>
		/// </summary>
		/// <returns>The pre render.</returns>
		/// <param name="e">E.</param>
		protected override void OnPreRender(EventArgs e)
		{
			AutoPostBack = ValueChanged != null;
			base.OnPreRender(e);
		}

		/// <summary>
		/// Initializes a new instance of the OKHOSTING.UI.Net4.WebForms.Controls.TextBox class.
		/// <para xml:alng="es">Inicializa una nueva instacia de la clase OKHOSTING.UI.Net4.WebForms.Controls.TextBox</para>
		/// </summary>
		public TextBox()
		{
			//set a default id so we ensure the extender's TargetControlID is set
			base.ID = "TextBox_InnerTextBox_" + Guid.NewGuid().ToString().Replace('-', '_');

			//ajax watermark
			InnerWatermarkExtender = new AjaxControlToolkit.TextBoxWatermarkExtender();
			InnerWatermarkExtender.ID = ID + "_TextBoxWatermarkExtender";
			InnerWatermarkExtender.TargetControlID = ID;
			//InnerWatermarkExtender.WatermarkCssClass = "AutoComplete_Watermark";
			//base.Controls.Add(InnerWatermarkExtender);
		}
	}
}