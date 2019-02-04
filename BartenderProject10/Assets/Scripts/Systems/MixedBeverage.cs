using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Mixed Beverage", menuName = "Make new Beverage")]
public class MixedBeverage : ScriptableObject
{
    public string m_BeverageName;
    public Sprite m_BeverageIcon;
    public List<Beverage> m_Beverages;
    public List<AddOn> m_AddOn;
    [TextArea]
    public string m_Information;
}
