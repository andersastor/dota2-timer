<script lang="ts">
	import { clock_time } from "../util/stores";
	import { formatTime } from "../util/time-formatting";
	import { onDestroy } from 'svelte';

	export let objAttributes = {} as {id, icon, type, spawn_time};
	let current = false;
	let faded = false;

	const unsubscribe = clock_time.subscribe(time => {
	if (time >= (objAttributes.spawn_time) && time < (objAttributes.spawn_time + 30) && !current) {
		current = true;
    }
    if ((objAttributes.spawn_time + 60) > time && time >= (objAttributes.spawn_time + 30) && !faded) {
		current = false;
		faded = true;
    }
  });

  onDestroy(unsubscribe);
</script>
<div class="{current === true ? 'box-current' : faded === true ? 'box-faded' : 'box'} container-side-by-side">
	<img src="{objAttributes.icon}" alt="icon" width="50" height="60">
	<div>
		<li>{objAttributes.type}</li>
		<li>spawn time: {formatTime(objAttributes.spawn_time)}</li>
		<li>Spawning in: {objAttributes.spawn_time - $clock_time} seconds</li>
	</div>
  
  
</div>
  
<style>
	.box {
		width: 300px;
		border: 1px solid #aaa;
		border-radius: 2px;
		box-shadow: 2px 2px 8px black;
		padding: 1em;
		margin: 0 0 1em 0;
	}
  .box-current {
		width: 400px;
		border: 1px solid #aaa;
		border-radius: 2px;
		box-shadow: 2px 2px 8px black;
		padding: 1em;
		margin: 0 0 1em 0;
	}
  .box-faded {
		width: 300px;
		border: 1px solid #aaa;
		border-radius: 2px;
		box-shadow: 2px 2px 8px black;
		background-color: blanchedalmond;
		padding: 1em;
		margin: 0 0 1em 0;
	}
	.container-side-by-side { 
		display: flex; 
		flex-direction: row; 
		flex-wrap: wrap; 
	} 
</style>