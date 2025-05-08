using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class DungeonGeneration : MonoBehaviour
{
    [SerializeField] private Room[] allRooms;
    [SerializeField] private Room firstRoom;
    [SerializeField] private int maxRoomsCount;
    [SerializeField] private int dungeonWidth, dungeonHeight;

    private bool[][,] roomsGenerationMatrix;
    private int roomsCreated = 1;

    private List<Room> createdRooms = new List<Room>();

    void Start()
    {
        CreateRoomsSpawnMatrix();
        PlaceRooms(firstRoom);
        CloseLeadingNowhereDoors();
    }

    private void CloseLeadingNowhereDoors()
    {
        //throw new System.NotImplementedException();
    }

    private void CreateRoomsSpawnMatrix()
    {
        firstRoom.posInGenerationMatrix = new Vector3(dungeonWidth / 2, dungeonHeight / 2, dungeonWidth / 2);

        roomsGenerationMatrix = new bool[dungeonHeight][,];
        for (int i = 0; i < dungeonHeight; i++)
            roomsGenerationMatrix[i] = new bool[dungeonWidth, dungeonWidth];

        roomsGenerationMatrix[0][(int)firstRoom.posInGenerationMatrix.x, (int)firstRoom.posInGenerationMatrix.z] = true;
    }
    
    private void PlaceRooms(Room firstRoom)
    {
        List<Room> rooms = new List<Room>();
        rooms.Add(firstRoom);
        createdRooms.Add(firstRoom);

        while (rooms.Count > 0)
        {
            Room parentRoom = rooms.First();

            for(int j = 0; j < parentRoom.doors.Length; j++)
            {
                SpawnDirection? direction = ConvertAngleToDirection(parentRoom.doors[j].eulerAngles.y);

                if (direction == null)
                    continue;

                Vector3 newRoomPosInGenerationMatrix = parentRoom.posInGenerationMatrix + GetOffset((SpawnDirection)direction);
                if (IsInBounds(newRoomPosInGenerationMatrix))
                {
                    if (IsRoomCanBePlaced(newRoomPosInGenerationMatrix))
                    {
                        Room newRoom = CreateRoom(parentRoom, (SpawnDirection)direction, j);
                        rooms.Add(newRoom);
                        createdRooms.Add(newRoom);
                        roomsCreated++;

                        newRoom.posInGenerationMatrix = newRoomPosInGenerationMatrix; // решить проблему с установкой нужных зн и проверку их

                        roomsGenerationMatrix[(int)newRoomPosInGenerationMatrix.y]
                            [(int)newRoomPosInGenerationMatrix.z, (int)newRoomPosInGenerationMatrix.x] = true;

                        if (roomsCreated >= maxRoomsCount)
                            return;
                    }
                }
            }

            rooms.Remove(parentRoom);
        }
    }

    private Room CreateRoom(Room parentRoom, SpawnDirection direction, int j)
    {
        Room newRoom = Instantiate(allRooms[Random.Range(0, allRooms.Length)]);
        Transform connectDoor = newRoom.GetRandomDoor();

        connectDoor.localRotation *= Quaternion.Euler(0, GetOpposite(parentRoom.doors[j].eulerAngles.y), 0);
        newRoom.gameObject.transform.rotation *= Quaternion.Euler(0, GetOpposite(parentRoom.doors[j].eulerAngles.y), 0);

        print($"{parentRoom.GetOffset(direction) / 2} {newRoom.GetOffset(direction)}");

        newRoom.transform.position = 
            parentRoom.transform.position + 
            parentRoom.GetOffset(direction) * 0.5f + 
            newRoom.GetOffset(direction);

        createdRooms.Add(newRoom);

        return newRoom;
    }

    private bool IsRoomCanBePlaced(Vector3 posInGenerationMatrix)
    {
        bool isBusy = roomsGenerationMatrix[(int)posInGenerationMatrix.y]
            [(int)posInGenerationMatrix.z, (int)posInGenerationMatrix.x];
        
        return !isBusy;
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

    private bool IsInBounds(Vector3 nextPos)
    {
        if (nextPos.x >= dungeonWidth || nextPos.x < 0) return false;
        if (nextPos.z >= dungeonWidth || nextPos.z < 0) return false;

        return true;
    }

    private float GetOpposite(float angle)
    {
        switch (angle)
        {
            case 0:
                return -180;
            case -180:
            case 180:
                return 0;
            case -90:
            case 90:
                return -270;
            case -270:
            case 270:
                return -90;
            default:
                throw new System.ArgumentException();
        }
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

    private float ConvertDirectionToAngle(SpawnDirection direction)
    {
        switch (direction)
        {
            case SpawnDirection.Forward:
                return 0;
            case SpawnDirection.Left:
                return -90;
            case SpawnDirection.Back:
                return -180;
            case SpawnDirection.Right:
                return -270;
            default:
                throw new System.ArgumentException();
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