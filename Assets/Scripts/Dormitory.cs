using UnityEngine;
using System.Collections;

public class Dormitory : MonoBehaviour {

    public int /*sizeX, sizeZ,*/ floors, floorHeight;

	public IntVector2 size;

    public DormitoryCell cellPrefab;

    private DormitoryCell[,] cells;

    public DormitoryWall wallPrefab;

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
        cell.transform.localPosition = new Vector3(coords.x - size.x * 0.5f + 0.5f, (float)(i * floorHeight), coords.z - size.z * 0.5f + 0.5f);
		if (i < floors)
		{
			CreateWalls(coords, cell);
		}
	}

	private void CreateWalls(IntVector2 coords, DormitoryCell cell)
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
			CreateWall(cell, null, DormitoryDirection.SOUTH);
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
}
