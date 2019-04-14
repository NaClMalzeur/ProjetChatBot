using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    //public Object scene;
    public int scene_index;

    public List<GameObject> panels;
    public GameObject selected_panel;

    public void Start() {
        if (panels.Count == 0) {
            Debug.LogWarning("ScenesManager: aucun panel ");
            return;
        } 

        SwitchToPanel(panels[0]);
    }

    public void SwitchToPanel(GameObject panel) {
        SetSelectedPanel(panel);
        HideAllButThisPanel(selected_panel);
    }

    public void SetSelectedPanel(GameObject panel) {
        selected_panel = panel;
    }


    /*
        Masque tous les panels sauf celui en argument
     */
    public void HideAllButThisPanel(GameObject panel) {
        foreach(GameObject p in panels) {
            SetPanelVisible(p, false);
        }
        SetPanelVisible(panel, true);
    }


    public void SetPanelVisible(GameObject panel, bool isVisible) {
        CanvasGroup canvasGroup = panel.GetComponent<CanvasGroup>();

        if (canvasGroup == null) {
            Debug.LogWarning("PartieManager: canvasGroup de " + panel.name +  " est null !");
            return;
        }

        canvasGroup.alpha = isVisible ? 1 : 0;
        canvasGroup.interactable = isVisible;
        canvasGroup.blocksRaycasts = isVisible;
    }

    public void ChangeScene() {
        SceneManager.LoadScene(scene_index);
    }


}
