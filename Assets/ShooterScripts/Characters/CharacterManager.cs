using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ChoiceType {
    Meaning,
    Pinying,
    Tone
}

public class CharacterManager : MonoBehaviour
{

    private List<ShooterCharacter> characters;
    private CurrentCharacterDisplay curr_char_display;

    private int curr_char_index;

    void Awake() {
        curr_char_display = GameObject.FindObjectOfType<CurrentCharacterDisplay>();
        characters = LoadCharacters.LoadLearningChineseCharacters();
    }

    void Start() {
    }

    private void NewCharacter() {
        curr_char_index = Random.Range(0, characters.Count);
        curr_char_display.SetText(characters[curr_char_index].StrChar);
    }

    public string CurrChar {
        get {
            return characters[curr_char_index].StrChar;
        }
    }

    public string CurrTone {
        get {
            return characters[curr_char_index].Tone;
        }
    }

    public ShooterCharacter CurrCharObj {
        get {
            return characters[curr_char_index];
        }
    }

    public List<ShooterCharacter> GetChoices(int nbr_choices, bool set_new_character) {

        if (set_new_character) {
            NewCharacter();
        }
        return GetRandomCharacters(characters[curr_char_index], characters, nbr_choices);
    }

    public List<ShooterCharacter> GetToneChoices() {
        var tone_choices = new List<ShooterCharacter>();
        tone_choices.Add(new ShooterCharacter("dummy", "dummy", "dummy", "1"));
        tone_choices.Add(new ShooterCharacter("dummy", "dummy", "dummy", "2"));
        tone_choices.Add(new ShooterCharacter("dummy", "dummy", "dummy", "3"));
        tone_choices.Add(new ShooterCharacter("dummy", "dummy", "dummy", "4"));
        tone_choices.Add(new ShooterCharacter("dummy", "dummy", "dummy", "5"));
        return tone_choices;
    }

    private List<ShooterCharacter> GetRandomCharacters(ShooterCharacter current, List<ShooterCharacter> chars, int count) {

        var chars_copy = new List<ShooterCharacter>(chars);
        chars_copy.Remove(current);
        chars_copy = MyUtils.Shuffle(chars_copy);

        List<ShooterCharacter> choices = new List<ShooterCharacter>();
        choices.Add(current);

        for (var i = 1; i < count; i++) {
            choices.Add(chars_copy[i]);
        }
        return MyUtils.Shuffle(choices);
    }

    private List<string> GetToneStrings(string base_string) {

        List<string> tone_strings = new List<string>();

        tone_strings.Add(base_string + "1");
        tone_strings.Add(base_string + "2");
        tone_strings.Add(base_string + "3");
        tone_strings.Add(base_string + "4");
        tone_strings.Add(base_string + "5");

        return tone_strings;
    }
}
