using UnityEngine;

namespace CharacterSystem
{
    public class CharacterCamera : MonoBehaviour
    {
        [SerializeField] Transform _character;
        [SerializeField] double _right;
        [SerializeField] double _left;
        double position;

        // Update is called once per frame
        void Update()
        {
            position = _character.position.x;
            if (_character.position.x <= _right && _character.position.x >= _left)
            {
                transform.position = new Vector3(_character.position.x, 0.03f, -10f);
            }
        }
    }

}
