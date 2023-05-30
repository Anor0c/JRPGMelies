using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement;
using System.Threading.Tasks; 

public class SceneScript : MonoBehaviour
{
    public static SceneScript instance;
    [SerializeField] Image loadingBar;
    [SerializeField] GameObject loadingCanvas;
    [SerializeField] float target;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    /*private void Start()
    {
            loadingBar.fillAmount = 0f;
            target = 0f; 
    }*/
    public async void LoadLevel(int _levelIndex)
    {
        loadingBar.fillAmount = 0;
        target = 0f; 
        var nextScene = SceneManager.LoadSceneAsync(_levelIndex, LoadSceneMode.Single);
        nextScene.allowSceneActivation=false;
        loadingCanvas.SetActive(true);
        do
        {
            target = nextScene.progress;
            Debug.Log(nextScene.progress); 
        } while (nextScene.progress < 0.9f);
        target = 1f; 
        await Task.Delay(1000); 
        nextScene.allowSceneActivation = true;
        loadingCanvas.SetActive(false); 
    }
    private void Update()
    {
        loadingBar.fillAmount = Mathf.MoveTowards(loadingBar.fillAmount, target, 3 * Time.deltaTime); 
    }
    public void ToQuit()
    {
        Application.Quit(); 
    }
    public void ToCombat()
    {
        SceneManager.LoadScene(2);
    }
    public void ToRoaming()
    {
        SceneManager.LoadScene(1); 
    }
}