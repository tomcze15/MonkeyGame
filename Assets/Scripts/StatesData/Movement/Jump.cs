using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MonkeyGame.Scripts
{
    [CreateAssetMenu(fileName = "New State", menuName = "MonkeyGame/AbilityData/Jump")]
    public class Jump : StateData
    {
        public float JumpForce;
        public AnimationCurve Gravity;

        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            animator.SetBool(TransitionParameter.Grounded.ToString(), false);
            ThirdPersonCharacterController characterController = characterState.GetThirdPersonCharacterController(animator);
            characterController.Rigidbody.AddForce(Vector3.up * JumpForce);
        }

        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
        }

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            ThirdPersonCharacterController characterController = characterState.GetThirdPersonCharacterController(animator);
            //characterController.GravityMultiplier = Gravity.Evaluate(stateInfo.normalizedTime);
        }
    }
}