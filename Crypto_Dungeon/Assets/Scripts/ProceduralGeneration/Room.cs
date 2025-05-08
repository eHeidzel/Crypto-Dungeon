using System;
using Assets.Scripts.ProceduralGeneration;
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

    public Door GetRandomDoor() => doors[Random.Range(0, doors.Length)];

    internal Vector3 GetOffset(Direction direction)
    {
        Vector3 upperRightCorner = upperCorner.localPosition;

        float roomWidthX = Mathf.Abs(upperRightCorner.x) + GenerateConstants.WALL_WIDTH;
        float roomWidthZ = Mathf.Abs(upperRightCorner.z) + GenerateConstants.WALL_WIDTH;

        switch (direction)
        {
            case Direction.Left: return new Vector3(-roomWidthX, 0, 0);
            case Direction.Right: return new Vector3(roomWidthX, 0, 0);
            case Direction.Forward: return new Vector3(0, 0, roomWidthZ);
            case Direction.Back: return new Vector3(0, 0, -roomWidthZ);
            default: throw new System.ArgumentException();
        }
    }
}
