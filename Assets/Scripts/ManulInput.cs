using UnityEngine;

namespace MonkeyGame.Scripts
{
    public class ManulInput : MonoBehaviour
    {
        [SerializeField] private ThirdPersonCharacterController CharacterController;

        // Start is called before the first frame update
        void Awake()
        {
            CharacterController = GetComponent<ThirdPersonCharacterController>();
        }

        // Update is called once per frame
        void Update()
        {
            if (VirtualInputManager.Instance.Forward)   CharacterController.RunForward  = true;
            else                                        CharacterController.RunForward  = false;

            if (VirtualInputManager.Instance.Back)      CharacterController.RunBack     = true;
            else                                        CharacterController.RunBack     = false;

            if (VirtualInputManager.Instance.Right)     CharacterController.RunRight   = true;
            else                                        CharacterController.RunRight   = false;

            if (VirtualInputManager.Instance.Left)      CharacterController.RunLeft    = true;
            else                                        CharacterController.RunLeft    = false;

            if (VirtualInputManager.Instance.Jump)      CharacterController.Jump        = true;
            else                                        CharacterController.Jump        = false;

            if (VirtualInputManager.Instance.TurnLeft)  CharacterController.TurnLeft = true;
            else                                        CharacterController.TurnLeft = false;

            if (VirtualInputManager.Instance.TurnRight) CharacterController.TurnRight = true;
            else                                        CharacterController.TurnRight = false;
        }
    }
}