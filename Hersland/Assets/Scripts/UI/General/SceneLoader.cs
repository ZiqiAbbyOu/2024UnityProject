using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace HL.UI
{
    public class SceneLoader : MonoBehaviour
    {
        // Start is called before the first frame update
        public void LoadCostomizationScene()
        {
            SceneManager.LoadScene("CustomizationScene");
        }

        public void LoadStartScene()
        {
            SceneManager.LoadScene("StartScene");
        }

        public void LoadGameScene()
        {
            SceneManager.LoadScene("GameScene");
        }
    }
}