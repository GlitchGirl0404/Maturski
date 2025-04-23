using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DajkstraButtons : MonoBehaviour
{
    bool level_finish = false;
    [SerializeField] GameObject dajkstra_manager;
    DajkstraManager dm;
    string data_dir_path;
    string data_file_name = "SaveData.pbg";
    void Start()
    {
        dm = dajkstra_manager.GetComponent<DajkstraManager>();
        data_dir_path = Application.persistentDataPath;
    }
    public void Click()
    {
        if (level_finish)
        {
            bool[,] stars = new bool[3, 3];
            string full_path = Path.Combine(data_dir_path, data_file_name);
            Directory.CreateDirectory(Path.GetDirectoryName(full_path));
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    stars[i, j] = false;
                }
            }
            if (File.Exists(full_path))
            {
                using(FileStream strem = new FileStream(full_path, FileMode.Open))
                {
                    using(StreamReader reader = new StreamReader(strem))
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            for (int j = 0; j < 3; j++)
                            {
                                stars[i, j] = bool.Parse(reader.ReadLine());
                            }
                        }
                    }
                }
            }
            if (LevelLoading.max_lopov.razdaljina == LevelLoading.ukradeno_lopov)
            {
                stars[LevelLoading.level_id, 0] = true;
            }
            if (LevelLoading.max_vrednost.razdaljina == LevelLoading.ukradena_vrednost)
            {
                stars[LevelLoading.level_id, 1] = true;
            }
            if (LevelLoading.najbrzi.razdaljina == LevelLoading.trenutni)
            {
                stars[LevelLoading.level_id, 2] = true;
            }
            using (FileStream stream = new FileStream(full_path, FileMode.Create))
            {
                using(StreamWriter writer = new StreamWriter(stream))
                {
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            writer.WriteLine(stars[i, j]);
                        }
                    }
                }
            }
            SceneManager.LoadScene("LevelSelect");
        }
        else
        {
            level_finish = true;
            dm.EndLevel();
        }
    }
}