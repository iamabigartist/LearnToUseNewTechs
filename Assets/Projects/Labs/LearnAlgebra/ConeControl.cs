using System.Collections.Generic;
using UnityEngine;
namespace Labs.LearnAlgebra
{
	public class ConeControl : MonoBehaviour
	{
		public float rotate_degree;
		Transform cone0;
		Transform cone1;
		void Start()
		{
			cone0 = transform.GetChild(0);
			cone1 = transform.GetChild(1);
		}
		void Update()
		{
			cone0.rotation = Quaternion.Euler(0, rotate_degree, 0);
			cone1.rotation = Quaternion.Euler(180, -rotate_degree, 0);
		}
	}
}