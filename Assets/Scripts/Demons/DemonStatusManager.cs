using UnityEngine;
using System.Collections;

public class DemonStatusManager : MonoBehaviour {

	[SerializeField]
	int seed, health, level, speed, damage, currentExperience, experienceToNextLevel;
	[SerializeField]
	string element;
	//Add modifier values to be temporarily buffed and debuffed for health, speed, damage etc.
	//Add boolean values to track buffs and debuffs.

	void Start() {
		//If no seed exists in file.
		seed = Random.Range(1, 5000);
	}

	public void SetLevel(int newLevel) {
		level = newLevel;
		//Increase all stats to reflect new the level by incrementing by a flat value based upon the seed determined on creation.
	}

	public void ModifyHealth(int value, string ele) {
		//Value of health modification will be further modified by the elemental type being passed in.
		health += value;

		if(health <= 0) {
			Death();
		}
	}

	public void CalculateBaseStats(int seed) {
		//Determine our base stats with seed to be serialized and stored.
	}

	public void AddBuff() {
		//TO DO.
	}

	public void RemoveBuff() {
		//TO DO
	}

	public void Death() {
		Debug.Log(gameObject.name + "has died.");
	}

	public void AddExperience(int xp) {
		currentExperience += xp;

		while(currentExperience >= experienceToNextLevel) {
			currentExperience = currentExperience - experienceToNextLevel;
			SetLevel(level + 1);
		}
	}
}
