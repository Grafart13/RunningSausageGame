using UnityEngine;
using System.Collections;

public enum DormitoryDirection {

	NORTH,
    EAST,
	SOUTH,
	WEST
}

public static class DormitoryDirections
{

	public const int Count = 4;

	private static IntVector2[] vectors =
	{
		new IntVector2(0,1),
		new IntVector2(1,0),
		new IntVector2(0,-1),
		new IntVector2(-1,0)
	};

	private static DormitoryDirection[] opposites =
	{
		DormitoryDirection.SOUTH,
		DormitoryDirection.WEST,
		DormitoryDirection.NORTH,
		DormitoryDirection.EAST
	};

	private static Quaternion[] rotations =
	{
		Quaternion.identity,
		Quaternion.Euler(0f, 90f, 0f),
		Quaternion.Euler(0f, 180f, 0f),
		Quaternion.Euler(0f, 270f, 0f)
	};

	public static IntVector2 ToIntVector2(this DormitoryDirection direction)
	{
		return vectors[(int)direction];
	}

	public static DormitoryDirection GetOpposite(this DormitoryDirection direction)
	{
		return opposites[(int)direction];
	}

	public static Quaternion ToRotation(this DormitoryDirection direction)
	{
		return rotations[(int)direction];
	}
}
