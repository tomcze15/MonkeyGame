using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MonkeyGame.Scripts
{
    [CreateAssetMenu(fileName = "New State", menuName = "MonkeyGame/AbilityData/MoveLeft")]
    public class MoveLeft : StateData
    {
        [Range(1f, 10)] public float Speed;
        public AnimationCurve SpeedGraph;

        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
        }

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            ThirdPersonCharacterController characterController = characterState.GetThirdPersonCharacterController(animator);

            if (
                (characterController.RunLeft && characterController.RunRight) == true ||
                (!characterController.RunLeft && !characterController.RunRight) == true
                )
            {
                animator.SetBool(TransitionParameter.RunLeft.ToString(), false);
                return;
            }

            if (characterController.RunLeft)
            {
                characterController.transform.Translate(-Vector3.right * Speed * SpeedGraph.Evaluate(stateInfo.normalizedTime) * Time.deltaTime);
                animator.SetBool(TransitionParameter.RunLeft.ToString(), true);
            }
            else 
            {
                animator.SetBool(TransitionParameter.RunLeft.ToString(), false);
            }
        }

        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            animator.SetBool(TransitionParameter.RunLeft.ToString(), false);
        }
    }
}