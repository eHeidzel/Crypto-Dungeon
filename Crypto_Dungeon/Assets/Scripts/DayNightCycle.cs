using UnityEngine;

public class SunRotationController : MonoBehaviour
{
    public GameObject sun; // ������ ������
    [SerializeField] public float cycleDuration; // ������������ ����� � ��������
    [SerializeField] private float yRotationOffset; // �������� �������� �� Y
    [SerializeField] private float zRotationOffset; // �������� �������� �� Z

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
