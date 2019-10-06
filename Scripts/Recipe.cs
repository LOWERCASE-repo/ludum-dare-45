using UnityEngine;

[CreateAssetMenu]
internal class Recipe : ScriptableObject {
  
  public Item[] inputs;
  public Item result;
}