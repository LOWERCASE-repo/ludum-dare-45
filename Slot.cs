using UnityEngine;
using UnityEngine.UI;
using TMPro;

internal class Slot : MonoBehaviour {
  
  [SerializeField]
  internal Item item;
  [Header("Components")]
  [SerializeField]
  internal Crafter crafter;
  [SerializeField]
  private Image image;
  [SerializeField]
  private TextMeshProUGUI text;
  
  public virtual void OnClick() {
    crafter.RemoveInput(gameObject.name[gameObject.name.Length - 1] - 49);
  }
  
  internal void UpdateIcon() {
    image.sprite = item.sprite;
    text.text = item.name;
  }
}
