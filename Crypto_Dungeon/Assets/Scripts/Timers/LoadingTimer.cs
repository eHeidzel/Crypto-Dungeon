using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class LoadingTimer : MonoBehaviour
{
    [SerializeField] private int _seconds;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private Object[] _onLoadingEndArgs;
    public UnityEvent<Object[]> _onLoadingEnd;

    private void Start()
    {
        StartCoroutine(Timer());
    }

    private IEnumerator Timer()
    {
        text.text = TimeConverter.SecondsToLongTimeFormat(_seconds);

        yield return new WaitForSeconds(1);
        _seconds--;

        if (_seconds > 0)
            StartCoroutine(Timer());
        else
            _onLoadingEnd.Invoke(_onLoadingEndArgs);
    }

    public void SetSeconds(int seconds)
    {
        _seconds = seconds;
    }
}
