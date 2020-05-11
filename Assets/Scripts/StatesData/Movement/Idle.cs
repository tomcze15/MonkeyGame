using UnityEngine;

namespace MonkeyGame.Scripts
{
    [CreateAssetMenu(fileName = "New State", menuName = "MonkeyGame/AbilityData/Idle")]
    public class Idle : StateData
    {
        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
        }

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            ThirdPersonCharacterController characterController = characterState.GetThirdPersonCharacterController(animator);

            if ((characterController.RunLeft && characterController.RunRight) == true)
            {
                animator.SetBool(TransitionParameter.RunLeft.ToString(), false);
                animator.SetBool(TransitionParameter.RunRight.ToString(), false);
                return;
            }

            if ((characterController.RunForward && characterController.RunBack) == true)
            {
                animator.SetBool(TransitionParameter.RunBack.ToString(), false);
                animator.SetBool(TransitionParameter.Run.ToString(), false);
                return;
            }

            if (characterController.RunForward)
            {
                animator.SetBool(TransitionParameter.Run.ToString(), true);
            }

            if (characterController.RunBack)
            {
                animator.SetBool(TransitionParameter.RunBack.ToString(), true);
            }

            if (characterController.RunLeft)
            {
                animator.SetBool(TransitionParameter.RunLeft.ToString(), true);
            }

            if (characterController.RunRight)
            {
                animator.SetBool(TransitionParameter.RunRight.ToString(), true);
            }

            if (characterController.TurnLeft)
            {
                animator.SetBool(TransitionParameter.TurnLeft.ToString(), true);
            }

            if (characterController.TurnRight)
            {
                animator.SetBool(TransitionParameter.TurnRight.ToString(), true);
            }

            if (characterController.Jump)
            {
                animator.SetBool(TransitionParameter.Jump.ToString(), true);
            }
        }

        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            
        }
    }
}