<script>
    import Sidebar from './Sidebar.svelte';
    import { clickOutside } from "./click_outside.js";

    let sidebar_show = false;
</script>

<div use:clickOutside on:outclick={() => (sidebar_show = false, console.log('clicking outside sidebar '))}>

    <Sidebar bind:show={sidebar_show} />
</div>

<header>
    <h1>
        Dota 2 timer
    </h1>
    <button on:click={() => sidebar_show = !sidebar_show}>Toggle Sidebar</button>
</header>

<style>

    header {
        background: var(--accent-color);
        padding: var(--padding-small);
    }
    h1 {
        margin: 0;
        color: var(--header-text-color);
    }
</style>