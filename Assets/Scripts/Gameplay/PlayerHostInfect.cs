using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

        player.timer.setTimeRemaining(5);

        player.animator.SetBool("infecting", true);
        switch (host.animal)
        {
            case Animal.Type.BIRD:
                player.spriteRenderer.sprite = player.GetComponent<HostSprites>().bird;
                break;
                
            case Animal.Type.CHICKEN:
                player.spriteRenderer.sprite = player.GetComponent<HostSprites>().chicken;
                break;

            case Animal.Type.COW:
                player.spriteRenderer.sprite = player.GetComponent<HostSprites>().cow;
                break;

            case Animal.Type.HORSE:
                player.spriteRenderer.sprite = player.GetComponent<HostSprites>().horse;
                break;

            case Animal.Type.HUMAN:
                player.spriteRenderer.sprite = player.GetComponent<HostSprites>().human;
                break;

            case Animal.Type.RAT:
                player.spriteRenderer.sprite = player.GetComponent<HostSprites>().rat;
                break;
            
            default:
                break;
        }
        // player.spriteRenderer.sprite = player.GetComponent<HostSprites>().horse;
    }
}
