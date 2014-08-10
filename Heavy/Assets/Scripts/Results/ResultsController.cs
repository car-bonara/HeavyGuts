using UnityEngine;
using System.Collections;

public class ResultsController : MonoBehaviour {

	private const string MALE_SPRITENAME = "Orc Armor - Boots";
	private const string FEMALE_SPRITENAME = "Orc Armor - Bracers";

	[SerializeField]
	private UILabel nameLabel;

	[SerializeField]
	private UILabel calorieLabel;

	[SerializeField]
	private UISprite genderSprite;

	void Start () {
		SetPlayerName ();
		SetGenderSprite ();
		SetCalorie ();
	}

	void SetPlayerName() {
		nameLabel.text = "Hi " + PlayerPrefs.GetString("Name");
	}

	void SetGenderSprite() {
		string gender = PlayerPrefs.GetString("Gender");
		switch (gender) {
		case "Male":
			genderSprite.spriteName = MALE_SPRITENAME;
			break;
		case "Female":
			genderSprite.spriteName = FEMALE_SPRITENAME;
			break;
		}
	}

	void SetCalorie() {
		float result = 0f;

		if (PlayerPrefs.GetString ("Gender") == "Male") 
			result = 10 * PlayerPrefs.GetFloat ("Weight") + 6.25f * PlayerPrefs.GetFloat ("Height") - 5 *
				PlayerPrefs.GetInt ("Age") + 5;
		else 
			result = 10 * PlayerPrefs.GetFloat ("Weight") + 6.25f * PlayerPrefs.GetFloat ("Height") - 5 *
				PlayerPrefs.GetInt ("Age") - 161;

		calorieLabel.text = result.ToString ();
	}
}
