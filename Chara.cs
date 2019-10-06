using UnityEngine;
using UnityEngine.UI;
using TMPro;

internal class Chara : Slot {
  
  public override void OnClick() {
    crafter.AddInput(item);
  }
  
  private void Start() {
    UpdateIcon();
  }
}
