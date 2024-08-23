using UnityEngine;
using UnityEngine.UI;

public class AboutCompanyUI : MonoBehaviour
{
    [SerializeField] private Button button_BackToMainMenu;

    public void Start() {
        button_BackToMainMenu.onClick.AddListener(() =>
        {
            GameManager.LOAD_MAIN_MENU();
        });
    }
}
