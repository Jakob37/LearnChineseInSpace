using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{

    List<ShooterCharacter> characters;

    void Start() {
        characters = new List<ShooterCharacter>();
        characters = GetHardcodedCharacters();
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

    private List<string> GetRandomMeanings(string current, List<ShooterCharacter> chars, int count) {

        List<string> meanings = new List<string>();
        for (var i = 0; i < count; i++) {
            meanings.Add(chars[i].Meaning);
        }
        return meanings;
    }

    private List<string> GetRandomPinyings(string current, List<ShooterCharacter> chars, int count) {

        List<string> pinyings = new List<string>();
        for (var i = 0; i < count; i++) {
            pinyings.Add(chars[i].FlatPinying);
        }
        return pinyings;
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
