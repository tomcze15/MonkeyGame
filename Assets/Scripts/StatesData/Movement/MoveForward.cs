using UnityEngine;

namespace MonkeyGame.Scripts
{
    [CreateAssetMenu(fileName = "New State", menuName = "MonkeyGame/AbilityData/MoveForward")]
    public class MoveForward : StateData
    {
        float height = 5f;
        [Range(1f, 10)] public float Speed;
        public AnimationCurve SpeedGraph;

        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
        }

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            ThirdPersonCharacterController characterController = characterState.GetThirdPersonCharacterController(animator);
            
            RaycastHit hitInfo;
            Physics.Raycast(characterController.transform.position, -Vector3.up, out hitInfo, 3);
            Vector3 forward = Vector3.Cross(characterController.transform.right, hitInfo.normal);
            Debug.DrawLine(characterController.transform.position, characterController.transform.position + forward * height, Color.red);
            characterController.Forward.y = forward.y;

            if (
                (characterController.RunForward && characterController.RunBack) == true ||
                (!characterController.RunForward && !characterController.RunBack) == true
                )
            {
                animator.SetBool(TransitionParameter.Run.ToString(), false);
                return;
            }

            // To jest to samo co an górze :P
            if ((characterController.RunForward && characterController.RunBack) == true)
            {
                animator.SetBool(TransitionParameter.Run.ToString(), false);
                return;
            }

            if (characterController.RunForward)
            {
                characterController.transform.Translate(characterController.Forward * Speed * SpeedGraph.Evaluate(stateInfo.normalizedTime) * Time.deltaTime);
                animator.SetBool(TransitionParameter.Run.ToString(), true);
                characterController.RotateToDirectionCamera();
            }

            //if (characterController.RunForward && characterController.RunLeft)
            //{
            //    animator.SetBool(TransitionParameter.Run.ToString(), true);
            //    animator.SetBool(TransitionParameter.RunLeft.ToString(), true);
            //}

            // To jest dla z biegu na bieg to tyłu
            if (characterController.RunBack)
            {
                animator.SetBool(TransitionParameter.Run.ToString(), false);
                animator.SetBool(TransitionParameter.RunBack.ToString(), true);
            }

            if (characterController.RunBack)
            {
                animator.SetBool(TransitionParameter.Run.ToString(), false);
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