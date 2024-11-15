using System.Collections;
using UnityEngine;

public class InputKeysReaderWithChecker : InputKeysReader
{
    [SerializeField] private string _checkSequence;
    [SerializeField] private bool _isNeedToCutSequence;
    [SerializeField] private float _checkOnSequenceDelayInMilliseconds;
    [SerializeField] private float _cutSequenceDelayInMilliseconds;

    private new void Start()
    {
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

        if (_text.ToString() == _checkSequence)
            print("Да, нужная последовательность");

        StartCoroutine(CheckOnSequence());
    }
}
