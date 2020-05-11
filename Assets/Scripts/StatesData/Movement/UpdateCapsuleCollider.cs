using UnityEngine;

namespace MonkeyGame.Scripts
{
    [CreateAssetMenu(fileName = "New State", menuName = "MonkeyGame/AbilityData/UpdateCapsuleCollider")]
    public class UpdateCapsuleCollider : StateData
    {
        public float TargetHeight;
        public float SizeUpdateSpeed;

        public Vector3 TargetCenter;
        public float CenterUpdateSpeed;

        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            ThirdPersonCharacterController characterController = characterState.GetThirdPersonCharacterController(animator);
            characterController.UpdatingCapsuleCollider = true;
            characterController.TargetHeight = TargetHeight;
            characterController.Size_Speed = SizeUpdateSpeed;

            characterController.TargetCenter = TargetCenter;
            characterController.Center_Speed = CenterUpdateSpeed;
        }

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {        
        }

        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

        }
    }
}