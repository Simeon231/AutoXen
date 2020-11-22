// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var deleteBtn = document.getElementsByName("deleteBtn");
if (deleteBtn != null) {
    console.log("from deletebtn")
    deleteBtn.forEach(x => x.addEventListener("click", () => {
        console.log("from click")
        confirm("Are you sure you want to delete your " + x.getAttribute("property") + "?");
    }))
}