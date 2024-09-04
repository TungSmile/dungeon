
using UnityEngine;

public class Portal : Colliable
{
    public string[] sceneNames;
    protected override void OnCollide(Collider2D coll)
    {
        if (coll.name == "Player")
        {
            // teleport player
            GameManager.instance.SaveState();
            string sceneName = sceneNames[Random.Range(0, sceneNames.Length)];


            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        }
    }
}
