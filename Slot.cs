using UnityEngine;
using UnityEngine.UI;

internal class Slot : MonoBehaviour {
  
  [SerializeField]
  private Crafter crafter;
  
  public void OnClick() {
    crafter.RemoveInput(gameObject.name[gameObject.name.Length - 1] - 49);
  }
}
