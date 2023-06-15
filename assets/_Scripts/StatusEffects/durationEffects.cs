using System.Collections;
using System.Collections.Generic;
using UnityEngine;




[CreateAssetMenu(fileName = "BurnEffectSettings", menuName = "Effects/New Fire Effect")]
public class BurnEffectSettings : ScriptableObject
{
    public float damagePerTick;
    public float duration;

}



[CreateAssetMenu(fileName = "IceEffectSettings", menuName = "Effects/New Ice Effect")]
public class IceEffectSettings : ScriptableObject
{
    public float movementAmount;
    public float duration;

}

[CreateAssetMenu(fileName = "BurnEffectSettings", menuName = "Effects/New Heal Effect/Heal Over Time")]
public class HealEffectSettings : ScriptableObject
{
    public float healOverTime;
    public float duration;

}
