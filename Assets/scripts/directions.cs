using UnityEngine;
using System;
namespace Utils
{
	public enum Directions{
		NONE,LEFT,RIGHT,UP,DOWN
	}

	public class Utilits{
		public static T GetRandomEnum<T>(int from)
		{
			System.Array A = System.Enum.GetValues(typeof(T));
			T V = (T)A.GetValue(UnityEngine.Random.Range(from,A.Length));
			return V;
		}
	}
}