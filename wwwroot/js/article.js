function changeRoute(route) {
    window.history.replaceState(null, "", route)
}

changeRoute(document.getElementById("title").value)