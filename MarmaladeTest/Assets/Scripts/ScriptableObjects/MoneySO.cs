using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Money Data", menuName = "Marmalade/ScriptableObjects/MoneyData")]
public class MoneySO : ScriptableObject
{
    public int MoneyAmount;
    public Mesh MoneyMesh;
    public string MoneyString;
}
