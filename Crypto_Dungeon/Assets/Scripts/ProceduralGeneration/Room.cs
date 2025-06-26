using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class Room : MonoBehaviour
{
    [SerializeField] public Door[] doors;
    [SerializeField] public Transform upperCorner;

    [HideInInspector]
    public Vector3 posInGenerationMatrix;

    public Vector3 Pos
    {
        get => transform.position;
        set => transform.position = value;
    }

    public Door GetRandomLeadingNowhereDoor() 
    {
        var leadingNowhereDoors = doors.Where(door => !door.IsLeading).ToList();

        if (leadingNowhereDoors.Count == 0)
            return null;

        return leadingNowhereDoors[Random.Range(0, leadingNowhereDoors.Count)];
    }

    internal Vector3 GetOffset(Direction direction, FloorLevel floorLevel, float scaleFactor, bool needY=false)
    {
        Vector3 upperRightCorner = upperCorner.localPosition;

        float roomWidthX = Mathf.Abs(upperRightCorner.x);
        float roomWidthZ = Mathf.Abs(upperRightCorner.z);
        float roomHeight = Mathf.Abs(upperRightCorner.y);

        Vector3 offset;

        switch (direction)
        {
            case Direction.Left: 
                offset = new Vector3(-roomWidthX, 0, 0);
                break;
            case Direction.Right:
                offset = new Vector3(roomWidthX, 0, 0);
                break;
            case Direction.Forward:
                offset = new Vector3(0, 0, roomWidthZ);
                break;
            case Direction.Back:
                offset = new Vector3(0, 0, -roomWidthZ);
                break;
            default: throw new System.ArgumentException();
        }

        offset *= scaleFactor;

        if (needY)
        {
            int heightDirection = floorLevel == FloorLevel.Upper ? 1 : floorLevel == FloorLevel.Lower ? -1 : 0;
            offset += new Vector3(0, roomHeight * heightDirection, 0) * 1.5f;
        }

        return offset;
    }
}
