using UnityEngine;
using TMPro;
using System.Linq;

public class NPCStats : MonoBehaviour
{
    [SerializeField] public TextMeshPro  DisplayNameTMP;

    [SerializeField] public Sprite MaleHead1;
    [SerializeField] public Sprite MaleHead2;
    [SerializeField] public Sprite MaleHead3;
    [SerializeField] public Sprite MaleHead4;
    [SerializeField] public Sprite MaleHead5;
    [SerializeField] public Sprite MaleHead6;

    [SerializeField] public Sprite FemaleHead1;

    string[] maleFirstNames = {
    "James", "Lucas", "Nathan", "Oliver", "Ethan", "Marcus", "Adrian", "Sebastian",
    "Henry", "Daniel", "Felix", "Gabriel", "Julian", "Leo", "Owen", "Theo",
    "Aaron", "Caleb", "Dominic", "Elias", "Finn", "Gavin", "Hugo", "Isaac",
    "Jasper", "Kai", "Liam", "Miles", "Noah", "Oscar", "Patrick", "Quentin",
    "Reuben", "Silas", "Tristan", "Victor", "Wesley", "Xavier", "Zane", "Alexander",
    "Benjamin", "Cole", "Dean", "Edward", "Frederick", "George", "Harvey", "Ivan",
    "Jack", "Kieran", "Leon", "Maxwell", "Nicholas", "Otis", "Phillip", "Roman",
    "Samuel", "Theodore", "Ulysses", "Vincent", "William", "Asher", "Bryce", "Connor", "Henning"
    };

    string[] femaleFirstNames = {
    "Sofia", "Elena", "Clara", "Mia", "Isla", "Aurora", "Nora", "Lyra",
    "Amelia", "Beatrice", "Charlotte", "Diana", "Eliza", "Freya", "Grace", "Harriet",
    "Iris", "Juliet", "Kate", "Lillian", "Madeline", "Natalie", "Olivia", "Penelope",
    "Quinn", "Rosalind", "Sienna", "Tessa", "Una", "Violet", "Willa", "Ximena",
    "Yvonne", "Zara", "Abigail", "Bridget", "Cecilia", "Daphne", "Emilia", "Fiona",
    "Genevieve", "Hazel", "Imogen", "Josephine", "Kira", "Lucia", "Margot", "Nadia",
    "Opal", "Phoebe", "Ruby", "Stella", "Thea", "Ursula", "Vera", "Wren",
    "Adeline", "Blair", "Camille", "Delia", "Esme", "Faye", "Greta", "Hannah", "Nora"
    };

    string[] lastNames = {
    "Archer", "Blake", "Cross", "Mercer", "Stone", "Vale", "Hartley", "Quinn",
    "Ashford", "Bennett", "Carter", "Donovan", "Ellison", "Fletcher", "Graham", "Holloway",
    "Irving", "Jennings", "Kendrick", "Lawson", "Marlowe", "Norwood", "Osborne", "Pierce",
    "Radcliffe", "Sinclair", "Thatcher", "Underwood", "Vance", "Whitfield", "Yates", "Ashby",
    "Barlow", "Calloway", "Drummond", "Ellery", "Forsythe", "Gallagher", "Hawthorne", "Ingram",
    "Jasper", "Kingsley", "Lambert", "Montague", "Newell", "Oakley", "Prescott", "Renshaw",
    "Sutherland", "Tremaine", "Vaughn", "Wakefield", "Ainsworth", "Bradshaw", "Caldwell", "Dunmore",
    "Easton", "Fairweather", "Grayson", "Huxley", "Ivers", "Kensington", "Lockhart", "Merrick", "Knudsen", "Trillhus"
    };

    public string gender;
    public int NPCid;

    public int colorOfClothes; 

    private SpriteRenderer sr;
    
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();

        // Set the NPC's stats here
        string maleName = maleFirstNames[Random.Range(0, maleFirstNames.Length)] + " " + lastNames[Random.Range(0, lastNames.Length)];
        string femaleName = femaleFirstNames[Random.Range(0, femaleFirstNames.Length)] + " " + lastNames[Random.Range(0, lastNames.Length)];
        gender = Random.Range(0, 2) == 0 ? "Male" : "Female";
        DisplayNameTMP.text = gender == "Male" ? maleName : femaleName;
        int id = NPCManager.instance.NPCList.Count > 0 ? NPCManager.instance.NPCList.Max(n => n.id) + 1 : 1;
        colorOfClothes = Random.Range(0, 2);
        NPCid = id;
        if (gender == "Male")
        {
            NPCManager.instance.addNPC(maleName, "Male", 21, id);
        }
        else
        {
            NPCManager.instance.addNPC(femaleName, "Female", 21, id);
        }
        setSprite();
        
        

    }

    void setSprite()
    {
        if (gender == "Male")
        {
            int headIndex = Random.Range(1, 7); // Randomly select a head index between 1 and 6
            switch (headIndex)
            {
                case 1:
                    sr.sprite = MaleHead1;
                    break;
                case 2:
                    sr.sprite = MaleHead2;
                    break;
                case 3:
                    sr.sprite = MaleHead3;
                    break;
                case 4:
                    sr.sprite = MaleHead4;
                    break;
                case 5:
                    sr.sprite = MaleHead5;
                    break;
                case 6:
                    sr.sprite = MaleHead6;
                    break;
            }
        }
        else
        {
            sr.sprite = FemaleHead1; // For now,
        }
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame
    void Update()
    {
        
    }
}
