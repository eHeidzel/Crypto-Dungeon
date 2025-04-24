using UnityEngine;

public class SunRotationController : MonoBehaviour
{
    public GameObject sun; // Объект солнца
    [SerializeField] public float cycleDuration; // Длительность цикла в секундах
    [SerializeField] private float yRotationOffset; // Смещение вращения по Y
    [SerializeField] private float zRotationOffset; // Смещение вращения по Z

    private Timer timer;

    private void Start()
    {
        timer = FindAnyObjectByType<Timer>();
    }
    void Update()
    {

        float cycleProgress = (timer.CurrentTime / cycleDuration)*360f;
        float sunAngle = cycleProgress;

        Quaternion rotation = Quaternion.Euler(
            sunAngle - 90f, 
            yRotationOffset,
            zRotationOffset 
        );

        sun.transform.rotation = rotation;
    }
}
