using UnityEngine;

namespace MonkeyGame.Scripts
{
    [CreateAssetMenu(fileName = "New State", menuName = "MonkeyGame/AbilityData/TurnLeft")]
    public class TurnLeft : StateData
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
                (characterController.TurnLeft && characterController.TurnRight) == true ||
                (!characterController.TurnLeft && !characterController.TurnRight) == true
                )
            {
                animator.SetBool(TransitionParameter.TurnLeft.ToString(), false);
                return;
            }

            if (characterController.TurnLeft)
            {    
                characterController.transform.Rotate(0, -Speed, 0);
                animator.SetBool(TransitionParameter.TurnLeft.ToString(), true);
            }
            else
            {
                animator.SetBool(TransitionParameter.TurnLeft.ToString(), false);
            }
        }

        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
        }
    }
}