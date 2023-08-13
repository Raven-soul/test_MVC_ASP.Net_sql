
function ajaxTakeRequest(userId, booksId) {
    $.post('../../Ajax/addBooks/', {
        'userId': userId,
        'booksId': JSON.stringify(booksId)
    }, function (data) {
        alert("ready");
    });
}

function addBook(button) {
    var rowList = getElementsByName(button.getAttribute("token"));
    var booksId = [];

    rowList.forEach((cbItem) => {
        if (cbItem.checked) {
            booksId.push(cbItem.getAttribute("book-id"))
        }
    })
    
    ajaxTakeRequest(button.getAttribute("user-id"), booksId)
    
}
