using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ChoiceType {
    Meaning,
    Pinying,
    Tone
}

// public class CharObj {
// 
//     private string character;
//     private string description;
//     private string pinying;
//     private int tone;
// 
//     public CharObj(string character, string description, string pinying, int tone) {
//         this.character = character;
//         this.description = description;
//         this.pinying = pinying;
//         this.tone = tone;
//     }
// }

public class CharacterManager : MonoBehaviour
{

    private List<ShooterCharacter> characters;
    private CurrentCharacterDisplay curr_char_display;

    void Awake() {
        // characters = new List<ShooterCharacter>();
        curr_char_display = GameObject.FindObjectOfType<CurrentCharacterDisplay>();
        characters = GetHardcodedCharacters();
    }

    void Start() {
        curr_char_display.SetText(CurrChar);
    }

    public string CurrChar {
        get {
            return characters[0].StrChar;
        }
    }

    public List<ShooterCharacter> GetChoices(int nbr_choices) {

        var curr_char = characters[0];
        return GetRandomCharacters(curr_char, characters, nbr_choices);
    }

    private List<ShooterCharacter> GetHardcodedCharacters() {

        var char_list = new List<ShooterCharacter>();

        char_list.Add(new ShooterCharacter("一", "one", "yi", 1));
        char_list.Add(new ShooterCharacter("二", "two", "er", 4));
        char_list.Add(new ShooterCharacter("三", "three", "san", 1));
        char_list.Add(new ShooterCharacter("十", "ten", "shi", 2));
        char_list.Add(new ShooterCharacter("口", "mouth", "kou", 3));
        char_list.Add(new ShooterCharacter("日", "sun", "ri", 4));
        char_list.Add(new ShooterCharacter("几", "number of", "ji", 3));
        char_list.Add(new ShooterCharacter("也", "also", "ye", 3));
        char_list.Add(new ShooterCharacter("不", "not", "bu", 4));
        char_list.Add(new ShooterCharacter("机", "machine", "ji", 1));
        char_list.Add(new ShooterCharacter("我", "me", "wo", 3));

        return char_list;
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

    void Update() {
        
    }
}
