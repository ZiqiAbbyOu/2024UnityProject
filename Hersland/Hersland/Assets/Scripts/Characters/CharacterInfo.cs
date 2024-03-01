using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HL.Characters.Roles;
using static HL.Characters.Roles.RoleManager;

namespace HL.Characters
{
    public class CharacterInfo : MonoBehaviour
    {
        public RoleType characterRole = RoleType.Default;
        public RoleType characterDreamRole = RoleType.Default;
        public Vector3Int characterPosition = new Vector3Int(0, 0, 0);
        public WuXing wuXing;
        public string familyNameKey;
        public string givenNameKey;

        public void Awake()
        {
            DontDestroyOnLoad(gameObject);
            wuXing = gameObject.AddComponent<WuXing>();
        }

        public void SetCharacterRole(RoleType roleType)
        {
            this.characterRole = roleType;
        }

        public void SetCharacterDreamRole(RoleType roleType)
        {
            this.characterDreamRole = roleType;
        }

        public Vector3Int GetCharacterPosition()
        {
            return characterPosition;
        }

        public void SetInitialPosition(Vector3Int initialPosition)
        {
            characterPosition = initialPosition;
        }

        public void SetCharacterPosition()
        {
            gameObject.transform.SetPositionAndRotation(characterPosition, Quaternion.identity);
        }

    }
}