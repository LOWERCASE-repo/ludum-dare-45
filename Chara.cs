using UnityEngine;
using UnityEngine.UI;

internal class Chara : MonoBehaviour {
  
  [SerializeField]
  private Item item;
  
  [Header("Components")]
  
  [SerializeField]
  private Image image;
  [SerializeField]
  private Text text;
  [SerializeField]
  private Crafter crafter;
  
  public void OnClick() {
    crafter.AddInput(item);
  }
  
  private void Start() {
    image.sprite = item.icon;
    text.text = item.name;
  }
}
