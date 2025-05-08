using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class DungeonGeneration : MonoBehaviour
{
    [SerializeField] private Room[] allRooms;
    [SerializeField] private Room firstRoom;
    [SerializeField] private int roomsCount;
    [SerializeField] private int dungeonWidth, dungeonHeight;

    private bool[][,] roomsSpawnMatrix;

    private List<Room> roomList = new List<Room>();
    private List<Vector2> roomPoss = new List<Vector2>();

    void Start()
    {
        CreateRoomsSpawnMatrix();
        roomList.Add(firstRoom);
        PlaceRooms();
    }

    private void CreateRoomsSpawnMatrix()
    {
        firstRoom.Pos = new Vector3(dungeonWidth / 2, dungeonHeight / 2);

        roomsSpawnMatrix = new bool[dungeonHeight][,];
        for (int i = 0; i < dungeonHeight; i++)
            roomsSpawnMatrix[i] = new bool[dungeonWidth, dungeonWidth];
    }
    
    private void PlaceRooms()
    {
        for (int i = 0; i < roomsCount; i++)
        {
            Room previousRoom = roomList[i];
            for(int j = 0; j < previousRoom.doors.Length; j++)
            {
                //if (IsInBounds())
                    CreateRoom(previousRoom, j);
            } 
        }
    }

    private void CreateRoom(Room previousRoom, int j)
    {
        SpawnDirection? spawnDirection = ConvertAngleToDirection(previousRoom.doors[j].rotation.y);

        if (spawnDirection == null)
            return;

        Room newRoom = Instantiate(allRooms[Random.Range(0, allRooms.Length)]);
        newRoom.transform.rotation = previousRoom.doors[j].rotation;
        newRoom.transform.position = previousRoom.doors[j].transform.position - newRoom.begin.position;

        roomList.Add(newRoom);
    }

    private bool IsRoomCanBePlaced(Vector3 roomPos, SpawnDirection spawnDirection)
    {


        //if (roomsSpawnMatrix[0][(int)room.Pos.x + xOffset, (int)room.Pos.z + zOffset])
        //    return false;

        //room.Pos += new Vector3(xOffset, 0, zOffset);

        return true;
    }

    private Vector3 GetOffset(SpawnDirection spawnDirection)
    {
        int xOffset, zOffset;

        xOffset = spawnDirection == SpawnDirection.Left ? -1 :
            spawnDirection == SpawnDirection.Right ? 1 : 0; ;

        zOffset = spawnDirection == SpawnDirection.Back ? -1 :
            spawnDirection == SpawnDirection.Forward ? 1 : 0;

        return new Vector3(xOffset, 0, zOffset);
    }

    private bool IsInBounds(Vector3 roomPos, Vector3 offset)
    {
        if (roomPos.x + offset.x >= dungeonWidth || roomPos.x + offset.x < 0) return false;
        if (roomPos.z + offset.z >= dungeonHeight || roomPos.z + offset.z < 0) return false;

        return true;
    }

    private SpawnDirection? ConvertAngleToDirection(float angle)
    {
        switch (angle)
        {
            case 0: 
                return SpawnDirection.Forward;
            case -90:
            case 90:
                return SpawnDirection.Left;
            case -180:
            case 180:
                return SpawnDirection.Back;
            case -270:
            case 270:
                return SpawnDirection.Right;
            default:
                return null;
        }
    }
}

enum SpawnDirection
{
    Left,
    Right,
    Forward,
    Back,
}