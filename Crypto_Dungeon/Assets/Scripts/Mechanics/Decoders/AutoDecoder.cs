using Assets.Scripts.Mechanics.Decoders;
using UnityEngine;

public class AutoDecoder : Decoder
{
    private int _defaultTime = 5;
    [SerializeField] private GameObject _loadingScreen;
    [SerializeField] private LoadingTimer timer;

    public override bool IsFree { get => timer.IsTimerEnd && Paper == null; }
	public override bool IsPaperPickable { get => timer.IsTimerEnd && Paper != null; }

    public override Item GetPaper()
    {
        _loadingScreen.SetActive(false);
        return base.GetPaper();        
    }

    public override void Decode(Paper paper)
    {
        base.Decode(paper);

        _loadingScreen.SetActive(true);
        timer.SetSeconds(_defaultTime);
    }
}
