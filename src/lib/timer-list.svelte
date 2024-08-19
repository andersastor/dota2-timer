<script lang="ts">
	import TimerListItem from "./timer-list-item.svelte";
	import { timer_list_items, clock_time } from "../util/stores";
	import { onMount, onDestroy } from 'svelte';
	import { TypeOfSpawn, RuneIcons } from "../util/types";

	onMount(async () => {
	// Only do the first 20 minutes of the game, after that you are on your own
	$timer_list_items = [
	//{id: 0, icon: RuneIcons.Bounty_Rune, type: TypeOfSpawn.Bounty_Rune, spawn_time: 0},
	{id: 1, icon: RuneIcons.Water_Rune, type: TypeOfSpawn.Water_Rune, spawn_time: 120},
	{id: 2, icon: RuneIcons.Bounty_Rune, type: TypeOfSpawn.Bounty_Rune, spawn_time: 180},
	{id: 3, icon: RuneIcons.Healing_Lotus, type: TypeOfSpawn.Healing_Lotus, spawn_time: 180},
	{id: 4, icon: RuneIcons.Water_Rune, type: TypeOfSpawn.Water_Rune, spawn_time: 240},
	{id: 5, icon: RuneIcons.Bounty_Rune, type: TypeOfSpawn.Bounty_Rune, spawn_time: 360},
	{id: 6, icon: RuneIcons.Power_Rune, type: TypeOfSpawn.Power_Rune, spawn_time: 360},
	{id: 7, icon: RuneIcons.Healing_Lotus, type: TypeOfSpawn.Healing_Lotus, spawn_time: 360},
	{id: 8, icon: RuneIcons.Wisdom_Rune, type: TypeOfSpawn.Wisdom_Rune, spawn_time: 420},
	{id: 9, icon: RuneIcons.Power_Rune, type: TypeOfSpawn.Power_Rune, spawn_time: 480},
	{id: 10, icon: RuneIcons.Bounty_Rune, type: TypeOfSpawn.Bounty_Rune, spawn_time: 540},
	{id: 11, icon: RuneIcons.Healing_Lotus, type: TypeOfSpawn.Healing_Lotus, spawn_time: 540},
	{id: 12, icon: RuneIcons.Power_Rune, type: TypeOfSpawn.Power_Rune, spawn_time: 600},
	{id: 13, icon: RuneIcons.Bounty_Rune, type: TypeOfSpawn.Bounty_Rune, spawn_time: 720},
	{id: 14, icon: RuneIcons.Power_Rune, type: TypeOfSpawn.Power_Rune, spawn_time: 720},
	{id: 15, icon: RuneIcons.Healing_Lotus, type: TypeOfSpawn.Healing_Lotus, spawn_time: 720},
	{id: 16, icon: RuneIcons.Power_Rune, type: TypeOfSpawn.Power_Rune, spawn_time: 840},
	{id: 17, icon: RuneIcons.Wisdom_Rune, type: TypeOfSpawn.Wisdom_Rune, spawn_time: 840},
	{id: 18, icon: RuneIcons.Bounty_Rune, type: TypeOfSpawn.Bounty_Rune, spawn_time: 900},
	{id: 19, icon: RuneIcons.Healing_Lotus, type: TypeOfSpawn.Healing_Lotus, spawn_time: 900},
	{id: 20, icon: RuneIcons.Power_Rune, type: TypeOfSpawn.Power_Rune, spawn_time: 960},
	{id: 21, icon: RuneIcons.Bounty_Rune, type: TypeOfSpawn.Bounty_Rune, spawn_time: 1080},
	{id: 22, icon: RuneIcons.Power_Rune, type: TypeOfSpawn.Power_Rune, spawn_time: 1080},
	{id: 23, icon: RuneIcons.Healing_Lotus, type: TypeOfSpawn.Healing_Lotus, spawn_time: 1080},
	{id: 24, icon: RuneIcons.Tormentor, type: TypeOfSpawn.Tormentor, spawn_time: 1200},
	{id: 25, icon: RuneIcons.Power_Rune, type: TypeOfSpawn.Power_Rune, spawn_time: 1200},
	];
	});

	const unsubscribe = clock_time.subscribe(time => {
	$timer_list_items = $timer_list_items.filter(list_item => (list_item.spawn_time + 60) > time);
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