using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class InputKeysReaderWithChecker : InputKeysReader
{
    [SerializeField] private string _checkSequence;
    [SerializeField] private bool _isNeedToCutSequence;
    [SerializeField] private float _checkOnSequenceDelayInMilliseconds;
    [SerializeField] private float _cutSequenceDelayInMilliseconds;
    [SerializeField] private Object[] _onSeqFoundArgs;
    public UnityEvent<Object[]> _onSeqFound;

    private new void Start()
    {
        _checkSequence = _checkSequence.ToLower();
        _onSeqFoundArgs[0] = _onSeqFoundArgs[0].GetComponent<Image>();
        base.Start();
        StartCoroutine(CheckOnSequence());

        if (_isNeedToCutSequence)
            StartCoroutine(CutSequence());
    }

    private IEnumerator CutSequence()
    {
        yield return new WaitForSeconds(_cutSequenceDelayInMilliseconds / 1000);

        if (_text.Length > _checkSequence.Length)
            _text.Remove(_checkSequence.Length, _text.Length - _checkSequence.Length);

        StartCoroutine(CutSequence());
    }

    private IEnumerator CheckOnSequence()
    {
        yield return new WaitForSeconds(_checkOnSequenceDelayInMilliseconds / 1000);

        if (_text.ToString().ToLower() == _checkSequence)
            _onSeqFound.Invoke(_onSeqFoundArgs);

        StartCoroutine(CheckOnSequence());
    }
}
