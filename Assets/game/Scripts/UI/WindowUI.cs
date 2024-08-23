using UnityEngine;
using UnityEngine.UI;

public class WindowUI : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] public Button button_CloseWindowCanvas;

    public virtual void Awake()
    {
        if (button_CloseWindowCanvas != null)
        {
            button_CloseWindowCanvas.onClick.AddListener(() =>
            {
                TryPlayClickSound();
                gameObject.SetActive(false);
            });
        }
    }

    public virtual void SetActive(bool value)
    {
        gameObject.SetActive(value);
    }

    public virtual void TryPlayClickSound()
    {

    }
}
