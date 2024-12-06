using Assets.Scripts.Cyphers;
using Assets.Scripts.Save;
using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

public class InputKeysReader : MonoBehaviour
{
    public string Text { get => _text.ToString(); }

    private readonly Array keyCodes = Enum.GetValues(typeof(KeyCode));

    [SerializeField] private bool _isNeedToClear;
    [SerializeField] private float _clearCheckDelayInMilliseconds;
    [SerializeField] private float _maxUpdateTimeBeforeClearInMilliseconds;

    protected Action _afterUpdate;
    protected string _text = "";
    private string _previousText;
    private Stopwatch _stopwatch = new Stopwatch();

    public void Restart()
    {
        StopAllCoroutines();
        ResetTimer();
        _text = "";

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
            _previousText = _text;

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
            _text = _text.Remove(_text.Length - 1, 1);
            ResetTimer();
            _afterUpdate?.Invoke();
            return;
        }
    }

    public void AddSym(char key)
    {
        ResetTimer();

        _text += key;

        _afterUpdate?.Invoke();
    }

    private char? GetAlphabetSymbolFromKeyCode(KeyCode keyCode)
    {
        bool isUpper = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
        Localization localization = GameSaves.Instance.Localization;
        char? letter = AlphabetManager.ConvertToLetter(keyCode, localization);

        if (letter == null)
            return null;

        return isUpper ?
               letter :
               char.ToLower((char)letter);
    }

    private IEnumerator ClearReadedTextIfNotUpdated()
    {
        yield return new WaitForSeconds(_clearCheckDelayInMilliseconds / 1000);

        if(_stopwatch.ElapsedMilliseconds >= _maxUpdateTimeBeforeClearInMilliseconds)
        {
            _text = "";
            _afterUpdate?.Invoke();
        }

        StartCoroutine(ClearReadedTextIfNotUpdated());
    }

    public void SetAfterUpdateEvent(Action action) => _afterUpdate = action;
}
