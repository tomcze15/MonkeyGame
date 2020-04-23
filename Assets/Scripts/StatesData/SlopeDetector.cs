using UnityEngine;

namespace MonkeyGame.Scripts
{
    [CreateAssetMenu(fileName = "New State", menuName = "MonkeyGame/AbilityData/SlopeDetector")]
    public class SlopeDetector : StateData
    {
        float   height = 5f;
        Vector3 forward;

        ThirdPersonCharacterController person;

        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            person = characterState.GetThirdPersonCharacterController(animator);
        }

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            RaycastHit hitInfo;
            Physics.Raycast(person.transform.position, -Vector3.up, out hitInfo, 3);
            forward = Vector3.Cross(person.transform.right, hitInfo.normal);
            Debug.DrawLine(person.transform.position, person.transform.position + forward * height, Color.red);
        }

        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
        }

    }
}