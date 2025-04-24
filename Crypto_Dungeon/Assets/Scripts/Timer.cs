using TMPro;
using UnityEditor.ShaderGraph.Drawing;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class Timer : MonoBehaviour
{
    [SerializeField] public float CurrentTime;
    [SerializeField] private TextMeshProUGUI TMP;
    private SunRotationController SunRotationController;

    private void Start()
    {
        SunRotationController = FindAnyObjectByType<SunRotationController>();
    }
    void FixedUpdate()
    {
        CurrentTime += Time.deltaTime;
        TMP.text = string.Format("{0:00}:{1:00}", Mathf.FloorToInt(CurrentTime / 60), Mathf.FloorToInt(CurrentTime % 60));
        if (CurrentTime > SunRotationController.cycleDuration-0.3) 
            CurrentTime = 0;
        
    }
}
