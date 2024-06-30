using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Character", menuName = "ScriptableObjec/CharacterData")]
public class CharacterData : ScriptableObject
{
    public enum Characters { Chicken, Cat, Dog };

    [Header("# Main Info")]
    public Characters charcters;

    [Header("# Skills")]
    public Sprite skill_Icon;
    public GameObject characterSkill;
    
}
