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

    void Awake() {
        // characters = new List<ShooterCharacter>();
        curr_char_display = GameObject.FindObjectOfType<CurrentCharacterDisplay>();
        characters = GetHardcodedCharacters();
        curr_char_display.SetText(characters[0].StrChar);
    }

    public List<string> GetChoices(ChoiceType choice_type, int choices) {

        var curr_char = characters[0];

        switch (choice_type) {
            case ChoiceType.Meaning:
                return GetRandomDisplay(curr_char, characters, choices, ChoiceType.Meaning);
            case ChoiceType.Pinying:
                return GetRandomDisplay(curr_char, characters, choices, ChoiceType.Pinying);
            case ChoiceType.Tone:
                return GetToneStrings(curr_char.FlatPinying);
            default:
                throw new System.Exception("Unknown type: " + choice_type);
        }
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

    private List<string> GetRandomDisplay(ShooterCharacter current, List<ShooterCharacter> chars, int count, ChoiceType type) {

        var chars_copy = new List<ShooterCharacter>(chars);
        chars_copy.Remove(current);
        chars_copy = MyUtils.Shuffle(chars_copy);

        List<string> display_text = new List<string>();
        if (type == ChoiceType.Meaning) display_text.Add(current.Meaning);
        else if (type == ChoiceType.Pinying) display_text.Add(current.FlatPinying);
        else throw new System.Exception("Unknown choice type: " + type);

        for (var i = 1; i < count; i++) {
            if (type == ChoiceType.Meaning) display_text.Add(chars_copy[i].Meaning);
            else if (type == ChoiceType.Pinying) display_text.Add(chars_copy[i].FlatPinying);
            else throw new System.Exception("Unknown choice type: " + type);
        }
        return MyUtils.Shuffle(display_text);
    }

    // private List<string> GetRandomPinyings(ShooterCharacter current, List<ShooterCharacter> chars, int count) {
    // 
    //     List<string> pinyings = new List<string>();
    //     pinyings.Add(current.FlatPinying);
    //     for (var i = 1; i < count; i++) {
    //         pinyings.Add(chars[i].FlatPinying);
    //     }
    //     return pinyings;
    // }

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
