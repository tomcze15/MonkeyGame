using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MonkeyGame.Scripts
{
    [CreateAssetMenu(fileName = "New State", menuName = "MonkeyGame/AbilityData/GroundDetector")]
    public class GroundDetector : StateData
    {
        [Range(0.01f, 1f)] public float CheckTime;
        public float Distance;

        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
        }

        bool IsGrounded(ThirdPersonCharacterController characterController)
        {
            foreach (GameObject obj in characterController.BottomSpheres)
            {
                Debug.DrawRay(obj.transform.position, -Vector3.up * Distance, Color.blue);
                RaycastHit hit;

                if (Physics.Raycast(obj.transform.position, -Vector3.up, out hit, Distance))
                {
                    if (hit.transform.tag == "Player")
                        return false;
                    return true;
                }
            }
            return false;
        }

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            ThirdPersonCharacterController characterController = characterState.GetThirdPersonCharacterController(animator);
            
            if (stateInfo.normalizedTime >= CheckTime)
            {
                if (IsGrounded(characterController))
                    animator.SetBool(TransitionParameter.Grounded.ToString(), true);
                else
                    animator.SetBool(TransitionParameter.Grounded.ToString(), false);
            }

        }

        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
        }

    }
}