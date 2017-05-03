$(document).ready(function () {
    $("#createForm").on("submit", function () {
        var humor = document.getElementById("humorRating").value;
        var story = document.getElementById('storyRating').value;
        var sum = parseInt(humor) + parseInt(story);
        console.log(sum);
    });
});
