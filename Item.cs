using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu]
internal class Item : ScriptableObject {
  
  public Sprite icon;
  public HashSet<Item> test;
  public string discoveryText;
}
