using UnityEngine;
using UnityEngine.SceneManagement;

namespace Outfit7.Util.LoadScene
{
    public class SceneLoader : MonoBehaviour
    {
        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}