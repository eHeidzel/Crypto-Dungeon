using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.UI.ButtonsOperations
{
	public class GameMenuButtonOperations : MonoBehaviour
	{
		public void ChangeSceneToMainMenu()
		{
			FindAnyObjectByType<CleverSceneLoader>().LoadScene("MainMenu");
		}

		public void ContinueGame()
		{
			MenuManager.DisableMenu(gameObject);
		}
	}
}
