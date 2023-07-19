<script lang="ts">
  import { clock_time, timer_list_items } from "../util/stores";
  import { onDestroy } from 'svelte';

  export let objAttributes = {} as {id, type, spawn_time};
  let removed = false;
  let current = false;
  let faded = false;

  function removeFromList() {
		$timer_list_items = $timer_list_items.filter(function(value){ 
			if (value.id != objAttributes.id) return value;
		});
	}

  const unsubscribe = clock_time.subscribe(time => {
    if (time >= (objAttributes.spawn_time) && time < (objAttributes.spawn_time + 30) && !current) {
		current = true;
    }
    if ((objAttributes.spawn_time + 60) > time && time >= (objAttributes.spawn_time + 30) && !faded) {
		current = false;
		faded = true;
    }
    if (time >= (objAttributes.spawn_time + 60) && !removed) {
		removed = true;
		removeFromList();
    }
  });

  onDestroy(unsubscribe);
</script>
<div class="{current === true ? 'box-current' : faded === true ? 'box-faded' : 'box'}">

	<li>{objAttributes.type}</li>
	<li>spawn time: {objAttributes.spawn_time}</li>
	<li>Spawning in: {objAttributes.spawn_time - $clock_time}</li>
  
  
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
</style>