using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour, IPointerClickHandler
{
    private GraphicRaycaster ui_raycaster;
    private PointerEventData click_data;
    private List<RaycastResult> click_results;

    // Start is called before the first frame update
    void Start()
    {
        ui_raycaster = gameObject.GetComponent<GraphicRaycaster>();
        click_data = new PointerEventData(EventSystem.current);
        click_results = new List<RaycastResult>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public UnityEvent onClick;
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        //Output to console the clicked GameObject's name and the following message. You can replace this with your own actions for when clicking the GameObject.
        Debug.Log(name + " Game Object Clicked!", this);

        // invoke your event
        onClick.Invoke();
    }
}
