using UnityEngine;
using System.IO;

public class SaveAndLoadData : MonoBehaviour
{
    [HideInInspector] public DataToSave datas;
    private string jsonData;

    private void Start()
    {
        datas = new DataToSave();
    }

    public void SaveToJSON()
    {
        jsonData = JsonUtility.ToJson(datas, true);
        File.WriteAllText(Application.dataPath + "/DataLog.json", jsonData); //DataLog est le nom du fichier et celui-ci se trouvera dans la racine du projet
    }

    public void LoadToJSON()
    {
        jsonData = File.ReadAllText(Application.dataPath + "/DataLog.json");
        datas = JsonUtility.FromJson<DataToSave>(jsonData);
    }
}
