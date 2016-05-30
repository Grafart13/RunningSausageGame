using UnityEngine;
using System.Collections;

public class Dormitory : MonoBehaviour {

    public int /*sizeX, sizeZ,*/ floors, floorHeight;

	public IntVector2 size;

    public DormitoryCell cellPrefab;

    public Chair chairPrefab;

    public Chair[] chairs;

    private DormitoryCell[,] cells;

    public DormitoryWall wallPrefab;

	public DormitoryExternalDoor extDoorPrefab;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public DormitoryCell GetCell(IntVector2 coords)
	{
		return cells[coords.x, coords.z];
	}

    public void Generate()
    {
	    System.Random rnd = new System.Random();
        //chairs = new Chair[10];
		for(int i =0; i<10; i++){
	        Chair chair = Instantiate(chairPrefab) as Chair;
	        //chairs[i] = chair;
	        chair.transform.parent = transform;
	        chair.transform.localScale += new Vector3(1, 1, 1);
	        chair.transform.localPosition = new Vector3(rnd.Next(-size.x,size.x), 0, rnd.Next(-size.z,size.z));
	        chair.transform.Rotate(new Vector3(0, 0, 1), rnd.Next(360));
	    }

        cells = new DormitoryCell[size.x, size.z];
        for (int i = 0; i < floors; i++)
        {
            CreateFloor(i);
        }
        CreateFloor(floors); //sufit
    }

    private void CreateFloor(int i)
    {
        for (int x = 0; x < size.x; x++)
        {
            for (int z = 0; z < size.z; z++)
            {
                CreateCell(new IntVector2(x,z), i);
            }
        }
    }

    private void CreateCell(IntVector2 coords, int i)
    {

        DormitoryCell cell = Instantiate(cellPrefab) as DormitoryCell;
        cells[coords.x, coords.z] = cell;
        cell.name = "Dorm cell " + coords.x + ", " + coords.z + "; floor " + i;
        cell.transform.parent = transform;
        cell.transform.localPosition = new Vector3(coords.x * 2f - size.x * 1f + 1f, (float)(i * floorHeight), coords.z * 2f - size.z * 1f + 1f);
		if (i < floors)
		{
			CreateWalls(coords, cell, i);
		}
	}

	private void CreateWalls(IntVector2 coords, DormitoryCell cell, int floor)
	{
		if (coords.x == 0)
		{
			CreateWall(cell, null, DormitoryDirection.WEST);
		}
		if (coords.x == size.x - 1)
		{
			CreateWall(cell, null, DormitoryDirection.EAST);
		}
		if (coords.z == 0)
		{
			if (floor == 0)
			{
				if (coords.x == size.x / 2 - 1)
				{
					CreateExternalDoor(cell, null, DormitoryDirection.SOUTH, true);
				}
				else if (coords.x == size.x / 2)
				{
					CreateExternalDoor(cell, null, DormitoryDirection.SOUTH, false);
				}
				else
				{
					CreateWall(cell, null, DormitoryDirection.SOUTH);
				}
			}
			else
			{
				CreateWall(cell, null, DormitoryDirection.SOUTH);
			}
		}
		if (coords.z == size.z - 1)
		{
			CreateWall(cell, null, DormitoryDirection.NORTH);
		}
	}

	public void CreateWall(DormitoryCell cellA, DormitoryCell cellB, DormitoryDirection direction)
	{
		DormitoryWall wall = Instantiate(wallPrefab) as DormitoryWall;
		wall.Initialize(cellA, cellB, direction);
		if(cellB != null)
		{
			wall = Instantiate(wallPrefab) as DormitoryWall;
			wall.Initialize(cellB, cellA, direction.GetOpposite());
		}
	}

	public void CreateExternalDoor(DormitoryCell cellA, DormitoryCell cellB, DormitoryDirection direction, bool mirrored)
	{
		DormitoryExternalDoor door = Instantiate(extDoorPrefab) as DormitoryExternalDoor;
		door.Initialize(cellA, cellB, direction);
		if (cellB != null)
		{
			door = Instantiate(extDoorPrefab) as DormitoryExternalDoor;
			door.Initialize(cellB, cellA, direction.GetOpposite());
		}
		if (mirrored)
		{
			door.transform.localPosition = new Vector3(0f, 0f, -1f);
			door.transform.localRotation = direction.GetOpposite().ToRotation();
		}
	}
}
