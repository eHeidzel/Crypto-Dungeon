using UnityEngine;

namespace Assets.Scripts.Mechanics.Decoders
{
    public class MiniGameDecoder : Decoder
    {
        [SerializeField] private GameObject _decodeScreen;
        [SerializeField] private InputKeysReaderWithChecker _reader;

        public new bool IsFree { get => Paper == null; }
        public new bool IsPaperPickable { get => Paper != null; }

        public new Items GetAndClearPaper()
        {
            _decodeScreen.SetActive(false);

            if (_reader.GetComponent<InputKeysReaderWithChecker>().IsSeqFound)
                Paper.ChangeStateToDecoded();

            //FindAnyObjectByType<Movement>().enabled = true;
            return base.GetAndClearPaper();
        }

        public new void Decode(Paper paper)
        {
            base.Decode(paper);
            //FindAnyObjectByType<Movement>().enabled = false;
            _decodeScreen.SetActive(true);
            _decodeScreen.GetComponent<DecodeScreen>().SetCipher(Paper.Cipher);
        }
    }
}
