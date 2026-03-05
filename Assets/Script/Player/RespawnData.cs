using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

[CreateAssetMenu(fileName = "RespawnData", menuName = "Scriptable Objects/PlayerPosititon")]
public class RespawnData : ScriptableObject
{
    public Vector2 respawnPosition;


}
