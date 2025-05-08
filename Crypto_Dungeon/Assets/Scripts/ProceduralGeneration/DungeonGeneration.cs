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
                Direction direction = parentRoom.doors[j].Direction;

                Vector3 newRoomPosInGenerationMatrix = parentRoom.posInGenerationMatrix + GetOffset(direction);
                if (IsInBounds(newRoomPosInGenerationMatrix))
                {
                    if (IsRoomCanBePlaced(newRoomPosInGenerationMatrix))
                    {
                        Room newRoom = CreateRoom(parentRoom, direction, j);
                        rooms.Add(newRoom);
                        createdRooms.Add(newRoom);
                        roomsCreated++;

                        newRoom.posInGenerationMatrix = newRoomPosInGenerationMatrix;

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

    private Room CreateRoom(Room parentRoom, Direction direction, int j)
    {
        Room newRoom = Instantiate(allRooms[Random.Range(0, allRooms.Length)]);
        Door connectDoor = newRoom.GetRandomDoor();

        //connectDoor.localRotation *= Quaternion.Euler(0, GetOpposite(parentRoom.doors[j].eulerAngles.y), 0);
        //newRoom.gameObject.transform.rotation *= Quaternion.Euler(0, GetOpposite(parentRoom.doors[j].eulerAngles.y), 0);

        print($"{parentRoom.GetOffset(direction) / 2} {newRoom.GetOffset(direction)}");

        newRoom.transform.position = 
            parentRoom.transform.position + 
            parentRoom.GetOffset(direction) + 
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

    private Vector3 GetOffset(Direction spawnDirection)
    {
        int xOffset, zOffset;

        xOffset = spawnDirection == Direction.Left ? -1 :
            spawnDirection == Direction.Right ? 1 : 0; ;

        zOffset = spawnDirection == Direction.Back ? -1 :
            spawnDirection == Direction.Forward ? 1 : 0;

        return new Vector3(xOffset, 0, zOffset);
    }

    private bool IsInBounds(Vector3 nextPos)
    {
        if (nextPos.x >= dungeonWidth || nextPos.x < 0) return false;
        if (nextPos.z >= dungeonWidth || nextPos.z < 0) return false;

        return true;
    }

    private Direction GetOpposite(Direction direction)
    {
        switch (direction)
        {
            case Direction.Left:
                return Direction.Right;
            case Direction.Right:
                return Direction.Left;
            case Direction.Forward:
                return Direction.Back;
            case Direction.Back:
                return Direction.Forward;
            default:
                throw new System.ArgumentException();
        }
    }

    private Direction GetNext(Direction direction)
    {
        switch (direction)
        {
            case Direction.Left:
                return Direction.Forward;
            case Direction.Forward:
                return Direction.Right;
            case Direction.Right:
                return Direction.Back;
            case Direction.Back:
                return Direction.Left;
            default:
                throw new System.ArgumentException();
        }
    }

    private int ConvertDirectionToDegreses(Direction direction)
    {
        switch (direction)
        {
            case Direction.Forward:
                return 0;
            case Direction.Right:
                return 90;
            case Direction.Back:
                return 180;
            case Direction.Left:
                return 270;
            default:
                throw new System.ArgumentException();
        }
    }

    public void RotateToFrontOf(Direction doorOut, Direction doorIn, Room newRoom)
    {
        int dODegreses = ConvertDirectionToDegreses(doorOut);
        int dIDegreses = ConvertDirectionToDegreses(doorIn);

        int rotateCount = Mathf.Abs(dODegreses - dIDegreses) / 90;

        for (int i = 0; i < rotateCount; i++)
            Rotate90Degreses(newRoom);
    }

    private void Rotate90Degreses(Room room)
    {
        //room.transform.rotation.
    }
}