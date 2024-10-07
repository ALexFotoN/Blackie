using UnityEngine;

namespace CharacterSystem
{
    public class CharacterCamera : MonoBehaviour
    {
        [SerializeField] Transform _character;
        double position;

        // Update is called once per frame
        void Update()
        {
            position = _character.position.x;
            if (_character.position.x <= 9.38768 && _character.position.x >= -8.501907)
            {
                transform.position = new Vector3(_character.position.x, 0.03f, -10f);
            }
        }
    }

}
