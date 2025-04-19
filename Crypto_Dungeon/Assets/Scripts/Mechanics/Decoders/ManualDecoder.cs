using UnityEngine;

namespace Assets.Scripts.Mechanics.Decoders
{
    public class ManualDecoder : Decoder
    {
        [SerializeField] private GameObject _decodeScreen;
        [SerializeField] private InputKeysReaderWithChecker _reader;

        public override bool IsFree { get => Paper == null; }
        public override bool IsPaperPickable { get => Paper != null; }

        public override Item GetPaper()
        {
            _decodeScreen.SetActive(false);

            if (_reader.GetComponent<InputKeysReaderWithChecker>().IsSeqFound)
                Paper.ChangeStateToDecoded();

            return base.GetPaper();
        }

        public override void Decode(Paper paper)
        {
            base.Decode(paper);
            _decodeScreen.SetActive(true);
            _decodeScreen.GetComponent<DecodeScreen>().SetCipher(Paper.Cipher);
        }
    }
}
