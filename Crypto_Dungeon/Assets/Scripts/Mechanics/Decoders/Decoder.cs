using UnityEngine;

namespace Assets.Scripts.Mechanics.Decoders
{
    public class Decoder : MonoBehaviour
    {
        public Paper Paper { get; protected set; }
        public GameObject PaperObj;
        public bool IsFree { get; }
        public bool IsPaperPickable { get; }

        public Items GetAndClearPaper()
        {
            Paper.ChangeStateToDecoded();
            Paper = null;

            return PaperObj.GetComponent<Items>();
        }

        public void Decode(Paper paper)
        {
            Paper = paper;
        }
    }
}
