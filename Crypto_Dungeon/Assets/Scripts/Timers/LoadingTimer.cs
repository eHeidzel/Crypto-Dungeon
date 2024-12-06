using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class LoadingTimer : MonoBehaviour
{
    [SerializeField] public int Seconds { get; private set; }
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private Object[] _onLoadingEndArgs;

    public UnityEvent<Object[]> _onLoadingEnd;
    public bool IsTimerEnd { get => Seconds <= 0; }

    private IEnumerator Timer()
    {
        text.text = TimeConverter.SecondsToLongTimeFormat(Seconds);
        yield return new WaitForSeconds(1);
        Seconds--;

        if (Seconds >= 0)
            StartCoroutine(Timer());
        else
            _onLoadingEnd.Invoke(_onLoadingEndArgs);
    }

    public void SetSeconds(int seconds)
    {
        Seconds = seconds;
        StopAllCoroutines();
        StartCoroutine(Timer());
    }
}
