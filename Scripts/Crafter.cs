using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

internal class Crafter : MonoBehaviour {
  
  [SerializeField]
  private Slot[] slots;
  [SerializeField]
  private Result result;
  [SerializeField]
  private Transform inventory;
  [SerializeField]
  private Chara chara;
  [SerializeField]
  private GameObject eventSystem;
  
  [SerializeField]
  private Item[] originalItems;
  [SerializeField]
  private Chara[] originalCharas;
  private Dictionary<Item, Chara> itemButtons;
  private Color complete;
  private List<Recipe> recipes;
  
  [SerializeField]
  private TutorialText tutText;
  [SerializeField]
  private GoldPopup gold;
  private bool golded;
  private bool tutted;
  
  [SerializeField]
  private Animator windex;
  
  private bool CompareContents<T>(IEnumerable<T> list1, IEnumerable<T> list2) {
    var dict = new Dictionary<T, int>();
    foreach (T item in list1) {
      if (item != null) {
        if (dict.ContainsKey(item)) {
          dict[item]++;
        } else {
          dict.Add(item, 1);
        }
      }
    }
    foreach (T item in list2) {
      if (item != null) {
        if (dict.ContainsKey(item)) {
          dict[item]--;
        } else {
          return false;
        }
      }
    }
    return dict.Values.All(count => count == 0);
  }
  
  internal void Craft() {
    Item[] inputs = new Item[] {
      slots[0].item, slots[1].item, slots[2].item, slots[3].item
    };
    Recipe result = null;
    
    // find matching
    for (int i = 0; i < recipes.Count; i++) {
      if (CompareContents(inputs, recipes[i].inputs)) {
        result = recipes[i];
      }
    }
    
    if (result == null) return;
    
    if (!tutted) {
      tutText.Fade();
      tutted = true;
    }
    // remove dupe recipes
    for (int i = recipes.Count - 1; i >= 0; i--) {
      if (result.result == recipes[i].result) {
        recipes.RemoveAt(i);
      }
    }
    
    // mark completed
    
    Item[] resultInputs = result.inputs;
    
    // for each item in recipe, if equal 
    foreach(KeyValuePair<Item, Chara> button in itemButtons) {
      bool completed = true;
      foreach (Recipe recipe in recipes) {
        foreach (Item input in recipe.inputs) {
          if (input == button.Key) {
            completed = false;
          }
        }
      }
      if (completed == true) {
        itemButtons[button.Key].Complete();
        if (!golded) {
          gold.Activate();
        }
        golded = true;
      }
    }
    
    bool resultCompleted = true;
    foreach (Recipe recipe in recipes) {
      foreach (Item input in recipe.inputs) {
        if (input == result.result) {
          resultCompleted = false;
        }
      }
    }
    if (resultCompleted) {
      StartCoroutine(DelayCollectCompleted(result.result));
    } else {
      StartCoroutine(DelayCollect(result.result));
    }
  }
  
  internal void AddInput(Item item) {
    for (int i = 0; i < 4; i++) {
      if (slots[i].item == null) {
        slots[i].SetItem(item);
        Craft();
        break;
      }
    }
  }
  
  // turn into event
  private IEnumerator DelayCollect(Item item) {
    eventSystem.SetActive(false);
    yield return new WaitForSeconds(1f/3f);
    result.SetItem(item);
    yield return new WaitForSeconds(1.5f);
    Chara chara = Instantiate(this.chara, inventory);
    chara.item = item;
    chara.crafter = this;
    itemButtons.Add(item, chara);
    for (int i = 0; i < 4; i++) {
      slots[i].Clear();
    }
    eventSystem.SetActive(true);
    yield return new WaitForSeconds(0.5f);
    CheckWin();
  }
  
  private IEnumerator DelayCollectCompleted(Item item) {
    eventSystem.SetActive(false);
    yield return new WaitForSeconds(1f/3f);
    result.SetItem(item);
    yield return new WaitForSeconds(1.5f);
    Chara chara = Instantiate(this.chara, inventory);
    chara.item = item;
    chara.crafter = this;
    itemButtons.Add(item, chara);
    chara.Complete();
    for (int i = 0; i < 4; i++) {
      slots[i].Clear();
    }
    eventSystem.SetActive(true);
    if (!golded) {
      gold.Activate();
    }
    golded = true;
    yield return new WaitForSeconds(0.5f);
    CheckWin();
  }
  
  private void CheckWin() {
    if (recipes.Count == 0) {
      windex.SetTrigger("yes");
    }
  }
  
  
  // this comment memorializes
  // the forgone cupe strike
  // rip hopes n dreams
  
  private void Start() {
    recipes = Resources.LoadAll("Recipes").Cast<Recipe>().ToList();
    itemButtons = new Dictionary<Item, Chara>();
    for (int i = 0; i < 4; i++) {
      itemButtons.Add(originalItems[i], originalCharas[i]);
    }
  }
}
