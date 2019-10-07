using UnityEngine;
using System.Collections;

internal class Slot : Icon {
  
  public void OnClick() {
    Clear();
    crafter.Craft();
  }
  
  internal void Clear() {
    item = null;
    animator.SetBool("Active", false);
  }
  
  internal override void SetItem(Item item) {
    base.SetItem(item);
    animator.SetBool("Active", true);
  }
}
