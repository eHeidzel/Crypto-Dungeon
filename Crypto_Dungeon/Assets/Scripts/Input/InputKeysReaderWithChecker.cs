using System.Collections;
using UnityEngine;
using UnityEngine.Events;

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
        base.Start();
        StartCoroutine(CheckOnSequence());

        if (_isNeedToCutSequence)
            StartCoroutine(CutSequence());
    }

    private IEnumerator CutSequence()
    {
        yield return new WaitForSeconds(_cutSequenceDelayInMilliseconds / 1000);

        if (_text.Length > _checkSequence.Length)
        {
            _text = _text.Substring(0, _checkSequence.Length);
            _afterUpdate?.Invoke();
        }

        StartCoroutine(CutSequence());
    }

    private IEnumerator CheckOnSequence()
    {
        yield return new WaitForSeconds(_checkOnSequenceDelayInMilliseconds / 1000);

        if (_text.ToLower() == _checkSequence)
            _onSeqFound?.Invoke(_onSeqFoundArgs);

        StartCoroutine(CheckOnSequence());
    }

    public void SetCheckSeq(string text) => _checkSequence = text;
}
