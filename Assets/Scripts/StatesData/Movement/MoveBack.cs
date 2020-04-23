using UnityEngine;

namespace MonkeyGame.Scripts
{
    [CreateAssetMenu(fileName = "New State", menuName = "MonkeyGame/AbilityData/MoveBack")]
    public class MoveBack : StateData
    {
        [Range(1, 10)] public float Speed;
        public AnimationCurve SpeedGraph;

        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            //animator.SetBool(TransitionParameter.Run.ToString(), false);
        }

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            ThirdPersonCharacterController characterController = characterState.GetThirdPersonCharacterController(animator);

            if (
                (characterController.RunForward && characterController.RunBack) == true ||
                (!characterController.RunForward && !characterController.RunBack) == true
                )
            {
                animator.SetBool(TransitionParameter.RunBack.ToString(), false);
                return;
            }

            if ((characterController.RunForward && characterController.RunBack) == true)
            {
                animator.SetBool(TransitionParameter.RunBack.ToString(), false);
                return;
            }

            //To jest dla z biegu do tyłu na bieg
            //if (characterController.RunForward)
            //{
            //    animator.SetBool(TransitionParameter.Run.ToString(), true);
            //    animator.SetBool(TransitionParameter.RunBack.ToString(), false);
            //}

            if (characterController.RunForward)
            {
                animator.SetBool(TransitionParameter.RunBack.ToString(), false);
            }

            if (characterController.RunBack)
            {
                characterController.transform.Translate(-Vector3.forward * Speed * SpeedGraph.Evaluate(stateInfo.normalizedTime) * Time.deltaTime);
                animator.SetBool(TransitionParameter.RunBack.ToString(), true);
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