using UnityEngine;

namespace MonkeyGame.Scripts
{
    [CreateAssetMenu(fileName = "New State", menuName = "MonkeyGame/AbilityData/MoveForward")]
    public class MoveForward : StateData
    {
        [Range(1f, 10)] public float Speed;
        public AnimationCurve SpeedGraph;
        //public float BlockDistance;

        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            //animator.SetBool(TransitionParameter.RunBack.ToString(), false);
        }

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            ThirdPersonCharacterController characterController = characterState.GetThirdPersonCharacterController(animator);

            if (
                (characterController.RunForward && characterController.RunBack) == true ||
                (!characterController.RunForward && !characterController.RunBack) == true
                )
            {
                animator.SetBool(TransitionParameter.Run.ToString(), false);
                return;
            }

            // To jest to samo co an górze :P
            //if ((characterController.RunForward && characterController.RunBack) == true)
            //{
            //    animator.SetBool(TransitionParameter.Run.ToString(), false);
            //    return;
            //}

            if (characterController.RunForward)
            {
                //Debug.Log("stateInfo.normalizedTime: " + stateInfo.normalizedTime);
                //Debug.Log("SpeedGraph.Evaluate(stateInfo.normalizedTime): " + SpeedGraph.Evaluate(stateInfo.normalizedTime));
                characterController.transform.Translate(Vector3.forward * Speed * SpeedGraph.Evaluate(stateInfo.normalizedTime) * Time.deltaTime);
                animator.SetBool(TransitionParameter.Run.ToString(), true);
                characterController.RotateToDirectionCamera();
            }

            //if (characterController.RunForward && characterController.RunLeft)
            //{
            //    animator.SetBool(TransitionParameter.Run.ToString(), true);
            //    animator.SetBool(TransitionParameter.RunLeft.ToString(), true);
            //}

            // To jest dla z biegu na bieg to tyłu
            //if (characterController.RunBack)
            //{
            //    animator.SetBool(TransitionParameter.Run.ToString(), false);
            //    animator.SetBool(TransitionParameter.RunBack.ToString(), true);
            //}



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

        //bool CheckFront(ThirdPersonCharacterController characterController)
        //{
        //    foreach (GameObject obj in characterController.FrontSpheres)
        //    {
        //        RaycastHit hit;
        //        Debug.DrawRay(obj.transform.position, characterController.transform.forward * BlockDistance, Color.blue);
        //        if (Physics.Raycast(obj.transform.position, characterController.transform.forward, out hit, BlockDistance))
        //        {
        //            if (hit.transform.tag == "Player")
        //                return false;
        //            return true;
        //        }
        //    }
        //    return false;
        //}
    }
}