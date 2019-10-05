using UnityEngine;
using UnityEngine.UI;

internal class Chara : MonoBehaviour {
  
  [SerializeField]
  private Image image;
  [SerializeField]
  private Text text;
  
  [SerializeField]
  private Item item;
  
  public void OnClick() {
    Debug.Log("oenthusnatoe");
  }
  
  private void Start() {
    image.sprite = item.icon;
    text.text = item.name;
  }
}
