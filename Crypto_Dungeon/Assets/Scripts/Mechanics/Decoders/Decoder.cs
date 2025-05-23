﻿using UnityEngine;

namespace Assets.Scripts.Mechanics.Decoders
{
    public class Decoder : MonoBehaviour
    {
		[SerializeField] protected GameObject _successScreen;

		public Paper Paper { get; protected set; }
        public GameObject PaperObj;
        public virtual bool IsFree { get; }
        public virtual bool IsPaperPickable { get; }

        public virtual Item GetPaper()
        {
            Paper = null;
			_successScreen.SetActive(false);

			return PaperObj.GetComponent<Item>();
        }

        public virtual void Decode(Paper paper)
        {
            Paper = paper;
        }
    }
}
