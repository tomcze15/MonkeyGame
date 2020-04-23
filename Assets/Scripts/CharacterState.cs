using System.Collections.Generic;
using UnityEngine;

namespace MonkeyGame.Scripts
{
    public class CharacterState : StateMachineBehaviour
    {
        public List<StateData> ListAbilityData = new List<StateData>();
        [SerializeField] private ThirdPersonCharacterController CharacterController;
        public void UpdateAll(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            foreach (StateData stateData in ListAbilityData)
                stateData.UpdateAbility(characterState, animator, stateInfo);
        }

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            foreach (StateData stateData in ListAbilityData)
                stateData.OnEnter(this, animator, stateInfo);
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            UpdateAll(this, animator, stateInfo);
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            foreach (StateData stateData in ListAbilityData)
                stateData.OnExit(this, animator, stateInfo);
        }

        public ThirdPersonCharacterController GetThirdPersonCharacterController(Animator animator) 
        {
            if (CharacterController == null)
                CharacterController = animator.GetComponentInParent<ThirdPersonCharacterController>();
            return CharacterController;
        }
    }
}