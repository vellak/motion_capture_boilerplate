using Assignment_Scripts.enums;
using UnityEngine;

namespace Assignment_Scripts
{
    public class CreateTarget : MonoBehaviour
    {
        [SerializeField] private Characters character;

        [SerializeField] private LogicManager manager;

        [SerializeField] private CompareBodyPositions comparer;
        
        [SerializeField] private GameObject targetObj;

        private bool _isCreated;

        private GameObject _createdGameObject;
        private bool _isTargetObjNotNull;


        // Start is called before the first frame update
        private void Start()
        {
            // checks for null once
            _isTargetObjNotNull = targetObj != null;
        }

        // Update is called once per frame
        private void Update()
        {
            if (character.Equals(manager.characterToSerialize) || comparer.systemChoice.Equals(Systems.System4))
            {
                // run it once only if the object isn't created but check for updates every frame
                if (!_isCreated)
                {
                    if (!_isTargetObjNotNull) return;
                    var transform1 = transform;
                    _createdGameObject =Instantiate(targetObj, transform1.position + new Vector3(0, 0, -13), transform1.rotation );
                    _isCreated = true;
                }
            }
            else
            {
                // if the selected member isnt equal to what is defined here
                // then destroy the game object and set the created bool to false
                if (_isCreated)
                {
                    _isCreated = false;
                    Destroy(_createdGameObject);
                }
            }
        }
    }
}
