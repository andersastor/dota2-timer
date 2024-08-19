export function formatTime(time) {
    var sec_num = parseInt(time, 10);
    if (sec_num < 0) {
        sec_num = sec_num * -1;
    }
    var minutes = Math.floor(sec_num / 60);
    var seconds = sec_num - (minutes * 60);

    if (minutes < 10) { minutes = "0" + minutes; }
    if (seconds < 10) { seconds = "0" + seconds; }
    return minutes + ':' + seconds;
}