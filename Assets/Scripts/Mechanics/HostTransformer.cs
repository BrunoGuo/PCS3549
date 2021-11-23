using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HostTransformerResult {
    public Animator animator;
    public Collider2D collider2d;
}

public class HostTransformer: MonoBehaviour {

    // Horse gameobject
    public GameObject horse;

    // Cow gameobject
    public GameObject cow;

    // Chicken gameobject
    public GameObject chicken;

    // Bird gameobject
    public GameObject bird;

    // Rat gameobject
    public GameObject rat;

    // Human gameobject
    public GameObject human;

    // Pink gameobject
    public GameObject pink;

    // Marcel gameobject

    private List<GameObject> hostList;
    private Dictionary<Animal.Type, GameObject> hostDictionary;

    private void Awake() {
        hostList = new List<GameObject>();
        hostList.Add(chicken);
        hostList.Add(bird);
        hostList.Add(rat);
        hostList.Add(human);
        hostList.Add(cow);
        hostList.Add(horse);
        foreach (GameObject host in hostList) {
            host.SetActive(false);
        }
        hostList.Add(pink);
        hostList[hostList.Count - 1].SetActive(true);

        hostDictionary = new Dictionary<Animal.Type, GameObject>();
        hostDictionary.Add(Animal.Type.HORSE, horse);
        hostDictionary.Add(Animal.Type.COW, cow);
        hostDictionary.Add(Animal.Type.CHICKEN, chicken);
        hostDictionary.Add(Animal.Type.BIRD, bird);
        hostDictionary.Add(Animal.Type.RAT, rat);
        hostDictionary.Add(Animal.Type.HUMAN, human);
        hostDictionary.Add(Animal.Type.PINK, pink);
    }

    private void setAllInactive() {
        foreach (GameObject host in hostList) {
            host.SetActive(false);
        }
    }

    private void setActive(Animal.Type type) {
        hostDictionary[type].SetActive(true);
    }

    public void setAnimal(Animal.Type type) {
        setAllInactive();
        setActive(type);
    }

    public HostTransformerResult getResult(Animal.Type type) {
        HostTransformerResult result = new HostTransformerResult();
        setAllInactive();
        setActive(type);
        switch (type) {
            case Animal.Type.HORSE:
                result.animator = horse.GetComponent<Animator>();
                result.collider2d = horse.GetComponent<Collider2D>();
                break;
            case Animal.Type.COW:
                result.animator = cow.GetComponent<Animator>();
                result.collider2d = cow.GetComponent<Collider2D>();
                break;
            case Animal.Type.CHICKEN:
                result.animator = chicken.GetComponent<Animator>();
                result.collider2d = chicken.GetComponent<Collider2D>();
                break;
            case Animal.Type.RAT:
                result.animator = rat.GetComponent<Animator>();
                result.collider2d = rat.GetComponent<Collider2D>();
                break;
            case Animal.Type.BIRD:
                result.animator = bird.GetComponent<Animator>();
                result.collider2d = bird.GetComponent<Collider2D>();
                break;
            case Animal.Type.HUMAN:
                result.animator = human.GetComponent<Animator>();
                result.collider2d = human.GetComponent<Collider2D>();
                break;
            case Animal.Type.PINK:
                result.animator = pink.GetComponent<Animator>();
                result.collider2d = pink.GetComponent<Collider2D>();
                break;
        }
        return result;
    }
}
