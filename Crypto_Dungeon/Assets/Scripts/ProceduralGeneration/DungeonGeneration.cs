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

    [SerializeField] Transform root;

    private bool[][,] roomsGenerationMatrix;

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
        firstRoom.posInGenerationMatrix = new Vector3((dungeonWidth - 1) / 2, (dungeonHeight - 1) / 2, (dungeonWidth - 1) / 2);

        roomsGenerationMatrix = new bool[dungeonHeight][,];
        for (int i = 0; i < dungeonHeight; i++)
            roomsGenerationMatrix[i] = new bool[dungeonWidth, dungeonWidth];

        roomsGenerationMatrix[(int)firstRoom.posInGenerationMatrix.y]
            [(int)firstRoom.posInGenerationMatrix.x,
            (int)firstRoom.posInGenerationMatrix.z] = true;
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
                Door randomDoor = parentRoom.GetRandomLeadingNowhereDoor();

                if (randomDoor == null)
                    continue;

                randomDoor.IsLeading = true;
                Direction direction = randomDoor.Direction;
                FloorLevel floorLevel = randomDoor.FloorLevel;

                Vector3 newRoomPosInGenerationMatrix = parentRoom.posInGenerationMatrix + GetOffset(direction, floorLevel);

                if (IsInBounds(newRoomPosInGenerationMatrix))
                {
                    if (IsRoomCanBePlaced(newRoomPosInGenerationMatrix))
                    {
                        Room newRoom = CreateRoom(parentRoom, direction, floorLevel);
                        RotateToFrontOf(direction, newRoom);

                        rooms.Add(newRoom);
                        createdRooms.Add(newRoom);

                        newRoom.posInGenerationMatrix = newRoomPosInGenerationMatrix;

                        roomsGenerationMatrix[(int)newRoomPosInGenerationMatrix.y]
                            [(int)newRoomPosInGenerationMatrix.z, (int)newRoomPosInGenerationMatrix.x] = true;

                        if (newRoom.gameObject.name.Contains("Two"))
                            if ((int)newRoomPosInGenerationMatrix.y + 1 < dungeonHeight)
                                roomsGenerationMatrix[(int)newRoomPosInGenerationMatrix.y + 1]
                                [(int)newRoomPosInGenerationMatrix.z, (int)newRoomPosInGenerationMatrix.x] = true;

                        if (createdRooms.Count >= maxRoomsCount)
                            return;
                    }
                }
            }

            rooms.Remove(parentRoom);
        }
    }

    private Room CreateRoom(Room parentRoom, Direction direction, FloorLevel floorLevel)
    {
        Room newRoom = Instantiate(allRooms[Random.Range(0, allRooms.Length)], root);

        newRoom.transform.position = 
            parentRoom.transform.position + 
            parentRoom.GetOffset(direction, floorLevel, root.localScale.x, true) + 
            newRoom.GetOffset(direction, floorLevel, root.localScale.x);

        return newRoom;
    }

    private bool IsRoomCanBePlaced(Vector3 posInGenerationMatrix)
    {
        bool isBusy = roomsGenerationMatrix[(int)posInGenerationMatrix.y]
            [(int)posInGenerationMatrix.z, (int)posInGenerationMatrix.x];
        
        return !isBusy;
    }

    private Vector3 GetOffset(Direction spawnDirection, FloorLevel floorLevel)
    {
        int xOffset, zOffset, yOffset;

        xOffset = spawnDirection == Direction.Left ? -1 :
            spawnDirection == Direction.Right ? 1 : 0; ;

        zOffset = spawnDirection == Direction.Back ? -1 :
            spawnDirection == Direction.Forward ? 1 : 0;

        yOffset = floorLevel == FloorLevel.Upper ? 1 : 
            floorLevel == FloorLevel.Lower ? -1 : 0;

        return new Vector3(xOffset, yOffset, zOffset);
    }

    private bool IsInBounds(Vector3 nextPos)
    {
        if (nextPos.x >= dungeonWidth || nextPos.x < 0) return false;
        if (nextPos.z >= dungeonWidth || nextPos.z < 0) return false;
        if (nextPos.y >= dungeonHeight || nextPos.y < 0) return false;

        return true;
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

    public void RotateToFrontOf(Direction direction, Room newRoom)
    {
        Door leadingDoor = newRoom.GetRandomLeadingNowhereDoor();
        leadingDoor.IsLeading = true;

        Direction doorInDirection = GetOpposite(leadingDoor.Direction);

        int dODegreses = ConvertDirectionToDegreses(direction);
        int dIDegreses = ConvertDirectionToDegreses(doorInDirection);

        int desiredRotation = (dODegreses - dIDegreses + 360) % 360;
        int rotateCount = desiredRotation / 90;

        for (int i = 0; i < rotateCount; i++)
            Rotate90Degreses(newRoom);
    }

    private void Rotate90Degreses(Room room)
    {
        room.transform.Rotate(0, 90, 0);
        foreach (Door door in room.doors)
            door.Direction = GetNext(door.Direction);
    }
}