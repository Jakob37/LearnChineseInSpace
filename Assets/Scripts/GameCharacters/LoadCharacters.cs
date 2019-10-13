using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public enum LoadMode {
    chapters,
    anki
}

namespace Assets.Scripts {
    class LoadCharacters {

        private static List<ShooterCharacter> target_characters;
        public static List<ShooterCharacter> TargetCharacters {
            get {
                return target_characters;
            }
        }

        public static void UpdateTargetCharacters(LoadMode load_mode, List<int> chapters=null, int anki_count=-1) {
            if (load_mode == LoadMode.chapters) {
                target_characters = SetupCharactersFromChapters(chapters);
                Debug.Log("Characters loaded");
            }
            else if (load_mode == LoadMode.anki) {
                Debug.Log("Anki characters loaded");
                target_characters = LoadCharactersFromAnki();
            }
            else {
                throw new System.Exception("No loading assigned!");
            }

            Debug.Log("Synced! Number of characters: " + LoadCharacters.TargetCharacters.Count);
        }

        private static List<ShooterCharacter> SetupCharactersFromChapters(List<int> selected_chapters=null) {
            List<ShooterCharacter> curr_characters;
            var all_characters = LoadCharacters.LoadLearningChineseCharacters();
            if (selected_chapters == null) {
                curr_characters = all_characters;
            }
            else {
                curr_characters = new List<ShooterCharacter>();
                foreach (ShooterCharacter shoot_char in all_characters) {
                    var chapter = shoot_char.Chapter;
                    if (selected_chapters.Contains(chapter)) {
                        curr_characters.Add(shoot_char);
                        Debug.Log("Adding character: " + shoot_char.StrChar);
                    }
                }
            }
            return curr_characters;
        }

        public static List<ShooterCharacter> LoadCharactersFromAnki() {

            string target_path = "anki";
            TextAsset mytxtData = (TextAsset)Resources.Load(target_path);
            string txt = mytxtData.text;
            string[] lines = txt.Split('\n');

            List<ShooterCharacter> shooter_chars = new List<ShooterCharacter>();

            for (int i = 0; i < lines.Length; i++) {

                string line = lines[i];
                if (line == "") {
                    continue;
                }

                string[] fields = line.Split('\t');

                // Debug.Log(fields[0]);
                // Debug.Log(fields[1]);
                // Debug.Log(fields[2]);
                // Debug.Log(fields[3]);
                // Debug.Log(fields[4]);
                // Debug.Log(fields[5]);

                // new ShooterCharacter("char", "meaning", "flat_pinying", "tone", "chapter");
                ShooterCharacter char_instance = new ShooterCharacter(
                    str_char: fields[0],
                    meaning: fields[3],
                    flat_pinying: fields[5],
                    tone: fields[6]
                );
                shooter_chars.Add(char_instance);
            }

            return shooter_chars;
        }

        public static List<ShooterCharacter> LoadLearningChineseCharacters() {

            var char_list = new List<ShooterCharacter>();

            // Chapter 1
            int chapter = 1;
            char_list.Add(new ShooterCharacter("一", "one", "yi", "1", chapter));
            char_list.Add(new ShooterCharacter("二", "two", "er", "4", chapter));
            char_list.Add(new ShooterCharacter("三", "three", "san", "1", chapter));
            char_list.Add(new ShooterCharacter("十", "ten", "shi", "2", chapter));
            char_list.Add(new ShooterCharacter("口", "mouth", "kou", "3", chapter));
            char_list.Add(new ShooterCharacter("日", "sun", "ri", "4", chapter));
            char_list.Add(new ShooterCharacter("几", "number of", "ji", "3", chapter));
            char_list.Add(new ShooterCharacter("也", "also", "ye", "3", chapter));
            char_list.Add(new ShooterCharacter("不", "not", "bu", "4", chapter));
            char_list.Add(new ShooterCharacter("机", "machine", "ji", "1", chapter));
            char_list.Add(new ShooterCharacter("杯", "cup", "bei", "1", chapter));
            char_list.Add(new ShooterCharacter("人", "person", "ren", "2", chapter));
            char_list.Add(new ShooterCharacter("他", "he", "ta", "1", chapter));
            char_list.Add(new ShooterCharacter("力", "power", "li", "4", chapter));
            char_list.Add(new ShooterCharacter("女", "woman", "nü", "3", chapter));
            char_list.Add(new ShooterCharacter("她", "her", "ta", "1", chapter));

            // Chapter 2
            chapter = 2;
            char_list.Add(new ShooterCharacter("子", "child", "zi", "5", chapter));
            char_list.Add(new ShooterCharacter("好", "good", "hao", "3", chapter));
            char_list.Add(new ShooterCharacter("个", "number of items", "ge", "4", chapter));
            char_list.Add(new ShooterCharacter("八", "eight", "ba", "1", chapter));
            char_list.Add(new ShooterCharacter("儿", "boy", "er", "2", chapter));
            char_list.Add(new ShooterCharacter("白", "white", "bai", "2", chapter));
            char_list.Add(new ShooterCharacter("的", "of", "de", "5", chapter));
            char_list.Add(new ShooterCharacter("四", "four", "si", "4", chapter));

            // Chapter 3
            chapter = 3;
            char_list.Add(new ShooterCharacter("文", "culture", "wen", "2", chapter));
            char_list.Add(new ShooterCharacter("这", "this", "zhe", "4", chapter));
            char_list.Add(new ShooterCharacter("门", "gate", "men", "2", chapter));
            char_list.Add(new ShooterCharacter("们", "people", "men", "5", chapter));
            char_list.Add(new ShooterCharacter("正", "upright", "zheng", "4", chapter));
            char_list.Add(new ShooterCharacter("是", "is", "shi", "4", chapter));
            char_list.Add(new ShooterCharacter("手", "hand", "shou", "3", chapter));
            char_list.Add(new ShooterCharacter("我", "me", "wo", "3", chapter));
            char_list.Add(new ShooterCharacter("中", "middle", "zhong", "1", chapter));

            // Chapter 4
            chapter = 4;
            char_list.Add(new ShooterCharacter("么", "appendage", "me", "5", chapter));
            char_list.Add(new ShooterCharacter("什", "what", "shen", "2", chapter));
            char_list.Add(new ShooterCharacter("五", "five", "wu", "3", chapter));
            char_list.Add(new ShooterCharacter("七", "seven", "qi", "1", chapter));
            char_list.Add(new ShooterCharacter("九", "nine", "jiu", "3", chapter));
            char_list.Add(new ShooterCharacter("六", "six", "liu", "4", chapter));
            char_list.Add(new ShooterCharacter("百", "hundred", "bai", "3", chapter));
            char_list.Add(new ShooterCharacter("边", "side", "bian", "1", chapter));
            char_list.Add(new ShooterCharacter("上", "above", "shang", "4", chapter));
            char_list.Add(new ShooterCharacter("下", "below", "xia", "4", chapter));
            char_list.Add(new ShooterCharacter("马", "horse", "ma", "3", chapter));
            char_list.Add(new ShooterCharacter("吗", "question mark", "ma", "5", chapter));
            char_list.Add(new ShooterCharacter("妈", "mum", "ma", "1", chapter));

            // Chapter 5
            chapter = 5;
            char_list.Add(new ShooterCharacter("大", "big", "da", "4", chapter));
            char_list.Add(new ShooterCharacter("太", "too much", "tai", "4", chapter));
            char_list.Add(new ShooterCharacter("夫", "husband", "fu", "1", chapter));
            char_list.Add(new ShooterCharacter("小", "small", "xiao", "3", chapter));
            char_list.Add(new ShooterCharacter("你", "you", "ni", "3", chapter));
            char_list.Add(new ShooterCharacter("又", "right hand, again", "you", "4", chapter));
            char_list.Add(new ShooterCharacter("友", "friend", "you", "3", chapter));
            char_list.Add(new ShooterCharacter("地", "ground, -ly", "di, de", "4", chapter));
            char_list.Add(new ShooterCharacter("在", "at", "zai", "4", chapter));
            char_list.Add(new ShooterCharacter("云", "cloud", "yun", "2", chapter));
            char_list.Add(new ShooterCharacter("运", "transport", "yun", "4", chapter));
            char_list.Add(new ShooterCharacter("动", "move", "dong", "4", chapter));
            char_list.Add(new ShooterCharacter("会", "meeting, can", "hui", "4", chapter));
            char_list.Add(new ShooterCharacter("国", "country", "guo", "2", chapter));

            // Chapter 6
            chapter = 6;
            char_list.Add(new ShooterCharacter("月", "moon", "yue", "4", chapter));
            char_list.Add(new ShooterCharacter("朋", "companion", "peng", "2", chapter));
            char_list.Add(new ShooterCharacter("有", "have", "you", "3", chapter));
            char_list.Add(new ShooterCharacter("妹", "younger sister", "mei", "4", chapter));
            char_list.Add(new ShooterCharacter("来", "come", "lai", "2", chapter));
            char_list.Add(new ShooterCharacter("了", "transition, complete", "le, liao", "5", chapter));
            char_list.Add(new ShooterCharacter("说", "say", "shuo", "1", chapter));
            char_list.Add(new ShooterCharacter("语", "language", "yu", "3", chapter));
            char_list.Add(new ShooterCharacter("多", "many", "duo", "1", chapter));
            char_list.Add(new ShooterCharacter("名", "name", "ming", "2", chapter));
            char_list.Add(new ShooterCharacter("外", "outside", "wai", "4", chapter));
            char_list.Add(new ShooterCharacter("刀", "knife", "dao", "1", chapter));
            char_list.Add(new ShooterCharacter("分", "division", "fen", "1", chapter));
            char_list.Add(new ShooterCharacter("到", "arrive", "dao", "4", chapter));
            char_list.Add(new ShooterCharacter("倒", "topple, invert", "dao, dao", "3", chapter));

            // Chapter 7
            chapter = 7;
            char_list.Add(new ShooterCharacter("天", "heaven", "tian", "1", chapter));
            char_list.Add(new ShooterCharacter("明", "bright", "ming", "2", chapter));
            char_list.Add(new ShooterCharacter("汉", "Han Chinese", "han", "4", chapter));
            char_list.Add(new ShooterCharacter("别", "don't", "bie", "2", chapter));
            char_list.Add(new ShooterCharacter("如", "if", "ru", "2", chapter));
            char_list.Add(new ShooterCharacter("行", "OK, line", "xing, hang", "2", chapter));
            char_list.Add(new ShooterCharacter("学", "study", "xue", "2", chapter));
            char_list.Add(new ShooterCharacter("车", "car", "car", "1", chapter));
            char_list.Add(new ShooterCharacter("连", "linked up", "lian", "2", chapter));
            char_list.Add(new ShooterCharacter("开", "open", "kai", "1", chapter));
            char_list.Add(new ShooterCharacter("去", "go", "qu", "4", chapter));
            char_list.Add(new ShooterCharacter("法", "law", "fa", "3", chapter));
            char_list.Add(new ShooterCharacter("取", "acquire", "qu", "3", chapter));
            char_list.Add(new ShooterCharacter("千", "thousand", "qian", "1", chapter));
            char_list.Add(new ShooterCharacter("前", "in front of", "qian", "2", chapter));

            // Chapter 8
            chapter = 8;
            char_list.Add(new ShooterCharacter("安", "peace", "an", "1", chapter));
            char_list.Add(new ShooterCharacter("字", "Chinese character", "zi", "4", chapter));
            char_list.Add(new ShooterCharacter("目", "eye", "mu", "4", chapter));
            char_list.Add(new ShooterCharacter("自", "self", "zi", "4", chapter));
            char_list.Add(new ShooterCharacter("咱", "we", "zan", "2", chapter));
            char_list.Add(new ShooterCharacter("阳", "in the open", "yang", "2", chapter));
            char_list.Add(new ShooterCharacter("阴", "hidden", "yin", "1", chapter));
            char_list.Add(new ShooterCharacter("那", "that", "na", "4", chapter));
            char_list.Add(new ShooterCharacter("哪", "which?", "na", "3", chapter));
            char_list.Add(new ShooterCharacter("西", "west", "xi", "1", chapter));
            char_list.Add(new ShooterCharacter("要", "want, ask for", "yao, yao", "4", chapter));
            char_list.Add(new ShooterCharacter("酒", "liquor", "jiu", "3", chapter));
            char_list.Add(new ShooterCharacter("从", "from", "cong", "2", chapter));
            char_list.Add(new ShooterCharacter("村", "village", "cun", "1", chapter));
            char_list.Add(new ShooterCharacter("时", "time", "shi", "2", chapter));
            char_list.Add(new ShooterCharacter("过", "to cross", "guo", "4", chapter));
            char_list.Add(new ShooterCharacter("身", "body", "shen", "1", chapter));
            char_list.Add(new ShooterCharacter("谢", "thank", "xie", "4", chapter));

            // Chapter 9
            chapter = 9;
            char_list.Add(new ShooterCharacter("家", "household", "jia", "1", chapter));
            char_list.Add(new ShooterCharacter("山", "mountain", "shan", "1", chapter));
            char_list.Add(new ShooterCharacter("羊", "sheep", "yang", "2", chapter));
            char_list.Add(new ShooterCharacter("样", "appearance", "yang", "4", chapter));
            char_list.Add(new ShooterCharacter("班", "team", "ban", "1", chapter));
            char_list.Add(new ShooterCharacter("出", "exit", "chu", "1", chapter));
            char_list.Add(new ShooterCharacter("础", "plinth", "chu", "3", chapter));
            char_list.Add(new ShooterCharacter("岁", "years old", "sui", "4", chapter));
            char_list.Add(new ShooterCharacter("但", "but", "dan", "4", chapter));
            char_list.Add(new ShooterCharacter("得", "obtain, way, must", "de, de, dei", "2", chapter));
            char_list.Add(new ShooterCharacter("公", "public", "gong", "1", chapter));
            char_list.Add(new ShooterCharacter("以", "using", "yi", "3", chapter));
            char_list.Add(new ShooterCharacter("之", "of", "zhi", "1", chapter));
            char_list.Add(new ShooterCharacter("为", "act as, for", "wei, wei", "2", chapter));
            char_list.Add(new ShooterCharacter("办", "manage", "ban", "4", chapter));
            char_list.Add(new ShooterCharacter("干", "dry, work", "gan, gan", "1", chapter));
            char_list.Add(new ShooterCharacter("午", "noon", "wu", "3", chapter));
            char_list.Add(new ShooterCharacter("和", "with, mix", "he, huo", "2", chapter));

            // Chapter 10
            chapter = 10;
            char_list.Add(new ShooterCharacter("母", "mother", "mu", "3", chapter));
            char_list.Add(new ShooterCharacter("每", "every", "mei", "3", chapter));
            char_list.Add(new ShooterCharacter("海", "sea", "hai", "3", chapter));
            char_list.Add(new ShooterCharacter("用", "to use", "yong", "4", chapter));
            char_list.Add(new ShooterCharacter("半", "half", "ban", "4", chapter));
            char_list.Add(new ShooterCharacter("利", "benefit", "li", "4", chapter));
            char_list.Add(new ShooterCharacter("生", "life", "sheng", "1", chapter));
            char_list.Add(new ShooterCharacter("胜", "triumph", "sheng", "4", chapter));
            char_list.Add(new ShooterCharacter("姓", "surname", "xing", "4", chapter));
            char_list.Add(new ShooterCharacter("星", "star", "xing", "1", chapter));
            char_list.Add(new ShooterCharacter("先", "ahead", "xian", "1", chapter));
            char_list.Add(new ShooterCharacter("告", "inform", "gao", "4", chapter));
            char_list.Add(new ShooterCharacter("洗", "wash", "xi", "3", chapter));
            char_list.Add(new ShooterCharacter("可", "may", "ke", "3", chapter));
            char_list.Add(new ShooterCharacter("河", "river", "he", "2", chapter));
            char_list.Add(new ShooterCharacter("何", "what", "he", "2", chapter));
            char_list.Add(new ShooterCharacter("啊", "eh!", "a", "1", chapter));
            char_list.Add(new ShooterCharacter("首", "head", "shou", "3", chapter));
            char_list.Add(new ShooterCharacter("道", "way", "dao", "4", chapter));
            char_list.Add(new ShooterCharacter("发", "send out", "fa", "1", chapter));
            char_list.Add(new ShooterCharacter("工", "to work", "gong", "1", chapter));
            char_list.Add(new ShooterCharacter("江", "river", "jiang", "1", chapter));

            // Chapter 11
            chapter = 11;
            char_list.Add(new ShooterCharacter("厂", "cliff", "chang", "3", chapter));
            char_list.Add(new ShooterCharacter("后", "rear", "hou", "4", chapter));
            char_list.Add(new ShooterCharacter("而", "and yet", "er", "2", chapter));
            char_list.Add(new ShooterCharacter("找", "look for", "zhao", "3", chapter));
            char_list.Add(new ShooterCharacter("打", "hit", "da", "3", chapter));
            char_list.Add(new ShooterCharacter("对", "correct", "dui", "4", chapter));
            char_list.Add(new ShooterCharacter("树", "tree", "shu", "4", chapter));
            char_list.Add(new ShooterCharacter("男", "male", "nan", "2", chapter));
            char_list.Add(new ShooterCharacter("里", "in", "li", "3", chapter));
            char_list.Add(new ShooterCharacter("理", "reason", "li", "3", chapter));
            char_list.Add(new ShooterCharacter("电", "electricity", "dian", "4", chapter));
            char_list.Add(new ShooterCharacter("同", "same", "tong", "2", chapter));
            char_list.Add(new ShooterCharacter("心", "heart", "xin", "1", chapter));
            char_list.Add(new ShooterCharacter("必", "inevitably", "bi", "4", chapter));
            char_list.Add(new ShooterCharacter("相", "mutual, appearance", "xiang, xiang", "1", chapter));
            char_list.Add(new ShooterCharacter("想", "think about", "xiang", "3", chapter));
            char_list.Add(new ShooterCharacter("思", "think", "si", "3", chapter));
            char_list.Add(new ShooterCharacter("今", "now", "jin", "1", chapter));
            char_list.Add(new ShooterCharacter("念", "to study", "nian", "4", chapter));

            // Chapter 12
            chapter = 12;
            char_list.Add(new ShooterCharacter("年", "year", "nian", "2", chapter));
            char_list.Add(new ShooterCharacter("没", "not", "mei", "2", chapter));
            char_list.Add(new ShooterCharacter("广", "shelter", "guang", "3", chapter));
            char_list.Add(new ShooterCharacter("床", "bed", "chuang", "2", chapter));
            char_list.Add(new ShooterCharacter("长", "long, chief", "chang, zhang", "2", chapter));
            char_list.Add(new ShooterCharacter("张", "sheet (of paper)", "zhang", "1", chapter));
            char_list.Add(new ShooterCharacter("本", "source", "ben", "3", chapter));
            char_list.Add(new ShooterCharacter("体", "body", "ti", "3", chapter));
            char_list.Add(new ShooterCharacter("书", "book", "shu", "1", chapter));
            char_list.Add(new ShooterCharacter("立", "to stand", "li", "4", chapter));
            char_list.Add(new ShooterCharacter("位", "place", "wei", "4", chapter));
            char_list.Add(new ShooterCharacter("拉", "pull", "la", "1", chapter));
            char_list.Add(new ShooterCharacter("啦", "exclamation", "la", "5", chapter));
            char_list.Add(new ShooterCharacter("火", "fire", "huo", "3", chapter));
            char_list.Add(new ShooterCharacter("灯", "lamp", "deng", "1", chapter));
            char_list.Add(new ShooterCharacter("占", "occupy", "zhan", "4", chapter));
            char_list.Add(new ShooterCharacter("站", "station", "zhan", "4", chapter));
            char_list.Add(new ShooterCharacter("点", "speck, to order", "dian", "3", chapter));
            char_list.Add(new ShooterCharacter("店", "store", "dian", "4", chapter));

            // Chapter 13
            chapter = 13;
            char_list.Add(new ShooterCharacter("果", "fruit", "guo", "3", chapter));
            char_list.Add(new ShooterCharacter("棵", "number of trees", "ke", "1", chapter));
            char_list.Add(new ShooterCharacter("课", "lesson", "ke", "4", chapter));
            char_list.Add(new ShooterCharacter("政", "government", "zheng", "4", chapter));
            char_list.Add(new ShooterCharacter("故", "former", "gu", "4", chapter));
            char_list.Add(new ShooterCharacter("姑", "aunt", "gu", "1", chapter));
            char_list.Add(new ShooterCharacter("湖", "lake", "hu", "2", chapter));
            char_list.Add(new ShooterCharacter("克", "gram", "ke", "4", chapter));
            char_list.Add(new ShooterCharacter("辛", "spicy", "xin", "1", chapter));
            char_list.Add(new ShooterCharacter("亲", "kin", "qin", "1", chapter));
            char_list.Add(new ShooterCharacter("产", "to produce", "chan", "3", chapter));
            char_list.Add(new ShooterCharacter("卡", "card", "ka", "3", chapter));
            char_list.Add(new ShooterCharacter("还", "still, give back", "hai, huan", "2", chapter));
            char_list.Add(new ShooterCharacter("看", "look at", "kan", "4", chapter));
            char_list.Add(new ShooterCharacter("讨", "ask for", "tao", "3", chapter));
            char_list.Add(new ShooterCharacter("回", "return", "hui", "2", chapter));
            char_list.Add(new ShooterCharacter("接", "receive", "jie", "1", chapter));
            char_list.Add(new ShooterCharacter("差", "fall short", "cha", "4", chapter));
            char_list.Add(new ShooterCharacter("着", "to catch, -ing", "zhao, zhe", "2", chapter));

            // Chapter 14
            chapter = 14;
            char_list.Add(new ShooterCharacter("能", "able to", "neng", "2", chapter));
            char_list.Add(new ShooterCharacter("作", "do", "zuo", "4", chapter));
            char_list.Add(new ShooterCharacter("昨", "yesterday", "zuo", "2", chapter));
            char_list.Add(new ShooterCharacter("左", "left (hand)", "zuo", "3", chapter));
            char_list.Add(new ShooterCharacter("做", "do", "zuo", "4", chapter));
            char_list.Add(new ShooterCharacter("坐", "sit", "zuo", "4", chapter));
            char_list.Add(new ShooterCharacter("座", "seat", "zuo", "4", chapter));
            char_list.Add(new ShooterCharacter("右", "right (hand)", "you", "4", chapter));
            char_list.Add(new ShooterCharacter("见", "see", "jian", "4", chapter));
            char_list.Add(new ShooterCharacter("现", "the present", "xian", "4", chapter));
            char_list.Add(new ShooterCharacter("观", "observe", "guan", "1", chapter));
            char_list.Add(new ShooterCharacter("再", "again", "zai", "4", chapter));
            char_list.Add(new ShooterCharacter("苦", "bitter", "ku", "3", chapter));
            char_list.Add(new ShooterCharacter("内", "inside", "nei", "4", chapter));
            char_list.Add(new ShooterCharacter("呐", "[shout]", "na", "4", chapter));
            char_list.Add(new ShooterCharacter("肉", "meat", "rou", "4", chapter));
            char_list.Add(new ShooterCharacter("两", "a couple", "liang", "3", chapter));
            char_list.Add(new ShooterCharacter("辆", "number of cars", "liang", "4", chapter));
            char_list.Add(new ShooterCharacter("俩", "two people", "lia", "3", chapter));
            char_list.Add(new ShooterCharacter("满", "full", "man", "3", chapter));
            char_list.Add(new ShooterCharacter("互", "reciprocal", "hu", "4", chapter));
            char_list.Add(new ShooterCharacter("它", "it", "ta", "1", chapter));
            char_list.Add(new ShooterCharacter("比", "compared with", "bi", "3", chapter));
            char_list.Add(new ShooterCharacter("批", "criticize", "pi", "1", chapter));
            char_list.Add(new ShooterCharacter("切", "to cut", "qie", "4", chapter));

            // Chapter 15
            chapter = 15;
            char_list.Add(new ShooterCharacter("词", "word", "ci", "2", chapter));
            char_list.Add(new ShooterCharacter("典", "reference book", "dian", "3", chapter));
            char_list.Add(new ShooterCharacter("红", "red", "hong", "2", chapter));
            char_list.Add(new ShooterCharacter("细", "slender", "xi", "4", chapter));
            char_list.Add(new ShooterCharacter("其", "'this or that'", "qi", "2", chapter));
            char_list.Add(new ShooterCharacter("期", "due", "qi", "1", chapter));
            char_list.Add(new ShooterCharacter("基", "foundation", "ji", "1", chapter));
            char_list.Add(new ShooterCharacter("尤", "especially", "you", "2", chapter));
            char_list.Add(new ShooterCharacter("就", "right away", "jiu", "4", chapter));
            char_list.Add(new ShooterCharacter("斤", "axe", "jin", "1", chapter));
            char_list.Add(new ShooterCharacter("近", "close", "jin", "4", chapter));
            char_list.Add(new ShooterCharacter("听", "listen", "ting", "1", chapter));
            char_list.Add(new ShooterCharacter("新", "new", "xin", "1", chapter));
            char_list.Add(new ShooterCharacter("经", "go through", "jing", "1", chapter));
            char_list.Add(new ShooterCharacter("轻", "lightweight", "qing", "1", chapter));
            char_list.Add(new ShooterCharacter("头", "head", "tou", "2", chapter));
            char_list.Add(new ShooterCharacter("买", "buy", "mai", "3", chapter));
            char_list.Add(new ShooterCharacter("卖", "sell", "mai", "4", chapter));
            char_list.Add(new ShooterCharacter("读", "to read", "du", "2", chapter));
            char_list.Add(new ShooterCharacter("实", "real", "shi", "2", chapter));

            return char_list;


        }
    }
}
