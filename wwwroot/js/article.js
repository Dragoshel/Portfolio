function changeRoute(route) {
    window.history.pushState("", "", route)
}

changeRoute(document.getElementById("title").innerHTML)