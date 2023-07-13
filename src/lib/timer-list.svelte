<script lang="ts">
  import TimerListItem from "./timer-list-item.svelte";
  import { timer_list_items } from "../util/stores";
  import { onMount, onDestroy } from 'svelte';
  import { TypeOfSpawn } from "../util/types";
    
  let unsubscribe;

  onMount(async () => {
        // Only do the first 20 minutes of the game, after that you are on your own
        $timer_list_items = [
            //{id: 0, type: TypeOfSpawn.Bounty_Rune, spawn_time: 0}, 
            {id: 1, type: TypeOfSpawn.Water_Rune, spawn_time: 120},
            {id: 2, type: TypeOfSpawn.Bounty_Rune, spawn_time: 180},
            {id: 3, type: TypeOfSpawn.Healing_Lotus, spawn_time: 180},
            {id: 4, type: TypeOfSpawn.Water_Rune, spawn_time: 240},
            {id: 5, type: TypeOfSpawn.Bounty_Rune, spawn_time: 360},
            {id: 6, type: TypeOfSpawn.Power_Rune, spawn_time: 360},
            {id: 7, type: TypeOfSpawn.Healing_Lotus, spawn_time: 360},
            {id: 8, type: TypeOfSpawn.Wisdom_Rune, spawn_time: 420},
            {id: 9, type: TypeOfSpawn.Power_Rune, spawn_time: 480},
            {id: 10, type: TypeOfSpawn.Bounty_Rune, spawn_time: 540},
            {id: 11, type: TypeOfSpawn.Healing_Lotus, spawn_time: 540},
            {id: 12, type: TypeOfSpawn.Power_Rune, spawn_time: 600},
            {id: 13, type: TypeOfSpawn.Bounty_Rune, spawn_time: 720},
            {id: 14, type: TypeOfSpawn.Power_Rune, spawn_time: 720},
            {id: 15, type: TypeOfSpawn.Healing_Lotus, spawn_time: 720},
            {id: 16, type: TypeOfSpawn.Power_Rune, spawn_time: 840},
            {id: 17, type: TypeOfSpawn.Wisdom_Rune, spawn_time: 840},
            {id: 18, type: TypeOfSpawn.Bounty_Rune, spawn_time: 900},
            {id: 19, type: TypeOfSpawn.Healing_Lotus, spawn_time: 900},
            {id: 20, type: TypeOfSpawn.Power_Rune, spawn_time: 960},
            {id: 21, type: TypeOfSpawn.Bounty_Rune, spawn_time: 1080},
            {id: 22, type: TypeOfSpawn.Power_Rune, spawn_time: 1080},
            {id: 23, type: TypeOfSpawn.Healing_Lotus, spawn_time: 1080},
            {id: 24, type: TypeOfSpawn.Tormentor, spawn_time: 1200},
            {id: 25, type: TypeOfSpawn.Power_Rune, spawn_time: 1200},
        ];
	});

  onDestroy(unsubscribe);
</script>
<ul class="no-bullets">
    {#each $timer_list_items.slice(0, 5) as item (item.id)}
        <li>
            <svelte:component
                this={TimerListItem}
                objAttributes={item} />
        </li>
    {/each}
</ul>

<style>
    ul.no-bullets {
        list-style-type: none;
    }
</style>