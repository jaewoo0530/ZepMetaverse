using UnityEngine;

public abstract class BaseUI : MonoBehaviour
{
    protected TopDownUIManager uiManager;

    public virtual void Init(TopDownUIManager uiManager)
    {
        this.uiManager = uiManager;
    }
    
    protected abstract UIState GetUIState(); 
    public void SetActive(UIState state)
    {
        this.gameObject.SetActive(GetUIState() == state);
    }
}