using System;
using System.Collections;
using System.Diagnostics;
using System.Text;
using UnityEngine;

public class InputKeysReader : MonoBehaviour
{
    private readonly Array keyCodes = Enum.GetValues(typeof(KeyCode));

    [SerializeField] private bool _isNeedToClear;
    [SerializeField] private float _clearCheckDelayInMilliseconds;
    [SerializeField] private float _maxUpdateTimeBeforeClearInMilliseconds;

    private Stopwatch _stopwatch = new Stopwatch();
    protected StringBuilder _text = new StringBuilder();

    protected void Start()
    {
        ResetTimer();

        if (_isNeedToClear)
            StartCoroutine(ClearReadedTextIfNotUpdated());
    }

    void Update()
    {
        ProcessCurrentPressedKeys();
    }

    private void ProcessCurrentPressedKeys()
    {
        if (Input.anyKeyDown)
        {
            foreach (KeyCode keyCode in keyCodes)
            {
                if (Input.GetKeyDown(keyCode))
                {
                    if (keyCode == KeyCode.Backspace)
                        RemoveLastSym();
                    var key = GetAlphabetSymbolFromKeyCode(keyCode);

                    if (key != null)
                        AddSym((char)key);
                }
            }
        }
    }

    private void ResetTimer()
    {
        _stopwatch.Reset();
        _stopwatch.Start();
    }

    public void RemoveLastSym()
    {
        if (_text.Length > 0)
        {
            _text.Remove(_text.Length - 1, 1);
            ResetTimer();
            print(_text);
            return;
        }
    }

    public void AddSym(char key)
    {
        ResetTimer();

        _text.Append(key);
        print(_text);
    }

    private char? GetAlphabetSymbolFromKeyCode(KeyCode keyCode)
    {
        if (keyCode >= KeyCode.A && keyCode <= KeyCode.Z)
        {
            return Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift) ?
                   keyCode.ToString()[0] :
                   char.ToLower(keyCode.ToString()[0]);
        }
        else
            return null;
    }

    private IEnumerator ClearReadedTextIfNotUpdated()
    {
        yield return new WaitForSeconds(_clearCheckDelayInMilliseconds / 1000);


        if(_stopwatch.ElapsedMilliseconds >= _maxUpdateTimeBeforeClearInMilliseconds)
            _text.Clear();

        StartCoroutine(ClearReadedTextIfNotUpdated());
    }
}
