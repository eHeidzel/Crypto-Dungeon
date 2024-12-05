using Assets.Scripts.Mechanics.Decoders;
using UnityEngine;

public class AutoDecoder : Decoder
{
    private int _defaultTime = 5;
    [SerializeField] private GameObject _loadingScreen;
    [SerializeField] private LoadingTimer timer;

    public bool IsFree { get => timer.IsTimerEnd && Paper == null; }
    public bool IsDecoded { get => timer.IsTimerEnd && Paper != null; }


    public new Items GetAndClearPaper()
    {
        _loadingScreen.SetActive(false);
        return base.GetAndClearPaper();        
    }

    public new void Decode(Paper paper)
    {
        base.Decode(paper);

        _loadingScreen.SetActive(true);
        timer.SetSeconds(_defaultTime);
    }
}
