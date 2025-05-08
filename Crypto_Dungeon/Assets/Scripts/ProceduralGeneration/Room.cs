using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField] public Transform[] doors;
    [SerializeField] public Transform begin;

    public Vector3 Pos
    {
        get => transform.position;
        set => transform.position = value;
    }

}
