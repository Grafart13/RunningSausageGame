using UnityEngine;
using System.Collections;

[System.Serializable]
public struct IntVector2 {

	public int x, z;

	public IntVector2(int x, int z)
	{
		this.x = x;
		this.z = z;
	}

	public static IntVector2 operator + (IntVector2 a, IntVector2 b)
	{
		IntVector2 newVector = new IntVector2(a.x, a.z);
		newVector.x += b.x;
		newVector.z += b.z;
		return newVector;
	}
}
