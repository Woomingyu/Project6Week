using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RangedAttackData", menuName = "TopDownController/Attacks/Ranged", order = 1)]
public class RangedAttackData : AttackSO
{

    //���Ÿ� ���� ��(�Ѿ� �±׸�, ��ġ ��)
    [Header("Ranged Attack Data")]
    public string bulletNameTag;
    public float duration;
    public float spread;
    public int numberofProjectilesPerShot;
    public float multipeProjectilesAngel;
    public Color projectileColor;
}
