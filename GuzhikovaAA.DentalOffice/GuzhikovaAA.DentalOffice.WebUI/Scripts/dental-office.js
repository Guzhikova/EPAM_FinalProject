function ReturnBack()
{
    if (history.length > 2)
    {
        window.history.back();

    } else {
        document.location.href = "/";
    }
};


function showOrHide(checkedElement, visiblePart) {

    var checkedElement = document.getElementById(checkedElement);
    var visiblePart = document.getElementById(visiblePart);

    if (checkedElement.checked)
    {
        visiblePart.style.display = "block";
    } else
    {
        visiblePart.style.display = "none";
    }
}
