using UnityEngine;
using UnityEngine.UI;

public class ChangeHealthUI : MonoBehaviour
{
    [SerializeField] private GameObject playerMod;

    [SerializeField] private GameObject hpbg;
    [SerializeField] private GameObject hpin;
    private RectTransform blackBackgroundHealth;
    private RectTransform greenBackgroundHealth;

    [SerializeField] private string tank;
    [SerializeField] private string warrior;
    [SerializeField] private string ninja;

    // Start is called before the first frame update
    void Start()
    {
        blackBackgroundHealth = hpbg.GetComponent<RectTransform>();
        greenBackgroundHealth = hpin.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        changeUIhealth();
    }

    public void changeUIhealth()
    {
        Debug.Log("Le joueur est un " + playerMod.GetComponent<HealthBehaviour>().playerStat);
        var currentPlayerMod = playerMod.GetComponent<HealthBehaviour>().playerStat.ToString();

        if (currentPlayerMod == warrior)
            setUpUI(1280, 1180, -320);

        if (currentPlayerMod == ninja)
            setUpUI(960, 860, -480);
    }

    private void setUpUI(float widthBlack, float widthGreen, float localX)
    {
        var heightBlack = 70f;
        var heightGreen = 50f;
        var localYBlack = 579f;
        var localYGreen = 569f;
        var localZ = 0f;

        blackBackgroundHealth.sizeDelta = new Vector2(widthBlack, heightBlack);
        blackBackgroundHealth.SetLocalPositionAndRotation(new Vector3(localX, localYBlack, localZ), transform.rotation);

        greenBackgroundHealth.sizeDelta = new Vector2(widthGreen, heightGreen);
        greenBackgroundHealth.SetLocalPositionAndRotation(new Vector3(localX, localYGreen, localZ), transform.rotation);
    }
}
