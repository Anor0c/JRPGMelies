using UnityEngine;
using UnityEngine.UI;

public class ChangeHealthUI : MonoBehaviour
{
    [SerializeField] private GameObject playerMod;

    [SerializeField] private GameObject hpbg;
    [SerializeField] private GameObject hpin;
    private RectTransform blackBackgroundHealth;
    private RectTransform greenBackgroundHealth;

    [SerializeField] private string warriorMod;
    [SerializeField] private string ninjaMod;

    // Start is called before the first frame update
    void Start()
    {
        blackBackgroundHealth = hpbg.GetComponent<RectTransform>();
        greenBackgroundHealth = hpin.GetComponent<RectTransform>();
    }

    public void changeUIhealth()
    {
        var currentPlayerMod = playerMod.GetComponent<HealthBehaviour>().playerStat.ToString();

        if (currentPlayerMod == warriorMod)
            setUpHealthUI(0.75f);

        if (currentPlayerMod == ninjaMod)
            setUpHealthUI(0.5f);
    }

    private void setUpHealthUI(float widthRatio)
    {
        var changeWidth = 1920 * widthRatio;

        blackBackgroundHealth.sizeDelta = new Vector2(changeWidth, blackBackgroundHealth.rect.height);
        blackBackgroundHealth.position = new Vector3(changeWidth / 2, blackBackgroundHealth.position.y, blackBackgroundHealth.position.z);

        greenBackgroundHealth.sizeDelta = new Vector2(changeWidth - 100, greenBackgroundHealth.rect.height);
        greenBackgroundHealth.position = new Vector3(changeWidth / 2, greenBackgroundHealth.position.y, greenBackgroundHealth.position.z);
    }
}
