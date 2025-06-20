using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] public Direction Direction;
    public FloorLevel FloorLevel = FloorLevel.Same;
    public bool IsLeading;
}
