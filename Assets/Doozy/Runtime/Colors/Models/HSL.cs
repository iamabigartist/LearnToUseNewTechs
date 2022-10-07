// Copyright (c) 2015 - 2022 Doozy Entertainment. All Rights Reserved.
// This code can only be used under the standard Unity Asset Store End User License Agreement
// A Copy of the EULA APPENDIX 1 is available at http://unity3d.com/company/legal/as_terms

using System;
using UnityEngine;

// ReSharper disable InconsistentNaming

namespace Doozy.Runtime.Colors.Models
{
	/// <summary>
	///     HSL stands for hue, saturation, and lightness (or luminosity).
	///     <para />
	///     In each cylinder, the angle around the central vertical axis corresponds to "hue", the distance from the axis corresponds to "saturation", and the distance along the axis corresponds to "lightness", "value" or "brightness".
	///     <para />
	///     Note that while "hue" in HSL and HSV refers to the same attribute, their definitions of "saturation" differ dramatically.
	/// </summary>
	[Serializable]
	public struct HSL
	{
		/// <summary> Construct a new HSL struct </summary>
		/// <param name="h"> Hue - h ∊ [0, 1] </param>
		/// <param name="s"> Saturation - s ∊ [0, 1] </param>
		/// <param name="l"> Lightness - l ∊ [0, 1] </param>
		public HSL(float h, float s, float l)
		{
			this.h = h;
			this.s = s;
			this.l = l;
		}

		/// <summary> Hue - h ∊ [0, 1] </summary>
		public float h;

		/// <summary> Saturation - s ∊ [0, 1] </summary>
		public float s;

		/// <summary> Lightness - l ∊ [0, 1] </summary>
		public float l;

		/// <summary> Get a copy of this HSL </summary>
		/// <returns> A new HSL </returns>
		public HSL Copy() =>
			new HSL(h, s, l);

		/// <summary> Convert this HSL to a Color with the given alpha value </summary>
		/// <param name="alpha"> Alpha value </param>
		/// <returns> A new Color </returns>
		public Color ToColor(float alpha = 1) =>
			ColorUtils.HSLtoRGB(this).Validate().ToColor();

		/// <summary> Convert this HSL to RGB </summary>
		/// <returns> A new RGB </returns>
		public RGB ToRGB() =>
			ColorUtils.HSLtoRGB(this);

		/// <summary> Validate HSL values </summary>
		/// <returns> Returns itself </returns>
		public HSL Validate()
		{
			h = ValidateColor(h, H.MIN, H.MAX);
			s = ValidateColor(s, S.MIN, S.MAX);
			l = ValidateColor(l, L.MIN, L.MAX);
			return this;
		}

		private float ValidateColor(float value, float min, float max) =>
			Mathf.Max(min, Mathf.Min(max, value));

		/// <summary> Get factorized values </summary>
		/// <returns> A new Vector3 with the factorized values of this HSL </returns>
		public Vector3 Factorize() =>
			new Vector3
			{
				x = FactorizeColor(h, H.MIN, H.MAX, H.F),
				y = FactorizeColor(s, S.MIN, S.MAX, S.F),
				z = FactorizeColor(l, L.MIN, L.MAX, L.F)
			};

		private int FactorizeColor(float value, float min, float max, float f) =>
			(int) Mathf.Max(min * f, Mathf.Min(max * f, Mathf.Round(value * f)));

		/// <summary> Convert HSL to string </summary>
		/// <param name="factorize"> If TRUE it uses factorized values </param>
		/// <returns> Pretty string </returns>
		public string ToString(bool factorize = false) =>
			factorize
				? $"hsl({Factorize().x}, {Factorize().y}%, {Factorize().z}%)"
				: $"hsl({h}, {s}%, {l}%)";

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

		/// <summary> Lightness </summary>
		public struct L
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