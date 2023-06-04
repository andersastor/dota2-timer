import { writable } from 'svelte/store';

export const clock_time = writable(0);
export let timer_list_items = writable([]);