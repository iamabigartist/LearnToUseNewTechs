// Copyright (c) 2015 - 2022 Doozy Entertainment. All Rights Reserved.
// This code can only be used under the standard Unity Asset Store End User License Agreement
// A Copy of the EULA APPENDIX 1 is available at http://unity3d.com/company/legal/as_terms

using System;
using UnityEngine;

// ReSharper disable InconsistentNaming

namespace Doozy.Runtime.Colors.Models
{
	/// <summary>
	/// HSV stands for hue, saturation, and value, and is also often called HSB (B for brightness).
	/// <para/> In each cylinder, the angle around the central vertical axis corresponds to "hue", the distance from the axis corresponds to "saturation", and the distance along the axis corresponds to "lightness", "value" or "brightness".
	/// <para/> Note that while "hue" in HSL and HSV refers to the same attribute, their definitions of "saturation" differ dramatically.
	/// </summary>
	[Serializable]
	public struct HSV
	{
		/// <summary> Construct a new HSV struct </summary>
		/// <param name="h"> Hue - h ∊ [0, 1] </param>
		/// <param name="s"> Saturation - s ∊ [0, 1] </param>
		/// <param name="v"> Value - l ∊ [0, 1] </param>
		public HSV(float h, float s, float v)
		{
			this.h = h;
			this.s = s;
			this.v = v;
		}

		/// <summary> Hue - h ∊ [0, 1] </summary>
		public float h;

		/// <summary> Saturation - s ∊ [0, 1] </summary>
		public float s;

		/// <summary> Value - l ∊ [0, 1] </summary>
		public float v;

		/// <summary> Get a copy of this HSV </summary>
		/// <returns> A new HSV </returns>
		public HSV Copy() =>
			new HSV(h, s, v);

		/// <summary> Convert this HSV to a Color with the given alpha value </summary>
		/// <param name="alpha"> Alpha value </param>
		/// <returns> A new Color </returns>
		public Color ToColor(float alpha = 1) =>
			ColorUtils.HSVtoRGB(this).Validate().ToColor();

		/// <summary> Convert this HSV to RGB </summary>
		/// <returns> A new RGB </returns>
		public RGB ToRGB() =>
			ColorUtils.HSVtoRGB(this);

		/// <summary> Validate HSV values </summary>
		/// /// <returns> Returns itself </returns>
		public HSV Validate()
		{
			h = ValidateColor(h, H.MIN, H.MAX);
			s = ValidateColor(s, S.MIN, S.MAX);
			v = ValidateColor(v, V.MIN, V.MAX);
			return this;
		}

		private float ValidateColor(float value, float min, float max) =>
			Mathf.Max(min, Mathf.Min(max, value));

		/// <summary> Get factorized values </summary>
		/// <returns> A new Vector3 with the factorized values of this HSV </returns>
		public Vector3 Factorize() =>
			new Vector3
			{
				x = FactorizeColor(h, H.MIN, H.MAX, H.F),
				y = FactorizeColor(s, S.MIN, S.MAX, S.F),
				z = FactorizeColor(v, V.MIN, V.MAX, V.F)
			};

		private int FactorizeColor(float value, float min, float max, float f) =>
			(int) Mathf.Max(min * f, Mathf.Min(max * f, Mathf.Round(value * f)));

		/// <summary> Convert HSV to string </summary>
		/// <param name="factorize"> If TRUE it uses factorized values </param>
		/// <returns> Pretty string </returns>
		public string ToString(bool factorize = false) =>
			factorize
				? $"hsv({Factorize().x}, {Factorize().y}%, {Factorize().z}%)"
				: $"hsv({h}, {s}%, {v}%)";

		/// <summary> Hue </summary>
		public struct H
		{
			/// <summary> Minimum value </summary>
			public const float MIN = 0;
			/// <summary> Maximum value </summary>
			public const float MAX = 1;
			/// <summary> Factorize value </summary>
			public const int F = 360;
		}

		/// <summary> Saturation </summary>
		public struct S
		{
			/// <summary> Minimum value </summary>
			public const float MIN = 0;
			/// <summary> Maximum value </summary>
			public const float MAX = 1;
			/// <summary> Factorize value </summary>
			public const int F = 100;
		}

		/// <summary> Value </summary>
		public struct V
		{
			/// <summary> Minimum value </summary>
			public const float MIN = 0;
			/// <summary> Maximum value </summary>
			public const float MAX = 1;
			/// <summary> Factorize value </summary>
			public const int F = 100;
		}
	}
}