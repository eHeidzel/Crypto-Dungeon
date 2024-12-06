using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class InputKeysReaderWithChecker : InputKeysReader
{
    [SerializeField] private bool _isNeedToCutSequence;
    [SerializeField] private float _checkOnSequenceDelayInMilliseconds;
    [SerializeField] private float _cutSequenceDelayInMilliseconds;
    [SerializeField] private Object[] _onSeqFoundArgs;
    private string _checkSequence = null;
    public UnityEvent<Object[]> _onSeqFound;
    public bool IsSeqFound { get; private set; }

    public void SetCheckSequence(string seq)
    {
        base.Restart();
        _checkSequence = seq;
        _checkSequence = _checkSequence.ToLower();
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
        {
            IsSeqFound = true;
            _onSeqFound?.Invoke(_onSeqFoundArgs);
            StopAllCoroutines();
            yield break;
        }

        StartCoroutine(CheckOnSequence());
    }
}
