using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Platformer.Core;
using Platformer.Mechanics;
using Platformer.Model;
using Pink.Constants;
using Animal;

public class PlayerHostInfect : Simulation.Event<PlayerHostInfect>
{
    public HostController host;
    public PlayerController player;

    public Sprite horseSprite;

    public override void Execute()
    {
        host.isInfected = true;
        host.gameObject.SetActive(false);
        // Timer timer = player.gameObject.AddComponent<Timer>() as Timer;
        // timer.setTimeRemaining(5);

        player.timer.setTimeRemaining(30);

        player.animator.SetBool("infecting", true);

        HostTransformer ht = player.GetComponent<HostTransformer>();
        HostTransformerResult result = ht.getResult(host.animal);

        player.gameObject.GetComponent<Animator>().runtimeAnimatorController = result.animator.runtimeAnimatorController;
        player.changeAnimal(host.animal);
        player.setAttr(host.canFly, host.canCarry, host.speed);
        Debug.Log("Player is infected");

        Debug.Log(player.collider2d);
        // HostTransformerResult result = HostTransformer.getResult(host.animal);

        // player.spriteRenderer.sprite = player.GetComponent<HostSprites>().horse;
    }
}
