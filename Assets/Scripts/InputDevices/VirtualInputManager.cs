using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MonkeyGame.Scripts
{
    public class VirtualInputManager : Singleton<VirtualInputManager>
    {
        public bool Forward;
        public bool Right;
        public bool Left;
        public bool Back;
        public bool Jump;
        public bool TurnLeft;
        public bool TurnRight;
    }
}