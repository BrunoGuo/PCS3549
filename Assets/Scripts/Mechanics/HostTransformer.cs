using UnityEngine;

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


    public HostTransformerResult getResult(Animal.Type type) {
        HostTransformerResult result = new HostTransformerResult();
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
