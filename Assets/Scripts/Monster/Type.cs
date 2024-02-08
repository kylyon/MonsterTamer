using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "NewType", menuName = "Type", order = 1)]
public class Type : ScriptableObject
{
    public string name;
    public Type[] weakness;
    public Type[] effectiveness;
    public Color color;

    public virtual string GetNameType()
    {
        return "NullType";
    }

    public virtual Type[] GetWeaknesses()
    {
        return weakness;
    }

    public virtual int multiplierEffectiveness(Type attackType)
    {
        return weakness.Contains(attackType) ? 2 : 1;
    }
}
