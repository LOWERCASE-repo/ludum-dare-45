using UnityEngine;
using UnityEngine.UI;

internal class Chara : MonoBehaviour {
  
  [SerializeField]
  internal Item item;
  
  [Header("Components")]
  
  [SerializeField]
  private Image image;
  [SerializeField]
  internal Crafter crafter;
  
  public void OnClick() {
    crafter.AddInput(item);
  }
  
  private void Start() {
    image.sprite = item.icon;
    // text.text = item.name;
  }
}
