﻿using UnityEngine;

namespace MonkeyGame
{
    public enum TypeCollect : sbyte
    {
        Basic = 1,
        Black = 3,
        Gold = 10
    }

    public class Collectible : MonoBehaviour
    {
        [SerializeField] private TypeCollect type = TypeCollect.Basic;

        public delegate void PickUpEvent(TypeCollect type);
        public event PickUpEvent PickUp;

        private void OnTriggerEnter(Collider collision)
        {
            PickUp(type);
            gameObject.SetActive(false); //Destroy(this.gameObject);
        }

        public TypeCollect GetType() => type;
    }
}
