using Interfaces;
using UnityEngine;

namespace CharacterSystem
{
    public class CharacterInvoker
    {
        private Character _character;
        private IControllable _controllable;

        public CharacterInvoker(Character character)
        {
            _character = character;
            _controllable = new CharacterMovement();
        }

        public void Move(Vector2 moveDirection)
        {
            _controllable.Move(_character.Rb, _character.MovementSpeed, moveDirection);
        }
    }
}