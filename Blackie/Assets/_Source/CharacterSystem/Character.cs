using UnityEngine;

namespace CharacterSystem
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Character : MonoBehaviour
    {
        [field: SerializeField] public float MovementSpeed { get; private set; }
        [field: SerializeField] public Rigidbody2D Rb { get; private set; }
        [field: SerializeField] AudioSource _walkingSound;

        private void Update()
        {
            if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0.35f)
            {
                if (_walkingSound.isPlaying) return;
                _walkingSound.Play();
            }
            else
            {
                _walkingSound.Stop();
            }
        }


    }

}