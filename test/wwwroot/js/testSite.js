
function ajaxTakeRequest(userId, booksId) {

    $.post('/Ajax/UserAddBook/', {
        'userId': userId,
        'booksId': booksId
    }, function (data) {
        alert(data);
    });
}

function addBook(button) {
    var tokenClass = button.getAttribute("token");
    var rowList = document.querySelectorAll("input." + tokenClass);
    var booksId = "";
    var k = 0;
    rowList.forEach((cbItem) => {
        if (cbItem.checked) {
            if (k == 0) {
                booksId = booksId + cbItem.getAttribute("book-id");
                k = k + 1;
            }
            else {
                booksId = booksId + "," + cbItem.getAttribute("book-id");
            }
            
        }
    })
    
    ajaxTakeRequest(button.getAttribute("user-id"), booksId);
    alert("ready after");
}